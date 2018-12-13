namespace JXCMIS.CommonForm
{
    partial class BasePurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxSerialnumber = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtBeginDate = new System.Windows.Forms.DateTimePicker();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSearchCondition = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOnProcess = new System.Windows.Forms.TextBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.txtCustodian = new System.Windows.Forms.TextBox();
            this.txtExaminer = new System.Windows.Forms.TextBox();
            this.txtStockDate = new System.Windows.Forms.TextBox();
            this.txtExaminerDate = new System.Windows.Forms.TextBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtPurchaseDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxSerialnumber
            // 
            this.lbxSerialnumber.FormattingEnabled = true;
            this.lbxSerialnumber.ItemHeight = 12;
            this.lbxSerialnumber.Location = new System.Drawing.Point(12, 34);
            this.lbxSerialnumber.Name = "lbxSerialnumber";
            this.lbxSerialnumber.Size = new System.Drawing.Size(180, 292);
            this.lbxSerialnumber.TabIndex = 0;
            this.lbxSerialnumber.Click += new System.EventHandler(this.lbxSerialnumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "进货单列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.dtBeginDate);
            this.groupBox1.Controls.Add(this.txtKeyWord);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbSearchCondition);
            this.groupBox1.Location = new System.Drawing.Point(209, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 105);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ForeColor = System.Drawing.Color.Red;
            this.btnSearch.Location = new System.Drawing.Point(445, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(272, 61);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(146, 21);
            this.dtEndDate.TabIndex = 3;
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.Location = new System.Drawing.Point(66, 61);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.Size = new System.Drawing.Size(141, 21);
            this.dtBeginDate.TabIndex = 3;
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(336, 18);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(184, 21);
            this.txtKeyWord.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "关键字";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "结束时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "查询条件";
            // 
            // cbSearchCondition
            // 
            this.cbSearchCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchCondition.FormattingEnabled = true;
            this.cbSearchCondition.Items.AddRange(new object[] {
            "按入库申请的流水号查询",
            "按业务员卡号查询",
            "按主管卡号查询",
            "按入库申请的状态查询"});
            this.cbSearchCondition.Location = new System.Drawing.Point(66, 19);
            this.cbSearchCondition.Name = "cbSearchCondition";
            this.cbSearchCondition.Size = new System.Drawing.Size(186, 20);
            this.cbSearchCondition.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOnProcess);
            this.groupBox2.Controls.Add(this.cbSupplier);
            this.groupBox2.Controls.Add(this.txtCustodian);
            this.groupBox2.Controls.Add(this.txtExaminer);
            this.groupBox2.Controls.Add(this.txtStockDate);
            this.groupBox2.Controls.Add(this.txtExaminerDate);
            this.groupBox2.Controls.Add(this.txtMemo);
            this.groupBox2.Controls.Add(this.txtSerialNumber);
            this.groupBox2.Controls.Add(this.txtPurchaseDate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(209, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 203);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入库单信息";
            // 
            // txtOnProcess
            // 
            this.txtOnProcess.Location = new System.Drawing.Point(66, 164);
            this.txtOnProcess.Name = "txtOnProcess";
            this.txtOnProcess.ReadOnly = true;
            this.txtOnProcess.Size = new System.Drawing.Size(186, 21);
            this.txtOnProcess.TabIndex = 3;
            // 
            // cbSupplier
            // 
            this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(66, 59);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(186, 20);
            this.cbSupplier.TabIndex = 2;
            // 
            // txtCustodian
            // 
            this.txtCustodian.Location = new System.Drawing.Point(336, 128);
            this.txtCustodian.Name = "txtCustodian";
            this.txtCustodian.ReadOnly = true;
            this.txtCustodian.Size = new System.Drawing.Size(184, 21);
            this.txtCustodian.TabIndex = 1;
            // 
            // txtExaminer
            // 
            this.txtExaminer.Location = new System.Drawing.Point(336, 96);
            this.txtExaminer.Name = "txtExaminer";
            this.txtExaminer.ReadOnly = true;
            this.txtExaminer.Size = new System.Drawing.Size(184, 21);
            this.txtExaminer.TabIndex = 1;
            // 
            // txtStockDate
            // 
            this.txtStockDate.Location = new System.Drawing.Point(66, 128);
            this.txtStockDate.Name = "txtStockDate";
            this.txtStockDate.ReadOnly = true;
            this.txtStockDate.Size = new System.Drawing.Size(186, 21);
            this.txtStockDate.TabIndex = 1;
            // 
            // txtExaminerDate
            // 
            this.txtExaminerDate.Location = new System.Drawing.Point(66, 96);
            this.txtExaminerDate.Name = "txtExaminerDate";
            this.txtExaminerDate.ReadOnly = true;
            this.txtExaminerDate.Size = new System.Drawing.Size(186, 21);
            this.txtExaminerDate.TabIndex = 1;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(336, 59);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(184, 21);
            this.txtMemo.TabIndex = 1;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(336, 23);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(184, 21);
            this.txtSerialNumber.TabIndex = 1;
            // 
            // txtPurchaseDate
            // 
            this.txtPurchaseDate.Location = new System.Drawing.Point(66, 23);
            this.txtPurchaseDate.Name = "txtPurchaseDate";
            this.txtPurchaseDate.ReadOnly = true;
            this.txtPurchaseDate.Size = new System.Drawing.Size(186, 21);
            this.txtPurchaseDate.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(277, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "检验人";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "订单编号";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(277, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "审核人";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "状态";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "入库时间";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "审核时间";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "备注";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "供应商";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "订单日期";
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(12, 413);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 23;
            this.dgvDetails.Size = new System.Drawing.Size(736, 197);
            this.dgvDetails.TabIndex = 3;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetails_DataBindingComplete);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(12, 390);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "进货单明细表";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(519, 392);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 14);
            this.label16.TabIndex = 0;
            this.label16.Text = "总价";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(562, 389);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(186, 21);
            this.txtTotalPrice.TabIndex = 3;
            // 
            // BasePurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 653);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxSerialnumber);
            this.Controls.Add(this.label16);
            this.Name = "BasePurchaseForm";
            this.Text = "BasePurchaseFrom";
            this.Load += new System.EventHandler(this.BasePurchaseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ListBox lbxSerialnumber;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button btnSearch;
        protected System.Windows.Forms.DateTimePicker dtEndDate;
        protected System.Windows.Forms.DateTimePicker dtBeginDate;
        protected System.Windows.Forms.TextBox txtKeyWord;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox cbSearchCondition;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.ComboBox cbSupplier;
        protected System.Windows.Forms.TextBox txtCustodian;
        protected System.Windows.Forms.TextBox txtExaminer;
        protected System.Windows.Forms.TextBox txtStockDate;
        protected System.Windows.Forms.TextBox txtExaminerDate;
        protected System.Windows.Forms.TextBox txtMemo;
        protected System.Windows.Forms.TextBox txtSerialNumber;
        protected System.Windows.Forms.TextBox txtPurchaseDate;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label14;
        protected System.Windows.Forms.TextBox txtOnProcess;
        protected System.Windows.Forms.DataGridView dgvDetails;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.TextBox txtTotalPrice;
    }
}