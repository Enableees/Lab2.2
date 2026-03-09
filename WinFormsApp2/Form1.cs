namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.input.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            Properties.Settings.Default.input = input;
            Properties.Settings.Default.Save();

            if (!int.TryParse(input, out int number))
            {
                MessageBox.Show("Ошибка: введите целое число");
                return;
            }

            string result = Logic.ConvertToRublesAndKopecks(number);
            MessageBox.Show(result);
        }
        public class Logic
        {
            public static string ConvertToRublesAndKopecks(int number)
            {
                if (number < 1 || number > 9999)
                {
                    return "Некорректное значение. Введите число от 1 до 9999";
                }

                int rubles = number / 100;
                int kopecks = number % 100;

                string rubleWord;
                if (rubles % 10 == 1 && rubles % 100 != 11)
                    rubleWord = "рубль";
                else if (rubles % 10 >= 2 && rubles % 10 <= 4 && (rubles % 100 < 10 || rubles % 100 >= 20))
                    rubleWord = "рубля";
                else
                    rubleWord = "рублей";

                string kopeckWord;
                if (kopecks % 10 == 1 && kopecks % 100 != 11)
                    kopeckWord = "копейка";
                else if (kopecks % 10 >= 2 && kopecks % 10 <= 4 && (kopecks % 100 < 10 || kopecks % 100 >= 20))
                    kopeckWord = "копейки";
                else
                    kopeckWord = "копеек";

                return $"{rubles} {rubleWord} {kopecks} {kopeckWord}";
            }
        }
    }
}
