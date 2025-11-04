namespace WinFormsApp33
{
    partial class Cardplus
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
            btn_CardSave = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btn_CardSave
            // 
            btn_CardSave.BackColor = Color.Blue;
            btn_CardSave.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_CardSave.ForeColor = Color.White;
            btn_CardSave.Location = new Point(41, 357);
            btn_CardSave.Name = "btn_CardSave";
            btn_CardSave.Size = new Size(596, 51);
            btn_CardSave.TabIndex = 23;
            btn_CardSave.Text = "카드 저장";
            btn_CardSave.UseVisualStyleBackColor = false;
            btn_CardSave.Click += btn_CardSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(390, 208);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 22;
            label7.Text = "보안 코드";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(41, 208);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 21;
            label6.Text = "MM/YY";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(390, 87);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 20;
            label5.Text = "카드번호";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "삼성카드", "현대카드", "롯데카드", "비씨카드", "KB국민카드", "신한카드", "우리카드", "하나카드" });
            comboBox1.Location = new Point(41, 119);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(208, 23);
            comboBox1.TabIndex = 19;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(390, 235);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(247, 23);
            textBox3.TabIndex = 18;
            textBox3.TextChanged += textBox3_TextChanged;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(41, 235);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 23);
            textBox2.TabIndex = 17;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(390, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(247, 23);
            textBox1.TabIndex = 16;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(41, 293);
            label3.Name = "label3";
            label3.Size = new Size(596, 39);
            label3.TabIndex = 15;
            label3.Text = "계속 진행하면 Google에서 수집하는 개인 정보,수집 목적, 저장 기간이 설명되어 있는 Google Payments 서비스 약관 \r\n및 개인정보처리방침,개인정보 수집 및 공유에 동의하는 것으로 간주됩니다. 동의를 거부할 수 있으며, 이 경우 위에 언\r\n급된 서비스를 이용할 수 없습니다.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(41, 61);
            label2.Name = "label2";
            label2.Size = new Size(151, 17);
            label2.TabIndex = 14;
            label2.Text = "모두 필수 입력란입니다.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(41, 9);
            label1.Name = "label1";
            label1.Size = new Size(261, 25);
            label1.TabIndex = 13;
            label1.Text = "신용카드 또는 체크카드 추가";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(41, 87);
            label4.Name = "label4";
            label4.Size = new Size(42, 21);
            label4.TabIndex = 24;
            label4.Text = "카드";
            // 
            // Cardplus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(btn_CardSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Cardplus";
            Text = "Cardplus";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_CardSave;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
    }
}