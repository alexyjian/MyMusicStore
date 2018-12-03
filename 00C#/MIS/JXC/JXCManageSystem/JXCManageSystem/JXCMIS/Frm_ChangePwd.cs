using BusinessLogicLayer;
using CommonUtility;
using Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXCMIS
{
    public partial class Frm_ChangePwd : Form
    {
        public string CardNo { get; set; }
        public Employee Employee;
        private EmployeeBLL _employeeBLL;

        public Frm_ChangePwd()
        {
            InitializeComponent();

            _employeeBLL = new EmployeeBLL();
        }

        private void txtConfirmPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNewPwd.Text != txtConfirmPwd.Text)
                lblMsg.Text = "两次输入的密码不一致。";
            else
                lblMsg.Text = string.Empty;
        }

        private void txtNewPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNewPwd.Text != txtConfirmPwd.Text)
                lblMsg.Text = "两次输入的密码不一致。";
            else
                lblMsg.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtConfirmPwd.Text = txtNewPwd.Text = txtOldPwd.Text = string.Empty;
            txtOldPwd.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //1.验证旧密码是否正确，重新登录一次
            //登录判断
            if (_employeeBLL.Login(CardNo, txtOldPwd.Text))
            {
                //2.继续改密码
                if(txtNewPwd.Text.Length>=3&&txtNewPwd.Text==txtConfirmPwd.Text)
                {
                    //3.修改密码
                    Employee = _employeeBLL.GetByCardNo(CardNo);
                    Employee.PassWord = new Encrypt().SHA1(txtNewPwd.Text);
                    if(_employeeBLL.Edit(Employee))
                    {
                        MessageBox.Show("密码修改成功!");
                        txtConfirmPwd.Text = txtNewPwd.Text = txtOldPwd.Text = string.Empty;
                        txtOldPwd.Focus();
                    }
                }
                else
                {
                    lblMsg.Text = "密码格式不正确，不能小于3位！";
                    txtOldPwd.Focus();
                }
            }
            else
            {
                lblMsg.Text = "旧密码不正确！";
                txtOldPwd.Focus();
            }
        }
    }
}
