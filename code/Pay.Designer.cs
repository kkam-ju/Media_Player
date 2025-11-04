namespace WinFormsApp33
{
    partial class Pay
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pay));
            timer1 = new System.Windows.Forms.Timer(components);
            labelTime = new Label();
            label18 = new Label();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label17 = new Label();
            label2 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // labelTime
            // 
            labelTime.AllowDrop = true;
            labelTime.AutoSize = true;
            labelTime.Location = new Point(165, 167);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(12, 15);
            labelTime.TabIndex = 46;
            labelTime.Text = "-";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(203, 221);
            label18.Name = "label18";
            label18.Size = new Size(17, 21);
            label18.TabIndex = 45;
            label18.Text = "-";
            label18.Click += label18_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(441, 515);
            button1.Name = "button1";
            button1.Size = new Size(324, 54);
            button1.TabIndex = 44;
            button1.Text = "구입";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(86, 200);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(91, 61);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 43;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(80, 84);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 61);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 42;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(85, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 41;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(685, 435);
            label17.Name = "label17";
            label17.Size = new Size(71, 21);
            label17.TabIndex = 40;
            label17.Text = "\\14,900\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 182);
            label2.Name = "label2";
            label2.Size = new Size(692, 15);
            label2.TabIndex = 39;
            label2.Text = "-----------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(141, 103);
            label16.Name = "label16";
            label16.Size = new Size(153, 21);
            label16.TabIndex = 38;
            label16.Text = "YouTube Premium";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(86, 167);
            label15.Name = "label15";
            label15.Size = new Size(74, 15);
            label15.TabIndex = 37;
            label15.Text = "청구 시작일:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(704, 107);
            label14.Name = "label14";
            label14.Size = new Size(61, 17);
            label14.TabIndex = 36;
            label14.Text = "\\14,900\r\n";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(86, 268);
            label13.Name = "label13";
            label13.Size = new Size(645, 30);
            label13.TabIndex = 35;
            label13.Text = "매월 자동으로 결제가 이루어집니다 서비스를 아직 사용하지 않은 경우, 구매일로부터 7일 이내에 청략철회권을 행사할\r\n수 있습니다.취소와 환불에 관해 자세히 알아보기.";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(85, 358);
            label12.Name = "label12";
            label12.Size = new Size(31, 15);
            label12.TabIndex = 34;
            label12.Text = "소계";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(85, 379);
            label11.Name = "label11";
            label11.Size = new Size(31, 15);
            label11.TabIndex = 33;
            label11.Text = "세금";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(152, 124);
            label10.Name = "label10";
            label10.Size = new Size(47, 17);
            label10.TabIndex = 32;
            label10.Text = "멤버쉽";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(85, 148);
            label9.Name = "label9";
            label9.Size = new Size(65, 17);
            label9.TabIndex = 31;
            label9.Text = "월별 청구";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(328, 298);
            label8.Name = "label8";
            label8.Size = new Size(0, 15);
            label8.TabIndex = 30;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(685, 148);
            label7.Name = "label7";
            label7.Size = new Size(80, 34);
            label7.TabIndex = 29;
            label7.Text = "\\14,900/월\r\n\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(86, 322);
            label6.Name = "label6";
            label6.Size = new Size(475, 15);
            label6.TabIndex = 28;
            label6.Text = "계속 진행함으로써 본인이 만 19세 이상임을 확인하고, 본 약관에 동의함을 확인합니다.\r\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(80, 432);
            label5.Name = "label5";
            label5.Size = new Size(140, 25);
            label5.TabIndex = 27;
            label5.Text = "오늘 결제 총액";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(696, 356);
            label4.Name = "label4";
            label4.Size = new Size(61, 17);
            label4.TabIndex = 26;
            label4.Text = "\\13,545";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(703, 377);
            label3.Name = "label3";
            label3.Size = new Size(53, 17);
            label3.TabIndex = 25;
            label3.Text = "\\1,355";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(141, 49);
            label1.Name = "label1";
            label1.Size = new Size(171, 25);
            label1.TabIndex = 24;
            label1.Text = "구매를 완료하세요";
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(80, 515);
            button2.Name = "button2";
            button2.Size = new Size(324, 54);
            button2.TabIndex = 47;
            button2.Text = "결제카드등록";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 689);
            Controls.Add(button2);
            Controls.Add(labelTime);
            Controls.Add(label18);
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label17);
            Controls.Add(label2);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "pay";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label labelTime;
        private Label label18;
        private Button button1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label17;
        private Label label2;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button button2;
    }
}
