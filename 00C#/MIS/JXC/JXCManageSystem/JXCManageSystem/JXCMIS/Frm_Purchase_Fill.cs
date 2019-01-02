using BusinessLogicLayer;
using Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JXCMIS
{
    public partial class Frm_Purchase_Fill : JXCMIS.CommonForm.BasePurchaseForm
    {
        private EnumOperation _op;
        private PurchaseBLL  _purchaseBLL;
        public static PurchaseDetail purchaseDetail_Add; //临时保存添加的明细

        public string CardNo { get; set; }  //员工的卡号
        public Employee Employee { get; set; }  //登录的员工信息

        public Frm_Purchase_Fill()
        {
            InitializeComponent();

            _purchaseBLL = new PurchaseBLL();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _op = EnumOperation.Insert;
            btnSave.Enabled = btnCancel.Enabled = btnDelDetail.Enabled = btnAddDetail.Enabled = cbSupplier.Enabled = txtMemo.Enabled = true;
            btnEdit.Enabled = btnDelete.Enabled = false;
        }

        private void lbxSerialnumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lbxSerialnumber.SelectedItem.ToString()))
                {
                    btnAdd.Enabled =  false;
                    btnEdit.Enabled =btnDelete.Enabled = btnSave.Enabled = btnCancel.Enabled = btnDelDetail.Enabled = btnAddDetail.Enabled = cbSupplier.Enabled = txtMemo.Enabled = true;
                    _op = EnumOperation.Update;
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Restore();
        }

        private void Restore()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = btnDelete.Enabled = btnSave.Enabled = btnCancel.Enabled
                = btnDelDetail.Enabled = btnAddDetail.Enabled = cbSupplier.Enabled = txtMemo.Enabled = false;
            //cbSupplier.SelectedIndex = 0;
            lbxSerialnumber.DataSource = null;
            purchase = null;
            purchaseDetails = null;
            selected_PurchaseDetail = null;

            //清理所有文本框
            foreach (var c in groupBox2.Controls)
                if (c is TextBox)
                    ((TextBox)c).Text = string.Empty;

            dgvDetails.DataSource = null;
            _op = EnumOperation.None;
            purchase = new Purchase();
            purchaseDetails = new List<PurchaseDetail>();
            selected_PurchaseDetail = new PurchaseDetail();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(_op)
            {
                case EnumOperation.Insert:
                    purchase = new Purchase();
                    purchase.Clerk = CardNo;
                    purchase.Memo = txtMemo.Text.Trim();
                    purchase.SupplierID =Convert.ToInt32(cbSupplier.SelectedValue);
                    var result = _purchaseBLL.Add(purchase);
                    if(result!=null)
                    {
                        //明细保存
                        if(purchaseDetails.Count>0)
                            foreach (var d in purchaseDetails)
                            {
                                d.Serialnumber = result.Serialnumber;
                                d.PurchaseID = result.PurchaseID;
                                purchaseBLL.AddDetail(d);
                            }

                        MessageBox.Show("入库申请提交成功！");

                        //显示该入库申请
                        //将当前的流水号添加到列表框中
                        lbxSerialnumber.Items.Add(purchase.Serialnumber);
                        //相关的入库信息显示到控件
                        txtPurchaseDate.Text = purchase.PurchaseDate.ToString("yyyy年MM月dd日 hh:mm:ss");
                        txtSerialNumber.Text = purchase.Serialnumber;
                        switch (purchase.OnProcess)
                        {
                            case -1:
                                txtOnProcess.Text = "撤销";
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
                    }
                    else
                    {
                        MessageBox.Show("入库申请提交失败！");
                        Restore();
                    }
                    break;

                case EnumOperation.Update:
                    //1.更新入库申请
                    purchase.Memo = txtMemo.Text.Trim();
                    purchase.SupplierID =Convert.ToInt32(cbSupplier.SelectedValue);
                    if (purchaseBLL.Edit(purchase))
                    {
                        //2.删除旧的明细
                        purchaseBLL.DeleteDetails(purchase.PurchaseID);
                        //3.重新添加新的明细
                        //明细保存
                        if (purchaseDetails.Count > 0)
                            foreach (var d in purchaseDetails)
                            {
                                d.Serialnumber = purchase.Serialnumber;
                                d.PurchaseID = purchase.PurchaseID;
                                purchaseBLL.AddDetail(d);
                            }

                        MessageBox.Show("入库申请修改成功！");
                        //相关的入库信息显示到控件
                        purchase = purchaseBLL.GetPurchaseBySerialNumber(purchase.Serialnumber);
                        txtPurchaseDate.Text = purchase.PurchaseDate.ToString("yyyy年MM月dd日 hh:mm:ss");
                    }
                    else
                    {
                        MessageBox.Show("入库申请提交失败！");
                        Restore();
                    }
                    break;

                case EnumOperation.Delete:
                    //业务员只能取消自己提交的申请
                    if(CardNo.ToLower()!=purchase.Clerk.ToLower())
                    {
                        MessageBox.Show("业务员只能取消自己提交的申请！");
                        return;
                    }
                    //取消申请 OnProcess=-1
                    purchase.OnProcess = -1;
                    purchase.PurchaseDate = DateTime.Now;
                    if(purchaseBLL.EditExamandStock(purchase))
                    {
                        MessageBox.Show("撤销成功！");
                        txtPurchaseDate.Text = purchase.PurchaseDate.ToString("yyyy年MM月dd日 hh:mm:ss");
                        switch (purchase.OnProcess)
                        {
                            case -1:
                                txtOnProcess.Text = "撤销";
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
                    }
                    else
                    {
                        MessageBox.Show("撤销失败！");
                        Restore();
                    }
                    break;

                case EnumOperation.None:                    
                default: break;
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var frm = new Frm_AddPurchaseDetail();
            frm.ShowDialog();

            if(purchaseDetail_Add!=null)
            {
                //判断商品在明细列表中是否有重复
                foreach(var d in purchaseDetails)
                    if(d.ProductID==purchaseDetail_Add.ProductID)
                    {
                        MessageBox.Show("该商品已存在！");
                        return;
                    }

                purchaseDetail_Add.SortCode = purchaseDetails.Count + 1;
                purchaseDetails.Add(purchaseDetail_Add);

                dgvDetails.DataSource = null;
                dgvDetails.DataSource = purchaseDetails;
                BindDetailsData();
            }
        }

        //商品明细绑定到DataGridView
        private void BindDetailsData()
        {
            //显示对应的商品明细
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

        //明细的删除
        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            if(selected_PurchaseDetail==null)
            {
                MessageBox.Show("请选择要删除的商品明细！");
                return;
            }

            DialogResult result = MessageBox.Show("确定要删除这条商品明细吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result==DialogResult.Yes)
            {
                purchaseDetails.Remove(selected_PurchaseDetail);
                var count = 1;
                foreach(var item in purchaseDetails)
                {
                    item.SortCode = count++;
                }
                //刷新明细中的数据
                dgvDetails.DataSource = null;
                dgvDetails.DataSource = purchaseDetails;
                BindDetailsData();
                selected_PurchaseDetail = null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //用户必须选定一条流水
            if(purchase ==null)
            {
                MessageBox.Show("请先选择要编辑的一条入库申请！");
                return;
            }

            //入库申请的状态为正在申0，才能编辑
            if(purchase.OnProcess!=0)
            {
                MessageBox.Show("此申请为已审核、已完成或已撤销状态时不能编辑！");
                return;
            }

            //编辑准备工作
            _op = EnumOperation.Update;
            btnSave.Enabled = btnCancel.Enabled = btnDelete.Enabled =btnDelDetail.Enabled = btnAddDetail.Enabled = cbSupplier.Enabled = txtMemo.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //用户必须选定一条流水
            if (purchase == null)
            {
                MessageBox.Show("请先选择要编辑的一条入库申请！");
                return;
            }

            //入库申请的状态为正在申0，才能编辑
            if (purchase.OnProcess != 0)
            {
                MessageBox.Show("此申请为已审核、已完成或已撤销状态时不能编辑！");
                return;
            }

            _op = EnumOperation.Delete;
            btnSave.Enabled = btnCancel.Enabled = btnEdit.Enabled = true;
            btnDelDetail.Enabled = btnAddDetail.Enabled = cbSupplier.Enabled =  txtMemo.Enabled = btnAdd.Enabled = false;
        }
    }
}
