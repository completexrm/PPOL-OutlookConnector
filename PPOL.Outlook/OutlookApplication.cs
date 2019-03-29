using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PPOL.MailObjects;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PPOL_Outlook
{
    class OutlookApplication : IOutlookApplication
    {
        readonly Outlook._Application _app;
        public OutlookApplication(Outlook._Application application)
        {
            _app = application;
        }
        public IMailItem GetItemByInspector(Outlook._Inspector inspector)
        {
            IMailItem mi = null;
                var item = inspector.CurrentItem;
                if (item != null)
                {
                    var mailItem = item as Outlook._MailItem;
                    if (mailItem != null)
                    {
                        mi = new OutlookMailItem(mailItem);
                        item = null;
                    }
                    if (item != null)
                    {
                        Marshal.ReleaseComObject(item);
                    }
                }
                return mi;
                
        }
        public IMailItem GetCurrentInspectorItem()
        {
            IMailItem mi = null;
            try
            {
                var inspector = _app.ActiveInspector();
                if (inspector != null)
                {
                    mi =  GetItemByInspector(inspector);
                    Marshal.ReleaseComObject(inspector);
                }
            }
            catch { }
            return mi;
        }
        
        public IEnumerable<string> GetPrimarySmtpAddresses()
        {
            var _session = _app.Session;
            // check smtp address of current user
            
            var user = _session.CurrentUser;
            if (user != null)
            {
                var entry = user.AddressEntry;
                if (entry != null)
                {
                    if (entry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olSmtpAddressEntry)
                    {
                        yield return entry.Address;
                    }
                    Marshal.ReleaseComObject(entry);
                }
                Marshal.ReleaseComObject(user);
            }
            //if (string.IsNullOrEmpty(smtpAddress))
            {
                var accounts = _session.Accounts;
                for (var idx = 1; idx <= accounts.Count; idx++)
                {
                    var account = accounts[idx];
                    yield return account.SmtpAddress;
                    Marshal.ReleaseComObject(account);
                }
                Marshal.ReleaseComObject(accounts);
            }
            Marshal.ReleaseComObject(_session);
        }


        public IEnumerable<IContactItem> FindContactsByEmailDisplayName(string displayName)
        {
            var session = _app.Session;
            var folder = session.GetDefaultFolder( Outlook.OlDefaultFolders.olFolderContacts);
            Marshal.ReleaseComObject(session);
            var items = folder.Items;
            Marshal.ReleaseComObject(folder);
            string filter = "[Email1DisplayName] = '" + displayName.Replace("'","''") + "'";
            object contactObj;
            try
            {
                contactObj = items.Find(filter);
            }
            catch
            {
                contactObj=null;
            }
            while (contactObj != null)
            {
                var cx = contactObj as Outlook._ContactItem;
                if (cx != null)
                {
                    yield return new OutlookContactItem(cx);
                }
                else
                {
                    Marshal.ReleaseComObject(contactObj);
                }
                contactObj = items.FindNext();
            }
            
            Marshal.ReleaseComObject(items);
            
            
        }




      
    }
}
