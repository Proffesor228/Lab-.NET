using System;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class FormsTasksForm : Form
    {
        public FormsTasksForm()
        {
            InitializeComponent();
        }

        private void buttonTask1_Click(object sender, EventArgs e)
        {
            SeriesSumForm form = new SeriesSumForm();
            form.Show();
        }

        private void buttonTask2_Click(object sender, EventArgs e)
        {
           FunctionCalculationForm form = new FunctionCalculationForm();
            form.Show();
        }

        private void buttonTask3_Click(object sender, EventArgs e)
        {
           Zad3Form form = new Zad3Form();
            form.Show();
        }

        private void buttonTask4_Click(object sender, EventArgs e)
        {
            Zad4Form form = new Zad4Form();
            form.Show();
        }

        private void FormsTasksForm_Load(object sender, EventArgs e)
        {

        }
    }
}
