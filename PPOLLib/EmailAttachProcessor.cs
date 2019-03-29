using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using PPOL.MailObjects;

namespace PPOL
{
    public class EmailAttachProcessor
    {
        readonly IOutlookApplication _application;
        public EmailAttachProcessor(IOutlookApplication application)
        {
            _application = application;
        }
        static string ReadAsContent(IAttachmentInfo attachment)
        {
            using (var stream = attachment.OpenRead())
            {
                return ReadAsContent(stream);
            }
        }

        static string ReadAsContent(System.IO.Stream stream)
        {
            if (stream == null)
            {
                return null;
            }
            using (var ms = new System.IO.MemoryStream())
            {
                var buf = new byte[1024 * 60];
                for (; ; )
                {
                    int read = stream.Read(buf, 0, buf.Length);
                    if (read <= 0)
                    {
                        break;
                    }
                    ms.Write(buf, 0, read);
                }
                return System.Convert.ToBase64String(ms.ToArray());
            }
            
        }
        struct AttachmentResult
        {
            public AttachmentResultCode Code { get; set; }
            public string Message { get; set; }
        }
        enum AttachmentResultCode
        {
            Ok,
            NotFound,
            Error
        }
        abstract class AttachWorkerBase : IDisposable
        {
            protected readonly PPOL.Legacy.PPOLService2.PsnNoteAPIService apiClient;
            protected readonly String PPOLUrl;
            protected readonly String ppolAccount;
            protected readonly String userName;
            protected readonly String password;
            protected String bccAddressList = "";
            protected String toAddress = "";
            protected String ccEmails = "";
            protected String fromName = "";
            protected IMailItem mailItem;
            protected IOutlookApplication _application;
            protected string subject;
            protected string body;
            public void Dispose()
            {
                Dispose(true);
            }
            protected virtual void Dispose(bool isDisposing)
            {
                try
                {
                    ((IDisposable)apiClient).Dispose();
                }
                catch{}
            }
            public abstract bool CreateNewObject(string message);
            public AttachWorkerBase()
            {
                Properties.Settings settings = new Properties.Settings();
                settings.Reload();
                PPOLUrl = settings.PPOLURL;
                ppolAccount = settings.Account;
                userName = settings.UserName;
                password = settings.Password;
                bccAddressList = "";
                toAddress = "";
                ccEmails = "";
                fromName = "";
                /*
                var binding = new System.ServiceModel.WSHttpBinding();
                var uri = new Uri(PPOLUrl + "/cxf/PsnNoteAPI");
                binding.Security.Mode = string.Equals(uri.Scheme, "https", StringComparison.OrdinalIgnoreCase)
                    ? System.ServiceModel.SecurityMode.Transport
                    : System.ServiceModel.SecurityMode.None;
                apiClient =  new PPOL.PPOLService.PsnNoteAPIClient(binding,new System.ServiceModel.EndpointAddress(uri));*/
                apiClient = new Legacy.PPOLService2.PsnNoteAPIService();
                apiClient.Url = PPOLUrl + "/cxf/PsnNoteAPI";


            }
            public void Init(IOutlookApplication application, IMailItem mailItem)
            {
                this._application = application;
                this.mailItem = mailItem;
                String accountAddress = application.GetPrimarySmtpAddresses().FirstOrDefault() ?? "";





               

                //PPOLService.PsnNoteAPIService local = new PPOLService.PsnNoteAPIService();
                this.body = mailItem.HTMLBody;
                this.subject = mailItem.Subject;
                var mItem = mailItem;
                if (mItem.SenderEmailAddress != null && !mItem.SenderEmailAddress.Equals(""))
                {
                    if (mItem.Sent)
                    {
                        fromName = mItem.SenderEmailAddress;
                        //   string fromAddr = "";

                        if (!fromName.Contains('@'))
                        {
                            string findAddress = "";
                            foreach (var contact in _application.FindContactsByEmailDisplayName(fromName))
                            {
                                using (contact)
                                {
                                    foreach (var emailAddress in contact.EmailAddresses)
                                    {
                                        findAddress = emailAddress;
                                        if (!string.IsNullOrEmpty(findAddress))
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (!string.IsNullOrEmpty(findAddress))
                                {
                                    break;
                                }

                            }
                            fromName = findAddress;

                        }
                    }
                    else
                    {
                        fromName =  mItem.GetRecipientAddresses().FirstOrDefault();

                    }
                    bccAddressList = accountAddress + "$" + fromName;
                }
                else
                {
                    bccAddressList = accountAddress;
                }
                //      MessageBox.Show(String.Format(bccAddressList));
                toAddress = string.Join(";", mItem.GetRecipientAddresses());
            }
            public virtual void OnAfterSuccessfulAttach()
            {
                //this.body = "";
            }
            protected abstract AttachmentResult ExecuteAttach(IAttachmentInfo attachmentInfo);
            public AttachmentResult ExecuteAttach()
            {
                //int attachmentidx = 0;
                //var r = new AttachmentResult { Code = AttachmentResultCode.Ok };
                AttachmentResult r;
                var mItem = this.mailItem;
                using (var singleAttachment = mItem.GetSingleAttachment())
                {
                    // null is acceptable
                    r = ExecuteAttach(singleAttachment);
                    if (r.Code == AttachmentResultCode.Ok)
                    {
                        OnAfterSuccessfulAttach();
                    }
                }
                return r;
                   
            }
            
            protected virtual AttachmentResult Parse(string result)
            {
                var r = new AttachmentResult { Message = result, Code = AttachmentResultCode.Ok};
                if (result != null)
                {
                    if (result.Contains("not found"))
                    {
                        r.Code = AttachmentResultCode.NotFound;
                    }
                    else if (result.Contains("doesn't exist"))
                    {
                        r.Code = AttachmentResultCode.NotFound;
                    }
                    else if (result.ToUpperInvariant().Contains("ERROR"))
                    {
                        r.Code = AttachmentResultCode.Error;
                    }
                }
                return r;
            }
        }
        class AttachWorkerOrganization : AttachWorkerBase
        {
            protected override AttachmentResult ExecuteAttach(IAttachmentInfo attachmentInfo)
            {
                string rtn;
                if (attachmentInfo != null)
                {
                    rtn = apiClient.attachToCustomerWithAttachment(ppolAccount, userName, password, toAddress, ccEmails,
                        bccAddressList, subject, body, attachmentInfo.FileName, ReadAsContent(attachmentInfo));
                }
                else
                {
                    rtn = apiClient.attachToCustomer(ppolAccount, userName, password, toAddress, ccEmails,
                        bccAddressList, subject, body);
                }
                return Parse(rtn);
            }
            public override bool CreateNewObject(string message)
            {
                DialogResult dlgResult = MessageBox.Show(message + Environment.NewLine + "Customer with the email address: " + fromName + " doesn't exist. Do you want to create a customer?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    using(var  customerCreateFrm = new OrgCreateFrm())
                    {
                        customerCreateFrm.setCustomerNotes(this.subject, this.body, fromName);
                        customerCreateFrm.ShowDialog();
                    }
                    return true;
                }
                return false;
            }
        }
        class AttachWorkerContact : AttachWorkerBase
        {
            
            protected override AttachmentResult ExecuteAttach(IAttachmentInfo attachmentInfo)
            {
                string rtn;
                if (attachmentInfo != null)
                {
                    rtn = apiClient.attachToContactWithAttachment(ppolAccount, userName, password, toAddress, ccEmails,
                        bccAddressList, subject, body, attachmentInfo.FileName, ReadAsContent(attachmentInfo));
                }
                else
                {
                    rtn = apiClient.attachToContact(ppolAccount, userName, password, toAddress, ccEmails,
                        bccAddressList, subject, body);
                }
                return Parse(rtn);
            }
            public override bool CreateNewObject(string message)
            {
 	            DialogResult dlgResult = MessageBox.Show(message+Environment.NewLine + "Contact with the email address: " + fromName + " doesn't exist. Do you want to create a contact?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    using(var contactCreateFrm = new ContactCreateFrm())
                    {
                        contactCreateFrm.setContactNotes(this.subject, this.body, fromName);
                        contactCreateFrm.ShowDialog();
                        return true;
                    }
                }
                return false;
            }
        }
       
        
        public void ExecuteAttach(AttachKind objType, IMailItem mItem)
        {
            try
            {


                AttachWorkerBase worker;
                switch (objType)
                {
                    case AttachKind.Contact:
                        worker  = new AttachWorkerContact();
                        break;
                    case AttachKind.Organization:
                        worker = new AttachWorkerOrganization();
                        break;
                    default:
                         throw new NotImplementedException(objType.ToString());
                }
                worker.Init(_application,mItem);
                var result = worker.ExecuteAttach();
                
                switch(result.Code)
                {
                    case AttachmentResultCode.NotFound:
                        if (worker.CreateNewObject(result.Message))
                        {
                            worker.OnAfterSuccessfulAttach();
                            result = worker.ExecuteAttach();
                        }
                        break;
                    case AttachmentResultCode.Error:
                        
                        MessageBox.Show(string.IsNullOrWhiteSpace(result.Message) ? "Error" : result.Message, "PPOL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        if (!string.IsNullOrWhiteSpace(result.Message))
                        {
                            MessageBox.Show(result.Message, "PPOL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {

                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }
        /*
        public void AttachEmail()
        {
            try
            {
                String accountAddress = "";



                Outlook.Accounts accounts = Globals.ThisAddIn.Application.Session.Accounts;
                foreach (Outlook.Account account in accounts)
                {
                    try
                    {
                        accountAddress = account.SmtpAddress;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }


                Microsoft.Office.Interop.Outlook.MailItem mItem =
                    (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;

                Properties.Settings settings = new Properties.Settings();
                settings.Reload();
                String PPOLUrl = settings.PPOLURL;
                String ppolAccount = settings.Account;
                String userName = settings.UserName;
                String password = settings.Password;
                String bccAddressList = "";
                String ccEmails = "";
                PPOLService.PsnNoteAPIService local = new PPOLService.PsnNoteAPIService();

                local.Url = PPOLUrl + "/cxf/PsnNoteAPI";

                if (mItem.SenderEmailAddress != null && !mItem.SenderEmailAddress.Equals(""))
                {
                    string fromName = mItem.SenderEmailAddress;
                    string fromAddr = "";
                    if (!fromName.Contains('@'))
                    {
                        Outlook.ContactItem contact =
                            Globals.ThisAddIn.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts)
                        .Items.Find("[Email1DisplayName] = '" + fromName + "'") as Outlook.ContactItem;
                        if (contact != null)
                        {
                            fromAddr = contact.Email1Address;
                        }
                    }
                    else
                    {
                        if (fromName.Contains('('))
                        {
                            int startPos = fromName.IndexOf('(');
                            int endPos = fromName.IndexOf(')');
                            string temp = fromName.Substring((startPos + 1), (endPos - (startPos + 1)));
                            fromAddr = temp;
                        }
                        else if (fromName.Contains('<'))
                        {
                            int startPos = fromName.IndexOf('<');
                            int endPos = fromName.IndexOf('>');
                            string temp = fromName.Substring((startPos + 1), (endPos - (startPos + 1)));
                            fromAddr = temp;
                        }
                        else
                        {
                            fromAddr = fromName;
                        }
                    }
                    bccAddressList = accountAddress + "$" + fromAddr;
                }
                else
                {
                    bccAddressList = accountAddress;
                }
                String toAddress = "";
                if (mItem.To.Contains(';'))
                {
                    string toNames = mItem.To;
                    string[] toList = toNames.Split(';');
                    foreach (string toName in toList)
                    {
                        if (!toName.Contains('@'))
                        {
                            Outlook.ContactItem contact =
                                Globals.ThisAddIn.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts)
                            .Items.Find("[Email1DisplayName] = '" + toName + "'") as Outlook.ContactItem;
                            if (contact != null)
                            {
                                toAddress = contact.Email1Address + ";" + toAddress;
                            }
                        }
                        else
                        {
                            if (toName.Contains('('))
                            {
                                int startPos = toName.IndexOf('(');
                                int endPos = toName.IndexOf(')');
                                string temp = toName.Substring((startPos + 1), (endPos - (startPos + 1)));
                                toAddress = temp + ";" + toAddress;

                            }
                            else if (toName.Contains('<'))
                            {
                                int startPos = toName.IndexOf('<');
                                int endPos = toName.IndexOf('>');
                                string temp = toName.Substring((startPos + 1), (endPos - (startPos + 1)));
                                toAddress = temp + ";" + toAddress;
                            }
                            else
                            {
                                toAddress = toName + ";" + toAddress;
                            }
                        }
                    }
                }
                else
                {
                    toAddress = mItem.To;
                    if (!toAddress.Contains('@'))
                    {
                        if (!toAddress.Contains('\''))
                        {
                            toAddress = "'" + toAddress + "'";
                        }
                        Outlook.ContactItem contact =
                               Globals.ThisAddIn.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts)
                           .Items.Find("[Email1DisplayName] = " + toAddress) as Outlook.ContactItem;
                        if (contact != null)
                        {
                            toAddress = contact.Email1Address;
                        }
                        else
                        {
                            string search = "[PhoneGap] Re: phonegap error : PhoneGap[549:20b]";
                            GetFilteredTable(search);
                    
                        }
                    }
                    else
                    {
                        if (toAddress.Contains('('))
                        {
                            int startPos = toAddress.IndexOf('(');
                            int endPos = toAddress.IndexOf(')');
                            string temp = toAddress.Substring((startPos + 1), (endPos - (startPos + 1)));
                            toAddress = temp;

                        }
                        else if (toAddress.Contains('<'))
                        {
                            int startPos = toAddress.IndexOf('<');
                            int endPos = toAddress.IndexOf('>');
                            string temp = toAddress.Substring((startPos + 1), (endPos - (startPos + 1)));
                            toAddress = temp;
                        }
                    }

                }
                if (mItem.CC != null)
                {
                    if (mItem.CC.Contains(';'))
                    {
                        string ccNames = mItem.CC;
                        string[] ccList = ccNames.Split(';');
                        foreach (string ccName in ccList)
                        {
                            if (!ccName.Contains('@'))
                            {


                                Outlook.ContactItem contact =
                                    Globals.ThisAddIn.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts)
                                .Items.Find("[Email1DisplayName] = '" + ccName + "'") as Outlook.ContactItem;
                                if (contact != null)
                                {
                                    ccEmails = contact.Email1Address + ";" + ccEmails;
                                }

                            }
                            else
                            {
                                if (ccName.Contains('('))
                                {
                                    int startPos = ccName.IndexOf('(');
                                    int endPos = ccName.IndexOf(')');
                                    string temp = ccName.Substring((startPos + 1), (endPos - (startPos + 1)));
                                    ccEmails = temp + ";" + ccEmails;
                                }
                                else if (ccName.Contains('<'))
                                {
                                    int startPos = ccName.IndexOf('<');
                                    int endPos = ccName.IndexOf('>');
                                    string temp = ccName.Substring((startPos + 1), (endPos - (startPos + 1)));
                                    ccEmails = temp + ";" + ccEmails;
                                }
                                else
                                {
                                    ccEmails = ccName + ";" + ccEmails;
                                }
                            }
                        }
                    }
                    else
                    {
                        ccEmails = mItem.CC;
                        if (!ccEmails.Contains('@'))
                        {

                            Outlook.ContactItem contact =
                                   Globals.ThisAddIn.Application.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts)
                               .Items.Find("[Email1DisplayName] = '" + ccEmails + "'") as Outlook.ContactItem;
                            if (contact != null)
                            {
                                ccEmails = contact.Email1Address;
                            }
                        }
                        else
                        {
                            if (ccEmails.Contains('('))
                            {
                                int startPos = ccEmails.IndexOf('(');
                                int endPos = ccEmails.IndexOf(')');
                                string temp = ccEmails.Substring((startPos + 1), (endPos - (startPos + 1)));
                                ccEmails = temp;
                            }
                            else if (ccEmails.Contains('<'))
                            {
                                int startPos = ccEmails.IndexOf('<');
                                int endPos = ccEmails.IndexOf('>');
                                string temp = ccEmails.Substring((startPos + 1), (endPos - (startPos + 1)));
                                ccEmails = temp;
                            }

                        }
                    }
                }
                String rtn = local.attachNoteToContact(ppolAccount, userName, password, toAddress, ccEmails,
                    bccAddressList, mItem.Subject, mItem.HTMLBody);
                MessageBox.Show(String.Format(rtn));

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(ex.Message));
            }
        }
        */
        /*
        void DisplayTableContents(Outlook.Table table)
        {
            // Add a new column, and reset the current 
            // row so that it is immediately before the
            // first row of data in the table:
            table.Columns.RemoveAll();
            table.Columns.Add("Subject");
            table.Columns.Add("From");
            table.Columns.Add("Display Name");

            StringWriter sw = new StringWriter();
            Outlook.Row row = null;

            while (!table.EndOfTable)
            {
                row = table.GetNextRow();
                sw.WriteLine("{0} from {1}",
                 row["Subject"], row["From"]);
            }

            // Assuming that you are working with a mail item,
            // cast the current item as a mail item, and insert
            // the data into the body:
            Outlook.MailItem mailItem =
             Globals.ThisAddIn.Application.ActiveInspector().CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                mailItem.Body = sw.ToString() + mailItem.Body;
                int count = mailItem.ItemProperties.Count;
                for (int i = 0; i < count; i++)
                {
                    //  MessageBox.Show(String.Format(mailItem.ItemProperties[i].Value.ToString()));
                }
            }
        }*/
        /*
        const String PROPTAG = "http://schemas.microsoft.com/mapi/proptag/";
        const String PR_SUBJECT = "0x0037001E";

        void GetFilteredTable(string searchText)
        {
            String filter =
              String.Format("@SQL=\"{0}{1}\" ci_phrasematch '{2}'",
              PROPTAG, PR_SUBJECT, searchText);

            Outlook.Folder folder =
              Globals.ThisAddIn.Application.Session.GetDefaultFolder(
              Outlook.OlDefaultFolders.olFolderInbox) as Outlook.Folder;

            if (folder != null)
            {
                try
                {
                    DisplayTableContents(
                      folder.GetTable(filter,
                      Outlook.OlTableContents.olUserItems));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }*/
   
    }
    public enum AttachKind
    {
        Organization=1,
        Contact=2
    }
}
