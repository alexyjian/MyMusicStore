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
    public partial class Frm_Main : Form
    {
        private string _cardNo;
        private Employee _loginEmployee;
        private EmployeeBLL _emoloyeeBLL;

        //定义三组子菜单项
        private ToolStripMenuItem[] _t1 = new ToolStripMenuItem[4];
        private ToolStripMenuItem[] _t2 = new ToolStripMenuItem[3];
        private ToolStripMenuItem[] _t3 = new ToolStripMenuItem[2];
        
        public Frm_Main()
        {
            InitializeComponent();

            _emoloyeeBLL = new EmployeeBLL();

            //禁用所有子菜单项
            ((ToolStripMenuItem)menuStrip1.Items[0]).DropDownItems.CopyTo(_t1, 0);
            ((ToolStripMenuItem)menuStrip1.Items[1]).DropDownItems.CopyTo(_t2, 0);
            ((ToolStripMenuItem)menuStrip1.Items[2]).DropDownItems.CopyTo(_t3, 0);

            ////三组主菜单禁用
            //for (int i = 0; i < 3; i++)
            //    ((ToolStripMenuItem)menuStrip1.Items[i]).Enabled = false;

            //只禁用子菜单？
            for (int i = 0; i < _t1.Length; i++)
                _t1[i].Enabled = false;

            for (int i = 0; i < _t2.Length; i++)
                _t2[i].Enabled = false;

            for (int i = 0; i < _t3.Length; i++)
                _t3[i].Enabled = false;
        }

        #region 菜单项
        private T ShowChildForm<T>() where T:Form,new ()  //泛型方法，并规定此方法只能是窗体，并且自动创建出对像来调用
        {
            foreach (var f in this.MdiChildren)
                if (f is T)
                {
                    f.Activate();   //激活此子窗体
                    return f as T;   //检测结束，跳出
                }
            var form = new T();
            form.MdiParent = this;  //认爸爸
            form.Show();   //打开窗体
            return form;
        }
        private void 产品分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm<Frm_Category>();
        }
        private void 产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm<Frm_Product>();
        }
        private void 供应商信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm<Frm_Supplier>();
        }
        private void 员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm<Frm_Employee>();
        }
        
        private void 填写进货申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = ShowChildForm<Frm_Purchase_Fill>();
            frm.CardNo = _cardNo;
            frm.Employee = _loginEmployee;
        }
        
        private void 审核进货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = ShowChildForm<Frm_Purchase_Exam>();
            frm.CardNo = _cardNo;
            frm.Employee = _loginEmployee;
        }

        private void 产品入库检验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = ShowChildForm<Frm_Purchase_Stock>();
            frm.CardNo = _cardNo;
            frm.Employee = _loginEmployee;
        }


        private void 用户权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChildForm<Frm_UserManager>();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = ShowChildForm<Frm_ChangePwd>();
            frm.CardNo = _cardNo;
            frm.Employee = _loginEmployee;
        }

        #endregion

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            loginControl1.Visible = true;
            welComeControl1.Visible = false;
        }

        private void loginControl1_VisibleChanged(object sender, EventArgs e)
        {
            welComeControl1.CardNo = loginControl1.CardNo;  //读取登录成功的卡号
            welComeControl1.Visible = !loginControl1.Visible;

            //读权限值，显示对应的菜单
            if(!loginControl1.Visible)
            {
                //登录成功后的处理
                _cardNo = loginControl1.CardNo;
                _loginEmployee = _emoloyeeBLL.GetByCardNo(loginControl1.CardNo);
                
                //读取对应的权限值设置菜单的访问许可
                MapMenuItems(_loginEmployee.BaseFunction, _t1);
                MapMenuItems(_loginEmployee.PurchaseFunction, _t2);
                MapMenuItems(_loginEmployee.EmployeeFunction, _t3);
            }
        }

        //将权限值映射到菜单项的处理
        //利用位按位与运算进行菜单设置& 
        private void MapMenuItems(int function,ToolStripMenuItem[] t)
        {
            for(int i=0;i<t.Length;i++)
            {
                if ((function & (int)Math.Pow(2, i)) != 0)
                    //对应的位上的运算得1，启用此菜单项
                    t[i].Enabled = true;
                else
                    t[i].Enabled = false;
            }
        }

        private void welComeControl1_VisibleChanged(object sender, EventArgs e)
        {
            loginControl1.Visible = !welComeControl1.Visible;

            //打开的子窗体全部关上
            foreach (var frm in this.MdiChildren)
                frm.Close();

            //所有的子菜单禁用
            for (int i = 0; i < _t1.Length; i++)
                _t1[i].Enabled = false;
            for (int i = 0; i < _t2.Length; i++)
                _t2[i].Enabled = false;
            for (int i = 0; i < _t3.Length; i++)
                _t3[i].Enabled = false;
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var helpPath = Application.StartupPath+"\\help.chm";
            Help.ShowHelp(this, helpPath);
        }

        //快捷键F1 打开帮助
        private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F1)
            {
                var helpPath = Application.StartupPath + "\\help.chm";
                Help.ShowHelp(this, helpPath);
            }
        }
    }
}
