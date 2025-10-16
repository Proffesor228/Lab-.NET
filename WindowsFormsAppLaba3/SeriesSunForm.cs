using System;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class SeriesSumForm : Form
    {
        public SeriesSumForm()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double eps = Convert.ToDouble(textBoxEps.Text);

                if (eps <= 0)
                {
                    MessageBox.Show("Eps должен быть больше 0!", "Ошибка");
                    return;
                }

                double sum = 0;
                double term = 1;
                int n = 1;
                string steps = "";

                // Вычисляем сумму ряда
                while (Math.Abs(term) >= eps)
                {
                    // Вычисляем знаменатель: sqrt(1 * 2 * ... * n)
                    double denominator = 1;
                    for (int i = 1; i <= n; i++)
                    {
                        denominator *= i;
                    }
                    denominator = Math.Sqrt(denominator);

                    term = 1.0 / denominator;
                    sum += term;

                    steps += $"n = {n}: 1/√({n}!) = {term:F10}\r\n";
                    n++;

                    // Защита от бесконечного цикла
                    if (n > 1000) break;
                }

                textBoxResult.Text = $"Сумма ряда с точностью ε = {eps}:\r\n";
                textBoxResult.Text += $"S = {sum:F10}\r\n\r\n";
                textBoxResult.Text += $"Количество итераций: {n - 1}\r\n\r\n";
                textBoxResult.Text += "Вычисления по шагам:\r\n" + steps;
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное число для eps!", "Ошибка ввода");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxEps.Clear();
            textBoxResult.Clear();
        }
    }
}