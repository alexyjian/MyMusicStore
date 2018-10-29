namespace JXCMIS
{
    partial class Frm_Purchase_Exam
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
            this.btnExam = new System.Windows.Forms.Button();
            this.btnCancelExam = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExam
            // 
            this.btnExam.Location = new System.Drawing.Point(12, 344);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(75, 23);
            this.btnExam.TabIndex = 4;
            this.btnExam.Text = "审核通过";
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.btnExam_Click);
            // 
            // btnCancelExam
            // 
            this.btnCancelExam.Location = new System.Drawing.Point(117, 344);
            this.btnCancelExam.Name = "btnCancelExam";
            this.btnCancelExam.Size = new System.Drawing.Size(75, 23);
            this.btnCancelExam.TabIndex = 4;
            this.btnCancelExam.Text = "取消通过";
            this.btnCancelExam.UseVisualStyleBackColor = true;
            this.btnCancelExam.Click += new System.EventHandler(this.btnCancelExam_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(673, 344);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(75, 23);
            this.btnRecover.TabIndex = 4;
            this.btnRecover.Text = "恢复申请";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(562, 344);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "撤销申请";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Frm_Purchase_Exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(760, 653);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.btnCancelExam);
            this.Controls.Add(this.btnExam);
            this.Name = "Frm_Purchase_Exam";
            this.Text = "主管审核入库申请";
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.lbxSerialnumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtTotalPrice, 0);
            this.Controls.SetChildIndex(this.btnExam, 0);
            this.Controls.SetChildIndex(this.btnCancelExam, 0);
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

        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Button btnCancelExam;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.Button btnDelete;
    }
}
