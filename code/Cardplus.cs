using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpMain;
using MySql.Data.MySqlClient;

namespace WinFormsApp33
{
    public partial class Cardplus : Form
    {
        private Pay W;
        private bool isHandlingTextChanged = false;
        bool isHandlingTextChanged2 = false;
        bool isHandlingTextChanged3 = false;

        public Cardplus()
        {

            InitializeComponent();
            W = new Pay();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isHandlingTextChanged) return; // 무한루프 방지
            isHandlingTextChanged = true;

            int selStart = textBox1.SelectionStart;
            int digitsBefore = textBox1.Text.Take(selStart).Count(char.IsDigit);

            // 숫자만 추출
            string digitsOnly = new string(textBox1.Text.Where(char.IsDigit).ToArray());

            // 최대 16자리로 제한
            if (digitsOnly.Length > 16)
                digitsOnly = digitsOnly.Substring(0, 16);

            // 4자리마다 - 붙이기
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < digitsOnly.Length; i++)
            {
                if (i > 0 && i % 4 == 0)
                    sb.Append("-");
                sb.Append(digitsOnly[i]);
            }

            textBox1.Text = sb.ToString();

            // 커서 위치 보정
            int newSelStart = 0;
            int digitCount = 0;
            while (digitCount < digitsBefore && newSelStart < textBox1.Text.Length)
            {
                if (char.IsDigit(textBox1.Text[newSelStart]))
                    digitCount++;
                newSelStart++;
            }

            textBox1.SelectionStart = newSelStart;
            isHandlingTextChanged = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }

            // 숫자 개수 제한 (16자리 초과 금지)
            string digitsOnly = textBox1.Text.Replace("-", "");
            if (char.IsDigit(e.KeyChar) && digitsOnly.Length >= 16)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (isHandlingTextChanged2) return;
            isHandlingTextChanged2 = true;

            int selStart = textBox2.SelectionStart;
            int digitsBefore = textBox2.Text.Take(selStart).Count(char.IsDigit);

            string digitsOnly = new string(textBox2.Text.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length > 4)
                digitsOnly = digitsOnly.Substring(0, 4);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < digitsOnly.Length; i++)
            {
                if (i == 2) sb.Append('/');
                sb.Append(digitsOnly[i]);
            }

            textBox2.Text = sb.ToString();

            int newSelStart = 0;
            int digitCount = 0;
            while (digitCount < digitsBefore && newSelStart < textBox2.Text.Length)
            {
                if (char.IsDigit(textBox2.Text[newSelStart]))
                    digitCount++;
                newSelStart++;
            }

            if (newSelStart == 3 && textBox2.Text.Length > 3 && textBox2.Text[2] == '/')
                newSelStart++;

            textBox2.SelectionStart = newSelStart;

            isHandlingTextChanged2 = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }

            // 최대 4자리 숫자 제한
            // '/' 포함 최대 5글자 (예: 12/34)
            string currentText = textBox2.Text;
            int digitsCount = currentText.Count(char.IsDigit);

            if (!char.IsControl(e.KeyChar) && digitsCount >= 4)
            {
                e.Handled = true;
            }
        }

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (isHandlingTextChanged3) return;
            isHandlingTextChanged3 = true;

            int selStart = textBox3.SelectionStart;
            int digitsBefore = textBox3.Text.Take(selStart).Count(char.IsDigit);

            string digitsOnly = new string(textBox3.Text.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length > 3)
                digitsOnly = digitsOnly.Substring(0, 3);

            textBox3.Text = digitsOnly;

            int newSelStart = 0;
            int digitCount = 0;
            while (digitCount < digitsBefore && newSelStart < textBox3.Text.Length)
            {
                if (char.IsDigit(textBox3.Text[newSelStart]))
                    digitCount++;
                newSelStart++;
            }

            textBox3.SelectionStart = newSelStart;

            isHandlingTextChanged3 = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 백스페이스는 항상 허용
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
                return;
            }

            // 최대 3자리 숫자 제한
            string currentText = textBox3.Text;
            int digitsCount = currentText.Count(char.IsDigit);

            if (!char.IsControl(e.KeyChar) && digitsCount >= 3)
            {
                e.Handled = true;
            }
        }

        private void btn_CardSave_Click(object sender, EventArgs e)
        {
            string comboValue = comboBox1.SelectedItem?.ToString() ?? "";
            string textValue = textBox1.Text;

            if (string.IsNullOrEmpty(comboValue))
            {
                MessageBox.Show("콤보박스에서 값을 선택하세요.");
                return;
            }

            string text1 = textBox1.Text.Trim();
            string text2 = textBox2.Text.Trim();
            string text3 = textBox3.Text.Trim();


            if (text1.Length != 19 || text2.Length != 5 || text3.Length != 3)

            {
                MessageBox.Show("16자리, 4자리, 3자리를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool paymentSuccess = true; // 실제로는 PG사 API 호출 결과가 됩니다.

            if (paymentSuccess)
            {
                string currentUsername = UserSession.Username;
                bool upgradeSuccess = PremiumService.UpgradeToPremium(currentUsername);

                if (upgradeSuccess)
                {
                    MessageBox.Show("결제가 완료되어 프리미엄 회원으로 전환되었습니다.");

                    // 결제 폼을 닫습니다.
                    this.Close();
                }
                else
                {
                    MessageBox.Show("회원 정보 업데이트에 실패했습니다. 고객센터에 문의해주세요.");
                }
            }
            else
            {
                MessageBox.Show("결제에 실패했습니다.");
            }

           // this.Close();


           
            //W.Show();
            //W.UpdateLabel(comboValue, textValue);
        }
    }
}
