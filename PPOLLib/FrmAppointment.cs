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
    public partial class FrmAppointment : Form
    {
        Object[] durationRange,durationValue;
        Object[] hourRange,hourValue;
        Object[] minutesRange,minutesValue;
        ServicesUtil serviceUtil = null;
        AppointmentService.apptOptions appointmentOptions;
        AppointmentService.apptStatus[] appointmentStatus;
        AppointmentService.apptType[] appointmentType;
        AppointmentService.apptImportance[] appointmentImportance;
        AppointmentService.apptCategory[] appointmentCategory;

        public FrmAppointment()
        {
            InitializeComponent();
            init();
            serviceUtil = new ServicesUtil();
            getApptData();
            loadMailInfo();
        }

        private void FrmAppointment_Load(object sender, EventArgs e)
        {

        }

        private void getApptData()
        {
            try
            {
            AppointmentService.ApptAPIService local = new AppointmentService.ApptAPIService();
            local.Url = serviceUtil.getPpolURL() + "/cxf/ApptAPI";

            appointmentOptions = local.getApptOptions(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword());
            if (appointmentOptions != null)
                {
                    appointmentCategory = appointmentOptions.apptCategoryList;
                    appointmentImportance = appointmentOptions.apptImportanceList;
                    appointmentStatus = appointmentOptions.apptStatusList;
                    appointmentType = appointmentOptions.apptTypeList;

                    

                    if (appointmentCategory != null)
                    {
                        this.cbCategory.Items.Add("");
                        for (int i = 0; i < appointmentCategory.Length; i++)
                        {
                            AppointmentService.apptCategory category = appointmentCategory[i];
                            this.cbCategory.Items.Add(category.name);
                        }
                    }
                    if (appointmentImportance != null)
                    {
                        this.cbImportance.Items.Add("");
                        for (int i = 0; i < appointmentImportance.Length; i++)
                        {
                            AppointmentService.apptImportance importance = appointmentImportance[i];
                            this.cbImportance.Items.Add(importance.name);
                        }
                    }
                    if (appointmentStatus != null)
                    {
                        this.cbStatus.Items.Add("");
                        for (int i = 0; i < appointmentStatus.Length; i++)
                        {
                            AppointmentService.apptStatus status = appointmentStatus[i];
                            this.cbStatus.Items.Add(status.name);
                        }
                    }
                    if (appointmentType != null)
                    {
                        this.cbType.Items.Add("");
                        for (int i = 0; i < appointmentType.Length; i++)
                        {
                            AppointmentService.apptType type = appointmentType[i];
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

        private void init()
        {
            durationRange = new Object[10];
            durationRange[0] = "";
            durationRange[1] = "30 Minutes";
            durationRange[2] = "1 Hour";
            durationRange[3] = "2 Hours";
            durationRange[4] = "3 Hours";
            durationRange[5] = "4 Hours";
            durationRange[6] = "5 Hours";
            durationRange[7] = "6 Hours";
            durationRange[8] = "7 Hours";
            durationRange[9] = "8 Hours";
            

            durationValue = new Object[10];
            durationValue[0] = "0";
            durationValue[1] = "30";
            durationValue[2] = "60";
            durationValue[3] = "120";
            durationValue[4] = "180";
            durationValue[5] = "240";
            durationValue[6] = "300";
            durationValue[7] = "360";
            durationValue[8] = "420";
            durationValue[9] = "480";
            

            hourRange = new Object[25];
            hourRange[0] = "";
            hourRange[1] = "12 AM";
            hourRange[2] = "1 AM";
            hourRange[3] = "2 AM";
            hourRange[4] = "3 AM";
            hourRange[5] = "4 AM";
            hourRange[6] = "5 AM";
            hourRange[7] = "6 AM";
            hourRange[8] = "7 AM";
            hourRange[9] = "8 AM";
            hourRange[10] = "9 AM";
            hourRange[11] = "10 AM";
            hourRange[12] = "11 AM";
            hourRange[13] = "11 PM";
            hourRange[14] = "1 PM";
            hourRange[15] = "2 PM";
            hourRange[16] = "3 PM";
            hourRange[17] = "4 PM";
            hourRange[18] = "5 PM";
            hourRange[19] = "6 PM";
            hourRange[20] = "7 PM";
            hourRange[21] = "8 PM";
            hourRange[22] = "9 PM";
            hourRange[23] = "10 PM";
            hourRange[24] = "11 PM";

            hourValue = new Object[25];
            hourValue[0] = "";
            hourValue[1] = "12";
            hourValue[2] = "01";
            hourValue[3] = "02";
            hourValue[4] = "03";
            hourValue[5] = "04";
            hourValue[6] = "05";
            hourValue[7] = "06";
            hourValue[8] = "07";
            hourValue[9] = "08";
            hourValue[10] = "09";
            hourValue[11] = "10";
            hourValue[12] = "11";
            hourValue[13] = "24";
            hourValue[14] = "13";
            hourValue[15] = "14";
            hourValue[16] = "15";
            hourValue[17] = "16";
            hourValue[18] = "17";
            hourValue[19] = "18";
            hourValue[20] = "19";
            hourValue[21] = "20";
            hourValue[22] = "21";
            hourValue[23] = "22";
            hourValue[24] = "23";
            

            minutesRange = new Object[2];
            minutesRange[0] = "00";
            minutesRange[1] = "30";

            minutesValue = new Object[2];
            minutesValue[0] = "00";
            minutesValue[1] = "30";
            
            
            this.cbDuration.Items.AddRange(durationRange);
            this.cbHour.Items.AddRange(hourRange);
            this.cbMinute.Items.AddRange(minutesRange);

            cbDuration.SelectedIndex = 0;
            cbMinute.SelectedIndex = 0;
            cbHour.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadMailInfo()
        {
            /*
            Microsoft.Office.Interop.Outlook.MailItem mItem =
                        (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
            
            this.txtName.Text = mItem.Subject;
            this.rtbDetail.Text = "Subject: " + mItem.Subject + " \n" + mItem.Body;*/
            using (var mItem = ClassFactory.Instance.Outlook.GetCurrentInspectorItem())
            {
                if (mItem != null)
                {
                    var subject = mItem.Subject;
                    txtName.Text = subject;
                    rtbDetail.Text = "Subject: " + subject + " \n" + mItem.Body;
                }

            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentService.ApptAPIService local = new AppointmentService.ApptAPIService();
                local.Url = serviceUtil.getPpolURL() + "/cxf/ApptAPI";
                
              

                if (this.txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Appointment name is a required field.");
                    txtName.Focus();
                }
                
                else if (this.cbHour.SelectedIndex < 1)
                {
                    MessageBox.Show("Appointment start time is a required field.");
                    this.cbHour.Focus();
                }
                else if (this.cbDuration.SelectedIndex < 1)
                {
                    MessageBox.Show("Appointment duration is a required field.");
                    this.cbDuration.Focus();
                }
                else
                {

                    int durationIndex = cbDuration.SelectedIndex;
                    int hourIndex = cbHour.SelectedIndex;
                    int minuteIndex = cbMinute.SelectedIndex;
                    int typeIndex = cbType.SelectedIndex;
                    int importanceIndex = cbImportance.SelectedIndex;
                    int statusIndex = cbStatus.SelectedIndex;
                    int categoryIndex = cbCategory.SelectedIndex;
                  
                    string startDate = this.dtpStart.Value.Month.ToString() + "/" + this.dtpStart.Value.Day.ToString() + "/" + this.dtpStart.Value.Year;
                    string desc = this.rtbDetail.Text;
                    string name = this.txtName.Text;
                    AppointmentService.appointment appt = new AppointmentService.appointment();
                    appt.apptName = name;
                    appt.apptDesc = desc;
                    appt.apptDate = startDate;
                    appt.startTime = hourValue[hourIndex] + ":" + minutesValue[minuteIndex];
                    appt.duration = (string)durationValue[durationIndex];
                    if (typeIndex < 1)
                        appt.evtType = "";
                    else
                        appt.evtType = this.appointmentType[typeIndex-1].key;
                    if (importanceIndex < 1)
                        appt.evtImportance = "";
                    else
                        appt.evtImportance = this.appointmentImportance[importanceIndex-1].key;
                    if (statusIndex < 1)
                        appt.evtStatus = "";
                    else
                        appt.evtStatus = this.appointmentStatus[statusIndex].key;
                    if (categoryIndex < 1)
                        appt.evtCategory = "";
                    else
                        appt.evtCategory = this.appointmentCategory[categoryIndex-1].key;
                    
                    if (this.chkPrivate.Checked)
                        appt.apptPrivate = "Y";
                    else
                        appt.apptPrivate = "N";
                    AppointmentService.appointment appt1 = local.transferEmailAsAppointment(serviceUtil.getPpolAccount(), serviceUtil.getUserName(), serviceUtil.getPassword(), appt);

                    MessageBox.Show("Email was transferred to an appointment '" + appt1.apptName + "' successfully.");

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                ClassFactory.Instance.ConnectionProblem(ex);
            }
        }
    }
}
