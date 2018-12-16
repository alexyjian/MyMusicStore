using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using CommonUtility;

namespace JXCMIS.Controls
{
    public partial class LoginControl : UserControl
    {
        private EmployeeBLL employeeBLL;
        public string CardNo { get; set; }
        private string PassWord { get; set; }

        public LoginControl()
        {
            InitializeComponent();

            employeeBLL = new EmployeeBLL();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CardNo = txtCardNo.Text;
            PassWord = txtPwd.Text;
            //用户必须输入卡号
            if(string.IsNullOrEmpty(CardNo))
            {
                MessageBox.Show("用户卡号不能为空。");
                txtCardNo.Focus();
                return;
            }
            //用户必须输入密码
            if (string.IsNullOrEmpty(PassWord))
            {
                MessageBox.Show("用户密码不能为空。");
                txtPwd.Focus();
                return;
            }
            //登录判断
            if(employeeBLL.Login(CardNo,PassWord))
            {
                this.Visible = false;               
                txtCardNo.Text = txtPwd.Text = string.Empty;  //用户输入清理
            }
            else
            {
                MessageBox.Show("用户卡号和密码不正确。");
                txtPwd.Focus();
            }
        }
    }
}
