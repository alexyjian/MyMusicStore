using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXCMIS.CommonForm
{
    public partial class BaseInfoForm : Form
    {
        //记录用户当前点击的操作
        public EnumOperation op;
    
        public BaseInfoForm()
        {
            InitializeComponent();
            op = EnumOperation.None;  //缺省为none，啥也没做
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            op = EnumOperation.Insert;
            btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = false;  //增改删按钮禁用，不能重复点两只
            gbInfo.Visible = true;   //下方区域显示
            gbInfo.Text = "新增数据";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            op = EnumOperation.Update;
            btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = false;  //增改删按钮禁用，不能重复点两只
            gbInfo.Visible = true;   //下方区域显示
            gbInfo.Text = "修改数据";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            op = EnumOperation.Delete;
            btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = false;  //增改删按钮禁用，不能重复点两只
            gbInfo.Visible = true;   //下方区域显示
            gbInfo.Text = "删除数据";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            op = EnumOperation.None;
            btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = true;
            gbInfo.Visible = false;
            gbInfo.Text = "操作";
        }
    }
}
