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

namespace JXCMIS.CommonForm
{
    public partial class BasePurchaseForm : Form
    {
        protected List<string> SNs = new List<string> ();
        protected SupplierBLL supplierBLL;
        protected PurchaseBLL purchaseBLL;
        protected Purchase purchase;
        protected List<PurchaseDetail> purchaseDetails;
        protected PurchaseDetail selected_PurchaseDetail;

        public BasePurchaseForm()
        {
            InitializeComponent();
            supplierBLL = new SupplierBLL();
            purchaseBLL = new PurchaseBLL();
            purchaseDetails = new List<PurchaseDetail>();
            purchase = new Purchase();
            selected_PurchaseDetail = new PurchaseDetail();

            dtBeginDate.Value = DateTime.Now;
            dtEndDate.Value = DateTime.Now.AddDays(1);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword =txtKeyWord.Text.Trim();
            DateTime beginDate = dtBeginDate.Value;
            //结束时间不能小于开始时间
            DateTime endDate = dtEndDate.Value < dtBeginDate.Value ? dtBeginDate.Value.AddDays(1) : dtEndDate.Value;  

            switch(cbSearchCondition.SelectedIndex)
            {
                case 0:
                    //MessageBox.Show("按入库申请的流水号查询" + "查询的关键字" + keyword + " 起止时间为" + beginDate + "-" + endDate);
                    SNs = purchaseBLL.GetSerialnumbers(keyword, beginDate, endDate);
                    break;

                case 1:
                    SNs = purchaseBLL.GetSerialnumbersByClerk(keyword, beginDate, endDate);
                    break;

                case 2:
                    SNs = purchaseBLL.GetSerialnumbersByExaminer(keyword, beginDate, endDate);
                    break;

                case 3:
                    int process = 0;
                    try
                    {
                        process = int.Parse(keyword);   //保证keyword是整数
                    }
                    catch { }
                    SNs = purchaseBLL.GetSerialnumbersByProcess(process, beginDate, endDate);
                    break;

                default:
                    MessageBox.Show("请选择一项查询条件");
                    break;
            }

            if (SNs.Count != 0)
                lbxSerialnumber.DataSource = SNs;
            else
            {
                MessageBox.Show("未找到对应的流水号");
                lbxSerialnumber.DataSource = null;
            }
        }

        //单击一条流水号，查询出相应数据在右区显示 
        private void lbxSerialnumber_Click(object sender, EventArgs e)
        {
            try
            {
                //1.取出流水号
                string sn = lbxSerialnumber.SelectedItem.ToString();
                
                //2.查询出相应入库申请
                purchase = purchaseBLL.GetPurchaseBySerialNumber(sn);

                //3.显示到控件
                txtPurchaseDate.Text = purchase.PurchaseDate.ToString("yyyy年MM月dd日 hh:mm:ss");
                txtSerialNumber.Text = purchase.Serialnumber;
                cbSupplier.SelectedValue = purchase.SupplierID;
                txtMemo.Text = purchase.Memo;
                //显示合理的时间 
                if (purchase.ExaminerDate.Year != 1)
                    txtExaminerDate.Text = purchase.ExaminerDate.ToString("yyyy年MM月dd日 hh:mm:ss");
                else
                    txtExaminerDate.Text = string.Empty;
                
                txtExaminer.Text = purchase.Examiner;

                if (purchase.StockDate.Year != 1)
                    txtStockDate.Text = purchase.StockDate.ToString("yyyy年MM月dd日 hh:mm:ss");
                else
                    txtStockDate.Text = string.Empty;

                txtCustodian.Text = purchase.Custodian;
                //显示中文的提示
                switch(purchase.OnProcess)
                {
                    case -1:
                        txtOnProcess.Text ="撤销";
                        break;

                    case 0:
                        txtOnProcess.Text = "正在申请";
                        break;

                    case 1:
                        txtOnProcess.Text = "正在进货";
                        break;

                    case 2:
                        txtOnProcess.Text = "入库成功";
                        break;
                }

                
                //显示对应的商品明细
                purchaseDetails = purchaseBLL.GetPurchaseDetails(sn);
                dgvDetails.DataSource = purchaseDetails;
                dgvDetails.AutoGenerateColumns = false;

                dgvDetails.Columns[0].DataPropertyName = "Serialnumber";
                dgvDetails.Columns[0].HeaderText = "流水号";
                dgvDetails.Columns[0].Width = 120;

                dgvDetails.Columns[1].DataPropertyName = "SortCode";
                dgvDetails.Columns[1].HeaderText = "明细号";
                dgvDetails.Columns[1].Width = 100;

                dgvDetails.Columns[2].DataPropertyName = "ProductName";
                dgvDetails.Columns[2].HeaderText = "商品名称";
                dgvDetails.Columns[2].Width = 120;

                dgvDetails.Columns[3].DataPropertyName = "BarCode";
                dgvDetails.Columns[3].HeaderText = "条码";
                dgvDetails.Columns[3].Width = 120;

                dgvDetails.Columns[4].DataPropertyName = "Price";
                dgvDetails.Columns[4].HeaderText = "价格";
                dgvDetails.Columns[4].Width = 120;

                dgvDetails.Columns[5].DataPropertyName = "Quantity";
                dgvDetails.Columns[5].HeaderText = "数量";
                dgvDetails.Columns[5].Width = 120;

                dgvDetails.Columns[6].Visible = false;
                dgvDetails.Columns[7].Visible = false;
                dgvDetails.Columns[8].Visible = false;
            }
            catch { }
        }

        //当数据绑定时，计算明细的总价
        private void dgvDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var total = 0.00M;
            foreach(var d in purchaseDetails)
            {
                total += d.Price * d.Quantity;
            }
            txtTotalPrice.Text ="￥"+ total.ToString("0.00");
        }

        //用户选择一条明细，保存的全局变量中，用于子窗体的删除操作
        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDetails.CurrentRow.Selected = true;
                selected_PurchaseDetail = purchaseDetails[e.RowIndex];  //保存当前选择的明细记录
            }
            catch { }
        }

        private void BasePurchaseForm_Load(object sender, EventArgs e)
        {
            cbSupplier.DataSource = supplierBLL.GetAll();
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
        }
    }
}
