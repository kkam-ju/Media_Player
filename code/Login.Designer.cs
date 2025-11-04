namespace MediaPlayer
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tb_ID = new TextBox();
            tb_PW = new TextBox();
            cb_Security = new CheckBox();
            btn_Login = new Button();
            btn_Signup = new Button();
            btn_Find_ID = new Button();
            btn_Find_PW = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(242, 39);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 0;
            label1.Text = "로그인";
            // 
            // tb_ID
            // 
            tb_ID.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_ID.ForeColor = Color.Gray;
            tb_ID.Location = new Point(138, 96);
            tb_ID.Multiline = true;
            tb_ID.Name = "tb_ID";
            tb_ID.Size = new Size(294, 29);
            tb_ID.TabIndex = 1;
            tb_ID.Text = "아이디를 입력하세요";
            tb_ID.Enter += tb_ID_Enter;
            tb_ID.Leave += tb_ID_Leave;
            // 
            // tb_PW
            // 
            tb_PW.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_PW.ForeColor = Color.Gray;
            tb_PW.Location = new Point(138, 146);
            tb_PW.Multiline = true;
            tb_PW.Name = "tb_PW";
            tb_PW.Size = new Size(294, 29);
            tb_PW.TabIndex = 2;
            tb_PW.Text = "비밀번호를 입력하세요";
            tb_PW.Enter += tb_PW_Enter;
            tb_PW.Leave += tb_PW_Leave;
            // 
            // cb_Security
            // 
            cb_Security.AutoSize = true;
            cb_Security.ForeColor = Color.White;
            cb_Security.Location = new Point(138, 188);
            cb_Security.Name = "cb_Security";
            cb_Security.Size = new Size(50, 19);
            cb_Security.TabIndex = 3;
            cb_Security.Text = "보안";
            cb_Security.UseVisualStyleBackColor = true;
            cb_Security.CheckedChanged += cb_Security_CheckedChanged;
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(138, 260);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(295, 29);
            btn_Login.TabIndex = 4;
            btn_Login.Text = "로그인";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Signup
            // 
            btn_Signup.Location = new Point(138, 310);
            btn_Signup.Name = "btn_Signup";
            btn_Signup.Size = new Size(294, 29);
            btn_Signup.TabIndex = 5;
            btn_Signup.Text = "회원가입";
            btn_Signup.UseVisualStyleBackColor = true;
            btn_Signup.Click += btn_Signup_Click;
            // 
            // btn_Find_ID
            // 
            btn_Find_ID.FlatAppearance.BorderSize = 0;
            btn_Find_ID.FlatStyle = FlatStyle.Flat;
            btn_Find_ID.ForeColor = Color.White;
            btn_Find_ID.Location = new Point(270, 186);
            btn_Find_ID.Name = "btn_Find_ID";
            btn_Find_ID.Size = new Size(85, 23);
            btn_Find_ID.TabIndex = 6;
            btn_Find_ID.Text = "아이디 찾기";
            btn_Find_ID.UseVisualStyleBackColor = true;
            btn_Find_ID.Click += btn_Find_ID_Click;
            // 
            // btn_Find_PW
            // 
            btn_Find_PW.FlatAppearance.BorderSize = 0;
            btn_Find_PW.FlatStyle = FlatStyle.Flat;
            btn_Find_PW.ForeColor = Color.White;
            btn_Find_PW.Location = new Point(347, 186);
            btn_Find_PW.Name = "btn_Find_PW";
            btn_Find_PW.Size = new Size(93, 23);
            btn_Find_PW.TabIndex = 7;
            btn_Find_PW.Text = "비밀번호 찾기";
            btn_Find_PW.UseVisualStyleBackColor = true;
            btn_Find_PW.Click += btn_Find_PW_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(344, 189);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 8;
            label2.Text = "/";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(563, 433);
            Controls.Add(label2);
            Controls.Add(btn_Find_PW);
            Controls.Add(btn_Find_ID);
            Controls.Add(btn_Signup);
            Controls.Add(btn_Login);
            Controls.Add(cb_Security);
            Controls.Add(tb_PW);
            Controls.Add(tb_ID);
            Controls.Add(label1);
            Name = "Login";
            Text = "로그인";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_ID;
        private TextBox tb_PW;
        private CheckBox cb_Security;
        private Button btn_Login;
        private Button btn_Signup;
        private Button btn_Find_ID;
        private Button btn_Find_PW;
        private Label label2;
    }
}
