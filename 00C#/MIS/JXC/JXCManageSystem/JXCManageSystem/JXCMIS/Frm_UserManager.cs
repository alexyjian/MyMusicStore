using BusinessLogicLayer;
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
    public partial class Frm_UserManager : Form
    {
        private EmployeeBLL _employeeBLL;
        private Employee _employee;

        CheckBox[] c1 = new CheckBox[4];
        CheckBox[] c2 = new CheckBox[3];
        CheckBox[] c3 = new CheckBox[2];

        public Frm_UserManager()
        {
            InitializeComponent();

            _employeeBLL = new EmployeeBLL();

            //将复选框赋值给数据元素，用于权限值显示
            c1[0] = cbxCategory;
            c1[1] = cbxProduct;
            c1[2] = cbxSupplier;
            c1[3] = cbxEmployee;

            c2[0] = cbxFill;
            c2[1] = cbxExam;
            c2[2] = cbxStock;

            c3[0] = cbxChangePwd;
            c3[1] = cbxUserManager;

            //在列表中显示所有的员工工号
            var cardNos = _employeeBLL.GetAll().Select(x=>x.CardNo).ToList();
            cardNos.Sort();
            lbxEmployee.DataSource = cardNos;
            lbxEmployee.SelectedIndex = -1;
        }

        private void lbxEmployee_Click(object sender, EventArgs e)
        {
            var cardno = lbxEmployee.SelectedItem.ToString();
            _employee = _employeeBLL.GetByCardNo(cardno);
            //显示员工基本信息
            txtName.Text = _employee.EmployeeName;
            txtSex.Text = _employee.Sex ? "男" : "女";
            txtPhone.Text = _employee.Phone;

            //第一组复选框
            Recover1();
            Recover2();
            Recover3();
        }

        private void Recover(int function, CheckBox[] t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if ((function & (int)Math.Pow(2, i)) != 0)
                    //对应的位上的运算得1，启用此菜单项
                    t[i].Checked = true;
                else
                    t[i].Checked = false;
            }
        }

        private void Recover1()
        {
            int baseFunction = _employee.BaseFunction;
            Recover(baseFunction, c1);
        }

        private void Recover2()
        {
            int purchaseFunction = _employee.PurchaseFunction;
            Recover(purchaseFunction, c2);
        }

        private void Recover3()
        {
            int employeeFunction = _employee.EmployeeFunction;
            Recover(employeeFunction, c3);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int result1 = ComputeAuthority(c1);
            int result2 = ComputeAuthority(c2);
            int result3 = ComputeAuthority(c3);

            if (_employee == null)
            {
                MessageBox.Show("请先选择一各员工！");
                return;
            }
            else
            {
                //保存到数据库
                _employee.BaseFunction = result1;
                _employee.PurchaseFunction = result2;
                _employee.EmployeeFunction = result3;
                if(_employeeBLL.Edit(_employee))
                {
                    MessageBox.Show("权限修改成功！");
                }
                else
                {
                    MessageBox.Show("权限修改失败，请重试！");
                }
            }
        }

        private int ComputeAuthority(CheckBox [] c)
        {
            int sum = 0;
            for(int i=0;i<c.Length;i++)
            {
                if (c[i].Checked)
                    sum +=(int)Math.Pow(2, i);
            }
            return sum;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < c1.Length; i++)
                c1[i].Checked = true;
            for (int i = 0; i < c2.Length; i++)
                c2[i].Checked = true;
            for (int i = 0; i < c3.Length; i++)
                c3[i].Checked = true;
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < c1.Length; i++)
                c1[i].Checked = false;
            for (int i = 0; i < c2.Length; i++)
                c2[i].Checked = false;
            for (int i = 0; i < c3.Length; i++)
                c3[i].Checked = false;
        }

        private void btnRecoverAll_Click(object sender, EventArgs e)
        {
            if(_employee==null)
            {
                MessageBox.Show("请先选择一各员工！");
                return;
            }

            Recover1();
            Recover2();
            Recover3();
        }

        private void btnSelect1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < c1.Length; i++)
                c1[i].Checked = true;
        }

        private void btnClean1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < c1.Length; i++)
                c1[i].Checked = false;
        }

        private void btnRecover1_Click(object sender, EventArgs e)
        {
            if (_employee == null)
            {
                MessageBox.Show("请先选择一各员工！");
                return;
            }

            Recover1();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
