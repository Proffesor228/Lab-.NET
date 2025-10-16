using System;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void buttonConsoleTasks_Click(object sender, EventArgs e)
        {
            // Запускаем консольное приложение
            System.Diagnostics.Process.Start("ConsoleAppLaba3.exe");
        }

        private void buttonFormsTasks_Click(object sender, EventArgs e)
        {
            // Открываем форму с заданиями Windows Forms
            FormsTasksForm tasksForm = new FormsTasksForm();
            tasksForm.Show();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
