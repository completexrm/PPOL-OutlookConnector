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
    public partial class TaskTransfer : Form
    {
        ServicesUtil serviceUtil = null;
        TaskService.taskOptions tskOptions = null;
        TaskService.taskPriority[] tskPriority = null;
        TaskService.taskStatus[] tskStatus = null;
        UserGroupService.ppolGroup[] ppolGroups = null;
        UserGroupService.fwkUserEO[] fwkUsers = null;
        int ownerId = -1;

        public TaskTransfer()
        {
            InitializeComponent();
            serviceUtil = new ServicesUtil();
            loadComboData();
            loadOwnerData();
            loadMailInfo();
        }

        private void TaskTransfer_Load(object sender, EventArgs e)
        {

        }

        private void loadComboData() {
            try
            {

                TaskService.TaskAPIService local = new TaskService.TaskAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/TaskAPI";

                tskOptions = local.getTaskOptions(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
                if (tskOptions != null)
                {
                    tskPriority = tskOptions.taskPriorityList;
                    tskStatus = tskOptions.taskStatusList;
                    if (tskPriority != null)
                    {
                        this.cbPriority.Items.Add("");
                                for (int i = 0; i < tskPriority.Length; i++)
                                {
                                    TaskService.taskPriority priority = tskPriority[i];
                                    this.cbPriority.Items.Add(priority.name);
                                }                           
                    }
                    if (tskStatus != null)
                    {
                        this.cbStatus.Items.Add("");
                        for (int i = 0; i < tskStatus.Length; i++)
                        {
                            TaskService.taskStatus status = tskStatus[i];
                            this.cbStatus.Items.Add(status.name);
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
                            ownerId = i+1;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                TaskService.TaskAPIService local = new TaskService.TaskAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/TaskAPI";
                TaskService.task inTask = new TaskService.task();
                inTask.taskName = this.txtDesc.Text;
                 int index = this.cbPriority.SelectedIndex-1;

                

                if (index > 0)
                {
                    TaskService.taskPriority selPriority = tskPriority[index];
                    inTask.taskPriority = selPriority.key;
                    inTask.fcABC = selPriority.key;
                }
                index = this.cbStatus.SelectedIndex-1;
                if (index > 0) 
                {
                    TaskService.taskStatus selStatus = tskStatus[index];
                    inTask.taskStatus = selStatus.key;
                    inTask.fcStatus = selStatus.key;
                }
                index = this.cbOwner.SelectedIndex-1;
                if (index > 0)
                {
                    UserGroupService.fwkUserEO selOwner = fwkUsers[index];
                    inTask.ownerId = selOwner.userId;
                }
                inTask.dueDate = this.dtpDue.Value.Month.ToString() + "/" + this.dtpDue.Value.Day.ToString() + "/" + this.dtpDue.Value.Year;

                inTask.taskDetail = this.rtbDetail.Text;

                TaskService.task tsk = local.transferEmailAsTask(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), inTask);
                
                MessageBox.Show("Email was transferred to task '" + tsk.taskName + "' successfully.");

                this.Close();

              
            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
