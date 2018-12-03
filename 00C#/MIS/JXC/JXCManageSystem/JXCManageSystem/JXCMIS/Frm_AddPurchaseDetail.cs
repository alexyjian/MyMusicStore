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
    public partial class Frm_AddPurchaseDetail : Form
    {
        public Frm_AddPurchaseDetail()
        {
            InitializeComponent();

            //商品下拉菜单
            cbProduct.DataSource = new ProductBLL().GetAll();
            cbProduct.DisplayMember = "ProductName";
            cbProduct.ValueMember = "ProductID";
            cbProduct.SelectedIndex = 0;

            //显示参考价格
            var product = new ProductBLL().GetByID(Convert.ToInt32(cbProduct.SelectedValue));
            nuPrice.Value = product.PurchasePrice;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //检测用户输入的正确性
            if (nuPrice.Value == 0 || nuQuantity.Value == 0)
            {
                lblMsg.Text = "请输入正确的价格和数量。";
            }
            else
            {
                lblMsg.Text = string.Empty;
                var detail = new PurchaseDetail();
                var p = new ProductBLL().GetByID(Convert.ToInt32(cbProduct.SelectedValue));
                detail.BarCode = p.BarCode;
                detail.Price = nuPrice.Value;
                detail.ProductID = Convert.ToInt32(cbProduct.SelectedValue);
                detail.ProductName = p.ProductName;
                detail.Quantity = Convert.ToInt32(nuQuantity.Value);
                Frm_Purchase_Fill.purchaseDetail_Add = detail;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Frm_Purchase_Fill.purchaseDetail_Add = null;
            this.Close();            
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //按用户选择的商品，显示价格
                var product = new ProductBLL().GetByID(Convert.ToInt32(cbProduct.SelectedValue));
                nuPrice.Value = product.PurchasePrice;
            }
            catch { }
        }
    }
}
