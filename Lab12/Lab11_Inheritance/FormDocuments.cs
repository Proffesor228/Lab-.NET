using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab11_Inheritance
{
    public partial class FormDocuments : Form
    {
        private Abiturient abiturient;
        private ListBox listBoxDocuments;
        private Button btnAddPassport, btnAddEducation, btnAddExam, btnAddSpecialization, btnAddMedical;
        private Button btnRemoveDocument, btnViewDocument, btnValidateAll, btnSaveDocuments;
        private TextBox txtDocumentInfo;
        private Label lblStatus;

        public FormDocuments(Abiturient abiturient)
        {
            this.abiturient = abiturient;
            InitializeComponent();
            LoadDocuments();
        }

        private void InitializeDocumentForm()
        {
            this.SuspendLayout();
            this.Text = $"Документы абитуриента: {abiturient.FullName}";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Список документов
            listBoxDocuments = new ListBox
            {
                Location = new Point(20, 20),
                Size = new Size(350, 400),
                Font = new Font("Consolas", 10)
            };
            listBoxDocuments.SelectedIndexChanged += ListBoxDocuments_SelectedIndexChanged;

            // Кнопки добавления документов
            int buttonY = 20;
            int buttonX = 400;

            btnAddPassport = CreateButton("Добавить паспорт", buttonX, buttonY += 40);
            btnAddPassport.Click += BtnAddPassport_Click;

            btnAddEducation = CreateButton("Добавить аттестат", buttonX, buttonY += 40);
            btnAddEducation.Click += BtnAddEducation_Click;

            btnAddExam = CreateButton("Добавить экзамен", buttonX, buttonY += 40);
            btnAddExam.Click += BtnAddExam_Click;

            btnAddSpecialization = CreateButton("Добавить заявление", buttonX, buttonY += 40);
            btnAddSpecialization.Click += BtnAddSpecialization_Click;

            btnAddMedical = CreateButton("Добавить медсправку", buttonX, buttonY += 40);
            btnAddMedical.Click += BtnAddMedical_Click;

            // Кнопки управления
            btnRemoveDocument = CreateButton("Удалить документ", 400, 300);
            btnRemoveDocument.Click += BtnRemoveDocument_Click;

            btnViewDocument = CreateButton("Просмотреть", 400, 340);
            btnViewDocument.Click += BtnViewDocument_Click;

            btnValidateAll = CreateButton("Проверить все", 400, 380);
            btnValidateAll.Click += BtnValidateAll_Click;

            btnSaveDocuments = CreateButton("Сохранить", 400, 420);
            btnSaveDocuments.Click += BtnSaveDocuments_Click;

            // Информация о документе
            txtDocumentInfo = new TextBox
            {
                Location = new Point(20, 430),
                Size = new Size(350, 120),
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Consolas", 9),
                ScrollBars = ScrollBars.Vertical
            };

            // Статус
            lblStatus = new Label
            {
                Location = new Point(20, 560),
                Size = new Size(500, 30),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Добавляем контролы на форму
            this.Controls.AddRange(new Control[] {
                listBoxDocuments, btnAddPassport, btnAddEducation, btnAddExam,
                btnAddSpecialization, btnAddMedical, btnRemoveDocument,
                btnViewDocument, btnValidateAll, btnSaveDocuments,
                txtDocumentInfo, lblStatus
            });

            this.ResumeLayout(false);
        }

        private Button CreateButton(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(180, 35),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 9)
            };
        }

        private void LoadDocuments()
        {
            listBoxDocuments.Items.Clear();
            var docs = abiturient.GetAllDocuments();

            foreach (var doc in docs)
            {
                listBoxDocuments.Items.Add($"{doc.DocumentType}: {GetDocDisplayName(doc)}");
            }

            UpdateStatus();
        }

        private string GetDocDisplayName(IDocument doc)
        {
            switch (doc)
            {
                case Passport p:
                    return p.FullName;
                case EducationDocument e:
                    return e.InstitutionName;
                case ExamResult er:
                    return er.Subject;
                case SpecializationApplication sa:
                    return sa.SpecializationName;
                case MedicalCertificate mc:
                    return mc.ClinicName;
                default:
                    return "Неизвестный документ";
            }
        }

        private void ListBoxDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDocuments.SelectedIndex >= 0)
            {
                var docs = abiturient.GetAllDocuments();
                if (listBoxDocuments.SelectedIndex < docs.Count)
                {
                    txtDocumentInfo.Text = docs[listBoxDocuments.SelectedIndex].GetInfo();
                }
            }
        }

        private void UpdateStatus()
        {
            string status = $"Документов: {abiturient.GetAllDocuments().Count} | ";
            status += $"Паспорт: {(abiturient.HasValidPassport() ? "✓" : "✗")} | ";
            status += $"Аттестат: {(abiturient.HasEducationDocument() ? "✓" : "✗")} | ";
            status += $"Заявление заполнено: {(abiturient.IsApplicationComplete() ? "✓" : "✗")}";

            lblStatus.Text = status;
            lblStatus.ForeColor = abiturient.IsApplicationComplete() ? Color.DarkGreen : Color.DarkRed;
        }

        private void ShowAddDocumentForm(IDocument document, string title)
        {
            var form = new FormAddDocument(document, title);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    abiturient.AddDocument(form.Document);
                    LoadDocuments();
                    MessageBox.Show("Документ добавлен успешно!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAddPassport_Click(object sender, EventArgs e)
        {
            var passport = new Passport
            {
                FullName = abiturient.FullName,
                BirthDate = abiturient.BirthDate
            };
            ShowAddDocumentForm(passport, "Добавление паспорта");
        }

        private void BtnAddEducation_Click(object sender, EventArgs e)
        {
            ShowAddDocumentForm(new EducationDocument(), "Добавление документа об образовании");
        }

        private void BtnAddExam_Click(object sender, EventArgs e)
        {
            ShowAddDocumentForm(new ExamResult(), "Добавление результата экзамена");
        }

        private void BtnAddSpecialization_Click(object sender, EventArgs e)
        {
            var app = new SpecializationApplication();
            ShowAddDocumentForm(app, "Добавление заявления на специальность");
        }

        private void BtnAddMedical_Click(object sender, EventArgs e)
        {
            ShowAddDocumentForm(new MedicalCertificate(), "Добавление медицинской справки");
        }

        private void BtnRemoveDocument_Click(object sender, EventArgs e)
        {
            if (listBoxDocuments.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Удалить выбранный документ?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // В реальном приложении здесь нужно получить номер документа
                    // Для упрощения удаляем по индексу
                    var docs = abiturient.GetAllDocuments();
                    if (listBoxDocuments.SelectedIndex < docs.Count)
                    {
                        var doc = docs[listBoxDocuments.SelectedIndex] as Document;
                        if (doc != null && abiturient.RemoveDocument(doc.DocumentNumber))
                        {
                            LoadDocuments();
                            txtDocumentInfo.Clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите документ для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnViewDocument_Click(object sender, EventArgs e)
        {
            if (listBoxDocuments.SelectedIndex >= 0)
            {
                var docs = abiturient.GetAllDocuments();
                if (listBoxDocuments.SelectedIndex < docs.Count)
                {
                    var info = docs[listBoxDocuments.SelectedIndex].GetInfo();
                    MessageBox.Show(info, "Информация о документе",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnValidateAll_Click(object sender, EventArgs e)
        {
            var invalidDocs = new List<string>();
            var docs = abiturient.GetAllDocuments();

            foreach (var doc in docs)
            {
                if (!doc.Validate())
                {
                    invalidDocs.Add(doc.DocumentType);
                }
            }

            if (invalidDocs.Count == 0)
            {
                MessageBox.Show("Все документы валидны!", "Проверка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Невалидные документы:\n{string.Join("\n", invalidDocs)}",
                    "Проверка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSaveDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                // Сохраняем информацию о документах в файл
                string filename = $"documents_{abiturient.Login}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                using (var writer = new System.IO.StreamWriter(filename))
                {
                    writer.WriteLine($"Абитуриент: {abiturient.FullName}");
                    writer.WriteLine($"Логин: {abiturient.Login}");
                    writer.WriteLine($"Дата экспорта: {DateTime.Now}");
                    writer.WriteLine(new string('-', 50));

                    foreach (var doc in abiturient.GetAllDocuments())
                    {
                        writer.WriteLine(doc.GetInfo());
                        writer.WriteLine(new string('-', 30));
                    }

                    writer.WriteLine($"\nИтог: {abiturient.GetAllDocuments().Count} документов");
                    writer.WriteLine($"Заявление заполнено: {(abiturient.IsApplicationComplete() ? "ДА" : "НЕТ")}");
                }

                MessageBox.Show($"Документы сохранены в файл: {filename}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}