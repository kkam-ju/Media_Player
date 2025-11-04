using  Music123;

namespace Music123
{
    partial class MusicPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlay));
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            panelTrackBase = new Panel();
            panelTrackProgress = new Panel();
            panel1 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            pb_Start = new PictureBox();
            pictureBox3 = new PictureBox();
            pb_next = new PictureBox();
            pb_Back = new PictureBox();
            pictureBox1 = new PictureBox();
            pb_Go_Main = new PictureBox();
            lb_Timenow = new Label();
            lb_TotalTime = new Label();
            label3 = new Label();
            pb_music1 = new PictureBox();
            lv_MusicList = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            pb_music3 = new PictureBox();
            pb_music2 = new PictureBox();
            pb_sound = new PictureBox();
            panel_sound = new Panel();
            panel_vol = new Panel();
            pb_soundoff = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            panelTrackBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Start).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_next).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Back).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Go_Main).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_music1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_music3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_music2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_sound).BeginInit();
            panel_sound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_soundoff).BeginInit();
            SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(1845, 800);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(31, 36);
            axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // panelTrackBase
            // 
            panelTrackBase.BackColor = SystemColors.ActiveCaptionText;
            panelTrackBase.Controls.Add(panelTrackProgress);
            panelTrackBase.Controls.Add(panel1);
            panelTrackBase.Location = new Point(3, 854);
            panelTrackBase.Name = "panelTrackBase";
            panelTrackBase.Size = new Size(1889, 27);
            panelTrackBase.TabIndex = 1;
            panelTrackBase.MouseDown += panelTrackBase_MouseDown;
            // 
            // panelTrackProgress
            // 
            panelTrackProgress.BackColor = Color.Red;
            panelTrackProgress.Location = new Point(0, 9);
            panelTrackProgress.Name = "panelTrackProgress";
            panelTrackProgress.Size = new Size(1886, 10);
            panelTrackProgress.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(0, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1886, 4);
            panel1.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pb_Start
            // 
            pb_Start.Image = (Image)resources.GetObject("pb_Start.Image");
            pb_Start.Location = new Point(139, 903);
            pb_Start.Name = "pb_Start";
            pb_Start.Size = new Size(46, 40);
            pb_Start.TabIndex = 2;
            pb_Start.TabStop = false;
            pb_Start.Click += pb_Start_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(141, 903);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pb_next
            // 
            pb_next.Image = (Image)resources.GetObject("pb_next.Image");
            pb_next.Location = new Point(187, 907);
            pb_next.Name = "pb_next";
            pb_next.Size = new Size(44, 40);
            pb_next.TabIndex = 2;
            pb_next.TabStop = false;
            pb_next.Click += pb_next_Click;
            // 
            // pb_Back
            // 
            pb_Back.Image = (Image)resources.GetObject("pb_Back.Image");
            pb_Back.Location = new Point(100, 907);
            pb_Back.Name = "pb_Back";
            pb_Back.Size = new Size(44, 40);
            pb_Back.TabIndex = 2;
            pb_Back.TabStop = false;
            pb_Back.Click += pb_Back_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 48);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pb_Go_Main
            // 
            pb_Go_Main.Image = (Image)resources.GetObject("pb_Go_Main.Image");
            pb_Go_Main.Location = new Point(3, 66);
            pb_Go_Main.Name = "pb_Go_Main";
            pb_Go_Main.Size = new Size(58, 62);
            pb_Go_Main.TabIndex = 4;
            pb_Go_Main.TabStop = false;
            pb_Go_Main.Click += pb_Go_Main_Click;
            // 
            // lb_Timenow
            // 
            lb_Timenow.AutoSize = true;
            lb_Timenow.ForeColor = SystemColors.ControlLightLight;
            lb_Timenow.Location = new Point(252, 919);
            lb_Timenow.Name = "lb_Timenow";
            lb_Timenow.Size = new Size(17, 15);
            lb_Timenow.TabIndex = 5;
            lb_Timenow.Text = "--";
            // 
            // lb_TotalTime
            // 
            lb_TotalTime.AutoSize = true;
            lb_TotalTime.ForeColor = SystemColors.ControlLightLight;
            lb_TotalTime.Location = new Point(305, 919);
            lb_TotalTime.Name = "lb_TotalTime";
            lb_TotalTime.Size = new Size(17, 15);
            lb_TotalTime.TabIndex = 5;
            lb_TotalTime.Text = "--";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(280, 915);
            label3.Name = "label3";
            label3.Size = new Size(16, 20);
            label3.TabIndex = 5;
            label3.Text = "/";
            // 
            // pb_music1
            // 
            pb_music1.BackColor = Color.Transparent;
            pb_music1.Location = new Point(600, 134);
            pb_music1.Name = "pb_music1";
            pb_music1.Size = new Size(550, 550);
            pb_music1.TabIndex = 6;
            pb_music1.TabStop = false;
            pb_music1.Click += pb_music1_Click;
            // 
            // lv_MusicList
            // 
            lv_MusicList.BackColor = Color.Black;
            lv_MusicList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lv_MusicList.ForeColor = SystemColors.Window;
            lv_MusicList.FullRowSelect = true;
            lv_MusicList.Location = new Point(1592, 134);
            lv_MusicList.Name = "lv_MusicList";
            lv_MusicList.OwnerDraw = true;
            lv_MusicList.Size = new Size(297, 550);
            lv_MusicList.TabIndex = 7;
            lv_MusicList.UseCompatibleStateImageBehavior = false;
            lv_MusicList.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "No.";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Title";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Artist";
            columnHeader3.Width = 110;
            // 
            // pb_music3
            // 
            pb_music3.BackColor = Color.Transparent;
            pb_music3.Location = new Point(1227, 234);
            pb_music3.Name = "pb_music3";
            pb_music3.Size = new Size(335, 330);
            pb_music3.TabIndex = 8;
            pb_music3.TabStop = false;
            // 
            // pb_music2
            // 
            pb_music2.BackColor = Color.Transparent;
            pb_music2.Location = new Point(187, 234);
            pb_music2.Name = "pb_music2";
            pb_music2.Size = new Size(335, 330);
            pb_music2.TabIndex = 8;
            pb_music2.TabStop = false;
            // 
            // pb_sound
            // 
            pb_sound.Image = (Image)resources.GetObject("pb_sound.Image");
            pb_sound.Location = new Point(1604, 915);
            pb_sound.Name = "pb_sound";
            pb_sound.Size = new Size(45, 32);
            pb_sound.TabIndex = 9;
            pb_sound.TabStop = false;
            pb_sound.Click += pb_sound_Click;
            // 
            // panel_sound
            // 
            panel_sound.Controls.Add(panel_vol);
            panel_sound.Location = new Point(1655, 914);
            panel_sound.Name = "panel_sound";
            panel_sound.Size = new Size(207, 29);
            panel_sound.TabIndex = 10;
            // 
            // panel_vol
            // 
            panel_vol.BackColor = Color.Red;
            panel_vol.Location = new Point(3, 10);
            panel_vol.Name = "panel_vol";
            panel_vol.Size = new Size(194, 10);
            panel_vol.TabIndex = 11;
            // 
            // pb_soundoff
            // 
            pb_soundoff.Image = (Image)resources.GetObject("pb_soundoff.Image");
            pb_soundoff.Location = new Point(1605, 912);
            pb_soundoff.Name = "pb_soundoff";
            pb_soundoff.Size = new Size(41, 46);
            pb_soundoff.TabIndex = 11;
            pb_soundoff.TabStop = false;
            pb_soundoff.Click += pb_soundoff_Click;
            // 
            // MusicPlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel_sound);
            Controls.Add(pb_sound);
            Controls.Add(pb_music2);
            Controls.Add(pb_music3);
            Controls.Add(lv_MusicList);
            Controls.Add(pb_music1);
            Controls.Add(label3);
            Controls.Add(lb_TotalTime);
            Controls.Add(lb_Timenow);
            Controls.Add(pb_Go_Main);
            Controls.Add(pictureBox1);
            Controls.Add(pb_Back);
            Controls.Add(pb_next);
            Controls.Add(panelTrackBase);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(pb_soundoff);
            Controls.Add(pb_Start);
            Controls.Add(pictureBox3);
            Name = "MusicPlay";
            Text = " ";
            Load += MusicPlay_Load;
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            panelTrackBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Start).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_next).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Back).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Go_Main).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_music1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_music3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_music2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_sound).EndInit();
            panel_sound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_soundoff).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Panel panelTrackBase;
        private Panel panelTrackProgress;
        private CircleSlider pictureSlider;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pb_Start;
        private PictureBox pictureBox3;
        private PictureBox pb_next;
        private PictureBox pb_Back;
        private PictureBox pictureBox1;
        private PictureBox pb_Go_Main;
        private Label lb_Timenow;
        private Label lb_TotalTime;
        private Label label3;
        private PictureBox pb_music1;
        private ListView lv_MusicList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private PictureBox pb_music3;
        private PictureBox pb_music2;
        private PictureBox pb_sound;
        private Panel panel_sound;
        private Panel panel_vol;
        private Panel panel1;
        private PictureBox pb_soundoff;
    }
}
