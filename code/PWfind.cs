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
    public partial class PWfind : Form
    {
        public PWfind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtID.Text.Trim();
            string phonenumber = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(phonenumber))
            {
                MessageBox.Show("아이디와 전화번호를 모두 입력해주세요.");
                return;
            }

            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT password FROM users WHERE username = @username AND phone_number = @phone_number";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@phone_number", phonenumber);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string foundPassword = result.ToString();
                        MessageBox.Show($"회원님의 비밀번호는 '{foundPassword}' 입니다.");
                    }
                    else
                    {
                        MessageBox.Show("일치하는 회원 정보가 없습니다. 정보를 다시 확인해주세요.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("비밀번호 찾기 중 오류 발생: " + ex.Message);
                }
            }
        }


        private void back1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}

  
