using System;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class FunctionCalculationForm : Form
    {
        public FunctionCalculationForm()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double start = 1.0; // начало отрезка [1;5]
                double end = 5.0;   // конец отрезка [1;5]
                double step = 0.1;  // шаг вычислений

                double sum = 0;
                string results = "";
                int pointCount = 0;

                // Вычисляем значения функции на отрезке [1;5]
                for (double x = start; x <= end; x += step)
                {
                    // Функция: 4 - x - 4/(x^2)
                    double value = 4 - x - (4 / (x * x));
                    sum += value;
                    pointCount++;

                    results += $"x = {x:F2}, f(x) = {value:F4}\r\n";
                }

                textBoxResult.Text = $"Функция: f(x) = 4 - x - 4/x²\r\n";
                textBoxResult.Text += $"Отрезок: [{start}; {end}]\r\n";
                textBoxResult.Text += $"Шаг: {step}\r\n\r\n";
                textBoxResult.Text += $"Количество точек: {pointCount}\r\n";
                textBoxResult.Text += $"Сумма значений функции: {sum:F4}\r\n\r\n";
                textBoxResult.Text += "Значения функции в точках:\r\n" + results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка вычислений");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
        }
    }
}