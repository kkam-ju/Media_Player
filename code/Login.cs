using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using TpMain;
namespace MediaPlayer
{
    public partial class Login : Form
    {
        public bool IsLoggedIn { get; private set; } = false;   //로그인 여부 확인 -> false : 로그인X
        public string Nickname { get; private set; } = "";       //
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Find_ID_Click(object sender, EventArgs e)
        {
            IDfind idFind = new IDfind();
            idFind.Show(); // Show the new form
            


        }

        private void btn_Find_PW_Click(object sender, EventArgs e)
        {
            PWfind pwFind = new PWfind();
            pwFind.Show(); // Show the new form

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = tb_ID.Text;
            string password = tb_PW.Text;

            // 아이디 비밀번호 검증
            if (string.IsNullOrEmpty(username) || username == "아이디를 입력하세요" ||
                string.IsNullOrEmpty(password) || password == "비밀번호를 입력하세요")
            {
                MessageBox.Show("아이디와 비밀번호를 정확히 입력해주세요.");
                return;
            }
            // DB 연결 정보 설정
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();             // MySQL 연결 열기

                    
                    // 로그인 정보 조회
                    string query = "SELECT user_id, password, nickname ,manager, is_premium FROM users WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);

                    // 결과 읽기
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // 아이디가 존재하면 true를 반환
                        {
                            int userId = reader.GetInt32("user_id");
                            string correctPassword = reader["password"].ToString();
                            string nickname = reader["nickname"].ToString();

                            // 아이디가 존재하므로, 이제 비밀번호를 비교
                            if (password == correctPassword)
                            {
                                bool manager = Convert.ToBoolean(reader["manager"]);
                                bool premium = Convert.ToBoolean(reader["is_premium"]);
                                // 로그인 성공! UserSession 클래스에 정보를 저장
                                UserSession.Login(userId, username, nickname,manager, premium);

                                // 관리자 계정 접속
                                if (manager)
                                {
                                    MessageBox.Show($"로그인 성공! 관리자 계정입니다.");
                                    ManagerForm managerform = new ManagerForm();
                                    managerform.ShowDialog();
                                    this.Close(); // 관리자 폼을 닫을 때 로그인 폼도 닫음
                                }
                                else
                                {
                                    // 일반 회원 로그인 성공
                                    this.Close(); 

                                   
                                }
                                
                            }
                            else
                            {
                                // 비밀번호가 틀렸을 경우
                                MessageBox.Show("비밀번호가 틀렸습니다.");
                            }
                        }
                        else
                        {
                            // 아이디가 존재하지 않을 경우
                            MessageBox.Show("존재하지 않는 아이디입니다.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("로그인 중 오류 발생: " + ex.Message);
                }
            }
        }

        private void btn_Signup_Click(object sender, EventArgs e)
        {
            NewMember newmember = new NewMember();
            newmember.Show();
        }

        private void tb_ID_Enter(object sender, EventArgs e)
        {
            if (tb_ID.Text == "아이디를 입력하세요")
            {
                tb_ID.Text = "";
                tb_ID.ForeColor = Color.Black;
            }
        }

        private void tb_PW_Enter(object sender, EventArgs e)
        {
            if (tb_PW.Text == "비밀번호를 입력하세요")
            {
                tb_PW.PasswordChar = '*';
                tb_PW.Text = "";
                tb_PW.ForeColor = Color.Black;
            }

        }

        private void tb_ID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ID.Text))
            {
                tb_ID.Text = "아이디를 입력하세요";
                tb_ID.ForeColor = Color.Gray;
            }
        }

        private void tb_PW_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_PW.Text))
            {
                tb_PW.Text = "비밀번호를 입력하세요";
                tb_PW.PasswordChar = '\0';
                tb_PW.ForeColor = Color.Gray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            
        }

        private void cb_Security_CheckedChanged(object sender, EventArgs e)
        {

            if (cb_Security.Checked == true)
            {
                // 체크되었을 때: 일반 문자 표시
                if (tb_PW.Text != "비밀번호를 입력하세요")
                {
                    
                    tb_PW.PasswordChar = '\0'; // null 문자
                }

            }
            else
            {    
                    // 체크 해제되었을 때: * 표시
                    tb_PW.PasswordChar = '*';

            }
        }

        
    }
}
