using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPOL
{
    public partial class PPOLSetting : Form
    {
        public PPOLSetting()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.userControlSettings1.Apply();
            this.Hide();
        }

        private void PPOLSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.userControlSettings1.Apply();
        }

        private void userControlSettings1_Load(object sender, EventArgs e)
        {

        }
    }
}
