using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TpMain
{

    public partial class MyPage : Form
    {


        public MyPage()
        {
            InitializeComponent();

        }


        private void MyPage_Load(object sender, EventArgs e)
        {
            // 0. 로그인 상태 확인
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("마이페이지를 보려면 로그인이 필요합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // 로그인 안되어 있으면 폼을 닫음
                return;
            }

            // 1. 현재 사용자 정보 설정
            lb_Name.Text = UserSession.Nickname;
            int currentUserId = GetUserIdFromUsername(UserSession.Username);

            if (currentUserId == -1)
            {
                MessageBox.Show("사용자 정보를 불러오는 데 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 2. 패널 비우기
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();

                // 3. 즐겨찾기 목록 로드 및 flowLayoutPanel1에 표시
                List<VideoInfo> favoriteVideos = GetFavoriteVideosFromDB(currentUserId);
                foreach (var video in favoriteVideos)
                {
                    Panel videoPanel = CreateVideoPanel(video);
                    flowLayoutPanel1.Controls.Add(videoPanel);
                }

                // 4. 내가 올린 동영상 목록 로드 및 flowLayoutPanel2에 표시
                List<VideoInfo> uploadedVideos = GetMyUploadedVideosFromDB(currentUserId);
                foreach (var video in uploadedVideos)
                {
                    Panel videoPanel = CreateVideoPanel(video);
                    flowLayoutPanel2.Controls.Add(videoPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 영상 1개의 UI 패널을 생성하는 함수
        /// </summary>
        private Panel CreateVideoPanel(VideoInfo video)
        {
            Panel videoPanel = new Panel
            {
                Width = 340,
                Height = 320,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // 1. 썸네일 PictureBox 생성
            PictureBox thumbnail = new PictureBox
            {
                Width = 320,
                Height = 200,
                Location = new Point(10, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.DarkGray,
                Cursor = Cursors.Hand
            };

            // 2. AxWindowsMediaPlayer 생성 및 단 한 번만 초기화
            AxWindowsMediaPlayer wmp = new AxWindowsMediaPlayer
            {
                Width = 320,
                Height = 200,
                Location = new Point(10, 5),
                Enabled = true,
                Visible = false // 처음엔 보이지 않게
            };
            ((System.ComponentModel.ISupportInitialize)(wmp)).BeginInit();
            videoPanel.Controls.Add(wmp); // 패널에 wmp 추가
            ((System.ComponentModel.ISupportInitialize)(wmp)).EndInit();

            wmp.URL = video.FilePath;
            wmp.uiMode = "none";
            wmp.Ctlcontrols.stop(); // 자동 재생 방지

            // 3. 이벤트 핸들러 단 한 번만 연결
            // 썸네일에 마우스를 올리면 → 썸네일 숨기고 영상 재생
            thumbnail.MouseEnter += (s, e) =>
            {
                thumbnail.Visible = false;
                wmp.Visible = true;
                wmp.Ctlcontrols.play();
            };

            // 패널 영역을 벗어나면 → 재생 중지하고 썸네일 다시 표시
            videoPanel.MouseLeave += (s, e) =>
            {
                wmp.Ctlcontrols.stop();
                wmp.Visible = false;
                thumbnail.Visible = true;
            };

            // 4. 리소스 관리에 유리한 방식으로 이미지 로드
            if (!string.IsNullOrEmpty(video.ThumbnailPath) && System.IO.File.Exists(video.ThumbnailPath))
            {
                try
                {
                    // 파일을 메모리로 읽어 스트림으로 변환 후 이미지 생성 (파일 잠금 방지)
                    byte[] bytes = System.IO.File.ReadAllBytes(video.ThumbnailPath);
                    using (var ms = new System.IO.MemoryStream(bytes))
                    {
                        thumbnail.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception)
                {
                    // 이미지 로딩 실패 시 처리
                }
            }

            // 5. 제목 및 닉네임 버튼 생성
            Button nicknameButton = new Button
            {
                Text = video.Nickname,
                Font = new Font("맑은 고딕", 9F, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 250),
                Width = 320,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            nicknameButton.FlatAppearance.BorderSize = 0;
            // (필요 시 nicknameButton 클릭 이벤트 추가)

            Button playButton = new Button
            {
                Text = $"제목: {video.Title}",
                Location = new Point(10, 200),
                Width = 320,
                Height = 30,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(100, 0, 0, 0), // 반투명 검정
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
            playButton.FlatAppearance.BorderSize = 0;

            playButton.Click += (s, e) =>
            {
                VideoView videoViewForm = new VideoView(video.FilePath, video.Title);
                videoViewForm.Show();
            };

            // 6. 컨트롤들을 패널에 추가
            videoPanel.Controls.Add(nicknameButton);
            videoPanel.Controls.Add(playButton);
            videoPanel.Controls.Add(thumbnail); // 썸네일을 다른 컨트롤보다 나중에 추가

            // 7. 특정 컨트롤을 맨 앞으로 가져오기
            thumbnail.BringToFront();
            playButton.BringToFront();

            return videoPanel;
        }

        // <<< ADDED: 즐겨찾기한 영상 목록을 DB에서 조회하는 메서드
        private List<VideoInfo> GetFavoriteVideosFromDB(int userId)
        {
            var videoList = new List<VideoInfo>();
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            // Favorites, Posts, Users 3개 테이블을 JOIN
            string query = @"SELECT p.title, u.nickname, p.video_path, p.video_sum_path 
                             FROM Favorites f
                             JOIN Posts p ON f.target_id = p.post_id
                             JOIN Users u ON p.user_id = u.user_id
                             WHERE f.user_id = @currentUserId AND f.target_type = 'post'";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@currentUserId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            videoList.Add(new VideoInfo
                            {
                                Title = reader.GetString("title"),
                                Nickname = reader.GetString("nickname"), // 게시글 작성자(채널주인)의 닉네임
                                FilePath = reader.GetString("video_path"),
                                ThumbnailPath = reader.GetString("video_sum_path")
                            });
                        }
                    }
                }
            }
            return videoList;
        }

        private List<VideoInfo> GetMyUploadedVideosFromDB(int userId)
        {
            var videoList = new List<VideoInfo>();
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            // Posts와 Users 테이블을 JOIN
            string query = @"SELECT p.title, u.nickname, p.video_path, p.video_sum_path 
                             FROM Posts p
                             JOIN Users u ON p.user_id = u.user_id
                             WHERE p.user_id = @currentUserId";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@currentUserId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            videoList.Add(new VideoInfo
                            {
                                Title = reader.GetString("title"),
                                Nickname = reader.GetString("nickname"),
                                FilePath = reader.GetString("video_path"),
                                ThumbnailPath = reader.GetString("video_sum_path")
                            });
                        }
                    }
                }
            }
            return videoList;
        }

        // <<< ADDED: Username으로 user_id를 조회하는 헬퍼 메서드
        private int GetUserIdFromUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return -1;

            int userId = -1;
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT user_id FROM Users WHERE username = @username LIMIT 1";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
            }
            return userId;
        }
        /// <summary>
        /// MySQL DB에서 영상 목록 조회
        /// </summary>
        private List<VideoInfo> GetVideoDataFromDB()
        {
            var videoList = new List<VideoInfo>();
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT title, user_id, video_path, video_sum_path FROM posts ORDER BY user_id DESC";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            videoList.Add(new VideoInfo
                            {
                                Title = reader.GetString("title"),
                                Nickname = reader.GetInt32(reader.GetOrdinal("user_id")).ToString(),
                                FilePath = reader.GetString("video_path"),
                                ThumbnailPath = reader.GetString("video_sum_path")
                                //ThumbnailPath = reader.GetString("video_sum_path")

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터베이스 오류: {ex.Message}", "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return videoList;
        }

        private void btn_goUp_Click(object sender, EventArgs e)
        {
            Upload upload = new Upload();
            upload.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            this.Hide();
            //MainForm1 mainform = new MainForm1();  //폼 연결하면 사용
            //mainform.Show();
        }
    }
}
