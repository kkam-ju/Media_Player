namespace TpMain
{
    partial class VideoView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoView));
            panel1 = new Panel();
            panelControls = new Panel();
            panelVolumeBase = new Panel();
            panelVolumeProgress = new Panel();
            panelTrackBase = new Panel();
            panelTrackProgress = new Panel();
            panel2 = new Panel();
            button4 = new Button();
            button5 = new Button();
            btset = new Button();
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            btstart = new Button();
            btmute = new Button();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            timer1 = new System.Windows.Forms.Timer(components);
            hideControlsTimer = new System.Windows.Forms.Timer(components);
            singleClickTimer = new System.Windows.Forms.Timer(components);
            volumeChangeTimer = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            toolTip6 = new ToolTip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            flowLayoutPanelComments = new FlowLayoutPanel();
            tbComment = new TextBox();
            btComment = new Button();
            btSubscribe = new Button();
            btFavorite = new Button();
            pictureBox1 = new PictureBox();
            imageList1 = new ImageList(components);
            imageList2 = new ImageList(components);
            panel3 = new Panel();
            panel1.SuspendLayout();
            panelControls.SuspendLayout();
            panelVolumeBase.SuspendLayout();
            panelTrackBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(panelControls);
            panel1.Controls.Add(axWindowsMediaPlayer1);
            panel1.ForeColor = SystemColors.Control;
            panel1.Location = new Point(168, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(864, 511);
            panel1.TabIndex = 5;
            // 
            // panelControls
            // 
            panelControls.AutoSize = true;
            panelControls.BackColor = SystemColors.MenuText;
            panelControls.Controls.Add(panelVolumeBase);
            panelControls.Controls.Add(panelTrackBase);
            panelControls.Controls.Add(button4);
            panelControls.Controls.Add(button5);
            panelControls.Controls.Add(btset);
            panelControls.Controls.Add(button6);
            panelControls.Controls.Add(button1);
            panelControls.Controls.Add(button2);
            panelControls.Controls.Add(button3);
            panelControls.Controls.Add(btstart);
            panelControls.Controls.Add(btmute);
            panelControls.Cursor = Cursors.Hand;
            panelControls.Dock = DockStyle.Bottom;
            panelControls.ForeColor = Color.Transparent;
            panelControls.Location = new Point(0, 408);
            panelControls.MaximumSize = new Size(1920, 1080);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(864, 103);
            panelControls.TabIndex = 3;
            panelControls.Visible = false;
            // 
            // panelVolumeBase
            // 
            panelVolumeBase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelVolumeBase.BackColor = SystemColors.ControlText;
            panelVolumeBase.Controls.Add(panelVolumeProgress);
            panelVolumeBase.Location = new Point(133, 55);
            panelVolumeBase.Name = "panelVolumeBase";
            panelVolumeBase.Size = new Size(199, 28);
            panelVolumeBase.TabIndex = 12;
            // 
            // panelVolumeProgress
            // 
            panelVolumeProgress.BackColor = Color.White;
            panelVolumeProgress.Location = new Point(3, 8);
            panelVolumeProgress.Name = "panelVolumeProgress";
            panelVolumeProgress.Size = new Size(196, 4);
            panelVolumeProgress.TabIndex = 0;
            // 
            // panelTrackBase
            // 
            panelTrackBase.BackColor = SystemColors.MenuText;
            panelTrackBase.Controls.Add(panelTrackProgress);
            panelTrackBase.Controls.Add(panel2);
            panelTrackBase.Dock = DockStyle.Top;
            panelTrackBase.ForeColor = Color.Black;
            panelTrackBase.Location = new Point(0, 0);
            panelTrackBase.Name = "panelTrackBase";
            panelTrackBase.Size = new Size(864, 19);
            panelTrackBase.TabIndex = 11;
            panelTrackBase.MouseDown += panelTrackBase_MouseDown;
            // 
            // panelTrackProgress
            // 
            panelTrackProgress.BackColor = Color.Red;
            panelTrackProgress.Location = new Point(4, 8);
            panelTrackProgress.Name = "panelTrackProgress";
            panelTrackProgress.Size = new Size(912, 3);
            panelTrackProgress.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(3, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(912, 2);
            panel2.TabIndex = 13;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(672, 43);
            button4.Name = "button4";
            button4.Size = new Size(59, 52);
            button4.TabIndex = 8;
            toolTip4.SetToolTip(button4, "자막");
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.ControlText;
            button5.Location = new Point(737, 45);
            button5.Name = "button5";
            button5.Size = new Size(61, 52);
            button5.TabIndex = 10;
            button5.Text = "▭";
            toolTip5.SetToolTip(button5, "영화관모드");
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btset
            // 
            btset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btset.BackColor = Color.Transparent;
            btset.BackgroundImage = (Image)resources.GetObject("btset.BackgroundImage");
            btset.BackgroundImageLayout = ImageLayout.Stretch;
            btset.FlatStyle = FlatStyle.Flat;
            btset.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btset.ForeColor = SystemColors.ControlText;
            btset.Location = new Point(608, 42);
            btset.Name = "btset";
            btset.Size = new Size(58, 53);
            btset.TabIndex = 1;
            toolTip3.SetToolTip(btset, "배속설정");
            btset.UseVisualStyleBackColor = false;
            btset.Click += btset_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = SystemColors.ControlText;
            button6.Location = new Point(804, 45);
            button6.Name = "button6";
            button6.Size = new Size(57, 55);
            button6.TabIndex = 9;
            button6.Text = "⛶";
            toolTip6.SetToolTip(button6, "전체화면");
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(1310, 42);
            button1.Name = "button1";
            button1.Size = new Size(50, 55);
            button1.TabIndex = 5;
            button1.Text = "💬";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(1355, 42);
            button2.Name = "button2";
            button2.Size = new Size(50, 55);
            button2.TabIndex = 7;
            button2.Text = "▭";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Right;
            button3.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(1402, 43);
            button3.Name = "button3";
            button3.Size = new Size(50, 55);
            button3.TabIndex = 6;
            button3.Text = "⛶";
            button3.UseVisualStyleBackColor = true;
            // 
            // btstart
            // 
            btstart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btstart.BackgroundImageLayout = ImageLayout.Stretch;
            btstart.FlatAppearance.BorderSize = 0;
            btstart.FlatStyle = FlatStyle.Flat;
            btstart.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btstart.ForeColor = Color.White;
            btstart.Location = new Point(17, 36);
            btstart.Name = "btstart";
            btstart.Size = new Size(53, 52);
            btstart.TabIndex = 2;
            btstart.Text = "▶";
            toolTip1.SetToolTip(btstart, "재생");
            btstart.UseVisualStyleBackColor = true;
            btstart.Click += btstart_Click;
            // 
            // btmute
            // 
            btmute.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btmute.FlatAppearance.BorderSize = 0;
            btmute.FlatStyle = FlatStyle.Flat;
            btmute.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btmute.ForeColor = Color.White;
            btmute.Location = new Point(87, 50);
            btmute.Name = "btmute";
            btmute.Size = new Size(40, 38);
            btmute.TabIndex = 4;
            btmute.Text = "🔊";
            toolTip2.SetToolTip(btmute, "음소거");
            btmute.UseVisualStyleBackColor = true;
            btmute.Click += btmute_Click;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(0, 0);
            axWindowsMediaPlayer1.MaximumSize = new Size(1920, 1080);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(864, 511);
            axWindowsMediaPlayer1.TabIndex = 0;
            axWindowsMediaPlayer1.MediaChange += axWindowsMediaPlayer1_MediaChange;
            axWindowsMediaPlayer1.ClickEvent += axWindowsMediaPlayer1_ClickEvent;
            axWindowsMediaPlayer1.DoubleClickEvent += axWindowsMediaPlayer1_DoubleClickEvent;
            axWindowsMediaPlayer1.KeyDownEvent += axWindowsMediaPlayer1_KeyDownEvent;
            axWindowsMediaPlayer1.MouseMoveEvent += axWindowsMediaPlayer1_MouseMoveEvent;
            axWindowsMediaPlayer1.Enter += axWindowsMediaPlayer1_Enter;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // hideControlsTimer
            // 
            hideControlsTimer.Tick += hideControlsTimer_Tick;
            // 
            // singleClickTimer
            // 
            singleClickTimer.Tick += singleClickTimer_Tick;
            // 
            // volumeChangeTimer
            // 
            volumeChangeTimer.Tick += volumeChangeTimer_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(92, 92);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(91, 22);
            toolStripMenuItem1.Text = "0.5";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(91, 22);
            toolStripMenuItem2.Text = "1.0";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(91, 22);
            toolStripMenuItem3.Text = "1.5";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(91, 22);
            toolStripMenuItem4.Text = "2.0";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(20, 20, 20);
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(125, 658);
            label1.Name = "label1";
            label1.Size = new Size(50, 25);
            label1.TabIndex = 6;
            label1.Text = "제목";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(20, 20, 20);
            label2.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(126, 706);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 6;
            label2.Text = "내용";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(125, 758);
            label3.Name = "label3";
            label3.Size = new Size(50, 25);
            label3.TabIndex = 6;
            label3.Text = "댓글";
            // 
            // flowLayoutPanelComments
            // 
            flowLayoutPanelComments.AutoScroll = true;
            flowLayoutPanelComments.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelComments.Location = new Point(128, 792);
            flowLayoutPanelComments.Name = "flowLayoutPanelComments";
            flowLayoutPanelComments.Size = new Size(913, 224);
            flowLayoutPanelComments.TabIndex = 7;
            flowLayoutPanelComments.WrapContents = false;
            // 
            // tbComment
            // 
            tbComment.BackColor = Color.Black;
            tbComment.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbComment.ForeColor = Color.White;
            tbComment.Location = new Point(197, 761);
            tbComment.Name = "tbComment";
            tbComment.Size = new Size(743, 23);
            tbComment.TabIndex = 8;
            // 
            // btComment
            // 
            btComment.FlatStyle = FlatStyle.Flat;
            btComment.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btComment.ForeColor = Color.White;
            btComment.Location = new Point(965, 758);
            btComment.Name = "btComment";
            btComment.Size = new Size(71, 28);
            btComment.TabIndex = 9;
            btComment.Text = "댓글 입력";
            btComment.UseVisualStyleBackColor = true;
            btComment.Click += btComment_Click;
            // 
            // btSubscribe
            // 
            btSubscribe.FlatStyle = FlatStyle.Flat;
            btSubscribe.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btSubscribe.ForeColor = Color.White;
            btSubscribe.Location = new Point(881, 646);
            btSubscribe.Name = "btSubscribe";
            btSubscribe.Size = new Size(75, 37);
            btSubscribe.TabIndex = 10;
            btSubscribe.Text = "구독";
            btSubscribe.UseVisualStyleBackColor = true;
            btSubscribe.Click += btSubscribe_Click;
            // 
            // btFavorite
            // 
            btFavorite.FlatStyle = FlatStyle.Flat;
            btFavorite.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btFavorite.ForeColor = Color.White;
            btFavorite.Location = new Point(962, 646);
            btFavorite.Name = "btFavorite";
            btFavorite.Size = new Size(74, 37);
            btFavorite.TabIndex = 11;
            btFavorite.Text = "재생목록";
            btFavorite.UseVisualStyleBackColor = true;
            btFavorite.Click += btFavorite_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth8Bit;
            imageList2.ImageSize = new Size(16, 16);
            imageList2.TransparentColor = Color.Transparent;
            // 
            // panel3
            // 
            panel3.Location = new Point(524, 603);
            panel3.Name = "panel3";
            panel3.Size = new Size(280, 128);
            panel3.TabIndex = 13;
            // 
            // VideoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(1904, 1041);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanelComments);
            Controls.Add(btComment);
            Controls.Add(label3);
            Controls.Add(tbComment);
            Controls.Add(btFavorite);
            Controls.Add(btSubscribe);
            Controls.Add(panel3);
            ForeColor = Color.White;
            Name = "VideoView";
            Text = "Form1";
            Load += VideoView_Load;
            KeyDown += VideoView_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelControls.ResumeLayout(false);
            panelVolumeBase.ResumeLayout(false);
            panelTrackBase.ResumeLayout(false);
            panelTrackBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panelControls;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button btset;
        private Button btstart;
        private Button btmute;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button button4;
        private Button button5;
        private Button button6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer hideControlsTimer;
        private System.Windows.Forms.Timer singleClickTimer;
        private System.Windows.Forms.Timer volumeChangeTimer;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip3;
        private ToolTip toolTip6;
        private Label label1;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanelComments;
        private Panel panelTrackBase;
        private Panel panelTrackProgress;
        private Panel panelVolumeBase;
        private Panel panelVolumeProgress;
        private TextBox tbComment;
        private Button btComment;
        private Button btSubscribe;
        private Button btFavorite;
        private Panel panel2;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private ImageList imageList2;
        private Panel panel3;
    }
}