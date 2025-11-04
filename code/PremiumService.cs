using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace TpMain
{
    internal class PremiumService
    {
        public static bool UpgradeToPremium(string username)
        {
            string connectionString = "Server=localhost;Database=youtube;Uid=root;Pwd=1234;";
            string query = "UPDATE users SET is_premium = 1 WHERE username = @username";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // 데이터베이스 업데이트 성공 시, UserSession 정보도 업데이트합니다.
                        UserSession.IsPremium = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("프리미엄 전환 중 오류 발생: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
