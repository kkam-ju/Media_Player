namespace MediaPlayer
{
    partial class NewMember
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
            label1 = new Label();
            tb_NewID = new TextBox();
            label2 = new Label();
            btn_IDCheck = new Button();
            label3 = new Label();
            tb_NewPW = new TextBox();
            label4 = new Label();
            tb_NewPW1 = new TextBox();
            btn_Complete = new Button();
            label5 = new Label();
            tb_NickName = new TextBox();
            label6 = new Label();
            tb_PhoneNum = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(57, 53);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "회원가입";
            // 
            // tb_NewID
            // 
            tb_NewID.ForeColor = Color.Black;
            tb_NewID.Location = new Point(57, 116);
            tb_NewID.Name = "tb_NewID";
            tb_NewID.Size = new Size(203, 23);
            tb_NewID.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(57, 98);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "아이디";
            // 
            // btn_IDCheck
            // 
            btn_IDCheck.Location = new Point(275, 116);
            btn_IDCheck.Name = "btn_IDCheck";
            btn_IDCheck.Size = new Size(75, 23);
            btn_IDCheck.TabIndex = 3;
            btn_IDCheck.Text = "중복확인";
            btn_IDCheck.UseVisualStyleBackColor = true;
            btn_IDCheck.Click += btn_IDCheck_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(57, 167);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "비밀번호";
            // 
            // tb_NewPW
            // 
            tb_NewPW.ForeColor = Color.Black;
            tb_NewPW.Location = new Point(57, 185);
            tb_NewPW.Name = "tb_NewPW";
            tb_NewPW.Size = new Size(293, 23);
            tb_NewPW.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(57, 242);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 4;
            label4.Text = "비밀번호 확인";
            // 
            // tb_NewPW1
            // 
            tb_NewPW1.ForeColor = Color.Black;
            tb_NewPW1.Location = new Point(57, 260);
            tb_NewPW1.Name = "tb_NewPW1";
            tb_NewPW1.Size = new Size(293, 23);
            tb_NewPW1.TabIndex = 5;
            // 
            // btn_Complete
            // 
            btn_Complete.Location = new Point(147, 474);
            btn_Complete.Name = "btn_Complete";
            btn_Complete.Size = new Size(75, 23);
            btn_Complete.TabIndex = 6;
            btn_Complete.Text = "완료";
            btn_Complete.UseVisualStyleBackColor = true;
            btn_Complete.Click += btn_Complete_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(57, 318);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "이름(닉네임)";
            // 
            // tb_NickName
            // 
            tb_NickName.ForeColor = Color.Black;
            tb_NickName.Location = new Point(57, 336);
            tb_NickName.Name = "tb_NickName";
            tb_NickName.Size = new Size(293, 23);
            tb_NickName.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(57, 391);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 4;
            label6.Text = "전화번호";
            // 
            // tb_PhoneNum
            // 
            tb_PhoneNum.ForeColor = Color.Black;
            tb_PhoneNum.Location = new Point(57, 409);
            tb_PhoneNum.Name = "tb_PhoneNum";
            tb_PhoneNum.Size = new Size(293, 23);
            tb_PhoneNum.TabIndex = 5;
            // 
            // NewMember
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(414, 541);
            Controls.Add(btn_Complete);
            Controls.Add(tb_PhoneNum);
            Controls.Add(tb_NickName);
            Controls.Add(label6);
            Controls.Add(tb_NewPW1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tb_NewPW);
            Controls.Add(label3);
            Controls.Add(btn_IDCheck);
            Controls.Add(label2);
            Controls.Add(tb_NewID);
            Controls.Add(label1);
            Name = "NewMember";
            Text = "회원가입";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_NewID;
        private Label label2;
        private Button btn_IDCheck;
        private Label label3;
        private TextBox tb_NewPW;
        private Label label4;
        private TextBox tb_NewPW1;
        private Button btn_Complete;
        private Label label5;
        private TextBox tb_NickName;
        private Label label6;
        private TextBox tb_PhoneNum;
    }
}