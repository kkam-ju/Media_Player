using AxWMPLib;
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
    public partial class Upload : Form
    {


        public string SelectedVideoPath { get; private set; } = "";
        public string SelectedThumbnailPath { get; private set; } = "";
        public Upload()
        {

            InitializeComponent();

            
        }
        private void SelectAndPlayVideo()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "비디오 파일 선택";
                openFileDialog.Filter = "비디오 파일 (*.mp4; *.avi; *.wmv)|*.mp4;*.avi;*.wmv|모든 파일 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.SelectedVideoPath = openFileDialog.FileName;
                    lb_Path.Text = this.SelectedVideoPath;

                    // 미디어 플레이어로 비디오 재생
                    pictureBox1.Visible = false;
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.URL = this.SelectedVideoPath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            SelectAndPlayVideo();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.URL = null; // URL도 초기화
            axWindowsMediaPlayer1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

            // PictureBox 이미지도 초기화
            pictureBox2.Image = null; // 또는 기본 이미지로 설정

            // 모든 경로 초기화
            lb_Path.Text = "파일을 선택하세요.";
            this.SelectedVideoPath = "";
            this.SelectedThumbnailPath = "";
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //업로드 버튼
        {
            // 1. 비디오 파일이 선택되었는지 확인
            if (string.IsNullOrEmpty(this.SelectedVideoPath))
            {
                MessageBox.Show("업로드할 비디오 파일을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 썸네일 이미지가 선택되었는지 확인
            if (string.IsNullOrEmpty(this.SelectedThumbnailPath))
            {
                MessageBox.Show("영상의 썸네일 이미지를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ▼▼▼ MODIFIED: 생성자에 썸네일 경로도 함께 전달 ▼▼▼
            // 3. Upload2 폼을 생성할 때 비디오와 썸네일 경로를 모두 전달
            Upload2 form2 = new Upload2(this.SelectedVideoPath, this.SelectedThumbnailPath);
            form2.Show();
            this.Close(); // 현재 폼 닫기 (선택사항)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "비디오 파일 선택";
            openFileDialog.Filter = "비디오 파일 (*.mp4; *.avi; *.wmv)|*.mp4;*.avi;*.wmv|모든 파일 (*.*)|*.*";

            // 2. 파일 대화상자를 열고, 사용자가 '열기'를 눌렀을 경우에만 아래 코드를 실행합니다.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // --- 이제부터 모든 작업을 한 곳에서 처리합니다. ---

                this.SelectedVideoPath = openFileDialog.FileName;

                // 4. 파일 경로를 Label에 표시합니다. (lb_Path 컨트롤이 폼에 있어야 합니다)
                lb_Path.Text = this.SelectedVideoPath;

                // 5. PictureBox는 숨기고, 그 자리에 있던 미디어 플레이어를 보이게 합니다.
                //    (pictureBox1과 axWindowsMediaPlayer1이 폼에 있어야 합니다)
                pictureBox1.Visible = false;
                axWindowsMediaPlayer1.Visible = true;

                // 6. 미디어 플레이어에 선택한 비디오를 로드하고 재생합니다.
                axWindowsMediaPlayer1.URL = this.SelectedVideoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void btThum_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "썸네일 이미지 선택";
                // 이미지 파일 필터 설정
                openFileDialog.Filter = "이미지 파일 (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|모든 파일 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.SelectedThumbnailPath = openFileDialog.FileName;

                    // 선택한 이미지로 PictureBox 업데이트
                    try
                    {
                        // 영상을 멈추고 PictureBox를 다시 보이게 함
                        //axWindowsMediaPlayer1.Ctlcontrols.stop();
                        //axWindowsMediaPlayer1.Visible = false;
                        pictureBox1.Visible = false;

                        pictureBox2.Image = Image.FromFile(this.SelectedThumbnailPath);
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"이미지를 불러오는 데 실패했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.SelectedThumbnailPath = ""; // 실패 시 경로 초기화
                    }
                }
            }
        }
    }

}
