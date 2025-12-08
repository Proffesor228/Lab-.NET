using System;
using System.IO;

namespace Lab11_Inheritance
{
    public class Abiturient : Person
    {
        // Специфичные поля абитуриента
        public string Specialization { get; set; }
        public decimal AverageScore { get; set; }
        public int ExamScore { get; set; }
        public string EducationForm { get; set; } // очная, заочная
        public bool HasBenefits { get; set; }

        public override string GetUserType()
        {
            return "Абитуриент";
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"\n" +
                   $"Специализация: {Specialization}\n" +
                   $"Средний балл: {AverageScore}\n" +
                   $"Баллы за экзамен: {ExamScore}\n" +
                   $"Форма обучения: {EducationForm}\n" +
                   $"Льготы: {(HasBenefits ? "Да" : "Нет")}";
        }

        public override void SaveToFile()
        {
            string folderPath = "abiturients";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{Login}.usr");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"FullName:{FullName}");
                writer.WriteLine($"BirthDate:{BirthDate:yyyy-MM-dd}");
                writer.WriteLine($"Email:{Email}");
                writer.WriteLine($"Phone:{Phone}");
                writer.WriteLine($"Address:{Address}");
                writer.WriteLine($"Citizenship:{Citizenship}");
                writer.WriteLine($"Specialization:{Specialization}");
                writer.WriteLine($"AverageScore:{AverageScore}");
                writer.WriteLine($"ExamScore:{ExamScore}");
                writer.WriteLine($"EducationForm:{EducationForm}");
                writer.WriteLine($"HasBenefits:{HasBenefits}");
                writer.WriteLine($"Login:{Login}");
                writer.WriteLine($"Password:{Password}");
                writer.WriteLine($"AuthCode:{AuthCode}");
            }
        }

        // Статические методы авторизации для абитуриента
     
    }
}