using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPOL
{
    public partial class ContactSearch : Form
    {

        public int contactIdFromSearch = 0;
        public string contactNameFromSearch = "";
        ServicesUtil serviceUtil = null;
        ContactService.ppolContact[] ppolContacts = null;

        public ContactSearch()
        {
            InitializeComponent();
            configGrid();
            serviceUtil = new ServicesUtil();
        }

        private void btnGoContact_Click(object sender, EventArgs e)
        {
            try
            {
                ContactService.PsnAPIService local = new ContactService.PsnAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/PsnAPI";

                ppolContacts = local.search(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), this.txtSrcContact.Text);

                if (ppolContacts == null || ppolContacts.Length == 0)
                {
                    if (this.txtSrcContact.Text.Trim() == "")
                    {
                        ShowError("Contacts are not found in your PlanPlus Online account.", MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ShowError("Contact name(s) containing '" + this.txtSrcContact.Text + "' are not found in your PlanPlus Online account.", MessageBoxIcon.Warning);
                    }
                }
                else
                {

                    this.grdUsers.Rows.Clear();
                    for (int i = 0; i < ppolContacts.Length; i++)
                    {
                        ContactService.ppolContact contact = ppolContacts[i];
                        if (contact.id < 1)
                        {
                            ShowError(contact.errorMessage);
                        }

                        this.grdUsers.Rows.Add();
                        this.grdUsers.Rows[i].Cells[0].Value = contact.id;
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
        void ShowError(string message)
        {
            ShowError(message, MessageBoxIcon.Error);
        }
        void ShowError(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(this, message, this.Text, MessageBoxButtons.OK, icon);

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (this.grdUsers.SelectedRows.Count > 0 &&
        this.grdUsers.SelectedRows[0].Index !=
        this.grdUsers.Rows.Count )
            {
                int rowSelected = this.grdUsers.SelectedRows[0].Index;
                DataGridViewRow gridViewRow = this.grdUsers.Rows[rowSelected];
                DataGridViewCell gridViewCell = gridViewRow.Cells[0];
                contactIdFromSearch = (int)gridViewCell.Value;
                contactNameFromSearch = (string)gridViewRow.Cells[1].Value;

                this.Close();
            }
            else
            {
                ShowError("Select a Contact", MessageBoxIcon.Warning); 
            }
                
        }

           private void configGrid()
        {
           
            
            this.grdUsers.ColumnCount = 3;

            grdUsers.Columns[0].Name = "ID";            
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
            grdUsers.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            grdUsers.MultiSelect = false;
  
        }

           private void btnCancel_Click(object sender, EventArgs e)
           {
               this.Close();
           }

           private void ContactSearch_Load(object sender, EventArgs e)
           {

           }
    }
}
