using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpMain
{
    

    public partial class UpSub : Form
    {
        public string SelectedVideoPath { get; private set; } = "";
        public UpSub()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedVideoPath))
            {
                MessageBox.Show("영상을 먼저 선택해주세요.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();  // 창 닫기
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "동영상 파일 선택";
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.wmv;*.mov;*.mkv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedVideoPath = openFileDialog.FileName;
                lb_Path.Text = SelectedVideoPath;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();  // 그냥 창 닫기
        }
    }
}
