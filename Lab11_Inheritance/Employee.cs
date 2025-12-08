using System;
using System.IO;

namespace Lab11_Inheritance
{
    public class Employee : Person
    {
        // Специфичные поля сотрудника
        public string Position { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        public override string GetUserType()
        {
            return "Сотрудник";
        }

        public override string GetDetails()
        {
            return base.GetDetails() + $"\n" +
                   $"Должность: {Position}\n" +
                   $"Факультет: {Faculty}\n" +
                   $"Кафедра: {Department}\n" +
                   $"Зарплата: {Salary} руб.\n" +
                   $"Дата приема: {HireDate:dd.MM.yyyy}";
        }

        public override void SaveToFile()
        {
            string folderPath = "employees";
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
                writer.WriteLine($"Position:{Position}");
                writer.WriteLine($"Faculty:{Faculty}");
                writer.WriteLine($"Department:{Department}");
                writer.WriteLine($"Salary:{Salary}");
                writer.WriteLine($"HireDate:{HireDate:yyyy-MM-dd}");
                writer.WriteLine($"Login:{Login}");
                writer.WriteLine($"Password:{Password}");
                writer.WriteLine($"AuthCode:{AuthCode}");
            }
        }
    }
}