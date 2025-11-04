using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MediaPlayer
{
    public partial class NewMember : Form
    {
        //public string RegisteredNickname { get; private set; }

        public NewMember()
        {
            InitializeComponent();
        }
        private bool IDCheck = false;

        // 아이디 중복 확인 버튼 
        private void btn_IDCheck_Click(object sender, EventArgs e)
        {
            string username = tb_NewID.Text.Trim();  

            // 아이디 입력 여부 확인
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("아이디를 입력해주세요.");
                return;
            }

            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // DB 연결

                    // 아이디 중복 여부를 COUNT(*)로 개수 확인 
                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkUserCmd = new MySqlCommand(checkUserQuery, connection);
                    checkUserCmd.Parameters.AddWithValue("@username", username);

                    int userCount = Convert.ToInt32(checkUserCmd.ExecuteScalar());

                    // COUNT가 0보다 크면 이미 존재하는 아이디
                    if (userCount > 0)
                    {
                        MessageBox.Show("이미 사용 중인 아이디입니다. 다른 아이디를 입력해주세요.");
                        IDCheck = false;
                    }
                    else
                    {
                        MessageBox.Show("사용 가능한 아이디입니다!");
                        IDCheck = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("중복 확인 중 오류 발생: " + ex.Message);
                }
            }
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            string username = tb_NewID.Text;
            string password = tb_NewPW.Text;
            string confirmPassword = tb_NewPW1.Text;
            string nickname=tb_NickName.Text;
            string phonenumber=tb_PhoneNum.Text;

            // 아이디 중복 확인 여부 체크
            if (!IDCheck)
            {
                MessageBox.Show("아이디 중복 확인을 해주세요.");
                return;
            }

            // 입력값 검사
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || 
                string.IsNullOrEmpty(confirmPassword)|| string.IsNullOrEmpty(nickname)|| 
                string.IsNullOrEmpty(phonenumber))
            {
                MessageBox.Show("항목을 확인해주세요.");
                return;
            }

            // 비밀번호 일치 검사
            if (password != confirmPassword)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }

            // MySQL 연결 문자열 (DB 이름은 users, 사용자명 root, 비밀번호는 환경에 따라 다름)
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 회원 정보 삽입
                    string insertQuery = "INSERT INTO users (username, password,nickname,phone_number) VALUES (@username, @password,@nickname,@phone_number)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@nickname", nickname);
                    insertCmd.Parameters.AddWithValue("@phone_number", phonenumber);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("회원가입이 완료되었습니다!");

                    // 입력값 초기화 또는 창 닫기
                    tb_NewID.Text = "";
                    tb_NewPW.Text = "";
                    tb_NewPW1.Text = "";
                    tb_NickName.Text = "";
                    tb_PhoneNum.Text = "";
                    //this.RegisteredNickname = nickname;  // 닉네임 저장
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    //this.Close(); // 창 닫기 (선택)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류 발생: " + ex.Message);
                }
            }
        }
    }
}
