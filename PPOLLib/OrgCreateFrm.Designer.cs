namespace PPOL
{
    partial class OrgCreateFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbBusiness = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.Phone = new System.Windows.Forms.GroupBox();
            this.txtExt3 = new System.Windows.Forms.TextBox();
            this.txtExt2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ext = new System.Windows.Forms.Label();
            this.txtExt1 = new System.Windows.Forms.TextBox();
            this.txtPhone3 = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.cbPhone3 = new System.Windows.Forms.ComboBox();
            this.cbPhone2 = new System.Windows.Forms.ComboBox();
            this.cbPhone1 = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbClassification = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Phone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(40, 461);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWebsite);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbBusiness);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Phone);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbClassification);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 432);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Customer";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(458, 91);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(214, 20);
            this.txtWebsite.TabIndex = 13;
            this.txtWebsite.Text = "http://";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(398, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Web Site:";
            // 
            // cbBusiness
            // 
            this.cbBusiness.FormattingEnabled = true;
            this.cbBusiness.Location = new System.Drawing.Point(458, 61);
            this.cbBusiness.Name = "cbBusiness";
            this.cbBusiness.Size = new System.Drawing.Size(214, 21);
            this.cbBusiness.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Business Line:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCountry);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtZip);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtState);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtAddress2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtAddress1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbAddress);
            this.groupBox2.Location = new System.Drawing.Point(26, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 147);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Address";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(92, 112);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(268, 20);
            this.txtCountry.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Country:";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(582, 85);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(135, 20);
            this.txtZip.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(509, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Postal Code:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(328, 85);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(153, 20);
            this.txtState.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "State:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(92, 85);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(166, 20);
            this.txtCity.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "City:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(449, 55);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(268, 20);
            this.txtAddress2.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Address Line 2:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(92, 55);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(268, 20);
            this.txtAddress1.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Address Line 1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Type:";
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(92, 24);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(182, 21);
            this.cbAddress.TabIndex = 1;
            // 
            // Phone
            // 
            this.Phone.Controls.Add(this.txtExt3);
            this.Phone.Controls.Add(this.txtExt2);
            this.Phone.Controls.Add(this.label6);
            this.Phone.Controls.Add(this.label5);
            this.Phone.Controls.Add(this.ext);
            this.Phone.Controls.Add(this.txtExt1);
            this.Phone.Controls.Add(this.txtPhone3);
            this.Phone.Controls.Add(this.txtPhone2);
            this.Phone.Controls.Add(this.txtPhone1);
            this.Phone.Controls.Add(this.cbPhone3);
            this.Phone.Controls.Add(this.cbPhone2);
            this.Phone.Controls.Add(this.cbPhone1);
            this.Phone.Location = new System.Drawing.Point(26, 129);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(739, 120);
            this.Phone.TabIndex = 8;
            this.Phone.TabStop = false;
            this.Phone.Text = "Phone";
            // 
            // txtExt3
            // 
            this.txtExt3.Location = new System.Drawing.Point(538, 83);
            this.txtExt3.Name = "txtExt3";
            this.txtExt3.Size = new System.Drawing.Size(108, 20);
            this.txtExt3.TabIndex = 16;
            // 
            // txtExt2
            // 
            this.txtExt2.Location = new System.Drawing.Point(538, 57);
            this.txtExt2.Name = "txtExt2";
            this.txtExt2.Size = new System.Drawing.Size(108, 20);
            this.txtExt2.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "ext:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "ext:";
            // 
            // ext
            // 
            this.ext.AutoSize = true;
            this.ext.Location = new System.Drawing.Point(508, 32);
            this.ext.Name = "ext";
            this.ext.Size = new System.Drawing.Size(24, 13);
            this.ext.TabIndex = 12;
            this.ext.Text = "ext:";
            // 
            // txtExt1
            // 
            this.txtExt1.Location = new System.Drawing.Point(538, 30);
            this.txtExt1.Name = "txtExt1";
            this.txtExt1.Size = new System.Drawing.Size(108, 20);
            this.txtExt1.TabIndex = 11;
            // 
            // txtPhone3
            // 
            this.txtPhone3.Location = new System.Drawing.Point(257, 83);
            this.txtPhone3.Name = "txtPhone3";
            this.txtPhone3.Size = new System.Drawing.Size(235, 20);
            this.txtPhone3.TabIndex = 10;
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(257, 57);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(235, 20);
            this.txtPhone2.TabIndex = 9;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(257, 29);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(235, 20);
            this.txtPhone1.TabIndex = 3;
            // 
            // cbPhone3
            // 
            this.cbPhone3.FormattingEnabled = true;
            this.cbPhone3.Location = new System.Drawing.Point(55, 83);
            this.cbPhone3.Name = "cbPhone3";
            this.cbPhone3.Size = new System.Drawing.Size(182, 21);
            this.cbPhone3.TabIndex = 2;
            // 
            // cbPhone2
            // 
            this.cbPhone2.FormattingEnabled = true;
            this.cbPhone2.Location = new System.Drawing.Point(55, 56);
            this.cbPhone2.Name = "cbPhone2";
            this.cbPhone2.Size = new System.Drawing.Size(182, 21);
            this.cbPhone2.TabIndex = 1;
            // 
            // cbPhone1
            // 
            this.cbPhone1.FormattingEnabled = true;
            this.cbPhone1.Location = new System.Drawing.Point(55, 29);
            this.cbPhone1.Name = "cbPhone1";
            this.cbPhone1.Size = new System.Drawing.Size(182, 21);
            this.cbPhone1.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(116, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(241, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "*Email:";
            // 
            // cbClassification
            // 
            this.cbClassification.FormattingEnabled = true;
            this.cbClassification.Location = new System.Drawing.Point(116, 61);
            this.cbClassification.Name = "cbClassification";
            this.cbClassification.Size = new System.Drawing.Size(191, 21);
            this.cbClassification.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(116, 32);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(556, 20);
            this.txtCustomer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Customer Name:";
            // 
            // OrgCreateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 502);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrgCreateFrm";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.OrgCreateFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Phone.ResumeLayout(false);
            this.Phone.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.GroupBox Phone;
        private System.Windows.Forms.TextBox txtExt3;
        private System.Windows.Forms.TextBox txtExt2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ext;
        private System.Windows.Forms.TextBox txtExt1;
        private System.Windows.Forms.TextBox txtPhone3;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.ComboBox cbPhone3;
        private System.Windows.Forms.ComboBox cbPhone2;
        private System.Windows.Forms.ComboBox cbPhone1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbClassification;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbBusiness;
        private System.Windows.Forms.Label label2;
    }
}