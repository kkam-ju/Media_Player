using MediaPlayer;
using MySql.Data.MySqlClient;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TpMain
{
    public partial class IDfind : Form                                    ///아이디 찾기
    {
        public IDfind()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }




        private void back2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nickname = txtNickname.Text.Trim();         // 닉네임 텍스트박스
            string phonenumber = txtPhoneNumber.Text.Trim();   // 전화번호 텍스트박스

            if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(phonenumber))
            {
                MessageBox.Show("닉네임과 전화번호를 모두 입력해주세요.");
                return;
            }

            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 아이디 찾기 쿼리 (nickname + phone_number 기준)
                    string query = "SELECT username FROM users WHERE nickname = @nickname AND phone_number = @phone_number";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nickname", nickname);
                    cmd.Parameters.AddWithValue("@phone_number", phonenumber);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string foundUsername = result.ToString();
                        MessageBox.Show($"회원님의 아이디는 '{foundUsername}' 입니다.");
                    }
                    else
                    {
                        MessageBox.Show("일치하는 회원 정보가 없습니다. 닉네임과 전화번호를 다시 확인해주세요.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("아이디 찾기 중 오류 발생: " + ex.Message);
                }
            }
        }

       
    }
}





