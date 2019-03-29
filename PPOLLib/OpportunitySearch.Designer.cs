namespace PPOL
{
    partial class frmOpportunitySearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpportunitySearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtOppName = new System.Windows.Forms.TextBox();
            this.lblOppName = new System.Windows.Forms.Label();
            this.grdOpp = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpp)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtOppName);
            this.panel1.Controls.Add(this.lblOppName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 46);
            this.panel1.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(424, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(343, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtOppName
            // 
            this.txtOppName.Location = new System.Drawing.Point(125, 12);
            this.txtOppName.Name = "txtOppName";
            this.txtOppName.Size = new System.Drawing.Size(212, 20);
            this.txtOppName.TabIndex = 5;
            // 
            // lblOppName
            // 
            this.lblOppName.AutoSize = true;
            this.lblOppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOppName.Location = new System.Drawing.Point(7, 15);
            this.lblOppName.Name = "lblOppName";
            this.lblOppName.Size = new System.Drawing.Size(112, 13);
            this.lblOppName.TabIndex = 4;
            this.lblOppName.Text = "Opportunity Name:";
            // 
            // grdOpp
            // 
            this.grdOpp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOpp.Location = new System.Drawing.Point(22, 64);
            this.grdOpp.Name = "grdOpp";
            this.grdOpp.ReadOnly = true;
            this.grdOpp.Size = new System.Drawing.Size(822, 281);
            this.grdOpp.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblText);
            this.panel2.Controls.Add(this.lblImage);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnAttach);
            this.panel2.Location = new System.Drawing.Point(12, 351);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 68);
            this.panel2.TabIndex = 6;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(25, 33);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(373, 26);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "To search for a Opportunity, simply enter a search string, and click on Search.\r\n" +
                "To select an Opportunity, simply select the row and click the Attach button. ";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Image = ((System.Drawing.Image)(resources.GetObject("lblImage.Image")));
            this.lblImage.Location = new System.Drawing.Point(9, 33);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(10, 13);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = " ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(90, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(9, 3);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 23);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // frmOpportunitySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 431);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grdOpp);
            this.Controls.Add(this.panel1);
            this.Name = "frmOpportunitySearch";
            this.Text = "PlanPlus Online Connector - Opportunity Search";
            this.Load += new System.EventHandler(this.frmOpportunitySearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtOppName;
        private System.Windows.Forms.Label lblOppName;
        private System.Windows.Forms.DataGridView grdOpp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAttach;

    }
}