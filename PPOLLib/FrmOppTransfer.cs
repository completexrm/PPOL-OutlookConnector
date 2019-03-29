using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PPOL;

namespace PPOL
{
    public partial class FrmOppTransfer : Form
    {
        Legacy.PPOLService.ppolContact psn;
        string senderName = "";
        ServicesUtil serviceUtil = null;

        public FrmOppTransfer()
        {
            InitializeComponent();
            serviceUtil = new ServicesUtil();
            getContact();
        }

        private void FrmOppTransfer_Load(object sender, EventArgs e)
        {

        }

        private void getContact()
        {

            try
            {
                string fromName = "";


                using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
                {
                    if (mItem != null)
                    {
                        var senderEmailAddress = mItem.SenderEmailAddress;
                        if (!string.IsNullOrEmpty(senderEmailAddress))
                        {
                            fromName = senderEmailAddress;
                            this.txtNewOpp.Text = mItem.Subject;
                            senderName = mItem.SenderName;
                        }
                    }

                }




                

                var local = new Legacy.PPOLService.PsnNoteAPIService();

                local.Url = serviceUtil.getPpolURL() + "/cxf/PsnNoteAPI";

                psn = local.findContactByEmail(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), fromName);




               

                if (psn != null)
                {
                    if (psn.errorMessage == "SUCCESS")
                    {
                        this.txtContactName.Text = psn.displayName;

                    }
                    else
                    {
                        if (psn.errorMessage.Trim().Contains("Account"))
                        {
                            MessageBox.Show(psn.errorMessage);
                            this.Close();
                        }
                        else
                        {
                            this.lblContactMsg.Text = "Contact was not found in PlanPlus Online. You can search and associate a contact, Otherwise system will create new contact.";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);

            }

        }

      

       

        private void btnSearchContact_Click(object sender, EventArgs e)
        {
            ContactSearch contactSearch = new ContactSearch();
            contactSearch.ShowDialog(this);
            if (contactSearch.contactIdFromSearch != 0)
            {
                psn = new Legacy.PPOLService.ppolContact();
                psn.id = contactSearch.contactIdFromSearch;
                this.txtContactName.Text = contactSearch.contactNameFromSearch;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
               /*
                Properties.Settings settings = new Properties.Settings();
                settings.Reload();
                String PPOLUrl = settings.PPOLURL;
                String ppolAccount = settings.Account;
                String userName = settings.UserName;
                String password = settings.Password;
                * */
                string fromName = "";
                string subject = "";
                string htmlBody = "";
                using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
                {
                    if (mItem != null)
                    {
                        var senderEmailAddress = mItem.SenderEmailAddress;
                        if (!string.IsNullOrEmpty(senderEmailAddress))
                        {
                            fromName = senderEmailAddress;
                        }
                        subject = mItem.Subject;
                        htmlBody = mItem.HTMLBody;
                    }

                }

                /*
                Microsoft.Office.Interop.Outlook.MailItem mItem =
                        (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
                if (mItem.SenderEmailAddress != null && !mItem.SenderEmailAddress.Equals(""))
                {
                    fromName = mItem.SenderEmailAddress;
                }*/

                OppService.OppNoteAPIService local = new OppService.OppNoteAPIService();

            //    local.Url = PPOLUrl + "/cxf/OppNoteAPI";
                local.Url = serviceUtil.getPpolURL() + "/cxf/OppNoteAPI";

                string rtn = local.transferEmailToOpp(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), 0, subject, htmlBody, this.rchTxtComment.Text, psn.id, senderName, fromName, this.chkAttachNote.Checked);
                if (rtn == "SUCCESS")
                {
                    MessageBox.Show(String.Format("Transfered email to an opportunity"));
                }
                else
                {
                    MessageBox.Show(String.Format(rtn));
                }
                this.Close();
            }
            catch (Exception ex)
            {
                   ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

      
    }
}

