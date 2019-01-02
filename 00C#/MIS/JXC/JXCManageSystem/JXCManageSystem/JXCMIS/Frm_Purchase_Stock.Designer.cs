namespace JXCMIS
{
    partial class Frm_Purchase_Stock
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStock = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(12, 346);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(180, 23);
            this.btnStock.TabIndex = 4;
            this.btnStock.Text = "商品入库检验";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(673, 346);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(75, 23);
            this.btnRecover.TabIndex = 5;
            this.btnRecover.Text = "恢复申请";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(592, 346);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "撤销入库";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Frm_Purchase_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(760, 653);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.btnStock);
            this.Name = "Frm_Purchase_Stock";
            this.Text = "入库检查";
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.lbxSerialnumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtTotalPrice, 0);
            this.Controls.SetChildIndex(this.btnStock, 0);
            this.Controls.SetChildIndex(this.btnRecover, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.Button btnDelete;
    }
}
