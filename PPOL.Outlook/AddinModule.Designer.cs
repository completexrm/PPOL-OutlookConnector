namespace PPOL_Outlook
{
    partial class AddinModule
    {
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;
 
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddinModule));
            this.tabRead = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.groupAddressBook = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnTo = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.btnCc = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.groupSendAttach = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnSendToOrganizations = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnSendToContacts = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.groupReadAttach = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnAttachAsOrganization = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnAttachAsContact = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnAttachAsOpportunity = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnAttachAsProject = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.groupReadTransfer = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnTransferAsTask = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnTransferAsAppointment = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnTransferAsProjectTask = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnTransferAsOpportunity = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.groupReadSettings = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnAccountSettings = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.groupReadHelp = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnHelp = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.adxOutlookEvents = new AddinExpress.MSO.ADXOutlookAppEvents(this.components);
            // 
            // tabRead
            // 
            this.tabRead.Caption = "PlanPlus Online CRM";
            this.tabRead.Controls.Add(this.groupAddressBook);
            this.tabRead.Controls.Add(this.groupSendAttach);
            this.tabRead.Controls.Add(this.groupReadAttach);
            this.tabRead.Controls.Add(this.groupReadTransfer);
            this.tabRead.Controls.Add(this.groupReadSettings);
            this.tabRead.Controls.Add(this.groupReadHelp);
            this.tabRead.Id = "adxRibbonTab_b08cf8b0435f47dda0b73490de401702";
            this.tabRead.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            // 
            // groupAddressBook
            // 
            this.groupAddressBook.Caption = "Address Book";
            this.groupAddressBook.Controls.Add(this.btnTo);
            this.groupAddressBook.Controls.Add(this.btnCc);
            this.groupAddressBook.Id = "adxRibbonGroup_c19409d9be4c42279add0575c42c3c53";
            this.groupAddressBook.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.groupAddressBook.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose;
            // 
            // btnTo
            // 
            this.btnTo.Caption = "To";
            this.btnTo.Id = "adxRibbonButton_14da57d93fa74b6b8a1176af7495d2c4";
            this.btnTo.Image = 7;
            this.btnTo.ImageList = this.imageList32;
            this.btnTo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnTo.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose;
            this.btnTo.ScreenTip = "Select from the PlanPlus account";
            this.btnTo.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnTo.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnTo_OnClick);
            // 
            // imageList32
            // 
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32.Images.SetKeyName(0, "account.png");
            this.imageList32.Images.SetKeyName(1, "account-1.png");
            this.imageList32.Images.SetKeyName(2, "account-attach.png");
            this.imageList32.Images.SetKeyName(3, "account-attach-v1.png");
            this.imageList32.Images.SetKeyName(4, "help.png");
            this.imageList32.Images.SetKeyName(5, "help-v2.png");
            this.imageList32.Images.SetKeyName(6, "mailCC-v2.png");
            this.imageList32.Images.SetKeyName(7, "mail-v2.png");
            this.imageList32.Images.SetKeyName(8, "opportunity-attach.png");
            this.imageList32.Images.SetKeyName(9, "opportunity-attach-v2.png");
            this.imageList32.Images.SetKeyName(10, "opportunity-forward.png");
            this.imageList32.Images.SetKeyName(11, "sales_accounts.gif");
            this.imageList32.Images.SetKeyName(12, "salescloud_opps.gif");
            // 
            // btnCc
            // 
            this.btnCc.Caption = "Cc";
            this.btnCc.Id = "adxRibbonButton_77045f3c323e457f80f62a776ace5669";
            this.btnCc.Image = 6;
            this.btnCc.ImageList = this.imageList32;
            this.btnCc.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnCc.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose;
            this.btnCc.ScreenTip = "Select from the PlanPlus account to send a copy";
            this.btnCc.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnCc.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnCc_OnClick);
            // 
            // groupSendAttach
            // 
            this.groupSendAttach.Caption = "Send and attach as note to";
            this.groupSendAttach.Controls.Add(this.btnSendToOrganizations);
            this.groupSendAttach.Controls.Add(this.btnSendToContacts);
            this.groupSendAttach.Id = "adxRibbonGroup_edbafad109c849c8ae0dafd95ae8086a";
            this.groupSendAttach.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.groupSendAttach.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose;
            // 
            // btnSendToOrganizations
            // 
            this.btnSendToOrganizations.Caption = "Organizations";
            this.btnSendToOrganizations.Id = "adxRibbonButton_ae8ea8fd3d694cf0be2cf0afead392ae";
            this.btnSendToOrganizations.Image = 3;
            this.btnSendToOrganizations.ImageList = this.imageList32;
            this.btnSendToOrganizations.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSendToOrganizations.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose;
            this.btnSendToOrganizations.ScreenTip = "Send email and attach as note to PlanPlus organization";
            this.btnSendToOrganizations.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnSendToOrganizations.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnSendToOrganizations_OnClick);
            // 
            // btnSendToContacts
            // 
            this.btnSendToContacts.Caption = "Contacts";
            this.btnSendToContacts.Id = "adxRibbonButton_c5cd47d5b3974cf79b24da83733de1cb";
            this.btnSendToContacts.Image = 2;
            this.btnSendToContacts.ImageList = this.imageList32;
            this.btnSendToContacts.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnSendToContacts.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose;
            this.btnSendToContacts.ScreenTip = "Send email and attach as note to PlanPlus contact";
            this.btnSendToContacts.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnSendToContacts.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnSendToContacts_OnClick);
            // 
            // groupReadAttach
            // 
            this.groupReadAttach.Caption = "Attach as note to";
            this.groupReadAttach.Controls.Add(this.btnAttachAsOrganization);
            this.groupReadAttach.Controls.Add(this.btnAttachAsContact);
            this.groupReadAttach.Controls.Add(this.btnAttachAsOpportunity);
            this.groupReadAttach.Controls.Add(this.btnAttachAsProject);
            this.groupReadAttach.Id = "adxRibbonGroup_fbb6972c4fd84e76bdcecd13d6357943";
            this.groupReadAttach.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.groupReadAttach.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            // 
            // btnAttachAsOrganization
            // 
            this.btnAttachAsOrganization.Caption = "Organization";
            this.btnAttachAsOrganization.Id = "adxRibbonButton_d4e625c191b64ac08ff88d6c7ccb1e00";
            this.btnAttachAsOrganization.Image = 3;
            this.btnAttachAsOrganization.ImageList = this.imageList32;
            this.btnAttachAsOrganization.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnAttachAsOrganization.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnAttachAsOrganization.ScreenTip = "Attach email as a note to PlanPlus Online Organization";
            this.btnAttachAsOrganization.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnAttachAsOrganization.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnAttachAsOrganization_OnClick);
            // 
            // btnAttachAsContact
            // 
            this.btnAttachAsContact.Caption = "Contact";
            this.btnAttachAsContact.Id = "adxRibbonButton_61c58d654bbb4afc99d98c4213ee3c31";
            this.btnAttachAsContact.Image = 2;
            this.btnAttachAsContact.ImageList = this.imageList32;
            this.btnAttachAsContact.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnAttachAsContact.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnAttachAsContact.ScreenTip = "Attach email as a note to PlanPlus Online Contact";
            this.btnAttachAsContact.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnAttachAsContact.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnAttachAsContact_OnClick);
            // 
            // btnAttachAsOpportunity
            // 
            this.btnAttachAsOpportunity.Caption = "Opportunity";
            this.btnAttachAsOpportunity.Id = "adxRibbonButton_dba14ec200f14dcf847cb78b5152f51e";
            this.btnAttachAsOpportunity.Image = 8;
            this.btnAttachAsOpportunity.ImageList = this.imageList32;
            this.btnAttachAsOpportunity.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnAttachAsOpportunity.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnAttachAsOpportunity.ScreenTip = "Attach email as a note to PlanPlus Online Opportunity";
            this.btnAttachAsOpportunity.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnAttachAsOpportunity.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnAttachAsOpportunity_OnClick);
            // 
            // btnAttachAsProject
            // 
            this.btnAttachAsProject.Caption = "Project";
            this.btnAttachAsProject.Id = "adxRibbonButton_9b28eb26c6fc4e4b985299423bf08195";
            this.btnAttachAsProject.Image = 9;
            this.btnAttachAsProject.ImageList = this.imageList32;
            this.btnAttachAsProject.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnAttachAsProject.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnAttachAsProject.ScreenTip = "Attach email as a note to PlanPlus Online Project";
            this.btnAttachAsProject.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnAttachAsProject.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnAttachAsProject_OnClick);
            // 
            // groupReadTransfer
            // 
            this.groupReadTransfer.Caption = "Transfer as";
            this.groupReadTransfer.Controls.Add(this.btnTransferAsTask);
            this.groupReadTransfer.Controls.Add(this.btnTransferAsAppointment);
            this.groupReadTransfer.Controls.Add(this.btnTransferAsProjectTask);
            this.groupReadTransfer.Controls.Add(this.btnTransferAsOpportunity);
            this.groupReadTransfer.Id = "adxRibbonGroup_6984b515019340729fe8d3f0a20843ff";
            this.groupReadTransfer.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.groupReadTransfer.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            // 
            // btnTransferAsTask
            // 
            this.btnTransferAsTask.Caption = "Task";
            this.btnTransferAsTask.Id = "adxRibbonButton_afd9ca884e4d4816bf5c5587cac209ec";
            this.btnTransferAsTask.Image = 7;
            this.btnTransferAsTask.ImageList = this.imageList32;
            this.btnTransferAsTask.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnTransferAsTask.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnTransferAsTask.ScreenTip = "Transfer the email as PlanPlus Online Opportunity";
            this.btnTransferAsTask.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnTransferAsTask.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnTransferAsTask_OnClick);
            // 
            // btnTransferAsAppointment
            // 
            this.btnTransferAsAppointment.Caption = "Appointment";
            this.btnTransferAsAppointment.Id = "adxRibbonButton_ec1456068b2c4bc7919202bfbfdd892b";
            this.btnTransferAsAppointment.Image = 10;
            this.btnTransferAsAppointment.ImageList = this.imageList32;
            this.btnTransferAsAppointment.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnTransferAsAppointment.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnTransferAsAppointment.ScreenTip = "Transfer the email as PlanPlus Online Appointment";
            this.btnTransferAsAppointment.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnTransferAsAppointment.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnTransferAsAppointment_OnClick);
            // 
            // btnTransferAsProjectTask
            // 
            this.btnTransferAsProjectTask.Caption = "Project Task";
            this.btnTransferAsProjectTask.Id = "adxRibbonButton_60254c4a2a7f40f09b82e4807e7b3919";
            this.btnTransferAsProjectTask.Image = 6;
            this.btnTransferAsProjectTask.ImageList = this.imageList32;
            this.btnTransferAsProjectTask.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnTransferAsProjectTask.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnTransferAsProjectTask.ScreenTip = "Transfer the email as PlanPlus Online Project Task";
            this.btnTransferAsProjectTask.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnTransferAsProjectTask.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnTransferAsProjectTask_OnClick);
            // 
            // btnTransferAsOpportunity
            // 
            this.btnTransferAsOpportunity.Caption = "Opportunity";
            this.btnTransferAsOpportunity.Id = "adxRibbonButton_3b8b4a6b984542f99089054f3e5e0add";
            this.btnTransferAsOpportunity.Image = 10;
            this.btnTransferAsOpportunity.ImageList = this.imageList32;
            this.btnTransferAsOpportunity.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnTransferAsOpportunity.Ribbons = AddinExpress.MSO.ADXRibbons.msrOutlookMailRead;
            this.btnTransferAsOpportunity.ScreenTip = "Transfer the email as PlanPlus Online Opportunity";
            this.btnTransferAsOpportunity.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnTransferAsOpportunity.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnTransferAsOpportunity_OnClick);
            // 
            // groupReadSettings
            // 
            this.groupReadSettings.Caption = "Settings";
            this.groupReadSettings.Controls.Add(this.btnAccountSettings);
            this.groupReadSettings.Id = "adxRibbonGroup_57b634c64f244e18bf79e4a379558e12";
            this.groupReadSettings.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.groupReadSettings.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.Caption = "Account";
            this.btnAccountSettings.Id = "adxRibbonButton_c231e891603645e296c676703c8ebf97";
            this.btnAccountSettings.Image = 1;
            this.btnAccountSettings.ImageList = this.imageList32;
            this.btnAccountSettings.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnAccountSettings.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            this.btnAccountSettings.ScreenTip = "Set up PlanPlus account settings";
            this.btnAccountSettings.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnAccountSettings.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnAccountSettings_OnClick);
            // 
            // groupReadHelp
            // 
            this.groupReadHelp.Caption = "Help";
            this.groupReadHelp.Controls.Add(this.btnHelp);
            this.groupReadHelp.Id = "adxRibbonGroup_971be4f0c9194c2f84772974936e08c4";
            this.groupReadHelp.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.groupReadHelp.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "View";
            this.btnHelp.Id = "adxRibbonButton_42dab00883714430914276883ab51ae0";
            this.btnHelp.Image = 4;
            this.btnHelp.ImageList = this.imageList32;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnHelp.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookMailRead | AddinExpress.MSO.ADXRibbons.msrOutlookMailCompose)));
            this.btnHelp.ScreenTip = "Online Help Files";
            this.btnHelp.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnHelp.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnHelp_OnClick);
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "ozicon16doc2.gif");
            this.imageList16.Images.SetKeyName(1, "ozIcon16Email.gif");
            this.imageList16.Images.SetKeyName(2, "ozicon16psn.gif");
            this.imageList16.Images.SetKeyName(3, "ozicontip2.gif");
            this.imageList16.Images.SetKeyName(4, "ozicontip21.gif");
            // 
            // adxOutlookEvents
            // 
            this.adxOutlookEvents.ItemSend += new AddinExpress.MSO.ADXOlItemSend_EventHandler(this.adxOutlookEvents_ItemSend);
            // 
            // AddinModule
            // 
            this.AddinName = "PlanPlus Online CRM";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;
            this.AddinInitialize += new AddinExpress.MSO.ADXEvents_EventHandler(this.AddinModule_AddinInitialize);
            this.AddinStartupComplete += new AddinExpress.MSO.ADXEvents_EventHandler(this.AddinModule_AddinStartupComplete);
            this.AddinFinalize += new AddinExpress.MSO.ADXEvents_EventHandler(this.AddinModule_AddinFinalize);

        }
        #endregion

        private AddinExpress.MSO.ADXRibbonTab tabRead;
        private AddinExpress.MSO.ADXRibbonGroup groupReadAttach;
        private AddinExpress.MSO.ADXRibbonButton btnAttachAsOrganization;
        private System.Windows.Forms.ImageList imageList32;
        private AddinExpress.MSO.ADXRibbonButton btnAttachAsContact;
        private AddinExpress.MSO.ADXRibbonButton btnAttachAsOpportunity;
        private AddinExpress.MSO.ADXRibbonButton btnAttachAsProject;
        private AddinExpress.MSO.ADXRibbonGroup groupReadTransfer;
        private AddinExpress.MSO.ADXRibbonButton btnTransferAsTask;
        private AddinExpress.MSO.ADXRibbonButton btnTransferAsAppointment;
        private AddinExpress.MSO.ADXRibbonButton btnTransferAsProjectTask;
        private AddinExpress.MSO.ADXRibbonButton btnTransferAsOpportunity;
        private AddinExpress.MSO.ADXRibbonGroup groupReadSettings;
        private AddinExpress.MSO.ADXRibbonButton btnAccountSettings;
        private AddinExpress.MSO.ADXRibbonGroup groupReadHelp;
        private AddinExpress.MSO.ADXRibbonButton btnHelp;
        private System.Windows.Forms.ImageList imageList16;
        private AddinExpress.MSO.ADXRibbonGroup groupAddressBook;
        private AddinExpress.MSO.ADXRibbonButton btnTo;
        private AddinExpress.MSO.ADXRibbonButton btnCc;
        private AddinExpress.MSO.ADXRibbonGroup groupSendAttach;
        private AddinExpress.MSO.ADXRibbonButton btnSendToOrganizations;
        private AddinExpress.MSO.ADXRibbonButton btnSendToContacts;
        private AddinExpress.MSO.ADXOutlookAppEvents adxOutlookEvents;
    }
}

