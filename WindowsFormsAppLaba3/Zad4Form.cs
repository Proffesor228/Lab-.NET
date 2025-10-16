using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HelloApp
{
    public partial class Zad4Form : Form
    {
        public Zad4Form()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBoxN.Text);

                if (n <= 0)
                {
                    MessageBox.Show("N должно быть больше 0!");
                    return;
                }

                long sum = 0;
                long factorial = 1;
                string steps = "";

                // Вычисляем сумму факториалов в одном цикле
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;  // вычисляем i!
                    sum += factorial; // добавляем к сумме

                    steps += $"{i}! = {factorial}";
                    if (i < n) steps += " + ";
                }

                textBoxResult.Text = $"Сумма факториалов от 1! до {n}!\r\n";
                textBoxResult.Text += $"Вычисление: {steps}\r\n";
                textBoxResult.Text += $"Результат: {sum}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целое число!");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число! Факториал растет очень быстро.");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxN.Clear();
            textBoxResult.Clear();
        }
    }
}