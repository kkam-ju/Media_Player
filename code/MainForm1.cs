using AxWMPLib;
using MediaPlayer;
using Microsoft.VisualBasic.Logging;
using Music123;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Threading.Channels;
using System.Windows.Forms;
using WinFormsApp33;

namespace TpMain
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            if (UserSession.Username == null)
            {
                pb_Logout.Visible = false;
                lb_login_suc.Visible = false;
                pb_Login.Visible = true;

                pb_searhbox.Visible = true;
                pb_Login.Visible = true;
                pb_Main.Visible = true;
                pb_premium1.Visible = false;
            }
            else
            {
                pb_Logout.Visible = true;
                lb_login_suc.Text = $"환영합니다! \n{UserSession.Nickname}님";
                lb_login_suc.Visible = true;
                pb_Login.Visible = false;

                pb_searhbox.Visible = false;
                pb_Login.Visible = false;
            }
                
         }

        private void LoadVideos()
        {
            // 기존에 표시된 동영상이 있다면 모두 제거
            flowLayoutPanel1.Controls.Clear();

            try
            {
                List<VideoInfo> videoList = GetVideoDataFromDB();

                // DB에서 가져온 동영상 개수만큼 반복
                foreach (var video in videoList)
                {
                    // 영상 카드 생성
                    Panel panel1 = CreateVideoPanel(video);

                    // 화면의 FlowLayoutPanel에 추가
                    flowLayoutPanel1.Controls.Add(panel1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pb_Mypage_Click(object sender, EventArgs e)
        {
            
            if (UserSession.IsLoggedIn)
            {
                this.Hide();
                MyPage Mpage = new MyPage();  //폼 연결하면 사용
                Mpage.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }

            
        }

        private void pb_premium_Click(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                if (UserSession.IsPremium) // 프리미엄 회원인지 확인
                {
                    // 프리미엄 회원이면 화면을 전환
                    pb_Main.Visible = false;
                    pb_premium1.Visible = true;
                }
                else
                {
                    // 프리미엄 회원이 아니면 안내 메시지
                    DialogResult result = MessageBox.Show("프리미엄 회원이 아닙니다. 프리미엄 서비스를 이용하려면 구독해주세요.\n결제창으로 넘어가시겠습니까?", "프리미엄", MessageBoxButtons.YesNo);
                    //MessageBox.Show("프리미엄 회원이 아닙니다. 프리미엄 서비스를 이용하려면 구독해주세요.");
                    if (result == DialogResult.Yes)
                    {
                        Pay pay = new Pay();
                        pay.Show();
                    }
                    else if (result == DialogResult.No)
                    {

                    }

                }
                //MessageBox.Show("굿");
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }
        }

        private void pb_Music_Click(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                if (UserSession.IsPremium) // 프리미엄 회원인지 확인
                {
                    MusicPlay Mplay = new MusicPlay();  //폼 연결하면 사용
                    Mplay.Show();
                    this.Hide();
                }
                else
                {
                    // 프리미엄 회원이 아니면 안내 메시지
                    DialogResult result = MessageBox.Show("프리미엄 회원이 아닙니다. 프리미엄 서비스를 이용하려면 구독해주세요.\n결제창으로 넘어가시겠습니까?", "프리미엄", MessageBoxButtons.YesNo);
                    //MessageBox.Show("프리미엄 회원이 아닙니다. 프리미엄 서비스를 이용하려면 구독해주세요.");
                    if (result == DialogResult.Yes)
                    {
                        Pay pay = new Pay();
                        pay.Show();
                        this.Hide();
                    }
                    else if (result == DialogResult.No)
                    {

                    }

                }
                //this.Hide();
                //MusicPlay Mplay = new MusicPlay();  //폼 연결하면 사용
                //Mplay.ShowDialog();
                

            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }
        }

        private void pb_sub_Click(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                MyPage f12 = new MyPage();
                f12.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }
        }

        private void pb_playlist_Click(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                MessageBox.Show("굿");
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }
        }

        private void pb_My_video_Click(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                MessageBox.Show("굿");
            }
            else
            {
                MessageBox.Show("로그인을 해주세요.");
            }
        }

        private void pb_Login_Click(object sender, EventArgs e)
        {
            //Login LogForm = new Login();
            //if (LogForm.ShowDialog() == DialogResult.OK)
            //{
            //     lb_login_suc.Visible = true;
            //     pb_searhbox.Visible = false;
            //} //상욱이가 성공하면 사용하는 코드
            //LogForm.ShowDialog();
            
            Login logform = new Login();
            logform.ShowDialog();
            
            if (UserSession.IsLoggedIn)
            {
               timer1.Start();
                lb_login_suc.Text = $"환영합니다! \n{UserSession.Nickname}님";
                lb_login_suc.Visible = true;
                pb_Login.Visible = false;
                
                pb_Logout.Visible = true;
                pb_searhbox.Visible = false;
                LoadVideos();
            }
            //this.Hide();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                UserSession.Logout();
                flowLayoutPanel1.Controls.Clear();
                pb_Login.Visible = true;
                
                pb_Logout.Visible = false;
                pb_searhbox.Visible = true;
                pb_Main.Visible = true;
                pb_premium1.Visible = false;
                // 모든 타이머 중지
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
            }
            else if (result == DialogResult.No)
            { 

            }
                //아무동작 안함
        }
            //pb_Login.Visible = true;
            //pb_video1.Visible = false;
            //pb_video2.Visible = false;
            //pb_video3.Visible = false;
            //pb_video4.Visible = false;
            //pb_video5.Visible = false;
            //pb_video6.Visible = false;
            //pb_Logout.Visible = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("1시간이 지났습니다. 휴식하세요!");
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            MessageBox.Show("2시간이 지났습니다.\n스트레칭을 권유드립니다!");
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            MessageBox.Show("3시간이 지났습니다.\n물한잔 마시고 화장실에 다녀오시길 권유 드립니다!");
            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            DialogResult result = MessageBox.Show("4시간이 지났습니다.\n로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                pb_Login.Visible = true;
                
                pb_Logout.Visible = false;
                //Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                timer1.Start();
            }
        }
            private Panel CreateVideoPanel(VideoInfo video)
        {
            Panel videoPanel = new Panel
            {
                Width = 340,
                Height = 320,
                Margin = new Padding(35),
                BorderStyle = BorderStyle.None
            };

            // 썸네일 추가
            PictureBox thumbnail = new PictureBox
            {
                Width = 320,
                Height = 200,
                Location = new Point(10, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.DarkGray,
                Cursor = Cursors.Hand
            };

            try
            {
                if (!string.IsNullOrEmpty(video.ThumbnailPath) && File.Exists(video.ThumbnailPath))
                {
                    // 파일을 잠그지 않도록 MemoryStream을 사용하여 이미지를 로드합니다.
                    byte[] bytes = File.ReadAllBytes(video.ThumbnailPath);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        thumbnail.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // 리소스에 'DefaultThumbnail'이라는 이름의 이미지가 추가되어 있다고 가정합니다.
                    // thumbnail.Image = Properties.Resources.DefaultThumbnail;
                    thumbnail.Image = null; // 기본 이미지가 없을 경우
                    thumbnail.Invalidate();
                }
            }
            catch (Exception ex)
            {
                // 파일 접근 오류나 이미지 형식 오류 발생 시 처리
                Console.WriteLine($"Error loading thumbnail: {ex.Message}");
                // thumbnail.Image = Properties.Resources.DefaultThumbnail;
                thumbnail.Image = null;
                thumbnail.Invalidate();
            }



            // AxWindowsMediaPlayer 생성 및 초기화
            AxWindowsMediaPlayer wmp = new AxWindowsMediaPlayer
            {
                Width = 320,
                Height = 200,
                Location = new Point(10, 5),
                Enabled = true,
                Visible = false
            };

            ((System.ComponentModel.ISupportInitialize)(wmp)).BeginInit();
            videoPanel.Controls.Add(wmp);
            ((System.ComponentModel.ISupportInitialize)(wmp)).EndInit();

            wmp.URL = video.FilePath;
            wmp.uiMode = "none";
            wmp.Ctlcontrols.stop(); // 자동 재생 방지

            //썸네일에 마우스를 올리면 → 썸네일 숨기고 영상 재생
            thumbnail.MouseEnter += (s, e) =>
            {
                thumbnail.Visible = false;
                wmp.Visible = true;
                wmp.Ctlcontrols.play();
            };


            // 플레이어에서 마우스를 벗어나면 → 재생 중지하고 썸네일 다시 표시
            videoPanel.MouseLeave += (s, e) =>
            {
                wmp.Ctlcontrols.stop();
                wmp.Visible = false;
                thumbnail.Visible = true;
            };

            //// 제목 라벨
            //Label titleLabel = new Label
            //{
            //    Text = video.Title,
            //    Font = new Font("맑은 고딕", 12F, FontStyle.Bold),
            //    Location = new Point(10, 230),
            //    ForeColor = Color.White,
            //    AutoSize = true,
            //    MaximumSize = new Size(320, 0)

            //};

            // 닉네임 라벨
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
                TextAlign = ContentAlignment.MiddleLeft
            };
            nicknameButton.FlatAppearance.BorderSize = 0;

            // 버튼 클릭시 사용자 이름이 바뀜
            nicknameButton.Click += (sender, e) =>
            {
                
            };

            // 버튼 추가
            LinkLabel playLink = new LinkLabel
            {
                Text = $"제목: {video.Title}",
                Location = new Point(10, 210),// 위치는 버튼과 맞게 조절하세요.
                AutoSize = true,               // 텍스트 길이에 맞춰 크기 자동 조절
                Font = new Font("맑은 고딕", 15F, FontStyle.Regular),
                LinkColor = Color.White,       // 링크의 평소 색상
                ActiveLinkColor = Color.LightGray, // 링크를 클릭했을 때 색상
                TextAlign = ContentAlignment.MiddleLeft
            };

            // 링크 클릭 시 메시지 박스 띄우기
            playLink.LinkClicked += (sender, e) =>
            {
                // // 기존 코드
                  // MessageBox.Show($"클릭된 영상 제목: {video.Title}", "알림");

                // --- 새로운 코드 ---
                // VideoView 폼에 영상 경로와 제목을 전달하며 생성
                VideoView videoViewForm = new VideoView(video.FilePath, video.Title);

                // VideoView 폼이 닫힐 때, 다시 메인 폼을 보여주기 위한 이벤트 핸들러 등록
                videoViewForm.FormClosed += (s, args) => this.Show();

                // VideoView 폼을 보여주고, 현재 메인 폼은 숨김
                videoViewForm.Show();
                this.Hide();
            };



            //videoPanel.Controls.Add(titleLabel);


            videoPanel.Controls.Add(thumbnail);
                videoPanel.Controls.Add(nicknameButton);
                videoPanel.Controls.Add(playLink);

                thumbnail.BringToFront();

            


                return videoPanel;
            
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
                    // Posts 테이블(p)과 Users 테이블(u)을 user_id로 JOIN합니다.
                    string query = @"SELECT 
                                p.title, 
                                u.nickname, 
                                p.video_path, 
                                p.video_sum_path
                             FROM 
                                Posts p
                             JOIN 
                                Users u ON p.user_id = u.user_id
                             ORDER BY 
                                p.post_id DESC";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            videoList.Add(new VideoInfo
                            {
                                Title = reader.GetString("title"),
                                // JOIN된 결과에서 'nickname' 컬럼을 직접 읽어옵니다.
                                Nickname = reader.GetString("nickname"),
                                FilePath = reader.GetString("video_path"),
                                ThumbnailPath = reader.GetString("video_sum_path")
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


    }
       
    }

