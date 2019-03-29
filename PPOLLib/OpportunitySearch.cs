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
    public partial class frmOpportunitySearch : Form
    {
        public frmOpportunitySearch()
        {
            InitializeComponent();
        }

        private void frmOpportunitySearch_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            

            grdOpp.ColumnCount = 6;

            grdOpp.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            grdOpp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grdOpp.ColumnHeadersDefaultCellStyle.Font =
                new Font(grdOpp.Font, FontStyle.Bold);

          
            grdOpp.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grdOpp.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            grdOpp.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdOpp.GridColor = Color.Black;
            grdOpp.RowHeadersVisible = false;

            grdOpp.Columns[0].Name = "ID";
            grdOpp.Columns[1].Name = "Name";
            grdOpp.Columns[1].Width = 200;
            grdOpp.Columns[2].Name = "Description";
            grdOpp.Columns[2].Width = 200;
            grdOpp.Columns[3].Name = "Status";
            grdOpp.Columns[4].Name = "Stage";
            grdOpp.Columns[5].Name = "Amount";

      //      DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
      //      grdOpp.Columns.Insert(6,col);
         //   grdOpp.Columns[5].DefaultCellStyle.Font =
         //       new Font(grdOpp.DefaultCellStyle.Font, FontStyle.Italic);

            grdOpp.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            grdOpp.MultiSelect = false;
        //    grdOpp.Dock = DockStyle.Fill;

          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          // searchOpportunities(String companyName, String loginUN, String loginPW,String searchStr)

            try
            {
                Properties.Settings settings = new Properties.Settings();
                settings.Reload();
                String PPOLUrl = settings.PPOLURL;
                String ppolAccount = settings.Account;
                String userName = settings.UserName;
                String password = settings.Password;

                var local = new OppService.OppNoteAPIService();
                local.Url = PPOLUrl + "/cxf/OppNoteAPI";
                OppService.opportunityList oppList = local.searchOpportunities(ppolAccount, userName, password, this.txtOppName.Text);
                if (oppList.list == null)
                {
                    if (oppList.errorMsg.Trim() != "")
                    {
                        MessageBox.Show(oppList.errorMsg);
                    }
                    else
                    {
                        if (this.txtOppName.Text.Trim() == "")
                        {
                            MessageBox.Show("Opportunities are not found in your PlanPlus Online account.");
                        }
                        else
                        {
                            MessageBox.Show("Opportunity name(s) containing '" + this.txtOppName.Text + "' are not found in your PlanPlus Online account.");
                        }
                    }
                }
                else
                {
                    OppService.opportunity[] opp = oppList.list;

                    this.grdOpp.Rows.Clear();
                    for (int i = 0; i < opp.Length; i++)
                    {
                        OppService.opportunity opportunity = opp[i];
                        string name = opportunity.oppName;
                        string[] gridRow = new string[6];
                        gridRow[0] = opportunity.oppId.ToString();
                        gridRow[1] = opportunity.oppName;
                        gridRow[2] = opportunity.oppDesc;
                        gridRow[3] = opportunity.oppStatus;
                        gridRow[4] = opportunity.oppStage;
                        gridRow[5] = opportunity.oppAmount.ToString();
                        //    gridRow[6] = 
                        this.grdOpp.Rows.Add(gridRow);
                        //     this.grdOpp.Rows[i].Cells[6].Value = true;

                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtOppName.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdOpp.SelectedRows.Count > 0 &&
                this.grdOpp.SelectedRows[0].Index !=
                this.grdOpp.Rows.Count - 1)
                {
                    int rowSelected = this.grdOpp.SelectedRows[0].Index;
                    DataGridViewRow gridViewRow = this.grdOpp.Rows[rowSelected];
                    DataGridViewCell gridViewCell = gridViewRow.Cells[0];
                    String cellValue = (string)gridViewCell.Value;

                    string subject = "";
                    string htmlBody = "";
                    using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
                    {
                        subject = mItem.Subject;
                        htmlBody = mItem.HTMLBody;
                    }
                    //Microsoft.Office.Interop.Outlook.MailItem mItem =
                    //    (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;

                    Properties.Settings settings = new Properties.Settings();
                    settings.Reload();
                    String PPOLUrl = settings.PPOLURL;
                    String ppolAccount = settings.Account;
                    String userName = settings.UserName;
                    String password = settings.Password;

                    OppService.OppNoteAPIService oppService = new OppService.OppNoteAPIService();
                    oppService.Url = PPOLUrl + "/cxf/OppNoteAPI";

                    string str = oppService.attachNoteToOpportunity(ppolAccount, userName, password, Convert.ToInt32(cellValue), subject, htmlBody);
                    if (str == "SUCCESS")
                    {
                        MessageBox.Show(String.Format("Attached email as note to the opportunity: " + cellValue + "-" + (string)gridViewRow.Cells[1].Value));
                    }
                    else
                    {
                        MessageBox.Show(String.Format(str));
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select an opportunity to attach");
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

    }
}
