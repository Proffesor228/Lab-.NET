using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab11_Inheritance
{
    public partial class Form2 : Form
    {
        private User user;
        private Label lblUserDetails;
        private TextBox txtDetails;
        private Button btnClose;
        private Button btnShowDocuments;
        private Button btnCheckApplication;
        private Button btnExportData;

        public Form2(User user)
        {
            this.user = user;
            InitializeComponent();
            UpdateUserDetails();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Text = $"Детали пользователя - {user.GetUserType()}";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;

            // Заголовок
            Label lblTitle = new Label()
            {
                Location = new Point(20, 20),
                Size = new Size(450, 30),
                Text = $"Пользователь: {user.FullName}",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Поле с деталями пользователя
            txtDetails = new TextBox()
            {
                Location = new Point(20, 60),
                Size = new Size(450, 250),
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Consolas", 10),
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.LightYellow,
                BorderStyle = BorderStyle.FixedSingle
            };

            int buttonY = 320;
            int buttonX = 20;

            // Кнопка управления документами (только для абитуриентов)
            if (user is Abiturient)
            {
                btnShowDocuments = new Button()
                {
                    Location = new Point(buttonX, buttonY),
                    Size = new Size(200, 40),
                    Text = "Управление документами",
                    Font = new Font("Arial", 10),
                    BackColor = Color.LightBlue,
                    ForeColor = Color.Black
                };
                btnShowDocuments.Click += new EventHandler(btnShowDocuments_Click);
                buttonY += 50;
            }

            // Кнопка проверки заявления
            if (user is Abiturient)
            {
                btnCheckApplication = new Button()
                {
                    Location = new Point(buttonX, buttonY),
                    Size = new Size(200, 40),
                    Text = "Проверить заявление",
                    Font = new Font("Arial", 10),
                    BackColor = Color.LightGreen,
                    ForeColor = Color.Black
                };
                btnCheckApplication.Click += new EventHandler(btnCheckApplication_Click);
                buttonY += 50;
            }

            // Кнопка экспорта данных
            btnExportData = new Button()
            {
                Location = new Point(buttonX, buttonY),
                Size = new Size(200, 40),
                Text = "Экспорт данных",
                Font = new Font("Arial", 10),
                BackColor = Color.LightCoral,
                ForeColor = Color.Black
            };
            btnExportData.Click += new EventHandler(btnExportData_Click);
            buttonY += 50;

            // Кнопка закрытия
            btnClose = new Button()
            {
                Location = new Point(200, 400),
                Size = new Size(100, 40),
                Text = "Закрыть",
                Font = new Font("Arial", 10),
                BackColor = Color.Silver
            };
            btnClose.Click += new EventHandler(btnClose_Click);

            // Добавляем контролы на форму
            Control[] controls = { lblTitle, txtDetails, btnExportData, btnClose };

            if (user is Abiturient)
            {
                controls = new Control[] { lblTitle, txtDetails, btnShowDocuments,
                    btnCheckApplication, btnExportData, btnClose };
            }

            this.Controls.AddRange(controls);
            this.ResumeLayout(false);
        }

        private void UpdateUserDetails()
        {
            txtDetails.Text = user.GetDetails();

            // Добавляем информацию о документах для абитуриента
            if (user is Abiturient abiturient)
            {
                txtDetails.Text += "\n\n=== ДОКУМЕНТЫ АБИТУРИЕНТА ===\n";

                var documents = abiturient.GetAllDocuments();
                if (documents.Count == 0)
                {
                    txtDetails.Text += "Документы не добавлены\n";
                }
                else
                {
                    txtDetails.Text += $"Всего документов: {documents.Count}\n";

                    // Сгруппируем по типам
                    var groups = documents.GroupBy(d => d.DocumentType);
                    foreach (var group in groups)
                    {
                        txtDetails.Text += $"{group.Key}: {group.Count()} шт.\n";
                    }

                    txtDetails.Text += $"\nПаспорт: {(abiturient.HasValidPassport() ? "✓ Валиден" : "✗ Отсутствует/Невалиден")}\n";
                    txtDetails.Text += $"Аттестат: {(abiturient.HasEducationDocument() ? "✓ Прикреплен" : "✗ Отсутствует")}\n";
                    txtDetails.Text += $"Заявление: {(abiturient.IsApplicationComplete() ? "✓ Полностью заполнено" : "✗ Не заполнено")}\n";

                    int totalScore = abiturient.GetTotalExamScore();
                    txtDetails.Text += $"Общая сумма баллов за экзамены: {totalScore}\n";
                }
            }
        }

        private void btnShowDocuments_Click(object sender, EventArgs e)
        {
            if (user is Abiturient abiturient)
            {
                try
                {
                    FormDocuments formDocuments = new FormDocuments(abiturient);
                    formDocuments.ShowDialog();
                    UpdateUserDetails(); // Обновляем информацию после закрытия формы документов
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка открытия формы документов: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCheckApplication_Click(object sender, EventArgs e)
        {
            if (user is Abiturient abiturient)
            {
                string message = "ПРОВЕРКА ЗАЯВЛЕНИЯ АБИТУРИЕНТА\n\n";
                message += $"Абитуриент: {abiturient.FullName}\n";
                message += $"Специализация: {abiturient.Specialization}\n";
                message += $"Средний балл: {abiturient.AverageScore}\n";
                message += $"Баллы за экзамены: {abiturient.ExamScore}\n";
                message += $"Льготы: {(abiturient.HasBenefits ? "Да" : "Нет")}\n\n";

                message += "СТАТУС ДОКУМЕНТОВ:\n";

                bool allValid = true;

                // Проверка паспорта
                if (!abiturient.HasValidPassport())
                {
                    message += "✗ Паспорт отсутствует или невалиден\n";
                    allValid = false;
                }
                else
                {
                    message += "✓ Паспорт валиден\n";
                }

                // Проверка аттестата
                if (!abiturient.HasEducationDocument())
                {
                    message += "✗ Документ об образовании отсутствует\n";
                    allValid = false;
                }
                else
                {
                    message += "✓ Документ об образовании прикреплен\n";
                }

                // Проверка заявлений
                var applications = abiturient.GetDocumentsByType("Заявление на специальность");
                if (applications.Count == 0)
                {
                    message += "✗ Заявление на специальность не подано\n";
                    allValid = false;
                }
                else
                {
                    message += $"✓ Подано заявлений: {applications.Count}\n";
                }

                // Проверка медсправки
                var medicalCerts = abiturient.GetDocumentsByType("Медицинская справка")
                    .OfType<MedicalCertificate>();
                bool hasValidMedical = medicalCerts.Any(m => m.IsHealthy && m.Validate());
                if (!hasValidMedical)
                {
                    message += "✗ Отсутствует действительная медицинская справка\n";
                    allValid = false;
                }
                else
                {
                    message += "✓ Медицинская справка действительна\n";
                }

                // Проверка экзаменов
                var exams = abiturient.GetDocumentsByType("Результат экзамена");
                if (exams.Count == 0)
                {
                    message += "✗ Результаты экзаменов отсутствуют\n";
                    allValid = false;
                }
                else
                {
                    message += $"✓ Сдано экзаменов: {exams.Count}\n";
                }

                message += $"\nИТОГ: Заявление {(allValid ? "ПОЛНОСТЬЮ ЗАПОЛНЕНО" : "НЕ ЗАПОЛНЕНО")}";

                MessageBox.Show(message, "Проверка заявления",
                    MessageBoxButtons.OK, allValid ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = $"user_data_{user.Login}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename))
                {
                    writer.WriteLine("ДАННЫЕ ПОЛЬЗОВАТЕЛЯ");
                    writer.WriteLine("===================");
                    writer.WriteLine($"Дата экспорта: {DateTime.Now}");
                    writer.WriteLine($"Тип пользователя: {user.GetUserType()}");
                    writer.WriteLine();
                    writer.WriteLine(user.GetDetails());

                    if (user is Abiturient abiturient)
                    {
                        writer.WriteLine("\nДОКУМЕНТЫ АБИТУРИЕНТА");
                        writer.WriteLine("======================");

                        var documents = abiturient.GetAllDocuments();
                        if (documents.Count > 0)
                        {
                            foreach (var doc in documents)
                            {
                                writer.WriteLine();
                                writer.WriteLine(new string('-', 50));
                                writer.WriteLine(doc.GetInfo());
                            }
                        }
                        else
                        {
                            writer.WriteLine("Документы отсутствуют");
                        }

                        writer.WriteLine($"\nИтоговый статус: Заявление {(abiturient.IsApplicationComplete() ? "заполнено" : "не заполнено")}");
                    }
                }

                MessageBox.Show($"Данные сохранены в файл: {filename}", "Экспорт завершен",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}