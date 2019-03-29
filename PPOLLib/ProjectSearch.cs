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
    public partial class ProjectSearch : Form
    {
        ServicesUtil serviceUtil = null;
        ProjectService.projectList prjList = null;
        public int projectIdFromSearch = 0;
        public string projectNameFromSearch = "";

        public ProjectSearch()
        {
            InitializeComponent();
            configGrid();
            serviceUtil = new ServicesUtil();
            getProjectData();
        }

        private void ProjectSearch_Load(object sender, EventArgs e)
        {

        }

        private void getProjectData()
        {
            try
            {
                ProjectService.PrjAPIService local = new ProjectService.PrjAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/PrjAPI";

                prjList = local.getAllProjects(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());

                if (prjList == null || prjList.list.Length == 0)
                {

                    MessageBox.Show("Projects are not found in your PlanPlus Online account.");

                }
                else
                {

                    this.grdProjects.Rows.Clear();
                    for (int i = 0; i < prjList.list.Length; i++)
                    {
                        ProjectService.project project = (ProjectService.project)prjList.list[i];


                        this.grdProjects.Rows.Add();
                        this.grdProjects.Rows[i].Cells[0].Value = project.projectId;
                        this.grdProjects.Rows[i].Cells[1].Value = project.projectName;
                        this.grdProjects.Rows[i].Cells[2].Value = project.description;

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


            this.grdProjects.ColumnCount = 3;

            grdProjects.Columns[0].Name = "ID";
            grdProjects.Columns[1].Name = "Name";
            grdProjects.Columns[1].Width = 200;
            grdProjects.Columns[2].Name = "Description";
            grdProjects.Columns[2].Width = 250;

            grdProjects.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            grdProjects.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grdProjects.ColumnHeadersDefaultCellStyle.Font =
                new Font(grdProjects.Font, FontStyle.Bold);


            //   grdProjects.AutoSizeRowsMode =
            //       DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //         grdProjects.ColumnHeadersBorderStyle =
            //             DataGridViewHeaderBorderStyle.Single;
            //     grdProjects.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdProjects.GridColor = Color.Black;
            grdProjects.RowHeadersVisible = false;
            grdProjects.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            grdProjects.MultiSelect = false;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdProjects.SelectedRows.Count > 0 &&
                this.grdProjects.SelectedRows[0].Index !=
                this.grdProjects.Rows.Count - 1)
                {
                    int rowSelected = this.grdProjects.SelectedRows[0].Index;
                    DataGridViewRow gridViewRow = this.grdProjects.Rows[rowSelected];
                    DataGridViewCell gridViewCell = gridViewRow.Cells[0];
                    int cellValue = (int)gridViewCell.Value;
                    
                    //Microsoft.Office.Interop.Outlook.MailItem mItem =
                    //    (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;

                    ProjectService.PrjAPIService local = new ProjectService.PrjAPIService();
                    local.Url = serviceUtil.getPpolURL() + "/cxf/PrjAPI";
                    ProjectService.message msg = new ProjectService.message();
                    
                    using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
                    {
                        if (mItem != null)
                        {
                            msg.date = mItem.SentOn.ToLongDateString();
                            msg.subject = mItem.Subject;
                            msg.content = mItem.HTMLBody;
                            
                        }

                    }

                    ProjectService.project prj = (ProjectService.project)prjList.list[rowSelected];
                    ProjectService.project rtnPrj = local.attachEmailAsNote(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), prj, msg);

                    MessageBox.Show(String.Format("Attached email as note to the project: " + cellValue + "-" + (string)gridViewRow.Cells[1].Value));

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Select an project to attach");
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
