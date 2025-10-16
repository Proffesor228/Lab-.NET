using System;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class Zad3Form : Form
    {
        public Zad3Form()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            string numberStr = textBoxNumber.Text;

            if (string.IsNullOrWhiteSpace(numberStr))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            int sum = 0;
            int count = 0;
            string evenDigits = "";

            foreach (char digitChar in numberStr)
            {
                if (char.IsDigit(digitChar))
                {
                    int digit = int.Parse(digitChar.ToString());
                    if (digit % 2 == 0) // проверяем четность
                    {
                        sum += digit;
                        count++;
                        evenDigits += digit + " ";
                    }
                }
            }

            if (count > 0)
            {
                double average = (double)sum / count;
                textBoxResult.Text = $"Четные цифры: {evenDigits}\r\n";
                textBoxResult.Text += $"Количество: {count}\r\n";
                textBoxResult.Text += $"Сумма: {sum}\r\n";
                textBoxResult.Text += $"Среднее арифметическое: {average:F2}";
            }
            else
            {
                textBoxResult.Text = "NO";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxNumber.Clear();
            textBoxResult.Clear();
        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}