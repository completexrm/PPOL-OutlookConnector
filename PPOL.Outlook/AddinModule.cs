using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using Outlook = Microsoft.Office.Interop.Outlook;
using PPOL;
using PPOL.MailObjects;
using System.Collections.Generic;

namespace PPOL_Outlook
{
    /// <summary>
    ///   Add-in Express Add-in Module
    /// </summary>
    [GuidAttribute("6EB7CF5C-F57B-431B-B6A0-0B1C8913F4AE"), ProgId("PPOL_Outlook.AddinModule")]
    public partial class AddinModule : AddinExpress.MSO.ADXAddinModule, IOutlookWindowHost
    {
        public AddinModule()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            // Please add any initialization code to the AddinInitialize event handler
        }
 
        #region Add-in Express automatic code
 
        // Required by Add-in Express - do not modify
        // the methods within this region
 
        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }
 
        [ComRegisterFunctionAttribute]
        public static void AddinRegister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXRegister(t);
        }
 
        [ComUnregisterFunctionAttribute]
        public static void AddinUnregister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXUnregister(t);
        }
 
        public override void UninstallControls()
        {
            base.UninstallControls();
        }

        #endregion

        public static new AddinModule CurrentInstance 
        {
            get
            {
                return AddinExpress.MSO.ADXAddinModule.CurrentInstance as AddinModule;
            }
        }

        public Outlook._Application OutlookApp
        {
            get
            {
                return (HostApplication as Outlook._Application);
            }
        }

        private void btnTo_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<FrmAddressList>(a => a.addressType = PPOL.MailObjects.MailRecipientKind.To);
        }
        void ExecuteShow<T>()
            where T : Form, new()
        {
            ExecuteShow<T>(null);
        }
     
        void ExecuteShow<T>(Action<T> init)
            where T: Form, new()
        {
            try
            {
                using (var f = new T())
                {
                    if (init != null)
                    {
                        init(f);
                    }
                    var wnd = this.CurrentWindow;
                    if (wnd!=null)
                    {
                        f.ShowDialog(wnd);
                    }
                    else
                    {
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowEx(ex);
            }
        }
        struct WindowByPtr : IWin32Window
        {
            public IntPtr Handle { get; set; }
        }
        public System.Windows.Forms.IWin32Window CurrentWindow
        {
            get
            {
                WindowByPtr ptr = new WindowByPtr { Handle = IntPtr.Zero };
                try
                {
                    var wnd = this.OutlookApp.ActiveWindow();
                    if (wnd != null)
                    {
                        ptr.Handle = this.GetOutlookWindowHandle(wnd);
                        Marshal.ReleaseComObject(wnd);
                    }
                    
                }
                catch { }
                if (ptr.Handle == IntPtr.Zero)
                {
                    return null;
                }
                return ptr;
            }
        }
        private void btnCc_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<FrmAddressList>(a => a.addressType = PPOL.MailObjects.MailRecipientKind.Cc);
          
        }

        private void btnSendToOrganizations_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteAttach(AttachKind.Organization, control, AttachBehavior.Send);
        }

        private void btnSendToContacts_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            
            ExecuteAttach(AttachKind.Contact, control, AttachBehavior.Send);
        }
        readonly Dictionary<IMailItem, AttachOnSendParameters> executeAttachOnSend = new Dictionary<IMailItem, AttachOnSendParameters>();
        struct AttachOnSendParameters
        {
            public AttachKind AttachKind { get; set; }
        }
        enum AttachBehavior
        {
            Send,
            SyncAttach
        }
        void ExecuteAttach(AttachKind kind, IRibbonControl control, AttachBehavior behavior)
        {

            try
            {
                var inspector = control.Context as Outlook._Inspector;
                if (inspector != null)
                {
                    inspector = OutlookApp.ActiveInspector();
                }
                if (inspector != null)
                {
                    using (var mi = app.GetItemByInspector(inspector))
                    {
                        Marshal.ReleaseComObject(inspector);
                        if (mi != null)
                        {
                            switch (behavior)
                            {
                                case AttachBehavior.Send:
                                    executeAttachOnSend[mi] = new AttachOnSendParameters { AttachKind = kind };
                                    try
                                    {
                                        mi.Send();
                                    }
                                    finally
                                    {
                                        executeAttachOnSend.Remove(mi);
                                    }
                                    break;
                                case AttachBehavior.SyncAttach:
                                    ClassFactory.Instance.EmailAttachProcessor.ExecuteAttach(kind, mi);
                                    break;
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowEx(ex);
            }

            
        }
        void ShowEx(Exception ex)
        {
            //this.ShowErrorDialog(this, ex);
            ClassFactory.Instance.Show(ex);
        }
        private void AddinModule_AddinInitialize(object sender, EventArgs e)
        {
            ClassFactory.Instance.WindowHost = this;
        }
        OutlookApplication app;
        private void AddinModule_AddinStartupComplete(object sender, EventArgs e)
        {
            app = new OutlookApplication(this.OutlookApp);
            ClassFactory.Instance.Outlook = app;
        }

        private void AddinModule_AddinFinalize(object sender, EventArgs e)
        {
            ClassFactory.Instance.Dispose();
        }

        private void btnAccountSettings_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<PPOLSetting>();

        }

        private void btnHelp_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<FrmHelp>();
        }

        private void adxOutlookEvents_ItemSend(object sender, ADXOlItemSendEventArgs e)
        {
            try
            {
                foreach (var itemPair in this.executeAttachOnSend)
                {
                    if (itemPair.Key.ComObject == e.Item)
                    {
                        ClassFactory.Instance.EmailAttachProcessor.ExecuteAttach(itemPair.Value.AttachKind, itemPair.Key);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowEx(ex);
            }
        }

        private void btnAttachAsOrganization_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteAttach(AttachKind.Organization, control, AttachBehavior.SyncAttach);
        }

        private void btnAttachAsContact_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteAttach(AttachKind.Contact, control, AttachBehavior.SyncAttach);
        }

        private void btnAttachAsOpportunity_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<frmOpportunitySearch>();
        }

        private void btnAttachAsProject_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<ProjectSearch>();
        }

        private void btnTransferAsAppointment_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<FrmAppointment>();
        }

        private void btnTransferAsOpportunity_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<FrmOppTransfer>();
        }

        private void btnTransferAsProjectTask_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<ProjectTaskTransfer>();
        }

        private void btnTransferAsTask_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ExecuteShow<TaskTransfer>();
        }
        
        

    }
}

