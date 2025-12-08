using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab11_Inheritance
{
    public abstract class User
    {
        // Общие поля для всех пользователей
        private string _login;
        private string _password;
        private string _authCode;

        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Общие свойства с валидацией
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

        // Абстрактные методы для наследования
        public abstract string GetUserType();
        public abstract string GetDetails();

        // Виртуальные методы авторизации
        public virtual bool AuthorizeByLogin(string login, string password)
        {
            return this.Login == login && this.Password == password;
        }

        public virtual bool AuthorizeByCode(string authCode)
        {
            return this.AuthCode == authCode;
        }

        // Абстрактный метод сохранения
        public abstract void SaveToFile();

        // Статические методы для загрузки
        public static T LoadFromFile<T>(string login, string folder) where T : User, new()
        {
            string filePath = Path.Combine(folder, $"{login}.usr");
            if (!File.Exists(filePath))
                return null;

            T user = new T();

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
                            case "FullName": user.FullName = value; break;
                            case "BirthDate": user.BirthDate = DateTime.Parse(value); break;
                            case "Email": user.Email = value; break;
                            case "Phone": user.Phone = value; break;
                            case "Login": user.Login = value; break;
                            case "Password": user._password = value; break;
                            case "AuthCode": user.AuthCode = value; break;
                        }
                    }
                }
            }

            return user;
        }
    }
}