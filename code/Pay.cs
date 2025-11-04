namespace WinFormsApp33
{
    public partial class Pay : Form
    {
        
        public Pay()
        {
            InitializeComponent();

            
        }
        private string storedComboValue;
        private string storedTextValue;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; // 1초마다
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        public void UpdateLabel(string comboValue, string textValue)
        {
            storedComboValue = comboValue;
            storedTextValue = textValue;

            label18.Text = comboValue + textValue;


            Console.WriteLine($"Received comboValue: {comboValue}, textValue: {textValue}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show($"카드: {storedComboValue}\n카드 번호: {storedTextValue}", "버튼 클릭 출력");
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("yyyy.MM.dd.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cardplus yy = new Cardplus();
            yy.Show();
            this.Hide();
        }
    }
}
