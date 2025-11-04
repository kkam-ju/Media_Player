using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TpMain
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            string connStr = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // users 테이블에서 사용자 정보 조회
                string query = "SELECT user_id, username, password, nickname, phone_number, is_premium, manager FROM users";
                // MySQL 데이터 어댑터를 이용하여 쿼리 결과 가져오기
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();  // 데이터를 담을 DataTable 객체 생성
                adapter.Fill(dt);   // 쿼리 결과를 DataTable에 채움
                DGV_Users.DataSource = dt;  // DataGridView에 데이터 표시
            }
        }
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            //LoadUsers();
        }

        private void btn_UserLoad_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btn_UserDelete_Click(object sender, EventArgs e)
        {
            if (DGV_Users.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 사용자를 선택하세요.");
                return;
            }

            int userId = Convert.ToInt32(DGV_Users.SelectedRows[0].Cells["user_id"].Value);

            string connStr = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // users 테이블에서 사용자 정보 조회
                string query = "DELETE FROM users WHERE user_id = @user_id";
                // MySQL 데이터 어댑터를 이용하여 쿼리 결과 가져오기
                MySqlCommand cmd = new MySqlCommand(query, conn);  // 데이터를 담을 DataTable 객체 생성
                cmd.Parameters.AddWithValue("@user_id", userId);  // 쿼리 결과를 DataTable에 채움
                cmd.ExecuteNonQuery();  // DataGridView에 데이터 표시
            }

            LoadUsers(); // 목록 갱신
            MessageBox.Show("사용자 삭제 완료.");
        }
    }
}
