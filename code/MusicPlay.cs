using AxWMPLib;
using  Music123 ;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpMain;

namespace Music123
{
    public partial class MusicPlay : Form
    {
        private bool isVolumeDragging = false;
        private Point volumeMouseOffset;
        private CircleSlider pictureSliderVolume;

        private List<MusicInfo> allMusic = new List<MusicInfo>();
        public MusicPlay()
        {

            InitializeComponent();

            // === 기본 UI 설정 ===
            this.ForeColor = Color.White;
            axWindowsMediaPlayer1.Visible = false;
            lv_MusicList.MultiSelect = false;
            lv_MusicList.ForeColor = Color.White;
            lv_MusicList.BackColor = Color.Black;
            lv_MusicList.OwnerDraw = true;

            // 이벤트 등록
            lv_MusicList.SelectedIndexChanged += lv_MusicList_SelectedIndexChanged;
            lv_MusicList.DrawColumnHeader += lv_MusicList_DrawColumnHeader;
            lv_MusicList.DrawItem += lv_MusicList_DrawItem;
            pb_music1.Click += MusicPictureBox_Click;
            pb_music2.Click += MusicPictureBox_Click;
            pb_music3.Click += MusicPictureBox_Click;

            // === 볼륨 조절 슬라이더 (pictureSliderVolume) 생성 및 초기화 ===
            pictureSliderVolume = new CircleSlider();
            pictureSliderVolume.Size = new Size(12, 12);
            pictureSliderVolume.BackColor = Color.Transparent;
            pictureSliderVolume.Visible = true;

            // 볼륨 슬라이더 이벤트 등록
            pictureSliderVolume.Paint += pictureSliderVolume_Paint;
            pictureSliderVolume.MouseDown += pictureSliderVolume_MouseDown;
            pictureSliderVolume.MouseMove += pictureSliderVolume_MouseMove;
            pictureSliderVolume.MouseUp += pictureSliderVolume_MouseUp;

            // ➡️ 수정된 부분: 볼륨바(panel_vol)와 슬라이더의 위치를 한 번에 정확하게 설정합니다.
            panel_vol.Height = 4;
            panel_vol.Top = (panel_sound.Height - panel_vol.Height) / 2;

            // 현재 볼륨 값에 따라 슬라이더의 초기 위치를 계산합니다.
            int initialVolume = axWindowsMediaPlayer1.settings.volume;
            double initialRatio = (double)initialVolume / 100.0;

            int initialSliderX = (int)(panel_sound.Width * initialRatio) - (pictureSliderVolume.Width / 2);

            pictureSliderVolume.Left = initialSliderX;
            pictureSliderVolume.Top = (panel_sound.Height - pictureSliderVolume.Height) / 2;

            // 볼륨 진행바의 너비를 슬라이더의 위치에 맞춥니다.
            panel_vol.Width = initialSliderX + (pictureSliderVolume.Width / 2);

            // 슬라이더를 panel_sound에 추가하고 맨 앞으로 가져옵니다.
            panel_sound.Controls.Add(pictureSliderVolume);
            pictureSliderVolume.BringToFront();

            // === 음악 목록 불러오기 ===
            LoadMusicList();

            // === 트랙 재생 슬라이더 (pictureSlider) 생성 및 초기화 ===
            pictureSlider = new CircleSlider();
            pictureSlider.Size = new Size(12, 12);
            pictureSlider.BackColor = Color.Transparent;
            pictureSlider.Visible = true;

            // 트랙 슬라이더 이벤트 등록
            pictureSlider.Paint += pictureSlider_Paint;
            pictureSlider.MouseDown += pictureSlider_MouseDown;
            pictureSlider.MouseMove += pictureSlider_MouseMove;
            pictureSlider.MouseUp += pictureSlider_MouseUp;

            // 트랙 슬라이더와 진행 바의 위치를 한 번에 정확하게 설정
            panelTrackProgress.Height = 4;
            panelTrackProgress.Top = (panelTrackBase.Height - panelTrackProgress.Height) / 2;

            pictureSlider.Top = (panelTrackBase.Height - pictureSlider.Height) / 2;
            panelTrackBase.Controls.Add(pictureSlider);
            pictureSlider.BringToFront();

            // === 미디어 플레이어 및 타이머 설정 ===
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            panelTrackBase.MouseDown += panelTrackBase_MouseDown;


        }




        private void LoadMusicList()
        {
            string connStr = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            lv_MusicList.Items.Clear();
            allMusic.Clear(); // 리스트 초기화

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // music_id를 함께 가져오도록 쿼리 수정
                string sql = "SELECT music_id, music_path, album_art_path FROM Music ORDER BY music_id ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    int sNo = 1;
                    while (reader.Read())
                    {
                        // MusicInfo 객체 생성 및 정보 저장
                        var musicInfo = new MusicInfo
                        {
                            MusicId = Convert.ToInt32(reader["music_id"]),
                            MusicPath = reader["music_path"].ToString(),
                            AlbumArtPath = reader["album_art_path"].ToString()
                        };
                        allMusic.Add(musicInfo); // 전체 리스트에 추가

                        string musicFileName = Path.GetFileName(musicInfo.MusicPath);

                        ListViewItem item = new ListViewItem(sNo.ToString());
                        item.SubItems.Add(musicFileName);
                        item.Tag = musicInfo; // Tag에 MusicInfo 객체 저장

                        lv_MusicList.Items.Add(item);
                        sNo++;
                    }
                }
            }

            // 로딩 후 첫 번째 곡을 선택하여 UI를 초기화 (새로 추가)
            if (lv_MusicList.Items.Count > 0)
            {
                lv_MusicList.Items[0].Selected = true;
            }
        }

        private void UpdateAlbumArtDisplay(int currentMusicId)
        {
            if (allMusic.Count == 0) return;

            // 현재 재생 중인 곡의 인덱스 찾기
            int currentIndex = allMusic.FindIndex(m => m.MusicId == currentMusicId);
            if (currentIndex == -1) return; // 곡을 찾지 못하면 종료

            // 1. 현재 곡 정보 가져오기
            MusicInfo currentSong = allMusic[currentIndex];

            // 2. 이전 곡 정보 가져오기 (처음이면 마지막 곡)
            int prevIndex = (currentIndex - 1 + allMusic.Count) % allMusic.Count;
            MusicInfo prevSong = allMusic[prevIndex];

            // 3. 다음 곡 정보 가져오기 (마지막이면 처음 곡)
            int nextIndex = (currentIndex + 1) % allMusic.Count;
            MusicInfo nextSong = allMusic[nextIndex];

            // PictureBox와 MusicInfo를 묶어서 처리하는 함수
            Action<PictureBox, MusicInfo> setPbInfo = (pb, info) =>
            {
                if (File.Exists(info.AlbumArtPath))
                {
                    pb.Image = Image.FromFile(info.AlbumArtPath);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pb.Image = null;
                }
                pb.Tag = info; // Tag에 MusicInfo 객체를 저장하여 클릭 시 정보 활용
            };

            // 각 PictureBox에 앨범 아트와 정보 설정
            setPbInfo(pb_music1, currentSong);
            setPbInfo(pb_music2, prevSong);
            setPbInfo(pb_music3, nextSong);
        }

        public class MusicInfo
        {
            public int MusicId { get; set; } // music_id 저장
            public string MusicPath { get; set; }
            public string AlbumArtPath { get; set; }
        }

        private void lv_MusicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_MusicList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lv_MusicList.SelectedItems[0];
                MusicInfo musicInfo = selectedItem.Tag as MusicInfo;

                if (musicInfo != null)
                {
                    PlayMusic(musicInfo.MusicPath);
                    // 앨범 아트 UI 업데이트 호출
                    UpdateAlbumArtDisplay(musicInfo.MusicId);
                }
            }
        }



        private void MusicPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            // Tag에 저장된 MusicInfo 객체를 가져옴
            if (pb != null && pb.Tag is MusicInfo clickedMusicInfo)
            {
                // 이미 재생중인 곡을 다시 클릭한게 아니라면 ListView에서 해당 곡을 찾아 선택
                if (axWindowsMediaPlayer1.URL != clickedMusicInfo.MusicPath)
                {
                    foreach (ListViewItem item in lv_MusicList.Items)
                    {
                        if (item.Tag is MusicInfo itemMusicInfo && itemMusicInfo.MusicId == clickedMusicInfo.MusicId)
                        {
                            // 해당 아이템을 선택 상태로 만듭니다.
                            // 이렇게 하면 lv_MusicList_SelectedIndexChanged 이벤트가 발생하여
                            // 노래 재생 및 UI 업데이트가 자동으로 처리됩니다.
                            item.Selected = true;
                            item.EnsureVisible(); // 해당 항목이 보이도록 스크롤
                            break;
                        }
                    }
                }
            }
        }
        private void PlayMusic(string filePath) //노래 재생 함수
        {
            axWindowsMediaPlayer1.URL = filePath;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            pb_Start.Visible = false;
            pictureBox3.Visible = true;
        }

        private string FormatTime(double seconds)//시간 함수
        {
            int minutes = (int)(seconds / 60);
            int secs = (int)(seconds % 60);
            return $"{minutes}:{secs:D2}";
        }


        private void pictureSlider_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Brush b = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(b, 0, 0, pictureSlider.Width - 1, pictureSlider.Height - 1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying && axWindowsMediaPlayer1.currentMedia != null)
            {
                double duration = axWindowsMediaPlayer1.currentMedia.duration;
                double current = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;

                double ratio = current / duration;
                int progressWidth = (int)(panelTrackBase.Width * ratio);

                panelTrackProgress.Width = progressWidth;

                int sliderX = panelTrackBase.Left + progressWidth - (pictureSlider.Width / 2);
                sliderX = Math.Max(panelTrackBase.Left - (pictureSlider.Width / 2), sliderX);
                sliderX = Math.Min(panelTrackBase.Right - (pictureSlider.Width / 2), sliderX);

                pictureSlider.Location = new Point(sliderX, pictureSlider.Top);
                pictureSlider.BringToFront();
                lb_Timenow.Text = FormatTime(current);
                lb_TotalTime.Text = FormatTime(duration);
            }



        }

        private bool isDragging = false;
        private Point mouseOffset;

        private void panelTrackBase_MouseDown(object sender, MouseEventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia != null)
            {
                // panelTrackBase 내에서 클릭된 위치 비율로 계산
                double clickRatio = (double)e.X / panelTrackBase.Width;
                double duration = axWindowsMediaPlayer1.currentMedia.duration;

                // 계산된 비율로 음악 위치 변경
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = duration * clickRatio;

                // 슬라이더를 클릭하면 드래그 시작
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    mouseOffset = e.Location;
                }
            }
        }

        private void pictureSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int newX = pictureSlider.Left + e.X - mouseOffset.X;

                // 슬라이더가 트랙바 내부에만 있도록 제한
                newX = Math.Max(0, newX);
                newX = Math.Min(panelTrackBase.Width - pictureSlider.Width, newX);

                pictureSlider.Left = newX;

                // 비율 계산 → 음악 위치 업데이트
                double ratio = (double)(newX + pictureSlider.Width / 2) / panelTrackBase.Width;
                double duration = axWindowsMediaPlayer1.currentMedia.duration;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = duration * ratio;

            }
        }

        private void pictureSlider_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void pictureSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseOffset = e.Location;
            }
        }

        private void pb_Start_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play(); // 음악 재생
                pb_Start.Visible = false;
                pictureBox3.Visible = true;
            }
        }

        private void pb_next_Click(object sender, EventArgs e)
        {
            if (lv_MusicList.SelectedItems.Count > 0)
            {
                int currentIndex = lv_MusicList.SelectedItems[0].Index;
                int nextIndex = currentIndex + 1;

                // === 중요: 현재 선택된 모든 항목을 먼저 해제합니다. ===
                foreach (ListViewItem item in lv_MusicList.SelectedItems)
                {
                    item.Selected = false;
                }

                if (nextIndex < lv_MusicList.Items.Count)
                {
                    lv_MusicList.Items[nextIndex].Selected = true;
                    lv_MusicList.Items[nextIndex].EnsureVisible();
                }
                else
                {
                    lv_MusicList.Items[0].Selected = true;
                    lv_MusicList.Items[0].EnsureVisible();
                }
            }
        }

        private void pb_Back_Click(object sender, EventArgs e)
        {
            if (lv_MusicList.SelectedItems.Count > 0)
            {
                int currentIndex = lv_MusicList.SelectedItems[0].Index;
                int prevIndex = currentIndex - 1;

                // === 중요: 현재 선택된 모든 항목을 먼저 해제합니다. ===
                foreach (ListViewItem item in lv_MusicList.SelectedItems)
                {
                    item.Selected = false;
                }

                if (prevIndex >= 0)
                {
                    lv_MusicList.Items[prevIndex].Selected = true;
                    lv_MusicList.Items[prevIndex].EnsureVisible();
                }
                else
                {
                    lv_MusicList.Items[lv_MusicList.Items.Count - 1].Selected = true;
                    lv_MusicList.Items[lv_MusicList.Items.Count - 1].EnsureVisible();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            pictureBox3.Visible = false;  // 정지 버튼 숨김
            pb_Start.Visible = true;
        }

        private void pb_Go_Main_Click(object sender, EventArgs e)
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
            //MainForm1 Main = new MainForm1();
            //Main.Show();
            this.Close();
        }

        private void pb_music1_Click(object sender, EventArgs e)
        {
            //LoadImageToPictureBoxFromDB(1, pb_music1); // music_id = 1, 대상 PictureBox = pb_music1
        }
        private void LoadImageToPictureBoxFromDB(int musicId, PictureBox pictureBox)
        {
            string connStr = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT album_art_path FROM Music WHERE music_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", musicId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string albumArtPath = reader["album_art_path"].ToString();

                            if (File.Exists(albumArtPath))
                            {
                                pictureBox.Image = Image.FromFile(albumArtPath);
                            }

                        }
                    }
                }
            }
        }
        //lv_musiclist.drawcolumnheader += lv_musiclist_drawcolumnheader;
        //    lv_musiclist.drawitem += lv_musiclist_drawitem;

        private void lv_MusicList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush headerBrush = new SolidBrush(Color.DimGray)) // 헤더 배경색
            using (SolidBrush textBrush = new SolidBrush(Color.White)) // 헤더 글자색
            {
                // 헤더 배경을 그립니다.
                e.Graphics.FillRectangle(headerBrush, e.Bounds);

                // 헤더 텍스트를 그립니다.
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(e.Header.Text, e.Font, textBrush, e.Bounds, sf);
            }
        }

        private void lv_MusicList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // 아이템의 배경색을 그립니다.
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(Brushes.DarkGreen, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
            }

            // 첫 번째 아이템(주 텍스트) 그리기
            e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.White, e.Bounds.Left, e.Bounds.Top);

            // 서브 아이템 그리기
            int subItemX = e.Bounds.Left + lv_MusicList.Columns[0].Width;

            // 반복문의 조건을 SubItems.Count와 Columns.Count 중 더 작은 값으로 변경
            int subItemCount = Math.Min(e.Item.SubItems.Count, lv_MusicList.Columns.Count);

            for (int i = 1; i < subItemCount; i++)
            {
                // 서브 아이템 텍스트 그리기
                // e.Graphics.DrawString(e.Item.SubItems[i].Text, e.Item.Font, Brushes.White, subItemX, e.Bounds.Top); // 이전 코드

                // 올바른 영역에 텍스트를 그리기 위해 SubItemBounds를 사용 (이전 에러 해결 코드가 충돌할 수 있음)
                // 만약 GetSubItemBounds 오류가 발생하지 않는 환경이라면 이 코드를 사용하는 것이 더 정확합니다.
                // e.Graphics.DrawString(e.Item.SubItems[i].Text, e.Item.Font, Brushes.White, e.Item.GetSubItemBounds(i).Location);

                // GetSubItemBounds 오류를 해결하기 위해 직접 계산한 코드
                Rectangle subItemBounds = new Rectangle(subItemX, e.Bounds.Top, lv_MusicList.Columns[i].Width, e.Bounds.Height);
                TextRenderer.DrawText(e.Graphics, e.Item.SubItems[i].Text, e.Item.Font, subItemBounds, Color.White, TextFormatFlags.VerticalCenter);

                // 다음 서브 아이템의 X 좌표 계산
                subItemX += lv_MusicList.Columns[i].Width;
            }

        }

        private void pictureSliderVolume_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Brush b = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(b, 0, 0, pictureSliderVolume.Width - 1, pictureSliderVolume.Height - 1);
            }
        }

        // 볼륨 슬라이더 마우스 다운
        private void pictureSliderVolume_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isVolumeDragging = true;
                volumeMouseOffset = e.Location;
            }
        }

        // 볼륨 슬라이더 마우스 이동 (드래그)
        private void pictureSliderVolume_MouseMove(object sender, MouseEventArgs e)
        {

            if (!isVolumeDragging) return;

            // 슬라이더의 새로운 X 위치 계산
            int newX = pictureSliderVolume.Left + e.X - volumeMouseOffset.X;

            // 슬라이더가 panel_sound 내부에만 있도록 제한 (슬라이더 중심 기준)
            newX = Math.Max(-(pictureSliderVolume.Width / 2), newX);
            newX = Math.Min(panel_sound.Width - (pictureSliderVolume.Width / 2), newX);

            // 슬라이더 위치 설정
            pictureSliderVolume.Left = newX;
            //pictureSliderVolume.Top = (panel_vol.Height - pictureSliderVolume.Height) / 2; // Y 좌표 고정!

            // 볼륨 비율 계산 (0.0 ~ 1.0)
            double ratio = (double)(newX + (pictureSliderVolume.Width / 2.0)) / panel_sound.Width;

            // WMP 볼륨 값 계산 (0 ~ 100)
            int newVolume = Math.Min(Math.Max((int)(ratio * 100), 0), 100);

            // WMP 볼륨 설정
            axWindowsMediaPlayer1.settings.volume = newVolume;

            // 볼륨 진행 바 너비 설정
            panel_vol.Width = newX + (pictureSliderVolume.Width / 2);
        }

        // 볼륨 슬라이더 마우스 업
        private void pictureSliderVolume_MouseUp(object sender, MouseEventArgs e)
        {
            isVolumeDragging = false;
        }

        private void pb_VolumeIcon_Click(object sender, EventArgs e)
        {

        }

        private void pb_sound_Click(object sender, EventArgs e)
        {
            bool isMuted = axWindowsMediaPlayer1.settings.mute;

            // 음소거 상태를 토글
            axWindowsMediaPlayer1.settings.mute = !isMuted;

            if (axWindowsMediaPlayer1.settings.mute)
            {
                // 음소거 상태일 때의 이미지로 변경
                pb_sound.Visible = false;
                pb_soundoff.Visible = true;
            }
            else
            {
                pb_sound.Visible = true;
                pb_soundoff.Visible = false;
            }
        }

        private void pb_soundoff_Click(object sender, EventArgs e)
        {
            bool isMuted = axWindowsMediaPlayer1.settings.mute;

            // 음소거 상태를 토글
            axWindowsMediaPlayer1.settings.mute = !isMuted;

            if (axWindowsMediaPlayer1.settings.mute)
            {
                // 음소거 상태일 때의 이미지로 변경
                pb_sound.Visible = false;
                pb_soundoff.Visible = true;
            }
            else
            {
                pb_sound.Visible = true;
                pb_soundoff.Visible = false;
            }
        }

        private void MusicPlay_Load(object sender, EventArgs e)
        {

        }
    }
}
