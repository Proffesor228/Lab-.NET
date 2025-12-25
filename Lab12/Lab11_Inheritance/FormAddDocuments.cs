using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab11_Inheritance
{
    public partial class FormAddDocument : Form
    {
        public IDocument Document { get; private set; }
        private Panel panelFields;
        private Button btnOK, btnCancel;

        public FormAddDocument(IDocument document, string title)
        {
            this.Document = document;
            InitializeComponent(title);
        }

        private void InitializeComponent(string title)
        {
            this.SuspendLayout();
            this.Text = title;
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            panelFields = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(460, 480),
                AutoScroll = true
            };

            CreateFieldsForDocument();

            btnOK = new Button
            {
                Text = "Сохранить",
                Location = new Point(200, 500),
                Size = new Size(90, 35),
                DialogResult = DialogResult.OK
            };

            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(300, 500),
                Size = new Size(90, 35),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { panelFields, btnOK, btnCancel });
            this.ResumeLayout(false);
        }

        private void CreateFieldsForDocument()
        {
            int y = 10;

            // Общие поля для всех документов
            if (Document is Document doc)
            {
                AddTextField("Номер документа:", doc.DocumentNumber ?? "", value => doc.DocumentNumber = value, ref y);
                AddDateField("Дата выдачи:", doc.IssueDate, value => doc.IssueDate = value, ref y);
                AddTextField("Кем выдан:", doc.IssuingAuthority ?? "", value => doc.IssuingAuthority = value, ref y);
            }

            // Специфичные поля
            switch (Document)
            {
                case Passport passport:
                    AddTextField("ФИО:", passport.FullName ?? "", value => passport.FullName = value, ref y);
                    AddDateField("Дата рождения:", passport.BirthDate, value => passport.BirthDate = value, ref y);
                    AddTextField("Место рождения:", passport.BirthPlace ?? "", value => passport.BirthPlace = value, ref y);
                    AddTextField("Пол:", passport.Gender ?? "", value => passport.Gender = value, ref y);
                    AddTextField("Гражданство:", passport.Citizenship ?? "", value => passport.Citizenship = value, ref y);
                    break;

                case EducationDocument education:
                    AddTextField("Учебное заведение:", education.InstitutionName ?? "", value => education.InstitutionName = value, ref y);
                    AddNumericField("Год окончания:", education.GraduationYear, value => education.GraduationYear = value, 1900, DateTime.Now.Year, ref y);
                    AddTextField("Квалификация:", education.Qualification ?? "", value => education.Qualification = value, ref y);
                    AddNumericField("Средний балл:", (int)(education.AverageGrade * 10), value => education.AverageGrade = value / 10m, 0, 100, ref y);
                    break;

                case ExamResult exam:
                    AddTextField("Предмет:", exam.Subject ?? "", value => exam.Subject = value, ref y);
                    AddNumericField("Баллы:", exam.Score, value => exam.Score = value, 0, exam.MaxScore, ref y);
                    AddDateField("Дата экзамена:", exam.ExamDate, value => exam.ExamDate = value, ref y);
                    break;

                case SpecializationApplication application:
                    AddTextField("Код специальности:", application.SpecializationCode ?? "", value => application.SpecializationCode = value, ref y);
                    AddTextField("Название:", application.SpecializationName ?? "", value => application.SpecializationName = value, ref y);
                    AddNumericField("Приоритет:", application.Priority, value => application.Priority = value, 1, 3, ref y);
                    AddTextField("Форма обучения:", application.StudyForm ?? "", value => application.StudyForm = value, ref y);
                    AddCheckBox("Бюджетное обучение:", application.IsBudget, value => application.IsBudget = value, ref y);
                    break;

                case MedicalCertificate medical:
                    AddCheckBox("Годен к обучению:", medical.IsHealthy, value => medical.IsHealthy = value, ref y);
                    AddTextField("Ограничения:", medical.Restrictions ?? "", value => medical.Restrictions = value, ref y);
                    AddDateField("Действительна до:", medical.ValidUntil, value => medical.ValidUntil = value, ref y);
                    AddTextField("Поликлиника:", medical.ClinicName ?? "", value => medical.ClinicName = value, ref y);
                    break;
            }
        }

        private void AddTextField(string label, string value, Action<string> setter, ref int y)
        {
            var lbl = new Label { Text = label, Location = new Point(10, y), Size = new Size(150, 20) };
            var txt = new TextBox { Text = value, Location = new Point(170, y), Size = new Size(250, 20) };
            txt.TextChanged += (s, e) => setter(txt.Text);

            panelFields.Controls.AddRange(new Control[] { lbl, txt });
            y += 30;
        }

        private void AddDateField(string label, DateTime value, Action<DateTime> setter, ref int y)
        {
            var lbl = new Label { Text = label, Location = new Point(10, y), Size = new Size(150, 20) };
            var dtp = new DateTimePicker { Value = value, Location = new Point(170, y), Size = new Size(150, 20) };
            dtp.ValueChanged += (s, e) => setter(dtp.Value);

            panelFields.Controls.AddRange(new Control[] { lbl, dtp });
            y += 30;
        }

        private void AddNumericField(string label, int value, Action<int> setter, int min, int max, ref int y)
        {
            var lbl = new Label { Text = label, Location = new Point(10, y), Size = new Size(150, 20) };
            var num = new NumericUpDown { Value = value, Minimum = min, Maximum = max, Location = new Point(170, y), Size = new Size(100, 20) };
            num.ValueChanged += (s, e) => setter((int)num.Value);

            panelFields.Controls.AddRange(new Control[] { lbl, num });
            y += 30;
        }

        private void AddCheckBox(string label, bool value, Action<bool> setter, ref int y)
        {
            var chk = new CheckBox { Text = label, Checked = value, Location = new Point(10, y), Size = new Size(200, 20) };
            chk.CheckedChanged += (s, e) => setter(chk.Checked);

            panelFields.Controls.Add(chk);
            y += 30;
        }
    }
}