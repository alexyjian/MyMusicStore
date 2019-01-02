using DBAUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("你点了一下我！");

            //添加一条读者记录
            var userid = txtUserID.Text.Trim();
            var username = txtUserName.Text.Trim();
            var pwd = txtPwd.Text;
            bool sex = true;
            if (rbRemale.Checked)
                sex = false;
            var email = txtEmail.Text.Trim();
            var classname = txtClassName.Text.Trim();
            //调用公共方法，添加一条读者
            var user = new User();
            var result = user.AddUser(userid,username,pwd,Convert.ToInt32(sex),email,classname);
            if (result)
                MessageBox.Show(userid + "," + username+" 添加成功.");
            else
                MessageBox.Show("添加失败!");
        }
    }
}
