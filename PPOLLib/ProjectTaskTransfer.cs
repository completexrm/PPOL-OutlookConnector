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
    public partial class ProjectTaskTransfer : Form
    {
        ServicesUtil serviceUtil = null;
        ProjectService.projectList prjList = null;
        ProjectService.prjTaskOptions tskOptions = null;
        ProjectService.prjTaskPriority[] tskPriority = null;
        ProjectService.prjTaskStatus[] tskStatus = null;
        ProjectService.prjTaskType[] tskType = null;
        UserGroupService.fwkUserEO[] fwkUsers = null;
        int ownerId = -1;

        public ProjectTaskTransfer()
        {
            InitializeComponent();
            serviceUtil = new ServicesUtil();
            loadComboData();
            loadOwnerData();
            getProjectData();
            loadMailInfo();
        }

        private void ProjectTaskTransfer_Load(object sender, EventArgs e)
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

                    this.cbProjects.Items.Add("Projects are not found in your PlanPlus Online account.");

                }
                else
                {

                   
                        this.cbProjects.Items.Add("");
                        for (int i = 0; i < prjList.list.Length; i++)
                        {
                            ProjectService.project project = (ProjectService.project)prjList.list[i];
                            this.cbProjects.Items.Add(project.projectId+"-"+project.projectName);
                        }
                   

                    
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void loadComboData()
        {
            try
            {

                ProjectService.PrjAPIService local = new ProjectService.PrjAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/PrjAPI";

                tskOptions = local.getTaskOptions(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                if (tskOptions != null)
                {
                    tskPriority = tskOptions.prjTaskPriorityList;
                    tskStatus = tskOptions.prjTaskStatusList;
                    tskType = tskOptions.prjTaskTypeList;

                    if (tskPriority != null)
                    {
                        this.cbPriority.Items.Add("");
                        for (int i = 0; i < tskPriority.Length; i++)
                        {
                            ProjectService.prjTaskPriority priority = tskPriority[i];
                            this.cbPriority.Items.Add(priority.name);
                        }
                    }
                    if (tskStatus != null)
                    {
                        this.cbStatus.Items.Add("");
                        for (int i = 0; i < tskStatus.Length; i++)
                        {
                            ProjectService.prjTaskStatus status = tskStatus[i];
                            this.cbStatus.Items.Add(status.name);
                        }
                    }
                    if (tskType != null)
                    {
                        this.cbType.Items.Add("");
                        for (int i = 0; i < tskType.Length; i++)
                        {
                            ProjectService.prjTaskType type = tskType[i];
                            this.cbType.Items.Add(type.name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void loadOwnerData()
        {
            try
            {
                UserGroupService.UserGroupAPIService local = new UserGroupService.UserGroupAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/UserGroupAPI";
                fwkUsers = local.getUsersByGroup(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), -1);

                if (fwkUsers != null)
                {

                    this.cbOwner.Items.Add("");
                    for (int i = 0; i < fwkUsers.Length; i++)
                    {
                        UserGroupService.fwkUserEO user = fwkUsers[i];
                        if (user.userName == serviceUtil.getUserName())
                        {
                            ownerId = i + 1;
                        }
                        this.cbOwner.Items.Add(user.displayName);
                    }
                    this.cbOwner.SelectedIndex = ownerId;

                }
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectService.PrjAPIService local = new ProjectService.PrjAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/PrjAPI";
                ProjectService.prjTask inPrjTask = new ProjectService.prjTask();
                inPrjTask.taskName = this.txtDesc.Text;
                int index = -1;

                int prjIndex = this.cbProjects.SelectedIndex;
                if (prjIndex < 1)
                {
                    MessageBox.Show("A valid project need to be selected to transfer an email to a project task.");
                    this.cbProjects.Focus();
                }
                else
                {

                    ProjectService.project proj = (ProjectService.project)prjList.list[prjIndex-1];
                    inPrjTask.project = proj;
                    index = this.cbPriority.SelectedIndex;
                    if (index > 0)
                    {                        
                        ProjectService.prjTaskPriority selPriority = tskPriority[index-1];
                        inPrjTask.priority = selPriority.key;
                      //  inPrjTask.fcABC = selPriority.key;
                    }
                    index = this.cbStatus.SelectedIndex;
                    if (index > 0)
                    {
                        ProjectService.prjTaskStatus selStatus = tskStatus[index-1];
                        inPrjTask.status = selStatus.key;
                    //    inPrjTask.fcStatus = selStatus.key;
                    }
                    index = this.cbOwner.SelectedIndex;
                    if (index > 0)
                    {
                        UserGroupService.fwkUserEO selOwner = fwkUsers[index-1];
                        inPrjTask.ownerId = selOwner.userId;
                    }
                    inPrjTask.startDate = this.dtpStart.Value.Month.ToString() + "/" + this.dtpStart.Value.Day.ToString() + "/" + this.dtpStart.Value.Year;
                    inPrjTask.endDate = this.dtpDue.Value.Month.ToString() + "/" + this.dtpDue.Value.Day.ToString() + "/" + this.dtpDue.Value.Year;

                    inPrjTask.desc = this.rtbDetail.Text;

                    ProjectService.prjTask tsk = local.transferEmailAsTask(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), inPrjTask);

                    MessageBox.Show("Email was transferred to task '" + tsk.taskName+ "' successfully.");
                    
                    this.Close();
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

        private void loadMailInfo()
        {
            using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
            {
                if (mItem != null)
                {
                    var subject = mItem.Subject;
                    txtDesc.Text = subject;
                    rtbDetail.Text = "Subject: " + subject + " \n" + mItem.Body;
                }

            }
            /*Microsoft.Office.Interop.Outlook.MailItem mItem =
                        (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
            this.txtDesc.Text = mItem.Subject;
            this.rtbDetail.Text = "Subject: " + mItem.Subject + " \n" + mItem.Body;*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
