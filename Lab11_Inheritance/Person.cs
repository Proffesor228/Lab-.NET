using System;
using System.IO;

namespace Lab11_Inheritance
{
    public class Person : User
    {
        public string Address { get; set; }
        public string Citizenship { get; set; }

        public Person()
        {
            Citizenship = "Россия"; // значение по умолчанию
        }

        public override string GetUserType()
        {
            return "Гость";
        }

        public override string GetDetails()
        {
            return $"Тип: {GetUserType()}\n" +
                   $"ФИО: {FullName}\n" +
                   $"Дата рождения: {BirthDate:dd.MM.yyyy}\n" +
                   $"Email: {Email}\n" +
                   $"Телефон: {Phone}\n" +
                   $"Адрес: {Address}\n" +
                   $"Гражданство: {Citizenship}";
        }

        // Авторизация гостя (упрощенная)
        public override bool AuthorizeByLogin(string login, string password)
        {
            // Гости могут авторизоваться без строгой проверки
            return this.Login == login;
        }

        public override void SaveToFile()
        {
            string folderPath = "persons";
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
                writer.WriteLine($"Login:{Login}");
                writer.WriteLine($"Password:{Password}");
                writer.WriteLine($"AuthCode:{AuthCode}");
            }
        }

        // Статические методы авторизации для гостя
        public static Person AuthorizeGuestByLogin(string login, string password)
        {
            Person person = LoadFromFile<Person>(login, "persons");
            if (person != null && person.AuthorizeByLogin(login, password))
                return person;
            return null;
        }

        public static Person AuthorizeGuestByCode(string authCode)
        {
            string folderPath = "persons";
            if (!Directory.Exists(folderPath))
                return null;

            foreach (string file in Directory.GetFiles(folderPath, "*.usr"))
            {
                Person person = LoadFromFile<Person>(Path.GetFileNameWithoutExtension(file), "persons");
                if (person != null && person.AuthorizeByCode(authCode))
                    return person;
            }
            return null;
        }
    }
}