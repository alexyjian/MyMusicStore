namespace JXCMIS
{
    partial class Frm_Product
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
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpellCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Special = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Original = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpellCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpecial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOriginal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.numPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.pbBarcode = new System.Windows.Forms.PictureBox();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Tag = "13";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Tag = "14";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Tag = "2";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Tag = "3";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Tag = "4";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.pbBarcode);
            this.gbInfo.Controls.Add(this.numQuantity);
            this.gbInfo.Controls.Add(this.numPurchasePrice);
            this.gbInfo.Controls.Add(this.cbCategory);
            this.gbInfo.Controls.Add(this.label9);
            this.gbInfo.Controls.Add(this.txtOriginal);
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Controls.Add(this.txtBarCode);
            this.gbInfo.Controls.Add(this.txtUnit);
            this.gbInfo.Controls.Add(this.label8);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.txtSpellCode);
            this.gbInfo.Controls.Add(this.txtSpecial);
            this.gbInfo.Controls.Add(this.label7);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.txtProductName);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.SetChildIndex(this.btnCancel, 0);
            this.gbInfo.Controls.SetChildIndex(this.btnSave, 0);
            this.gbInfo.Controls.SetChildIndex(this.label1, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtProductName, 0);
            this.gbInfo.Controls.SetChildIndex(this.label4, 0);
            this.gbInfo.Controls.SetChildIndex(this.label2, 0);
            this.gbInfo.Controls.SetChildIndex(this.label7, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtSpecial, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtSpellCode, 0);
            this.gbInfo.Controls.SetChildIndex(this.label5, 0);
            this.gbInfo.Controls.SetChildIndex(this.label3, 0);
            this.gbInfo.Controls.SetChildIndex(this.label8, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtUnit, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtBarCode, 0);
            this.gbInfo.Controls.SetChildIndex(this.label6, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtOriginal, 0);
            this.gbInfo.Controls.SetChildIndex(this.label9, 0);
            this.gbInfo.Controls.SetChildIndex(this.cbCategory, 0);
            this.gbInfo.Controls.SetChildIndex(this.numPurchasePrice, 0);
            this.gbInfo.Controls.SetChildIndex(this.numQuantity, 0);
            this.gbInfo.Controls.SetChildIndex(this.pbBarcode, 0);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.SpellCode,
            this.BarCode,
            this.Special,
            this.Unit,
            this.Original,
            this.PurchasePrice,
            this.Quantity,
            this.CategoryName});
            this.dgvProduct.Location = new System.Drawing.Point(12, 12);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.Size = new System.Drawing.Size(736, 245);
            this.dgvProduct.TabIndex = 1;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "产品编号";
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "名称";
            this.ProductName.Name = "ProductName";
            // 
            // SpellCode
            // 
            this.SpellCode.DataPropertyName = "SpellCode";
            this.SpellCode.HeaderText = "拼音码";
            this.SpellCode.Name = "SpellCode";
            // 
            // BarCode
            // 
            this.BarCode.DataPropertyName = "BarCode";
            this.BarCode.HeaderText = "条码";
            this.BarCode.Name = "BarCode";
            // 
            // Special
            // 
            this.Special.DataPropertyName = "Special";
            this.Special.HeaderText = "规格型号";
            this.Special.Name = "Special";
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            // 
            // Original
            // 
            this.Original.DataPropertyName = "Original";
            this.Original.HeaderText = "厂家产地";
            this.Original.Name = "Original";
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.DataPropertyName = "PurchasePrice";
            this.PurchasePrice.HeaderText = "价格";
            this.PurchasePrice.Name = "PurchasePrice";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "库存";
            this.Quantity.Name = "Quantity";
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "分类";
            this.CategoryName.Name = "CategoryName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "产品名称";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(77, 35);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(150, 21);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.Tag = "5";
            this.txtProductName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "拼音码";
            // 
            // txtSpellCode
            // 
            this.txtSpellCode.Location = new System.Drawing.Point(318, 35);
            this.txtSpellCode.Name = "txtSpellCode";
            this.txtSpellCode.ReadOnly = true;
            this.txtSpellCode.Size = new System.Drawing.Size(150, 21);
            this.txtSpellCode.TabIndex = 3;
            this.txtSpellCode.Tag = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "条码";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(562, 35);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(150, 21);
            this.txtBarCode.TabIndex = 3;
            this.txtBarCode.Tag = "6";
            this.txtBarCode.Leave += new System.EventHandler(this.txtBarCode_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "规格型号";
            // 
            // txtSpecial
            // 
            this.txtSpecial.Location = new System.Drawing.Point(77, 79);
            this.txtSpecial.Name = "txtSpecial";
            this.txtSpecial.Size = new System.Drawing.Size(150, 21);
            this.txtSpecial.TabIndex = 3;
            this.txtSpecial.Tag = "7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "单位";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(318, 79);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(150, 21);
            this.txtUnit.TabIndex = 3;
            this.txtUnit.Tag = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "产地";
            // 
            // txtOriginal
            // 
            this.txtOriginal.Location = new System.Drawing.Point(562, 79);
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(150, 21);
            this.txtOriginal.TabIndex = 3;
            this.txtOriginal.Tag = "9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "进货价格";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(271, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "数量";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(503, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "所属分类";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(563, 125);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(149, 20);
            this.cbCategory.TabIndex = 4;
            this.cbCategory.Tag = "12";
            // 
            // numPurchasePrice
            // 
            this.numPurchasePrice.DecimalPlaces = 2;
            this.numPurchasePrice.Location = new System.Drawing.Point(77, 124);
            this.numPurchasePrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new System.Drawing.Size(150, 21);
            this.numPurchasePrice.TabIndex = 5;
            this.numPurchasePrice.Tag = "10";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(318, 126);
            this.numQuantity.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(150, 21);
            this.numQuantity.TabIndex = 5;
            this.numQuantity.Tag = "11";
            // 
            // pbBarcode
            // 
            this.pbBarcode.Location = new System.Drawing.Point(20, 184);
            this.pbBarcode.Name = "pbBarcode";
            this.pbBarcode.Size = new System.Drawing.Size(256, 80);
            this.pbBarcode.TabIndex = 6;
            this.pbBarcode.TabStop = false;
            // 
            // Frm_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(760, 613);
            this.Controls.Add(this.dgvProduct);
            this.Name = "Frm_Product";
            this.Text = "产品管理";
            this.Controls.SetChildIndex(this.gbInfo, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.dgvProduct, 0);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpellCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Special;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Original;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numPurchasePrice;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOriginal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSpellCode;
        private System.Windows.Forms.TextBox txtSpecial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBarcode;
    }
}
