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
    public partial class Frm_Purchase_Stock : JXCMIS.CommonForm.BasePurchaseForm
    {
        public string CardNo { get; set; }
        public Employee Employee { get; set; }

        public Frm_Purchase_Stock()
        {
            InitializeComponent();

            cbSupplier.Enabled = false;
        }

        //按流水号检查商品明细  状态 1->2  供应商字段不能修改，可以写备注
        private void btnStock_Click(object sender, EventArgs e)
        {
            if(purchase!=null)
            {
                //入库申请的状态为撤销或完成的 不能进行入库检查
                if(purchase.OnProcess==-1||purchase.OnProcess==2)
                {
                    MessageBox.Show("入库申请的状态为撤销或完成的,不能进行入库检查!");
                    return;
                }
                else if(purchase.OnProcess==0)
                {
                    MessageBox.Show("入库申请的未审核的,不能进行入库检查!");
                    return;
                }
                else
                {
                    purchase.Custodian = CardNo;
                    purchase.StockDate = DateTime.Now;
                    purchase.OnProcess = 2;
                    purchase.Memo = txtMemo.Text;
                    if(purchaseBLL.EditExamandStock(purchase))
                    {
                        MessageBox.Show("入库成功!");
                        //显示结果
                        txtMemo.Text = purchase.Memo;
                        //显示合理的时间 
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
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要入库的申请。");
                return;
            }
        }

        //送货来过 有质量问题 1->-1 备注写明送货“质量不行”供应商字段不能修改，可以写备注
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        //送货再来过 质量问题已解决  -1->1  备注写明送货“质量过关”供应商字段不能修改，可以写备注
        private void btnRecover_Click(object sender, EventArgs e)
        {

        }
    }
}
