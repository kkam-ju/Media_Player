namespace TpMain
{
    partial class PWfind
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
            label = new Label();
            label2 = new Label();
            txtID = new TextBox();
            txtPhoneNumber = new TextBox();
            button1 = new Button();
            label1 = new Label();
            back1 = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label.ForeColor = Color.White;
            label.Location = new Point(37, 110);
            label.Name = "label";
            label.Size = new Size(78, 17);
            label.TabIndex = 0;
            label.Text = "아이디 입력";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(37, 173);
            label2.Name = "label2";
            label2.Size = new Size(86, 17);
            label2.TabIndex = 1;
            label2.Text = "전화번호입력";
            // 
            // txtID
            // 
            txtID.ForeColor = Color.Black;
            txtID.Location = new Point(133, 108);
            txtID.Name = "txtID";
            txtID.Size = new Size(211, 23);
            txtID.TabIndex = 2;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.ForeColor = Color.Black;
            txtPhoneNumber.Location = new Point(133, 167);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(211, 23);
            txtPhoneNumber.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(110, 254);
            button1.Name = "button1";
            button1.Size = new Size(157, 33);
            button1.TabIndex = 4;
            button1.Text = "입력";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(121, 40);
            label1.Name = "label1";
            label1.Size = new Size(146, 30);
            label1.TabIndex = 5;
            label1.Text = "비밀번호 찾기";
            // 
            // back1
            // 
            back1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            back1.Location = new Point(110, 306);
            back1.Name = "back1";
            back1.Size = new Size(157, 33);
            back1.TabIndex = 6;
            back1.Text = "뒤로";
            back1.UseVisualStyleBackColor = true;
            back1.Click += back1_Click;
            // 
            // PWfind
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(387, 410);
            Controls.Add(back1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtID);
            Controls.Add(label2);
            Controls.Add(label);
            Name = "PWfind";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private Label label2;
        private TextBox txtID;
        private TextBox txtPhoneNumber;
        private Button button1;
        private Label label1;
        private Button back1;
    }
}