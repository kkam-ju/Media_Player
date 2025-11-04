namespace TpMain
{
    partial class MyPage
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
            panel1 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            lb_Name = new Label();
            btn_goUp = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lb_Name);
            panel1.Location = new Point(104, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1147, 1031);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(48, 632);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1096, 362);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Location = new Point(44, 137);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1580, 311);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(48, 582);
            label2.Name = "label2";
            label2.Size = new Size(118, 21);
            label2.TabIndex = 1;
            label2.Text = "내가 올린 영상";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(44, 97);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 1;
            label1.Text = "구독 목록";
            // 
            // lb_Name
            // 
            lb_Name.AutoSize = true;
            lb_Name.Font = new Font("맑은 고딕", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Name.ForeColor = Color.White;
            lb_Name.Location = new Point(119, 29);
            lb_Name.Name = "lb_Name";
            lb_Name.Size = new Size(107, 45);
            lb_Name.TabIndex = 0;
            lb_Name.Text = "label1";
            // 
            // btn_goUp
            // 
            btn_goUp.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_goUp.Location = new Point(1341, 75);
            btn_goUp.Name = "btn_goUp";
            btn_goUp.Size = new Size(245, 115);
            btn_goUp.TabIndex = 1;
            btn_goUp.Text = "업로드";
            btn_goUp.UseVisualStyleBackColor = true;
            btn_goUp.Click += btn_goUp_Click;
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(1341, 238);
            button1.Name = "button1";
            button1.Size = new Size(245, 115);
            button1.TabIndex = 2;
            button1.Text = "나가기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MyPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(btn_goUp);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            Name = "MyPage";
            Text = "MyPage";
            Load += MyPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lb_Name;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Label label1;
        private Button btn_goUp;
        private Button button1;
    }
}