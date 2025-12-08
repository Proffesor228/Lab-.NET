using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab10_Authorization
{
    public class Employee
    {
        // Поля для авторизации
        private string _login;
        private string _password;
        private string _authCode;

        // Основные поля
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Faculty { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Свойства с валидацией
        public string Login
        {
            get { return _login; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Логин не может быть пустым");
                if (value.Length < 3)
                    throw new ArgumentException("Логин должен содержать минимум 3 символа");
                _login = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Пароль не может быть пустым");
                if (value.Length < 8)
                    throw new ArgumentException("Пароль должен содержать минимум 8 символов");
                if (value.Contains(" "))
                    throw new ArgumentException("Пароль не должен содержать пробелы");
                if (!Regex.IsMatch(value, @"[0-9]"))
                    throw new ArgumentException("Пароль должен содержать цифры");
                if (!Regex.IsMatch(value, @"[A-Z]"))
                    throw new ArgumentException("Пароль должен содержать заглавные буквы");
                if (!Regex.IsMatch(value, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
                    throw new ArgumentException("Пароль должен содержать специальные символы");

                _password = value;
            }
        }

        public string AuthCode
        {
            get { return _authCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Код авторизации не может быть пустым");
                if (value.Length != 6)
                    throw new ArgumentException("Код авторизации должен содержать 6 символов");
                _authCode = value;
            }
        }

        // Конструктор
        public Employee() { }

        // Метод для сохранения в файл
        public void SaveToFile()
        {
            string folderPath = "employees";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{Login}.emp");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"FullName:{FullName}");
                writer.WriteLine($"Position:{Position}");
                writer.WriteLine($"Faculty:{Faculty}");
                writer.WriteLine($"Gender:{Gender}");
                writer.WriteLine($"BirthDate:{BirthDate:yyyy-MM-dd}");
                writer.WriteLine($"Email:{Email}");
                writer.WriteLine($"Phone:{Phone}");
                writer.WriteLine($"Login:{Login}");
                writer.WriteLine($"Password:{Password}");
                writer.WriteLine($"AuthCode:{AuthCode}");
            }
        }

        // Метод для загрузки из файла
        public static Employee LoadFromFile(string login)
        {
            string filePath = Path.Combine("employees", $"{login}.emp");
            if (!File.Exists(filePath))
                return null;

            Employee employee = new Employee();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0];
                        string value = parts[1];

                        switch (key)
                        {
                            case "FullName": employee.FullName = value; break;
                            case "Position": employee.Position = value; break;
                            case "Faculty": employee.Faculty = value; break;
                            case "Gender": employee.Gender = value; break;
                            case "BirthDate": employee.BirthDate = DateTime.Parse(value); break;
                            case "Email": employee.Email = value; break;
                            case "Phone": employee.Phone = value; break;
                            case "Login": employee.Login = value; break;
                            case "Password": employee._password = value; break;
                            case "AuthCode": employee.AuthCode = value; break;
                        }
                    }
                }
            }

            return employee;
        }

        // Методы авторизации
        public static Employee AuthorizeByLogin(string login, string password)
        {
            Employee employee = LoadFromFile(login);
            if (employee != null && employee.Password == password)
                return employee;
            return null;
        }

        public static Employee AuthorizeByCode(string authCode)
        {
            string folderPath = "employees";
            if (!Directory.Exists(folderPath))
                return null;

            foreach (string file in Directory.GetFiles(folderPath, "*.emp"))
            {
                Employee employee = LoadFromFile(Path.GetFileNameWithoutExtension(file));
                if (employee != null && employee.AuthCode == authCode)
                    return employee;
            }
            return null;
        }

        public static Employee AuthorizeByKey(string keyFilePath)
        {
            if (!File.Exists(keyFilePath))
                return null;

            string authCode = File.ReadAllText(keyFilePath).Trim();
            return AuthorizeByCode(authCode);
        }
    }
}