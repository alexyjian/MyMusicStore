namespace JXCMIS
{
    partial class Frm_Employee
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
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrief = new System.Windows.Forms.TextBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Controls.Add(this.txtPwd);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.txtBrief);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.cbSex);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.txtEmployeeID);
            this.gbInfo.Controls.Add(this.textBox1);
            this.gbInfo.Controls.Add(this.txtEmployeeName);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.SetChildIndex(this.label1, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtEmployeeName, 0);
            this.gbInfo.Controls.SetChildIndex(this.textBox1, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtEmployeeID, 0);
            this.gbInfo.Controls.SetChildIndex(this.label2, 0);
            this.gbInfo.Controls.SetChildIndex(this.label3, 0);
            this.gbInfo.Controls.SetChildIndex(this.cbSex, 0);
            this.gbInfo.Controls.SetChildIndex(this.label4, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtBrief, 0);
            this.gbInfo.Controls.SetChildIndex(this.label5, 0);
            this.gbInfo.Controls.SetChildIndex(this.btnCancel, 0);
            this.gbInfo.Controls.SetChildIndex(this.btnSave, 0);
            this.gbInfo.Controls.SetChildIndex(this.txtPwd, 0);
            this.gbInfo.Controls.SetChildIndex(this.label6, 0);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cardno,
            this.name,
            this.sex,
            this.phone,
            this.memo});
            this.dgvEmployee.Location = new System.Drawing.Point(12, 14);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 23;
            this.dgvEmployee.Size = new System.Drawing.Size(736, 230);
            this.dgvEmployee.TabIndex = 3;
            this.dgvEmployee.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmployee_CellFormatting);
            // 
            // id
            // 
            this.id.DataPropertyName = "EmployeeID";
            this.id.HeaderText = "员工编号";
            this.id.Name = "id";
            // 
            // cardno
            // 
            this.cardno.DataPropertyName = "CardNo";
            this.cardno.HeaderText = "工号";
            this.cardno.Name = "cardno";
            // 
            // name
            // 
            this.name.DataPropertyName = "EmployeeName";
            this.name.HeaderText = "员工姓名";
            this.name.Name = "name";
            // 
            // sex
            // 
            this.sex.DataPropertyName = "Sex";
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            // 
            // phone
            // 
            this.phone.DataPropertyName = "Phone";
            this.phone.HeaderText = "电话";
            this.phone.Name = "phone";
            // 
            // memo
            // 
            this.memo.DataPropertyName = "Memo";
            this.memo.HeaderText = "简介";
            this.memo.Name = "memo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "简  历：";
            // 
            // txtBrief
            // 
            this.txtBrief.Location = new System.Drawing.Point(397, 66);
            this.txtBrief.Multiline = true;
            this.txtBrief.Name = "txtBrief";
            this.txtBrief.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBrief.Size = new System.Drawing.Size(332, 129);
            this.txtBrief.TabIndex = 31;
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "女",
            "男"});
            this.cbSex.Location = new System.Drawing.Point(118, 130);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(187, 20);
            this.cbSex.TabIndex = 30;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(118, 36);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(187, 21);
            this.txtEmployeeID.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "卡号";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(118, 82);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(187, 21);
            this.txtEmployeeName.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "性别";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 21);
            this.textBox1.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "电话";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(118, 215);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(187, 21);
            this.txtPwd.TabIndex = 34;
            // 
            // Frm_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(760, 613);
            this.Controls.Add(this.dgvEmployee);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Frm_Employee";
            this.Text = "员工管理";
            this.Controls.SetChildIndex(this.gbInfo, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.dgvEmployee, 0);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBrief;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardno;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPwd;
    }
}
