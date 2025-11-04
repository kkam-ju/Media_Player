using MySql.Data.MySqlClient;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace TpMain
{
    public partial class VideoView : Form
    {
        private Point lastMousePosition;
        // MainForm으로부터 전달받을 비디오 경로와 제목을 저장할 변수
        private string videoPath;
        private string videoTitle;
        private int currentPostId = -1; // 현재 게시글의 ID를 저장할 변수
        private PictureBox pictureSlider; // 슬라이더 핸들
        private bool isDragging = false;  // 슬라이더를 드래그 중인지 여부
        private Point mouseOffset;        // 마우스 오프셋
        private PictureBox volumeSlider;
        private bool isVolumeDragging = false;
        private int currentChannelId = -1;


        public VideoView()
        {
            InitializeComponent();
            InitializeCommentControls();
        }

        public VideoView(string path, string title)
        {
            InitializeComponent();

            // 전달받은 값들을 멤버 변수에 저장
            this.videoPath = path;
            this.videoTitle = title;
        }

        private void InitializeCommentControls()
        {
            // 이 메서드는 예시이며, 실제로는 폼 디자이너에서 컨트롤을 추가하고 속성을 설정해야 합니다.
            // 아래 코드는 디자이너에서 컨트롤을 추가했다는 가정 하에 진행됩니다.
            // 만약 코드로 컨트롤을 생성해야 한다면, 여기에 위치, 크기 등 속성 설정을 추가하세요.

            // flowLayoutPanelComments (디자이너에 이미 있다고 가정)
            // this.flowLayoutPanelComments = new FlowLayoutPanel();
            // ...

            // tbComment
            this.tbComment = new TextBox();
            this.tbComment.Location = new Point(12, 650); // 위치는 예시입니다.
            this.tbComment.Size = new Size(500, 23);
            this.Controls.Add(this.tbComment);


            // btComment
            this.btComment = new Button();
            this.btComment.Location = new Point(520, 650); // 위치는 예시입니다.
            this.btComment.Size = new Size(75, 23);
            this.btComment.Text = "댓글 등록";
            this.btComment.Click += new System.EventHandler(this.btComment_Click); // 이벤트 핸들러 연결
            this.Controls.Add(this.btComment);
        }

        private void btset_Click(object sender, EventArgs e)     //톱니바퀴 버튼을 누르면 contextMenuStrip이 설정위에 뜨도록하기
        {
            Button btn = sender as Button;

            // 2. 메뉴가 나타날 위치를 계산합니다. (버튼 바로 위)
            //    메뉴의 높이만큼 위쪽으로 이동시킵니다.
            Point menuPosition = new Point(0, -contextMenuStrip1.Height);

            // 3. ContextMenuStrip을 버튼의 계산된 위치에 표시합니다.
            contextMenuStrip1.Show(btn, menuPosition);
        }


        private void btstart_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btstart.Text = "▶"; // 버튼 모양을 '재생'으로 변경
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btstart.Text = "❚❚"; // 버튼 모양을 '일시정지'로 변경
            }
        }

        private void btmute_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.mute = !axWindowsMediaPlayer1.settings.mute;

            // 음소거 상태에 따라 버튼 텍스트(아이콘)를 변경합니다.
            if (axWindowsMediaPlayer1.settings.mute)
            {
                btmute.Text = "🔊"; // 음소거 상태일 때는 '소리 켜기' 아이콘 표시
            }
            else
            {
                btmute.Text = "🔇"; // 소리가 켜진 상태일 때는 '음소거' 아이콘 표시
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)        //전체화면 버튼
        {
            // 현재 패널이 영화관 모드 상태인지 확인
            if (panel1.Dock == DockStyle.None || panel1.Dock == DockStyle.Top)
            {
                // 맞다면 원래대로 복원
                panel1.Dock = DockStyle.Fill;
            }
            else
            {
                panel1.Dock = DockStyle.None;
            }
            panel1.Focus(); //패널1의 포커스를 다른곳으로 돌려 스페이스바를 누르면 최대최소되는 것을 방지    
        }



        private void VideoView_Load(object sender, EventArgs e)
        {
            // 기존 UI 및 미디어 플레이어 설정
            label1.Text = videoTitle;
            axWindowsMediaPlayer1.URL = videoPath;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.autoStart = false; // 자동 시작 비활성화
            btstart.Text = "▶";
            btmute.Text = "🔇";
            btset.Text = "⚙️";
            toolStripMenuItem2.Checked = true; // 기본 배속 1.0
            this.KeyPreview = true;
            hideControlsTimer.Interval = 3000;
            lastMousePosition = Cursor.Position;
            timer1.Start();

            InitializeCustomSlider();
            InitializeVolumeSlider();
            InitializeSubscribeButton();
            InitializeFavoriteButton();

            // DB에서 콘텐츠 및 댓글 로드
            try
            {
                // ▼▼▼ MODIFIED: 수정된 로직 ▼▼▼
                LoadPostDetailsFromDB(this.videoTitle);

                if (this.currentPostId != -1)
                {
                    LoadComments(this.currentPostId);
                    CheckSubscriptionStatus();
                    CheckFavoriteStatus();   // <<< ADDED: 즐겨찾기 상태 확인 및 버튼 업데이트
                }
                else
                {
                    label2.Text = "영상 정보를 불러오는 데 실패했습니다.";
                    btSubscribe.Enabled = false;
                    btFavorite.Enabled = false; // <<< ADDED: 정보가 없으면 즐겨찾기 버튼도 비활성화
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSubscribeButton()
        {
            this.btSubscribe = new Button();
            // 이 부분은 디자이너에서 버튼을 추가했다면 필요 없습니다.
            // 만약 코드로 버튼을 추가해야 한다면 아래 속성들을 설정하세요.
            this.btSubscribe.Text = "구독";
            this.btSubscribe.Location = new Point(600, 650); // 위치는 예시입니다. 적절히 조정하세요.
            this.btSubscribe.Size = new Size(80, 23);
            this.btSubscribe.Click += new System.EventHandler(this.btSubscribe_Click);
            this.Controls.Add(this.btSubscribe); // 폼에 버튼 추가
        }

        // <<< ADDED: 게시글의 상세 정보(ID, 내용, 작성자ID)를 한번에 불러오는 메서드
        private void LoadPostDetailsFromDB(string title)
        {
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT post_id, content, user_id FROM Posts WHERE title = @title LIMIT 1";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.currentPostId = Convert.ToInt32(reader["post_id"]);
                            label2.Text = reader["content"].ToString(); // 게시글 설명 설정
                            this.currentChannelId = Convert.ToInt32(reader["user_id"]); // 채널(게시자) ID 저장
                        }
                    }
                }
            }
        }

        // <<< ADDED: 현재 사용자가 이 채널을 구독했는지 확인하는 메서드
        private void CheckSubscriptionStatus()
        {
            if (!UserSession.IsLoggedIn || this.currentChannelId == -1)
            {
                btSubscribe.Text = "구독";
                // 로그인하지 않았으면 구독 버튼은 비활성화
                btSubscribe.Enabled = UserSession.IsLoggedIn;
                return;
            }

            // ▼▼▼ MODIFIED PART ▼▼▼
            // UserSession.Username으로 DB에서 subscriber_id를 가져옵니다.
            int subscriberId = GetUserIdFromUsername(UserSession.Username);
            if (subscriberId == -1)
            {
                // 사용자 ID를 찾을 수 없는 예외적인 경우
                btSubscribe.Enabled = false;
                return;
            }
            // ▲▲▲ MODIFIED PART ▲▲▲


            bool isSubscribed = false;
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM subscriptions WHERE subscriber_id = @subscriberId AND channel_id = @channelId";
                using (var command = new MySqlCommand(query, connection))
                {
                    // ▼▼▼ MODIFIED PART ▼▼▼
                    command.Parameters.AddWithValue("@subscriberId", subscriberId); // 조회된 ID 사용
                    command.Parameters.AddWithValue("@channelId", this.currentChannelId);

                    isSubscribed = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }

            // 자기 자신을 구독하는 경우 버튼 비활성화
            if (subscriberId == this.currentChannelId)
            {
                btSubscribe.Text = "내 채널";
                btSubscribe.Enabled = false;
                return;
            }

            if (isSubscribed)
            {
                btSubscribe.Text = "구독중";
                btSubscribe.Enabled = false;
            }
            else
            {
                btSubscribe.Text = "구독";
                btSubscribe.Enabled = true;
            }
        }
        private int GetUserIdFromUsername(string username)
        {
            // username이 없는 경우 -1 반환
            if (string.IsNullOrEmpty(username))
            {
                return -1;
            }

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

        // --- ADDED: 볼륨 슬라이더 초기화 메서드 ---
        private void InitializeVolumeSlider()
        {
            volumeSlider = new PictureBox
            {
                Size = new Size(14, 14),
                BackColor = Color.Transparent,
                Visible = true
            };

            volumeSlider.Paint += pictureSlider_Paint; // 같은 Paint 이벤트 사용
            volumeSlider.MouseDown += volumeSlider_MouseDown;
            volumeSlider.MouseMove += volumeSlider_MouseMove;
            volumeSlider.MouseUp += volumeSlider_MouseUp;

            panelVolumeBase.MouseDown += panelVolumeBase_MouseDown;

            panelControls.Controls.Add(volumeSlider);
            volumeSlider.BringToFront();

            panelVolumeProgress.Height = 4;
            panelVolumeProgress.Top = (panelVolumeBase.Height - panelVolumeProgress.Height) / 2;

            // 초기 볼륨 설정
            SetVolume(axWindowsMediaPlayer1.settings.volume);
        }

        // --- ADDED: 커스텀 슬라이더 초기화 메서드 ---
        private void InitializeCustomSlider()
        {
            // pictureSlider 생성 및 초기화
            pictureSlider = new PictureBox();
            pictureSlider.Size = new Size(14, 14); // 핸들 크기
            pictureSlider.BackColor = Color.Transparent;
            pictureSlider.Visible = true;

            // 이벤트 등록
            pictureSlider.Paint += pictureSlider_Paint;
            pictureSlider.MouseDown += pictureSlider_MouseDown;
            pictureSlider.MouseMove += pictureSlider_MouseMove;
            pictureSlider.MouseUp += pictureSlider_MouseUp;

            // 트랙 베이스 패널 마우스 다운 이벤트 등록
            panelTrackBase.MouseDown += panelTrackBase_MouseDown;

            // 컨트롤들을 담고 있는 부모 패널(panelControls)에 추가
            panelControls.Controls.Add(pictureSlider);
            pictureSlider.BringToFront();

            // 진행 바 및 슬라이더 위치 초기화
            panelTrackProgress.Height = 4;
            panelTrackProgress.Top = (panelTrackBase.Height - panelTrackProgress.Height) / 2;
            panelTrackProgress.Width = 0;

            pictureSlider.Top = (panelTrackBase.Height - pictureSlider.Height) / 2;
            pictureSlider.Left = panelTrackBase.Left - (pictureSlider.Width / 2);
        }

        private void InitializeFavoriteButton()
        {
            // 이 코드는 디자이너에서 버튼을 추가했을 경우 시각적인 위치/크기 조정 외에는 필수가 아닙니다.
            // 만약 코드로 컨트롤을 생성해야 한다면 아래와 같이 속성을 설정하세요.
            this.btFavorite = new Button();
            this.btFavorite.Text = "즐겨찾기";
            this.btFavorite.Location = new Point(690, 650); // 위치는 예시입니다. 구독 버튼 옆으로 조정하세요.
            this.btFavorite.Size = new Size(80, 23);
            this.btFavorite.Click += new System.EventHandler(this.btFavorite_Click);
            this.Controls.Add(this.btFavorite); // 폼에 버튼 추가
        }

        private void hideControlsTimer_Tick(object sender, EventArgs e)
        {
            hideControlsTimer.Stop(); // 타이머는 한 번만 실행하고 멈춥니다.

            if (!panelControls.ClientRectangle.Contains(panelControls.PointToClient(Cursor.Position)))
            {
                panelControls.Visible = false;
            }
        }

        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (Cursor.Position != lastMousePosition)
            {
                panelControls.Visible = true;
                hideControlsTimer.Stop();
                hideControlsTimer.Start();
            }

            // 현재 위치를 마지막 위치로 저장
            lastMousePosition = Cursor.Position;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null && axWindowsMediaPlayer1.currentMedia.duration > 0)
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying && !isDragging)
                {
                    double ratio = axWindowsMediaPlayer1.Ctlcontrols.currentPosition / axWindowsMediaPlayer1.currentMedia.duration;
                    int progressWidth = (int)(panelTrackBase.Width * ratio);
                    UpdateSliderUIPosition(progressWidth);
                }
            }
        }


        private void axWindowsMediaPlayer1_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                // 이제 trackBar1.Maximum을 설정할 필요가 없습니다.
                // timer1.Start()는 Load 이벤트에서 이미 호출됩니다.
            }
        }

        private void pictureSlider_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Brush b = new SolidBrush(Color.White)) // 핸들 색상
            {
                e.Graphics.FillEllipse(b, 0, 0, pictureSlider.Width - 1, pictureSlider.Height - 1);
            }
        }
        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (axWindowsMediaPlayer1.currentMedia == null || trackBar1.Maximum == 0)
            //{
            //    return;
            //}

            //// 1. 트랙바의 전체 너비에서 마우스가 클릭한 X좌표의 비율을 계산합니다.
            //double clickRatio = (double)e.X / (double)trackBar1.ClientSize.Width;

            //// 2. 그 비율을 트랙바의 최대값에 곱하여 예상 위치 값을 계산합니다.
            //int newPositionValue = (int)(clickRatio * trackBar1.Maximum);

            //// [방어 코드 2]
            //// 계산된 값이 범위를 벗어나지 않도록 강제로 보정합니다.
            //if (newPositionValue < trackBar1.Minimum) newPositionValue = trackBar1.Minimum;
            //if (newPositionValue > trackBar1.Maximum) newPositionValue = trackBar1.Maximum;

            //// 3. 최종 보정된 값으로 트랙바와 영상 위치를 설정합니다.
            //trackBar1.Value = newPositionValue;
            //axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar1.Value;
        }

        //마우스가 재생바 위에 잇을때
        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (axWindowsMediaPlayer1.currentMedia == null) return;

            //double clickRatio = (double)e.X / (double)trackBar1.ClientSize.Width;
            //int newPositionValue = (int)(clickRatio * trackBar1.Maximum);
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                btstart.Text = "▶"; // 버튼 모양을 '재생'으로 변경
                                    // 일시정지합니다.

                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else // 영상이 정지 또는 일시정지 상태라면,
            {
                // 재생합니다.
                btstart.Text = "❚❚"; // 버튼 모양을 '일시정지'로 변경

                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //// 트랙바의 값을 미디어 플레이어의 볼륨에 바로 적용합니다.
            //axWindowsMediaPlayer1.settings.volume = trackBar2.Value;

            //// 볼륨 조절 시 음소거 상태이면 음소거를 해제합니다.
            //if (axWindowsMediaPlayer1.settings.volume > 0 && axWindowsMediaPlayer1.settings.mute)
            //{
            //    axWindowsMediaPlayer1.settings.mute = false;
            //    btmute.Text = "🔇"; // 음소거 아이콘으로 변경
            //}
        }

        private void axWindowsMediaPlayer1_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {

        }

        private void VideoView_KeyDown(object sender, KeyEventArgs e)
        {
            // 현재 재생 중인 미디어가 없으면 아무 작업도 하지 않음
            if (axWindowsMediaPlayer1.currentMedia == null) return;

            double currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            double duration = axWindowsMediaPlayer1.currentMedia.duration;

            // 왼쪽 방향키를 눌렀을 때
            if (e.KeyCode == Keys.Left)
            {
                double newPosition = currentPosition - 10;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = newPosition < 0 ? 0 : newPosition;
            }
            // 오른쪽 방향키를 눌렀을 때
            else if (e.KeyCode == Keys.Right)
            {
                double newPosition = currentPosition + 10;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = newPosition > duration ? duration : newPosition;
            }
            // ▼▼▼ [추가] 스페이스바를 눌렀을 때 ▼▼▼
            else if (e.KeyCode == Keys.Space)
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    btstart.Text = "▶"; // 버튼 아이콘을 '재생'으로 변경
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    btstart.Text = "❚❚"; // 버튼 아이콘을 '일시정지'로 변경
                }
            }
            //esc누르면 초기화면으로 전환
            else if (e.KeyCode == Keys.Escape)
            {
                panel1.Dock = DockStyle.None;
            }
        }

        private void button5_Click(object sender, EventArgs e)   //영화관모드 버튼
        {
            // 현재 패널이 영화관 모드 상태인지 확인
            if (panel1.Dock == DockStyle.None || panel1.Dock == DockStyle.Fill)
            {
                // 맞다면 원래대로 복원
                panel1.Dock = DockStyle.Top;
            }
            else
            {
                panel1.Dock = DockStyle.None;
            }

        }
        private void CheckFavoriteStatus()
        {
            if (!UserSession.IsLoggedIn || this.currentPostId == -1)
            {
                btFavorite.Text = "즐겨찾기";
                btFavorite.Enabled = UserSession.IsLoggedIn;
                return;
            }

            int userId = GetUserIdFromUsername(UserSession.Username);
            if (userId == -1)
            {
                btFavorite.Enabled = false;
                return;
            }

            bool isFavorited = false;
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // [수정] 컬럼 이름을 target_type, target_id로 변경하고, 값은 소문자 'post'로 통일합니다.
                string query = "SELECT COUNT(1) FROM Favorites WHERE user_id = @userId AND target_type = 'post' AND target_id = @postId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@postId", this.currentPostId);

                    isFavorited = Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }

            if (isFavorited)
            {
                btFavorite.Text = "즐겨찾기됨";
                btFavorite.Enabled = false;
            }
            else
            {
                btFavorite.Text = "즐겨찾기";
                btFavorite.Enabled = true;
            }
        }
        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            if (panel1.Dock == DockStyle.None)
            {
                panel1.Dock = DockStyle.Fill;
            }
            else
                panel1.Dock = DockStyle.None;
        }

        private void trackBar2_MouseDown(object sender, MouseEventArgs e)
        {
            //if (trackBar2.Maximum == trackBar2.Minimum)
            //{
            //    return; // 최소/최대 값이 같으면 처리하지 않음
            //}

            //// 1. 트랙바의 전체 너비에서 마우스가 클릭한 X좌표의 비율을 계산합니다.
            //double clickRatio = (double)e.X / (double)trackBar2.ClientSize.Width;

            //// 2. 그 비율을 트랙바의 최대값과 최소값 사이의 범위에 곱하여 예상 볼륨 값을 계산합니다.
            //int newVolumeValue = trackBar2.Minimum + (int)(clickRatio * (trackBar2.Maximum - trackBar2.Minimum));

            //// 3. 계산된 값으로 볼륨을 설정합니다.
            //trackBar2.Value = newVolumeValue;

            //// [추가] 볼륨 조절 시 음소거 상태이면 해제
            //if (axWindowsMediaPlayer1.settings.mute && newVolumeValue > 0)
            //{
            //    axWindowsMediaPlayer1.settings.mute = false;
            //    btmute.Text = "🔇"; // 음소거 아이콘 업데이트
            //}
            //else if (newVolumeValue == 0)
            //{
            //    axWindowsMediaPlayer1.settings.mute = true;
            //    btmute.Text = "🔊"; // 음소거 아이콘 업데이트
            //}
            //axWindowsMediaPlayer1.settings.volume = newVolumeValue; // 즉시 볼륨 적용
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.rate = 0.5;

            // 체크 표시 관리
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.rate = 1.0;

            // 체크 표시 관리
            toolStripMenuItem1.Checked = false;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.rate = 1.5;

            // 체크 표시 관리
            toolStripMenuItem1.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.rate = 2.0;

            // 체크 표시 관리
            toolStripMenuItem1.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
        }

        private void singleClickTimer_Tick(object sender, EventArgs e)
        {

        }

        private void volumeChangeTimer_Tick(object sender, EventArgs e)
        {

        }
        private void LoadComments(int postId)
        {
            // 기존 댓글 컨트롤들을 모두 제거
            flowLayoutPanelComments.Controls.Clear();

            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Comments 테이블과 Users 테이블을 JOIN하여 닉네임과 댓글 내용을 함께 가져옵니다.
                string query = @"SELECT u.nickname, c.content, c.created_at 
                                 FROM Comments c 
                                 JOIN Users u ON c.user_id = u.user_id 
                                 WHERE c.post_id = @postId 
                                 ORDER BY c.created_at ASC";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nickname = reader["nickname"].ToString();
                            string content = reader["content"].ToString();
                            DateTime createdAt = Convert.ToDateTime(reader["created_at"]);

                            // 각 댓글을 표시할 Label 생성
                            Label commentLabel = new Label
                            {
                                Text = $"{nickname}: {content} ({createdAt:yyyy-MM-dd HH:mm})",
                                Font = new Font("맑은 고딕", 9F, FontStyle.Regular),
                                ForeColor = Color.White,
                                AutoSize = true, // 내용에 맞게 크기 자동 조절
                                Margin = new Padding(5) // 다른 댓글과의 간격
                            };

                            // FlowLayoutPanel에 댓글 라벨 추가
                            flowLayoutPanelComments.Controls.Add(commentLabel);
                        }
                    }
                }
            }
        }

        private int GetPostIdFromTitle(string title)
        {
            int postId = -1;
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT post_id FROM Posts WHERE title = @title LIMIT 1";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        postId = Convert.ToInt32(result);
                    }
                }
            }
            return postId;
        }



        private string GetContentFromDB(string title)
        {
            string content = string.Empty;
            // DB 연결 문자열 (MainForm1과 동일하게 설정)
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            // using 구문을 사용하여 DB 연결을 안전하게 관리
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // SQL Injection 공격을 방지하기 위해 파라미터화된 쿼리 사용
                string query = "SELECT content FROM Posts WHERE title = @title LIMIT 1";

                using (var command = new MySqlCommand(query, connection))
                {
                    // 쿼리의 @title 파라미터에 실제 제목 값을 바인딩
                    command.Parameters.AddWithValue("@title", title);

                    // 쿼리 실행 후 결과에서 첫 번째 행, 첫 번째 열의 값을 가져옴
                    // 결과가 없으면 null을 반환
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        content = result.ToString();
                    }
                    else
                    {
                        content = "해당 영상에 대한 설명이 없습니다.";
                    }
                }
            }
            return content;
        }

        private void panelTrackBase_MouseDown(object sender, MouseEventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null && axWindowsMediaPlayer1.currentMedia.duration > 0)
            {
                // 클릭한 위치로 재생 시점 이동
                double clickRatio = (double)e.X / panelTrackBase.Width;
                double duration = axWindowsMediaPlayer1.currentMedia.duration;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = duration * clickRatio;

                // UI 즉시 업데이트
                UpdateSliderUIPosition(e.X);
            }
        }
        private void pictureSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseOffset = e.Location;
            }
        }

        private void pictureSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // pictureSlider는 panelControls를 기준으로 움직이므로,
                // panelTrackBase의 시작점(Left)을 기준으로 새 위치를 계산해야 합니다.
                Point newLocationInParent = pictureSlider.Parent.PointToClient(Cursor.Position);
                int newX = newLocationInParent.X - mouseOffset.X;

                // 트랙 바 내부로 위치 제한
                int minX = panelTrackBase.Left - (pictureSlider.Width / 2);
                int maxX = panelTrackBase.Right - (pictureSlider.Width / 2);
                newX = Math.Max(minX, Math.Min(newX, maxX));

                pictureSlider.Left = newX;

                // 실제 재생 위치 계산 (핸들 중심 기준)
                int sliderPositionInTrack = newX - panelTrackBase.Left + (pictureSlider.Width / 2);

                // UI 업데이트
                UpdateSliderUIPosition(sliderPositionInTrack);

                // 음악 위치 업데이트
                if (axWindowsMediaPlayer1.currentMedia != null && axWindowsMediaPlayer1.currentMedia.duration > 0)
                {
                    double ratio = (double)sliderPositionInTrack / panelTrackBase.Width;
                    ratio = Math.Max(0, Math.Min(1, ratio)); // 0과 1 사이 값으로 보정
                    double duration = axWindowsMediaPlayer1.currentMedia.duration;
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition = duration * ratio;
                }
            }
        }
        // --- ADDED: 볼륨 슬라이더 이벤트 ---
        private void panelVolumeBase_MouseDown(object sender, MouseEventArgs e)
        {
            double clickRatio = (double)e.X / panelVolumeBase.Width;
            int newVolume = (int)(clickRatio * 100);
            SetVolume(newVolume);
        }
        private void volumeSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { isVolumeDragging = true; mouseOffset = e.Location; }
        }
        private void volumeSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (isVolumeDragging)
            {
                Point newLocationInParent = volumeSlider.Parent.PointToClient(Cursor.Position);
                int newX = newLocationInParent.X - mouseOffset.X;

                int minX = panelVolumeBase.Left - (volumeSlider.Width / 2);
                int maxX = panelVolumeBase.Right - (volumeSlider.Width / 2);
                newX = Math.Max(minX, Math.Min(newX, maxX));

                int sliderPositionInTrack = newX - panelVolumeBase.Left + (volumeSlider.Width / 2);
                double ratio = (double)sliderPositionInTrack / panelVolumeBase.Width;
                int newVolume = (int)(ratio * 100);
                SetVolume(newVolume);
            }
        }
        private void SetVolume(int volume)
        {
            // 1. 볼륨 값을 0 ~ 100 사이로 보정
            volume = Math.Max(0, Math.Min(100, volume));

            // 2. 실제 플레이어 볼륨 설정
            axWindowsMediaPlayer1.settings.volume = volume;

            // 3. 음소거 상태 및 버튼 업데이트
            if (volume > 0 && axWindowsMediaPlayer1.settings.mute)
            {
                axWindowsMediaPlayer1.settings.mute = false;
            }
            else if (volume == 0)
            {
                axWindowsMediaPlayer1.settings.mute = true;
            }
            btmute.Text = axWindowsMediaPlayer1.settings.mute ? "🔊" : "🔇";

            // 4. 볼륨 UI 업데이트
            double ratio = volume / 100.0;
            int progressWidth = (int)(panelVolumeBase.Width * ratio);
            panelVolumeProgress.Width = progressWidth;

            int sliderX = panelVolumeBase.Left + progressWidth - (volumeSlider.Width / 2);
            volumeSlider.Top = panelVolumeBase.Top + (panelVolumeBase.Height - volumeSlider.Height) / 2;
            volumeSlider.Left = sliderX;
        }
        private void volumeSlider_MouseUp(object sender, MouseEventArgs e)
        {
            isVolumeDragging = false;
        }
        private void pictureSlider_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void UpdateSliderUIPosition(int positionInTrack)
        {
            // 위치 보정
            positionInTrack = Math.Max(0, Math.Min(panelTrackBase.Width, positionInTrack));
            panelTrackProgress.Width = positionInTrack;
            int sliderX = panelTrackBase.Left + positionInTrack - (pictureSlider.Width / 2);
            pictureSlider.Location = new Point(sliderX, pictureSlider.Top);
        }

        private void btComment_Click(object sender, EventArgs e)
        {
            // 0. 로그인 상태 확인
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("댓글을 작성하려면 로그인이 필요합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string commentText = tbComment.Text.Trim();

            // 1. 유효성 검사: 댓글 내용
            if (string.IsNullOrEmpty(commentText))
            {
                MessageBox.Show("댓글 내용을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 유효성 검사: 게시글 ID
            if (currentPostId == -1)
            {
                MessageBox.Show("댓글을 작성할 게시글을 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int userId = -1;
                string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // 3. UserSession의 username을 사용하여 DB에서 user_id를 조회
                    string getUserIDQuery = "SELECT user_id FROM Users WHERE username = @username";
                    using (var command = new MySqlCommand(getUserIDQuery, connection))
                    {
                        // UserSession 클래스에 public static string Username 속성이 있다고 가정합니다.
                        command.Parameters.AddWithValue("@username", UserSession.Username);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("사용자 정보를 찾을 수 없습니다. 다시 로그인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // user_id를 찾지 못했으므로 여기서 중단
                        }
                    }

                    // 4. 조회한 user_id를 사용하여 댓글을 DB에 삽입
                    if (userId != -1)
                    {
                        string insertCommentQuery = @"INSERT INTO Comments (post_id, user_id, content, created_at) 
                                                      VALUES (@post_id, @user_id, @content, NOW())";
                        using (var command = new MySqlCommand(insertCommentQuery, connection))
                        {
                            command.Parameters.AddWithValue("@post_id", this.currentPostId);
                            command.Parameters.AddWithValue("@user_id", userId); // 조회된 숫자 ID 사용
                            command.Parameters.AddWithValue("@content", commentText);

                            int insertResult = command.ExecuteNonQuery();

                            if (insertResult > 0)
                            {
                                // 5. 성공 시 UI 갱신
                                tbComment.Clear();
                                LoadComments(this.currentPostId);
                            }
                            else
                            {
                                MessageBox.Show("댓글 등록에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"댓글을 등록하는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSubscribe_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("구독하려면 로그인이 필요합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.currentChannelId == -1)
            {
                MessageBox.Show("채널 정보를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ▼▼▼ MODIFIED PART ▼▼▼
            // UserSession.Username으로 DB에서 구독자(subscriber)의 ID를 가져옵니다.
            int subscriberId = GetUserIdFromUsername(UserSession.Username);

            // 사용자 ID를 찾을 수 없는 경우 처리
            if (subscriberId == -1)
            {
                MessageBox.Show("사용자 정보를 찾을 수 없습니다. 다시 로그인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // ▲▲▲ MODIFIED PART ▲▲▲

            if (subscriberId == this.currentChannelId)
            {
                MessageBox.Show("자기 자신을 구독할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(1) FROM subscriptions WHERE subscriber_id = @subscriberId AND channel_id = @channelId";
                    using (var checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@subscriberId", subscriberId); // 조회된 ID 사용
                        checkCmd.Parameters.AddWithValue("@channelId", this.currentChannelId);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("이미 구독한 채널입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btSubscribe.Text = "구독중";
                            btSubscribe.Enabled = false;
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO subscriptions (subscriber_id, channel_id, subscribed_at) VALUES (@subscriberId, @channelId, NOW())";
                    using (var insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@subscriberId", subscriberId); // 조회된 ID 사용
                        insertCmd.Parameters.AddWithValue("@channelId", this.currentChannelId);

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("구독했습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btSubscribe.Text = "구독중";
                            btSubscribe.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("구독에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"구독 처리 중 오류가 발생했습니다: {ex.Message}", "데이터베이스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFavorite_Click(object sender, EventArgs e)
        {
            // 1. 로그인 상태 확인
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("즐겨찾기를 하려면 로그인이 필요합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. 게시글 정보 유효성 확인
            if (this.currentPostId == -1)
            {
                MessageBox.Show("즐겨찾기할 게시글 정보를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = GetUserIdFromUsername(UserSession.Username);
            if (userId == -1)
            {
                MessageBox.Show("사용자 정보를 찾을 수 없습니다. 다시 로그인해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // 3. [수정] 이미 즐겨찾기 했는지 확인하는 쿼리의 컬럼 이름 변경
                    string checkQuery = "SELECT COUNT(1) FROM Favorites WHERE user_id = @userId AND target_type = 'post' AND target_id = @postId";
                    using (var checkCmd = new MySqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@userId", userId);
                        checkCmd.Parameters.AddWithValue("@postId", this.currentPostId);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("이미 즐겨찾기에 추가된 게시글입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btFavorite.Text = "즐겨찾기됨";
                            btFavorite.Enabled = false;
                            return;
                        }
                    }

                    // 4. [수정] Favorites 테이블에 데이터를 삽입하는 쿼리의 컬럼 이름 변경
                    string insertQuery = "INSERT INTO Favorites (user_id, target_type, target_id, created_at) VALUES (@userId, 'post', @postId, NOW())";
                    using (var insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@userId", userId);
                        insertCmd.Parameters.AddWithValue("@postId", this.currentPostId);

                        int result = insertCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("게시글을 즐겨찾기에 추가했습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btFavorite.Text = "즐겨찾기됨";
                            btFavorite.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("즐겨찾기 추가에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"즐겨찾기 처리 중 오류가 발생했습니다: {ex.Message}", "데이터베이스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            //this.Hide();
            //MainForm1 main = new MainForm1();
            //main.Show();
            this.Close();
        }

        // --- REMOVED: 기존 trackBar1 관련 이벤트 핸들러 제거 ---
        // private void trackBar1_MouseDown(object sender, MouseEventArgs e) { ... }
        // private void trackBar1_MouseUp(object sender, MouseEventArgs e) { ... }

        // --- MODIFIED: 미디어 변경 시 trackBar 관련 코드 제거 ---

    }
}