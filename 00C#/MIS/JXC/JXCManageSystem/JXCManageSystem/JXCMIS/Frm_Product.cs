using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;
using Enity;
using System.Linq;
using CommonUtility;

namespace JXCMIS
{
    public partial class Frm_Product : JXCMIS.CommonForm.BaseInfoForm
    {
        private ProductBLL _productBLL;  //数据访问的对象
        private List<Product> _list;            //临时保存的数据集合
        private Product _productObj;        //临时保存的单个数据

        public Frm_Product()
        {
            InitializeComponent();
            //对象初始化
            _productBLL = new ProductBLL();
            //数据显示
            QueryData();

            //下拉菜单的绑定
            cbCategory.DataSource = new CategoryBLL().GetAll();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";
        }

        //查询数据，并在DGV上显示
        private void QueryData()
        {
            _list = _productBLL.GetAll();
            dgvProduct.DataSource = _list;
            dgvProduct.Columns["CategoryID"].Visible = false;
        }

        private void txtProductName_KeyUp(object sender, KeyEventArgs e)
        {
            txtSpellCode.Text = PinyinLib.HZToSpell(txtProductName.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CleanControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        public void CleanControl()
        {
            foreach (Control c in gbInfo.Controls)
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                    c.Enabled = true;
                }
            cbCategory.SelectedIndex = 0;
            numPurchasePrice.Value = 0.00M;
            numQuantity.Value = 0M;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarCode.Text))
            {
                try
                {
                    pbBarcode.Image = BarQrCodeLib.GetBarCode(txtBarCode.Text.Trim());
                }
                catch { }
            }
        }
    }
}
