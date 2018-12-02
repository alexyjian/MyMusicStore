namespace JXCMIS
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbStu = new System.Windows.Forms.ListBox();
            this.lbRoom = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStuRoom = new System.Windows.Forms.ListBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "学生列表";
            // 
            // lbStu
            // 
            this.lbStu.FormattingEnabled = true;
            this.lbStu.ItemHeight = 12;
            this.lbStu.Location = new System.Drawing.Point(20, 40);
            this.lbStu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbStu.Name = "lbStu";
            this.lbStu.Size = new System.Drawing.Size(189, 496);
            this.lbStu.TabIndex = 1;
            this.lbStu.Click += new System.EventHandler(this.lbStu_Click);
            // 
            // lbRoom
            // 
            this.lbRoom.FormattingEnabled = true;
            this.lbRoom.ItemHeight = 12;
            this.lbRoom.Location = new System.Drawing.Point(246, 40);
            this.lbRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(189, 496);
            this.lbRoom.TabIndex = 1;
            this.lbRoom.Click += new System.EventHandler(this.lbRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(244, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "备选宿舍";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(492, 500);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(132, 32);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "入住";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "住宿情况";
            // 
            // lbStuRoom
            // 
            this.lbStuRoom.FormattingEnabled = true;
            this.lbStuRoom.ItemHeight = 12;
            this.lbStuRoom.Location = new System.Drawing.Point(492, 182);
            this.lbStuRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbStuRoom.Name = "lbStuRoom";
            this.lbStuRoom.Size = new System.Drawing.Size(276, 304);
            this.lbStuRoom.TabIndex = 5;
            this.lbStuRoom.Click += new System.EventHandler(this.lbStuRoom_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(637, 500);
            this.btnOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(128, 32);
            this.btnOut.TabIndex = 2;
            this.btnOut.Text = "搬出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "宿舍名称";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(552, 51);
            this.txtRoomName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.ReadOnly = true;
            this.txtRoomName.Size = new System.Drawing.Size(215, 21);
            this.txtRoomName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "容纳人数";
            // 
            // txtCap
            // 
            this.txtCap.Location = new System.Drawing.Point(552, 86);
            this.txtCap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCap.Name = "txtCap";
            this.txtCap.ReadOnly = true;
            this.txtCap.Size = new System.Drawing.Size(215, 21);
            this.txtCap.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(490, 122);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "性    别";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(552, 121);
            this.txtSex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(215, 21);
            this.txtSex.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(490, 154);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "状    态";
            // 
            // txtStatus
            // 
            this.txtStatus.ForeColor = System.Drawing.Color.Red;
            this.txtStatus.Location = new System.Drawing.Point(552, 153);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(215, 21);
            this.txtStatus.TabIndex = 7;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 579);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.txtCap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbStuRoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.lbStu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宿舍管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbStu;
        private System.Windows.Forms.ListBox lbRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbStuRoom;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStatus;
    }
}