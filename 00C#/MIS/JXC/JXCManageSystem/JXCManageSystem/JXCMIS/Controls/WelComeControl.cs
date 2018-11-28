using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXCMIS.Controls
{
    public partial class WelComeControl : UserControl
    {
        public string CardNo { get; set; }

        public WelComeControl()
        {
            InitializeComponent();
        }

        private void WelComeControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                lblCardNo.Text = CardNo;
            else
                lblCardNo.Text = string.Empty;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
