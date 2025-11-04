namespace TpMain
{
    partial class Upload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Upload));
            btn_Upload = new Button();
            btn_Delete = new Button();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lb_Path = new Label();
            button1 = new Button();
            btThum = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btn_Upload
            // 
            btn_Upload.BackColor = SystemColors.WindowText;
            btn_Upload.FlatStyle = FlatStyle.Flat;
            btn_Upload.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Upload.ForeColor = Color.White;
            btn_Upload.Location = new Point(464, 608);
            btn_Upload.Name = "btn_Upload";
            btn_Upload.Size = new Size(91, 31);
            btn_Upload.TabIndex = 0;
            btn_Upload.Text = "파일선택";
            btn_Upload.UseVisualStyleBackColor = false;
            btn_Upload.Click += btn_Upload_Click;
            // 
            // btn_Delete
            // 
            btn_Delete.BackColor = SystemColors.WindowText;
            btn_Delete.FlatStyle = FlatStyle.Flat;
            btn_Delete.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Delete.ForeColor = Color.White;
            btn_Delete.Location = new Point(464, 688);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(91, 31);
            btn_Delete.TabIndex = 1;
            btn_Delete.Text = "삭제";
            btn_Delete.UseVisualStyleBackColor = false;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.AllowDrop = true;
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(40, 136);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(483, 453);
            axWindowsMediaPlayer1.TabIndex = 2;
            axWindowsMediaPlayer1.Visible = false;
            axWindowsMediaPlayer1.Enter += axWindowsMediaPlayer1_Enter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(440, 248);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 6);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 4;
            label1.Text = "동영상 업로드";
            // 
            // lb_Path
            // 
            lb_Path.AutoSize = true;
            lb_Path.Location = new Point(576, 616);
            lb_Path.Name = "lb_Path";
            lb_Path.Size = new Size(50, 15);
            lb_Path.TabIndex = 6;
            lb_Path.Text = " lb_Path";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.WindowText;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(412, 736);
            button1.Name = "button1";
            button1.Size = new Size(200, 61);
            button1.TabIndex = 7;
            button1.Text = "확인";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btThum
            // 
            btThum.BackColor = SystemColors.WindowText;
            btThum.FlatAppearance.BorderSize = 0;
            btThum.FlatStyle = FlatStyle.Flat;
            btThum.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btThum.ForeColor = Color.White;
            btThum.Location = new Point(464, 648);
            btThum.Name = "btThum";
            btThum.Size = new Size(91, 31);
            btThum.TabIndex = 8;
            btThum.Text = "썸네일 선택";
            btThum.UseVisualStyleBackColor = false;
            btThum.Click += btThum_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(584, 136);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(432, 448);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // Upload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1052, 831);
            Controls.Add(pictureBox1);
            Controls.Add(btThum);
            Controls.Add(button1);
            Controls.Add(lb_Path);
            Controls.Add(label1);
            Controls.Add(btn_Delete);
            Controls.Add(btn_Upload);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(pictureBox2);
            Name = "Upload";
            Text = "Upload";
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Upload;
        private Button btn_Delete;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label lb_Path;
        private Button button1;
        private Button btThum;
        private PictureBox pictureBox2;
    }
}