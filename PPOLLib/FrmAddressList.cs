using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PPOL;
using PPOL.MailObjects;

namespace PPOL
{
    public partial class FrmAddressList : Form
    {
        ServicesUtil serviceUtil = null;
        UserGroupService.ppolGroup[] ppolGroups = null;
        UserGroupService.fwkUserEO[] fwkUsers = null;
        ContactService.mktAudlistEO[] contactLists = null;
        ContactService.ppolContact[] ppolContacts = null;
        UserService.fwkUserEO[] users = null;
        public int listType = 0;
        public MailRecipientKind addressType = MailRecipientKind.Unknown;
        
        public FrmAddressList()
        {
            InitializeComponent();
            serviceUtil = new ServicesUtil();
      //      initData();
            configGrid();
        }

      
        private void loadGroupUsers(int userGroupId)
        {
            try
            {
                try
                {
                    this.cbContactList.SelectedIndex = 0;
                    this.txtSrchUser.Text = "";
                    this.txtSrcContact.Text = "";
                }
                catch (Exception e1)
                {

                }
                this.listType = 1;
                UserGroupService.UserGroupAPIService local = new UserGroupService.UserGroupAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/UserGroupAPI";
                fwkUsers = local.getUsersByGroup(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), userGroupId);
                this.grdUsers.Rows.Clear();
                if (fwkUsers != null)                
                {                    
                    for (int i = 0; i < fwkUsers.Length; i++)
                    {
                        UserGroupService.fwkUserEO fwkUser = fwkUsers[i];

                        this.grdUsers.Rows.Add();
                        this.grdUsers.Rows[i].Cells[0].Value = false;
                        this.grdUsers.Rows[i].Cells[1].Value = fwkUser.displayName;
                        this.grdUsers.Rows[i].Cells[2].Value = fwkUser.emailAddress;

                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void configGrid()
        {
           
            
            this.grdUsers.ColumnCount = 2;

            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            grdUsers.Columns.Insert(0, col);
            grdUsers.Columns[1].Name = "Name";
            grdUsers.Columns[1].Width = 200;
            grdUsers.Columns[2].Name = "Email";
            grdUsers.Columns[2].Width = 200;

            grdUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            grdUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grdUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font(grdUsers.Font, FontStyle.Bold);


         //   grdUsers.AutoSizeRowsMode =
         //       DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
   //         grdUsers.ColumnHeadersBorderStyle =
   //             DataGridViewHeaderBorderStyle.Single;
       //     grdUsers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdUsers.GridColor = Color.Black;
            grdUsers.RowHeadersVisible = false;
            

           

           
           
        }

        private void initData()
        {
            try
            {
                UserGroupService.UserGroupAPIService local = new UserGroupService.UserGroupAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/UserGroupAPI";

                ppolGroups = local.getUserGroups(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                if (ppolGroups != null)
                {
                    if (ppolGroups.Length > 0)
                    {
                        UserGroupService.ppolGroup grp = ppolGroups[0];
                        if (grp.id == -1)
                        {
                       //     MessageBox.Show(grp.errorMessage);
                        }

                        else
                        {

                            this.cbUserGroup.Items.Add("");
                            for (int i = 0; i < ppolGroups.Length; i++)
                            {
                                UserGroupService.ppolGroup group = ppolGroups[i];
                                this.cbUserGroup.Items.Add(group.name);
                            }

                            ContactService.PsnAPIService local1 = new ContactService.PsnAPIService();
                            local1.Url = serviceUtil.getPpolURL() + "/cxf/PsnAPI";

                            contactLists = local1.getContactList(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                            if (contactLists != null)
                            {
                                this.cbContactList.Items.Add("");
                                for (int i = 0; i < contactLists.Length; i++)
                                {
                                    ContactService.mktAudlistEO list = contactLists[i];
                                    this.cbContactList.Items.Add(list.audlistName);
                                }
                            }
                        }
                    }
                 }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Outlook.MailItem mItem =
            //       (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
            using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
            {


                if (this.listType == 1)
                {
                    for (int i = 0; i < fwkUsers.Length; i++)
                    {

                        DataGridViewRow row = grdUsers.Rows[i];
                        DataGridViewCell cell = row.Cells[0];
                        bool rtn = (Boolean)cell.Value;
                        if (rtn)
                        {
                            mItem.AddRecipient(fwkUsers[i].emailAddress, this.addressType);
                            
                        }
                    }
                }
                else if (this.listType == 2)
                {
                    for (int i = 0; i < ppolContacts.Length; i++)
                    {

                        DataGridViewRow row = grdUsers.Rows[i];
                        DataGridViewCell cell = row.Cells[0];
                        bool rtn = (Boolean)cell.Value;
                        if (rtn)
                        {
                            mItem.AddRecipient(ppolContacts[i].primaryEmail, this.addressType);
                        }
                    }

                }
                else if (this.listType == 3)
                {
                    for (int i = 0; i < users.Length; i++)
                    {

                        DataGridViewRow row = grdUsers.Rows[i];
                        DataGridViewCell cell = row.Cells[0];
                        bool rtn = (Boolean)cell.Value;
                        if (rtn)
                        {
                            mItem.AddRecipient(users[i].emailAddress, this.addressType);
                            
                        }
                    }
                }
                else if (this.listType == 4)
                {
                    for (int i = 0; i < ppolContacts.Length; i++)
                    {

                        DataGridViewRow row = grdUsers.Rows[i];
                        DataGridViewCell cell = row.Cells[0];
                        bool rtn = (Boolean)cell.Value;
                        if (rtn)
                        {
                            mItem.AddRecipient(ppolContacts[i].primaryEmail, this.addressType);
                            
                        }
                    }
                }
            }
            this.Close();
        }

        

        
        private void loadContactLists(int contactListId)
        {

            try
            {
                try
                {
                    this.cbUserGroup.SelectedIndex = 0;
                    this.txtSrchUser.Text = "";
                    this.txtSrcContact.Text = "";
                }
                catch (Exception e1)
                {
                }
                
                this.listType = 2;
                ContactService.PsnAPIService local = new ContactService.PsnAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/PsnAPI";
                ppolContacts = local.getContactsByList(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), contactListId);
                this.grdUsers.Rows.Clear();
                if (ppolContacts != null)
                {
                    for (int i = 0; i < ppolContacts.Length; i++)
                    {
                        ContactService.ppolContact contact = ppolContacts[i];

                        this.grdUsers.Rows.Add();
                        this.grdUsers.Rows[i].Cells[0].Value = false;
                        this.grdUsers.Rows[i].Cells[1].Value = contact.displayName;
                        this.grdUsers.Rows[i].Cells[2].Value = contact.primaryEmail;

                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       

        private void FrmAddressList_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGoContact_Click_1(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.cbUserGroup.SelectedIndex = 0;
                    this.cbContactList.SelectedIndex = 0;
                    this.txtSrchUser.Text = "";

                }
                catch (Exception ex1)
                {

                }
                this.listType = 4;

                ContactService.PsnAPIService local = new ContactService.PsnAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/PsnAPI";

                ppolContacts = local.search(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), this.txtSrcContact.Text);
                if (ppolContacts != null)
                {
                    if (ppolContacts.Length > 0)
                    {
                        ContactService.ppolContact ppolCntct = ppolContacts[0];
                        if (ppolCntct.id == -1)
                        {
                            MessageBox.Show(ppolCntct.errorMessage);
                        }
                        else
                        {
                            this.grdUsers.Rows.Clear();
                            for (int i = 0; i < ppolContacts.Length; i++)
                            {
                                ContactService.ppolContact contact = ppolContacts[i];

                                this.grdUsers.Rows.Add();
                                this.grdUsers.Rows[i].Cells[0].Value = false;
                                this.grdUsers.Rows[i].Cells[1].Value = contact.displayName;
                                this.grdUsers.Rows[i].Cells[2].Value = contact.primaryEmail;

                            }
                        }
                    }
                }
                else
                {
                    if (this.txtSrcContact.Text.Trim() == "")
                    {
                        MessageBox.Show("Contacts are not found in your PlanPlus Online account.");
                    }
                    else
                    {
                        MessageBox.Show("Contact name(s) containing '" + this.txtSrcContact.Text + "' are not found in your PlanPlus Online account.");
                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
               

                            ContactService.PsnAPIService local1 = new ContactService.PsnAPIService();
                            local1.Url = serviceUtil.getPpolURL() + "/cxf/PsnAPI";

                            contactLists = local1.getContactList(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                            if (contactLists != null)
                            {
                                if (contactLists.Length > 0)
                                {
                                    ContactService.mktAudlistEO aud = contactLists[0];
                                    if (aud.audlistId == -1)
                                    {
                                        MessageBox.Show(aud.returnMsg);
                                    }

                                    else
                                    {
                                        this.cbContactList.Items.Add("");
                                        for (int i = 0; i < contactLists.Length; i++)
                                        {
                                            ContactService.mktAudlistEO list = contactLists[i];
                                            this.cbContactList.Items.Add(list.audlistName);
                                        }
                                    }
                                }
                            }
                        
                
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            try
            {
                UserGroupService.UserGroupAPIService local = new UserGroupService.UserGroupAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/UserGroupAPI";

                ppolGroups = local.getUserGroups(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                if (ppolGroups != null)
                {
                    if (ppolGroups.Length > 0)
                    {
                        UserGroupService.ppolGroup grp = ppolGroups[0];
                        if (grp.id == -1)
                        {
                                 MessageBox.Show(grp.errorMessage);
                        }

                        else
                        {

                            this.cbUserGroup.Items.Add("");
                            for (int i = 0; i < ppolGroups.Length; i++)
                            {
                                UserGroupService.ppolGroup group = ppolGroups[i];
                                this.cbUserGroup.Items.Add(group.name);
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to the PlanPlus Online Application, please check if your account information is correct. If you continue to experience problems contact support at http://www.planplusonline.com/support");
            }
        }

        private void btnGoUser_Click_1(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.cbUserGroup.SelectedIndex = 0;
                    this.cbContactList.SelectedIndex = 0;
                    this.txtSrcContact.Text = "";

                }
                catch (Exception e1)
                {

                }
                this.listType = 3;
                UserService.UserAPIService local = new UserService.UserAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/UserAPI";

                users = local.search(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), this.txtSrchUser.Text);
                if (users != null)
                {
                    if (users.Length > 0)
                    {
                        UserService.fwkUserEO usr = users[0];
                        if (usr.userId == -1)
                        {
                            MessageBox.Show(usr.returnMsg);
                        }
                        else
                        {
                            this.grdUsers.Rows.Clear();
                            for (int i = 0; i < users.Length; i++)
                            {
                                UserService.fwkUserEO user = users[i];

                                this.grdUsers.Rows.Add();
                                this.grdUsers.Rows[i].Cells[0].Value = false;
                                this.grdUsers.Rows[i].Cells[1].Value = user.displayName;
                                this.grdUsers.Rows[i].Cells[2].Value = user.emailAddress;

                            }
                        }
                    }
                }
                else
                {
                    //txtSrchUser
                    if (this.txtSrchUser.Text.Trim() == "")
                    {
                        MessageBox.Show("Users are not found in your PlanPlus Online account.");
                    }
                    else
                    {
                        MessageBox.Show("User name(s) containing '" + this.txtSrchUser.Text + "' are not found in your PlanPlus Online account.");
                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void cbContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cbContactList.SelectedIndex;
            if (index != 0)
            {
                int contactListId = contactLists[index - 1].audlistId;
                loadContactLists(contactListId);
            }
        }

        private void cbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.cbUserGroup.SelectedIndex;
            if (index != 0)
            {
                int userGroupId = ppolGroups[index - 1].id;
                loadGroupUsers(userGroupId);
            }
        }

      

       
    }
    public enum AddressType
    {
        Unknown=0,
        To=1,
        Cc=2
    }
}
