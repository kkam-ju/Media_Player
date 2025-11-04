namespace TpMain
{
    partial class IDfind
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
            txtPhoneNumber = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            back2 = new Button();
            txtNickname = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(148, 171);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(211, 23);
            txtPhoneNumber.TabIndex = 1;
            txtPhoneNumber.TextChanged += txtPhoneNumber_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(139, 55);
            label1.Name = "label1";
            label1.Size = new Size(125, 30);
            label1.TabIndex = 4;
            label1.Text = "아이디 찾기";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(41, 173);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 5;
            label2.Text = "전화번호 입력";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(41, 118);
            label3.Name = "label3";
            label3.Size = new Size(65, 17);
            label3.TabIndex = 6;
            label3.Text = "이름 입력";
            // 
            // back2
            // 
            back2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            back2.Location = new Point(123, 298);
            back2.Name = "back2";
            back2.Size = new Size(157, 34);
            back2.TabIndex = 7;
            back2.Text = "뒤로";
            back2.UseVisualStyleBackColor = true;
            back2.Click += back2_Click;
            // 
            // txtNickname
            // 
            txtNickname.Location = new Point(148, 116);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(211, 23);
            txtNickname.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(123, 245);
            button1.Name = "button1";
            button1.Size = new Size(157, 34);
            button1.TabIndex = 0;
            button1.Text = "입력";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // IDfind
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(409, 397);
            Controls.Add(back2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNickname);
            Controls.Add(txtPhoneNumber);
            Controls.Add(button1);
            Name = "IDfind";
            Text = "Form1";
//            Load += IDfind_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtPhoneNumber;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button back2;
        private TextBox txtNickname;
        private Button button1;
    }
}