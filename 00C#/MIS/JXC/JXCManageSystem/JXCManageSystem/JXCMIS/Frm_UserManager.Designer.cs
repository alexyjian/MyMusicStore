namespace JXCMIS
{
    partial class Frm_UserManager
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
            this.lbxEmployee = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnRecoverAll = new System.Windows.Forms.Button();
            this.btnCleanAll = new System.Windows.Forms.Button();
            this.btnSelect1 = new System.Windows.Forms.Button();
            this.btnClean1 = new System.Windows.Forms.Button();
            this.btnRecover1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxEmployee = new System.Windows.Forms.CheckBox();
            this.cbxSupplier = new System.Windows.Forms.CheckBox();
            this.cbxProduct = new System.Windows.Forms.CheckBox();
            this.cbxCategory = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxStock = new System.Windows.Forms.CheckBox();
            this.cbxExam = new System.Windows.Forms.CheckBox();
            this.cbxFill = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxUserManager = new System.Windows.Forms.CheckBox();
            this.cbxChangePwd = new System.Windows.Forms.CheckBox();
            this.btnSelect2 = new System.Windows.Forms.Button();
            this.btnClean2 = new System.Windows.Forms.Button();
            this.btnRecover2 = new System.Windows.Forms.Button();
            this.btnSelect3 = new System.Windows.Forms.Button();
            this.btnClean3 = new System.Windows.Forms.Button();
            this.btnRecover3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxEmployee
            // 
            this.lbxEmployee.FormattingEnabled = true;
            this.lbxEmployee.ItemHeight = 12;
            this.lbxEmployee.Location = new System.Drawing.Point(12, 12);
            this.lbxEmployee.Name = "lbxEmployee";
            this.lbxEmployee.Size = new System.Drawing.Size(246, 544);
            this.lbxEmployee.TabIndex = 0;
            this.lbxEmployee.Click += new System.EventHandler(this.lbxEmployee_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 578);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(359, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(379, 578);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(369, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(373, 92);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(121, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "选择以下全部";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRecoverAll
            // 
            this.btnRecoverAll.Location = new System.Drawing.Point(627, 92);
            this.btnRecoverAll.Name = "btnRecoverAll";
            this.btnRecoverAll.Size = new System.Drawing.Size(121, 23);
            this.btnRecoverAll.TabIndex = 2;
            this.btnRecoverAll.Text = "恢复全部权限";
            this.btnRecoverAll.UseVisualStyleBackColor = true;
            this.btnRecoverAll.Click += new System.EventHandler(this.btnRecoverAll_Click);
            // 
            // btnCleanAll
            // 
            this.btnCleanAll.Location = new System.Drawing.Point(500, 92);
            this.btnCleanAll.Name = "btnCleanAll";
            this.btnCleanAll.Size = new System.Drawing.Size(121, 23);
            this.btnCleanAll.TabIndex = 2;
            this.btnCleanAll.Text = "取消全选";
            this.btnCleanAll.UseVisualStyleBackColor = true;
            this.btnCleanAll.Click += new System.EventHandler(this.btnCleanAll_Click);
            // 
            // btnSelect1
            // 
            this.btnSelect1.Location = new System.Drawing.Point(278, 173);
            this.btnSelect1.Name = "btnSelect1";
            this.btnSelect1.Size = new System.Drawing.Size(75, 23);
            this.btnSelect1.TabIndex = 3;
            this.btnSelect1.Text = "全选";
            this.btnSelect1.UseVisualStyleBackColor = true;
            this.btnSelect1.Click += new System.EventHandler(this.btnSelect1_Click);
            // 
            // btnClean1
            // 
            this.btnClean1.Location = new System.Drawing.Point(278, 202);
            this.btnClean1.Name = "btnClean1";
            this.btnClean1.Size = new System.Drawing.Size(75, 23);
            this.btnClean1.TabIndex = 3;
            this.btnClean1.Text = "清除";
            this.btnClean1.UseVisualStyleBackColor = true;
            this.btnClean1.Click += new System.EventHandler(this.btnClean1_Click);
            // 
            // btnRecover1
            // 
            this.btnRecover1.Location = new System.Drawing.Point(278, 231);
            this.btnRecover1.Name = "btnRecover1";
            this.btnRecover1.Size = new System.Drawing.Size(75, 23);
            this.btnRecover1.TabIndex = 3;
            this.btnRecover1.Text = "恢复";
            this.btnRecover1.UseVisualStyleBackColor = true;
            this.btnRecover1.Click += new System.EventHandler(this.btnRecover1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxEmployee);
            this.groupBox1.Controls.Add(this.cbxSupplier);
            this.groupBox1.Controls.Add(this.cbxProduct);
            this.groupBox1.Controls.Add(this.cbxCategory);
            this.groupBox1.Location = new System.Drawing.Point(373, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基础数据管理";
            // 
            // cbxEmployee
            // 
            this.cbxEmployee.AutoSize = true;
            this.cbxEmployee.Location = new System.Drawing.Point(194, 97);
            this.cbxEmployee.Name = "cbxEmployee";
            this.cbxEmployee.Size = new System.Drawing.Size(72, 16);
            this.cbxEmployee.TabIndex = 0;
            this.cbxEmployee.Text = "员工管理";
            this.cbxEmployee.UseVisualStyleBackColor = true;
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.AutoSize = true;
            this.cbxSupplier.Location = new System.Drawing.Point(34, 97);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(84, 16);
            this.cbxSupplier.TabIndex = 0;
            this.cbxSupplier.Text = "供应商管理";
            this.cbxSupplier.UseVisualStyleBackColor = true;
            // 
            // cbxProduct
            // 
            this.cbxProduct.AutoSize = true;
            this.cbxProduct.Location = new System.Drawing.Point(194, 49);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(72, 16);
            this.cbxProduct.TabIndex = 0;
            this.cbxProduct.Text = "产品管理";
            this.cbxProduct.UseVisualStyleBackColor = true;
            // 
            // cbxCategory
            // 
            this.cbxCategory.AutoSize = true;
            this.cbxCategory.Location = new System.Drawing.Point(34, 49);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(96, 16);
            this.cbxCategory.TabIndex = 0;
            this.cbxCategory.Text = "产品分类管理";
            this.cbxCategory.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxStock);
            this.groupBox2.Controls.Add(this.cbxExam);
            this.groupBox2.Controls.Add(this.cbxFill);
            this.groupBox2.Location = new System.Drawing.Point(373, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 143);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "进货管理";
            // 
            // cbxStock
            // 
            this.cbxStock.AutoSize = true;
            this.cbxStock.Location = new System.Drawing.Point(34, 100);
            this.cbxStock.Name = "cbxStock";
            this.cbxStock.Size = new System.Drawing.Size(96, 16);
            this.cbxStock.TabIndex = 0;
            this.cbxStock.Text = "产品入库检验";
            this.cbxStock.UseVisualStyleBackColor = true;
            // 
            // cbxExam
            // 
            this.cbxExam.AutoSize = true;
            this.cbxExam.Location = new System.Drawing.Point(194, 49);
            this.cbxExam.Name = "cbxExam";
            this.cbxExam.Size = new System.Drawing.Size(84, 16);
            this.cbxExam.TabIndex = 0;
            this.cbxExam.Text = "审核进货单";
            this.cbxExam.UseVisualStyleBackColor = true;
            // 
            // cbxFill
            // 
            this.cbxFill.AutoSize = true;
            this.cbxFill.Location = new System.Drawing.Point(34, 49);
            this.cbxFill.Name = "cbxFill";
            this.cbxFill.Size = new System.Drawing.Size(84, 16);
            this.cbxFill.TabIndex = 0;
            this.cbxFill.Text = "填写进货单";
            this.cbxFill.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxUserManager);
            this.groupBox3.Controls.Add(this.cbxChangePwd);
            this.groupBox3.Location = new System.Drawing.Point(373, 434);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 113);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "用户管理";
            // 
            // cbxUserManager
            // 
            this.cbxUserManager.AutoSize = true;
            this.cbxUserManager.Location = new System.Drawing.Point(194, 49);
            this.cbxUserManager.Name = "cbxUserManager";
            this.cbxUserManager.Size = new System.Drawing.Size(72, 16);
            this.cbxUserManager.TabIndex = 0;
            this.cbxUserManager.Text = "权限管理";
            this.cbxUserManager.UseVisualStyleBackColor = true;
            // 
            // cbxChangePwd
            // 
            this.cbxChangePwd.AutoSize = true;
            this.cbxChangePwd.Location = new System.Drawing.Point(34, 49);
            this.cbxChangePwd.Name = "cbxChangePwd";
            this.cbxChangePwd.Size = new System.Drawing.Size(96, 16);
            this.cbxChangePwd.TabIndex = 0;
            this.cbxChangePwd.Text = "修改个人密码";
            this.cbxChangePwd.UseVisualStyleBackColor = true;
            // 
            // btnSelect2
            // 
            this.btnSelect2.Location = new System.Drawing.Point(278, 327);
            this.btnSelect2.Name = "btnSelect2";
            this.btnSelect2.Size = new System.Drawing.Size(75, 23);
            this.btnSelect2.TabIndex = 3;
            this.btnSelect2.Text = "全选";
            this.btnSelect2.UseVisualStyleBackColor = true;
            // 
            // btnClean2
            // 
            this.btnClean2.Location = new System.Drawing.Point(278, 356);
            this.btnClean2.Name = "btnClean2";
            this.btnClean2.Size = new System.Drawing.Size(75, 23);
            this.btnClean2.TabIndex = 3;
            this.btnClean2.Text = "清除";
            this.btnClean2.UseVisualStyleBackColor = true;
            // 
            // btnRecover2
            // 
            this.btnRecover2.Location = new System.Drawing.Point(278, 385);
            this.btnRecover2.Name = "btnRecover2";
            this.btnRecover2.Size = new System.Drawing.Size(75, 23);
            this.btnRecover2.TabIndex = 3;
            this.btnRecover2.Text = "恢复";
            this.btnRecover2.UseVisualStyleBackColor = true;
            // 
            // btnSelect3
            // 
            this.btnSelect3.Location = new System.Drawing.Point(278, 449);
            this.btnSelect3.Name = "btnSelect3";
            this.btnSelect3.Size = new System.Drawing.Size(75, 23);
            this.btnSelect3.TabIndex = 3;
            this.btnSelect3.Text = "全选";
            this.btnSelect3.UseVisualStyleBackColor = true;
            // 
            // btnClean3
            // 
            this.btnClean3.Location = new System.Drawing.Point(278, 478);
            this.btnClean3.Name = "btnClean3";
            this.btnClean3.Size = new System.Drawing.Size(75, 23);
            this.btnClean3.TabIndex = 3;
            this.btnClean3.Text = "清除";
            this.btnClean3.UseVisualStyleBackColor = true;
            // 
            // btnRecover3
            // 
            this.btnRecover3.Location = new System.Drawing.Point(278, 507);
            this.btnRecover3.Name = "btnRecover3";
            this.btnRecover3.Size = new System.Drawing.Size(75, 23);
            this.btnRecover3.TabIndex = 3;
            this.btnRecover3.Text = "恢复";
            this.btnRecover3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "姓名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(332, 24);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "性别";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(490, 24);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(100, 21);
            this.txtSex.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "电话";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(648, 24);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 6;
            // 
            // Frm_UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 613);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRecover3);
            this.Controls.Add(this.btnClean3);
            this.Controls.Add(this.btnRecover2);
            this.Controls.Add(this.btnClean2);
            this.Controls.Add(this.btnSelect3);
            this.Controls.Add(this.btnRecover1);
            this.Controls.Add(this.btnSelect2);
            this.Controls.Add(this.btnClean1);
            this.Controls.Add(this.btnSelect1);
            this.Controls.Add(this.btnCleanAll);
            this.Controls.Add(this.btnRecoverAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbxEmployee);
            this.Name = "Frm_UserManager";
            this.Text = "权限管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxEmployee;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnRecoverAll;
        private System.Windows.Forms.Button btnCleanAll;
        private System.Windows.Forms.Button btnSelect1;
        private System.Windows.Forms.Button btnClean1;
        private System.Windows.Forms.Button btnRecover1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxEmployee;
        private System.Windows.Forms.CheckBox cbxSupplier;
        private System.Windows.Forms.CheckBox cbxProduct;
        private System.Windows.Forms.CheckBox cbxCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxStock;
        private System.Windows.Forms.CheckBox cbxExam;
        private System.Windows.Forms.CheckBox cbxFill;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxUserManager;
        private System.Windows.Forms.CheckBox cbxChangePwd;
        private System.Windows.Forms.Button btnSelect2;
        private System.Windows.Forms.Button btnClean2;
        private System.Windows.Forms.Button btnRecover2;
        private System.Windows.Forms.Button btnSelect3;
        private System.Windows.Forms.Button btnClean3;
        private System.Windows.Forms.Button btnRecover3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
    }
}