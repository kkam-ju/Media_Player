using MySql.Data.MySqlClient; // MySQL용 using 구문
using System;
using System.Windows.Forms;

namespace TpMain
{
    public partial class Upload2 : Form
    {
        // Upload1 폼으로부터 전달받은 영상 파일 경로를 저장하는 변수
        private string videoPathToPlay;
        private string selectedThumbnailPath;


        // 생성자: 다른 폼에서 new Upload2("경로") 형태로 호출될 때 실행됨
        public Upload2(string videoPath, string thumnale)
        {
            InitializeComponent();
            // 전달받은 경로를 클래스 변수에 저장
            this.videoPathToPlay = videoPath;
            this.selectedThumbnailPath = thumnale;
        }

        // 폼이 화면에 처음 나타날 때 실행되는 이벤트
        private void Upload2_Load(object sender, EventArgs e)
        {
            // 전달받은 영상 경로가 있다면 미디어 플레이어에서 재생
            if (!string.IsNullOrEmpty(videoPathToPlay))
            {
                // 폼 디자이너에 axWindowsMediaPlayer2 컨트롤이 있어야 함
                axWindowsMediaPlayer2.URL = videoPathToPlay;
                axWindowsMediaPlayer2.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // --- 1. 사전 준비 ---
            // TODO: 실제로는 LoginSession 같은 곳에서 현재 로그인한 사용자 ID를 가져와야 합니다.
       
            int loggedInUserId = UserSession.UserId;

            // 텍스트박스 내용을 변수에 저장 (폼 디자이너의 컨트롤 이름: textBox1, textBox2)
            string videoTitle = textBox1.Text;
            string videoDescription = textBox2.Text;

            // --- 2. 입력값 확인 ---
            // title은 NOT NULL이므로 반드시 확인해야 합니다.
            if (string.IsNullOrEmpty(videoTitle))
            {
                MessageBox.Show("영상의 제목을 입력해주세요.");
                return;
            }

            // --- 3. DB 연결 및 데이터 저장 ---
            // MySQL 연결 문자열 (자신의 PC 환경에 맞게 수정!)
            string connectionString = "Server=localhost;Port=3306;Database=youtube;Uid=root;Pwd=1234;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // --- 4. posts 테이블에 영상 정보 저장 ---
                    // 보내주신 DB 스키마와 컬럼 이름을 정확히 일치시킨 쿼리입니다.
                    // (post_id, created_at, updated_at, like_count는 DB가 자동 처리)
                    string query = "INSERT INTO posts (user_id, title, content, video_path, video_sum_path) VALUES (@user_id, @title, @content, @video_path, @video_sum_path);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // SQL 파라미터에 값을 채워 넣습니다.
                        cmd.Parameters.AddWithValue("@user_id", loggedInUserId);
                        cmd.Parameters.AddWithValue("@title", videoTitle);
                        cmd.Parameters.AddWithValue("@content", videoDescription);
                        cmd.Parameters.AddWithValue("@video_path", this.videoPathToPlay);

                        // video_sum_path는 NOT NULL이므로, 임시로 video_path와 동일한 값을 넣어줍니다.
                        // TODO: 나중에 썸네일 생성 기능이 추가되면, 실제 썸네일 경로로 변경해야 합니다.
                        cmd.Parameters.AddWithValue("@video_sum_path", this.selectedThumbnailPath);

                        // INSERT 쿼리 실행
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("영상이 성공적으로 업로드되었습니다.");
                        //MainForm1 mainform1=new MainForm1();
                        //mainform1.Show();
                        Form existingForm = Application.OpenForms["MainForm1"];
                        if (existingForm != null)
                        {
                            existingForm.Show();         // 숨겨져 있으면 다시 보이기
                            existingForm.BringToFront(); // 앞으로 가져오기
                        }
                        else
                        {
                            // 없을 경우에만 새로 생성
                            MainForm1 mainForm = new MainForm1();
                            mainForm.Show();
                        }
                        this.Close(); // 성공 후 창 닫기
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DB 작업 중 오류가 발생했습니다: " + ex.Message);
                }
            }
        }
    }
}


