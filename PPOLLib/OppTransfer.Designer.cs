namespace PPOL
{
    partial class OppTransfer
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
            this.lblTransfer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.rchTxtComment = new System.Windows.Forms.RichTextBox();
            this.chkAttachNote = new System.Windows.Forms.CheckBox();
            this.txtNewOpp = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblContactMsg = new System.Windows.Forms.Label();
            this.btnSearchContact = new System.Windows.Forms.Button();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransfer
            // 
            this.lblTransfer.AutoSize = true;
            this.lblTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTransfer.Location = new System.Drawing.Point(13, 13);
            this.lblTransfer.Name = "lblTransfer";
            this.lblTransfer.Size = new System.Drawing.Size(176, 13);
            this.lblTransfer.TabIndex = 0;
            this.lblTransfer.Text = "Transfer Email To Opportunity";
            // 
            // shapeContainer1
            // 
            // 
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "You can transfer the Email to an Opportunity. ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(54, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 402);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblComment);
            this.groupBox2.Controls.Add(this.rchTxtComment);
            this.groupBox2.Controls.Add(this.chkAttachNote);
            this.groupBox2.Controls.Add(this.txtNewOpp);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(41, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 269);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transfer this email as";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Opportunity Name:";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(14, 64);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(58, 13);
            this.lblComment.TabIndex = 7;
            this.lblComment.Text = "Comment";
            // 
            // rchTxtComment
            // 
            this.rchTxtComment.Location = new System.Drawing.Point(17, 88);
            this.rchTxtComment.Name = "rchTxtComment";
            this.rchTxtComment.Size = new System.Drawing.Size(433, 152);
            this.rchTxtComment.TabIndex = 6;
            this.rchTxtComment.Text = "";
            // 
            // chkAttachNote
            // 
            this.chkAttachNote.AutoSize = true;
            this.chkAttachNote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAttachNote.Location = new System.Drawing.Point(17, 246);
            this.chkAttachNote.Name = "chkAttachNote";
            this.chkAttachNote.Size = new System.Drawing.Size(115, 17);
            this.chkAttachNote.TabIndex = 5;
            this.chkAttachNote.Text = "Attach as Note:";
            this.chkAttachNote.UseVisualStyleBackColor = true;
            // 
            // txtNewOpp
            // 
            this.txtNewOpp.Location = new System.Drawing.Point(137, 34);
            this.txtNewOpp.Name = "txtNewOpp";
            this.txtNewOpp.Size = new System.Drawing.Size(313, 20);
            this.txtNewOpp.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblContactMsg);
            this.groupBox1.Controls.Add(this.btnSearchContact);
            this.groupBox1.Controls.Add(this.txtContactName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(41, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opportunity Owner";
            // 
            // lblContactMsg
            // 
            this.lblContactMsg.AutoSize = true;
            this.lblContactMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactMsg.ForeColor = System.Drawing.Color.Red;
            this.lblContactMsg.Location = new System.Drawing.Point(20, 55);
            this.lblContactMsg.Name = "lblContactMsg";
            this.lblContactMsg.Size = new System.Drawing.Size(0, 13);
            this.lblContactMsg.TabIndex = 3;
            // 
            // btnSearchContact
            // 
            this.btnSearchContact.Location = new System.Drawing.Point(340, 19);
            this.btnSearchContact.Name = "btnSearchContact";
            this.btnSearchContact.Size = new System.Drawing.Size(110, 23);
            this.btnSearchContact.TabIndex = 2;
            this.btnSearchContact.Text = "Search Contact";
            this.btnSearchContact.UseVisualStyleBackColor = true;
            this.btnSearchContact.Click += new System.EventHandler(this.btnSearchContact_Click);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(137, 22);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(197, 20);
            this.txtContactName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contact Name:";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(54, 491);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 5;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(135, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::PPOL.Properties.Resources.ozicontip21;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = " ";
            // 
            // OppTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 539);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTransfer);
            this.Name = "OppTransfer";
            this.Text = "PlanPlus Online Connector - Opportunity";
            this.Load += new System.EventHandler(this.OppTransfer_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAttachNote;
        private System.Windows.Forms.TextBox txtNewOpp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.RichTextBox rchTxtComment;
        private System.Windows.Forms.Button btnSearchContact;
        private System.Windows.Forms.Label lblContactMsg;
        private System.Windows.Forms.Label label4;
    }
}