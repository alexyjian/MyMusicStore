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
    public partial class Frm_Purchase_Exam : JXCMIS.CommonForm.BasePurchaseForm
    {
        public string CardNo { get; set; }
        public Employee Employee { get; set; }

        public Frm_Purchase_Exam()
        {
            InitializeComponent();
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            if(purchase!=null)
            {
                switch(purchase.OnProcess)
                {
                    case 0:
                        purchase.Examiner = CardNo;
                        purchase.ExaminerDate = DateTime.Now;
                        purchase.OnProcess = 1;
                        purchase.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);   //供应商也可以改
                        purchase.Memo = txtMemo.Text.Trim();
                        if(purchaseBLL.EditExamandStock(purchase))
                        {
                            MessageBox.Show("审核成功！");
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

                        break;

                    case 1:  
                        MessageBox.Show("该申请已经审核，不能重复操作！");
                        return;

                    case 2:
                        MessageBox.Show("该申请已经入库成功，无法操作！");
                        return;

                        case -1:
                        MessageBox.Show("该申请已经撤销，请先恢复！");
                        return;
                }
            }
            else
            {
                MessageBox.Show("请先选定要处理的入库申请");
                return;
            }
        }

        // Onprocess 1-> 0
        private void btnCancelExam_Click(object sender, EventArgs e)
        {
            if (purchase != null)
            {
                switch (purchase.OnProcess)
                {
                    case 0:
                       MessageBox.Show("正在申请的入库，不能取消审核！");
                       return;

                    case 1:                         
                        purchase.ExaminerDate = DateTime.Now;
                        purchase.OnProcess = 0;
                        purchase.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);   //供应商也可以改
                        purchase.Memo = txtMemo.Text.Trim();
                        if (purchaseBLL.EditExamandStock(purchase))
                        {
                            MessageBox.Show("取消审核成功！");
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
                        break;
                    case 2:
                        MessageBox.Show("该申请已经入库成功，无法取消审核操作！");
                        return;

                    case -1:
                        MessageBox.Show("该申请已经撤销，无法取消审核操作！");
                        return;
                }
            }
            else
            {
                MessageBox.Show("请先选定要处理的入库申请");
                return;
            }
        }

        // Onprocess 0,1 > -1
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (purchase != null)
            {
                switch (purchase.OnProcess)
                {
                    case 0:
                    case 1:
                        purchase.ExaminerDate = DateTime.Now;
                        purchase.OnProcess = -1;
                        purchase.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);   //供应商也可以改
                        purchase.Memo = txtMemo.Text.Trim();
                        if (purchaseBLL.EditExamandStock(purchase))
                        {
                            MessageBox.Show("撤销成功！");
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
                        break;
                    case 2:
                        MessageBox.Show("该申请已经入库成功，无法撤销！");
                        return;

                    case -1:
                        MessageBox.Show("该申请已经撤销，不能重复操作！");
                        return;
                }
            }
            else
            {
                MessageBox.Show("请先选定要处理的入库申请");
                return;
            }
        }

        // Onprocess-1 -> 0
        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (purchase != null)
            {
                switch (purchase.OnProcess)
                {
                    case -1:
                        purchase.ExaminerDate = DateTime.Now;
                        purchase.OnProcess = 0;
                        purchase.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);   //供应商也可以改
                        purchase.Memo = txtMemo.Text.Trim();
                        if (purchaseBLL.EditExamandStock(purchase))
                        {
                            MessageBox.Show("恢复成功！");
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
                        break;
                    case 0:
                        MessageBox.Show("该入库正在申请中，不能恢复操作！");
                        return;
                    case 1:
                        MessageBox.Show("该入库已经审核，不能恢复操作！");
                        return;
                    case 2:
                        MessageBox.Show("该申请已经入库成功，无法撤销！");
                        return;
                }
            }
            else
            {
                MessageBox.Show("请先选定要处理的入库申请");
                return;
            }
        }
    }
}
