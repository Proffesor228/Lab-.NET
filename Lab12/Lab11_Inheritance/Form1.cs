using System;
using System.IO;
using System.Windows.Forms;

namespace Lab11_Inheritance
{
    public partial class Form1 : Form
    {
        private TabControl tabControl1;
        private TabPage tabRegister, tabLogin;

        // Регистрация
        private Label lblRegisterTitle;
        private ComboBox cmbRegisterUserType;
        private TextBox txtFullName, txtEmail, txtPhone, txtLogin, txtPassword, txtAuthCode;
        private TextBox txtAddress, txtPosition, txtFaculty, txtSpecialization;
        private DateTimePicker dtpBirthDate;
        private Button btnRegister;
        private Label lblRegisterResult;

        // Авторизация
        private Label lblLoginTitle;
        private ComboBox cmbLoginUserType;
        private TabControl tabAuthMethods;
        private TabPage tabLoginPass, tabLoginCode;
        private TextBox txtLoginLogin, txtLoginPassword, txtLoginCode;
        private Button btnLogin;
        private Label lblLoginResult;

        private User currentUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Text = "Лаба 11 - Наследование и полиморфизм";
            this.Size = new System.Drawing.Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // TabControl
            this.tabControl1 = new TabControl();
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Controls.AddRange(new TabPage[] {
                this.tabRegister = new TabPage() { Text = "Регистрация" },
                this.tabLogin = new TabPage() { Text = "Авторизация" }
            });

            // ===== РЕГИСТРАЦИЯ =====
            this.lblRegisterTitle = new Label()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 25),
                Text = "Регистрация нового пользователя",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
            };

            // Выбор типа пользователя при регистрации
            this.cmbRegisterUserType = new ComboBox()
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(200, 20)
            };
            this.cmbRegisterUserType.Items.AddRange(new string[] { "Сотрудник", "Абитуриент", "Гость" });
            this.cmbRegisterUserType.SelectedIndex = 0;
            this.cmbRegisterUserType.SelectedIndexChanged += new EventHandler(this.cmbRegisterUserType_Changed);

            // Поля ввода
            int y = 90;
            this.txtFullName = CreateTextBox("ФИО:", ref y);
            this.txtEmail = CreateTextBox("Email:", ref y);
            this.txtPhone = CreateTextBox("Телефон:", ref y);
            this.txtAddress = CreateTextBox("Адрес:", ref y);
            this.dtpBirthDate = CreateDatePicker("Дата рождения:", ref y);
            this.txtLogin = CreateTextBox("Логин:", ref y);
            this.txtPassword = CreateTextBox("Пароль:", ref y);
            this.txtPassword.PasswordChar = '*';
            this.txtAuthCode = CreateTextBox("Код авторизации (6 цифр):", ref y);

            // Специфичные поля
            this.txtPosition = CreateTextBox("Должность:", ref y);
            this.txtFaculty = CreateTextBox("Факультет:", ref y);
            this.txtSpecialization = CreateTextBox("Специализация:", ref y);

            // Кнопка регистрации
            this.btnRegister = new Button()
            {
                Location = new System.Drawing.Point(20, y + 10),
                Size = new System.Drawing.Size(200, 35),
                Text = "Зарегистрировать",
                BackColor = System.Drawing.Color.LightBlue
            };
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // Результат регистрации
            this.lblRegisterResult = new Label()
            {
                Location = new System.Drawing.Point(20, y + 60),
                Size = new System.Drawing.Size(500, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Добавляем на вкладку регистрации
            this.tabRegister.Controls.AddRange(new Control[] {
                lblRegisterTitle, cmbRegisterUserType, txtFullName, txtEmail, txtPhone,
                txtAddress, dtpBirthDate, txtLogin, txtPassword, txtAuthCode,
                txtPosition, txtFaculty, txtSpecialization, btnRegister, lblRegisterResult
            });

            // ===== АВТОРИЗАЦИЯ =====
            this.lblLoginTitle = new Label()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 25),
                Text = "Авторизация пользователей",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
            };

            // Выбор типа пользователя при авторизации
            this.cmbLoginUserType = new ComboBox()
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(200, 20)
            };
            this.cmbLoginUserType.Items.AddRange(new string[] { "Сотрудник", "Абитуриент", "Гость" });
            this.cmbLoginUserType.SelectedIndex = 0;

            // Методы авторизации
            this.tabAuthMethods = new TabControl()
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(400, 150)
            };

            // Вкладка Логин/Пароль
            this.tabLoginPass = new TabPage() { Text = "Логин/Пароль" };
            this.txtLoginLogin = new TextBox() { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(200, 20) };
            this.txtLoginPassword = new TextBox() { Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(200, 20), PasswordChar = '*' };
            this.tabLoginPass.Controls.AddRange(new Control[] {
                new Label() { Location = new System.Drawing.Point(20, 0), Size = new System.Drawing.Size(100, 20), Text = "Логин:" },
                txtLoginLogin,
                new Label() { Location = new System.Drawing.Point(20, 40), Size = new System.Drawing.Size(100, 20), Text = "Пароль:" },
                txtLoginPassword
            });

            // Вкладка Код авторизации
            this.tabLoginCode = new TabPage() { Text = "Код авторизации" };
            this.txtLoginCode = new TextBox() { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(200, 20) };
            this.tabLoginCode.Controls.AddRange(new Control[] {
                new Label() { Location = new System.Drawing.Point(20, 0), Size = new System.Drawing.Size(150, 20), Text = "Код авторизации:" },
                txtLoginCode
            });

            this.tabAuthMethods.Controls.AddRange(new TabPage[] { tabLoginPass, tabLoginCode });

            // Кнопка входа
            this.btnLogin = new Button()
            {
                Location = new System.Drawing.Point(20, 260),
                Size = new System.Drawing.Size(200, 35),
                Text = "Войти",
                BackColor = System.Drawing.Color.LightGreen
            };
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Результат
            this.lblLoginResult = new Label()
            {
                Location = new System.Drawing.Point(20, 310),
                Size = new System.Drawing.Size(400, 40),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Добавляем на вкладку авторизации
            this.tabLogin.Controls.AddRange(new Control[] {
                lblLoginTitle, cmbLoginUserType, tabAuthMethods, btnLogin, lblLoginResult
            });

            // Добавляем на форму
            this.Controls.Add(tabControl1);
            this.ResumeLayout(false);

            // Скрываем специфичные поля по умолчанию
            UpdateRegistrationFields();
        }

        // Вспомогательные методы для создания контролов
        private TextBox CreateTextBox(string labelText, ref int y)
        {
            Label label = new Label()
            {
                Location = new System.Drawing.Point(20, y),
                Size = new System.Drawing.Size(120, 20),
                Text = labelText
            };
            TextBox textBox = new TextBox()
            {
                Location = new System.Drawing.Point(150, y),
                Size = new System.Drawing.Size(200, 20)
            };
            this.tabRegister.Controls.Add(label);
            y += 30;
            return textBox;
        }

        private DateTimePicker CreateDatePicker(string labelText, ref int y)
        {
            Label label = new Label()
            {
                Location = new System.Drawing.Point(20, y),
                Size = new System.Drawing.Size(120, 20),
                Text = labelText
            };
            DateTimePicker picker = new DateTimePicker()
            {
                Location = new System.Drawing.Point(150, y),
                Size = new System.Drawing.Size(200, 20),
                Value = DateTime.Now.AddYears(-25)
            };
            this.tabRegister.Controls.Add(label);
            y += 30;
            return picker;
        }

        // Обновление полей регистрации в зависимости от типа пользователя
        private void cmbRegisterUserType_Changed(object sender, EventArgs e)
        {
            UpdateRegistrationFields();
        }

        private void UpdateRegistrationFields()
        {
            string userType = cmbRegisterUserType.SelectedItem.ToString();

            // Показываем/скрываем специфичные поля
            txtPosition.Visible = (userType == "Сотрудник");
            txtFaculty.Visible = (userType == "Сотрудник");
            txtSpecialization.Visible = (userType == "Абитуриент");
        }

        // Регистрация пользователя
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string userType = cmbRegisterUserType.SelectedItem.ToString();
                User newUser = null;

                switch (userType)
                {
                    case "Сотрудник":
                        newUser = new Employee();
                        ((Employee)newUser).Position = txtPosition.Text;
                        ((Employee)newUser).Faculty = txtFaculty.Text;
                        ((Employee)newUser).Department = "Кафедра";
                        ((Employee)newUser).Salary = 50000;
                        ((Employee)newUser).HireDate = DateTime.Now;
                        break;
                    case "Абитуриент":
                        newUser = new Abiturient();
                        ((Abiturient)newUser).Specialization = txtSpecialization.Text;
                        ((Abiturient)newUser).AverageScore = 4.5m;
                        ((Abiturient)newUser).ExamScore = 85;
                        ((Abiturient)newUser).EducationForm = "Очная";
                        ((Abiturient)newUser).HasBenefits = false;
                        break;
                    case "Гость":
                        newUser = new Person();
                        break;
                }

                // Заполняем общие поля
                newUser.FullName = txtFullName.Text;
                newUser.BirthDate = dtpBirthDate.Value;
                newUser.Email = txtEmail.Text;
                newUser.Phone = txtPhone.Text;
                ((Person)newUser).Address = txtAddress.Text;
                newUser.Login = txtLogin.Text;
                newUser.Password = txtPassword.Text;
                newUser.AuthCode = txtAuthCode.Text;

                // Сохранение в файл
                newUser.SaveToFile();

                lblRegisterResult.Text = $"Регистрация успешна!\nСоздан пользователь: {newUser.FullName} ({newUser.GetUserType()})";
                lblRegisterResult.ForeColor = System.Drawing.Color.DarkGreen;

                // Очистка полей
                ClearRegistrationFields();
            }
            catch (Exception ex)
            {
                lblRegisterResult.Text = $"Ошибка регистрации: {ex.Message}";
                lblRegisterResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Авторизация пользователя
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userType = cmbLoginUserType.SelectedItem.ToString();
                User user = null;

                if (tabAuthMethods.SelectedTab == tabLoginPass)
                {
                    // Авторизация по логину/паролю
                    string login = txtLoginLogin.Text;
                    string password = txtLoginPassword.Text;

                    user = AuthorizeUser(login, password, userType, "login");
                }
                else
                {
                    // Авторизация по коду
                    string authCode = txtLoginCode.Text;

                    user = AuthorizeUser(null, null, userType, "code", authCode);
                }

                if (user != null)
                {
                    currentUser = user;
                    lblLoginResult.Text = $"Авторизация успешна!\nДобро пожаловать, {user.FullName} ({user.GetUserType()})";
                    lblLoginResult.ForeColor = System.Drawing.Color.DarkGreen;

                    Form2 userDetailsForm = new Form2(user);
                    userDetailsForm.Show();
                }
                else
                {
                    lblLoginResult.Text = "Ошибка авторизации! Проверьте введенные данные.";
                    lblLoginResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblLoginResult.Text = $"Ошибка: {ex.Message}";
                lblLoginResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        private User AuthorizeUser(string login, string password, string userType, string authMethod, string authCode = null)
        {
            string folder = "";
            switch (userType)
            {
                case "Сотрудник": folder = "employees"; break;
                case "Абитуриент": folder = "abiturients"; break;
                case "Гость": folder = "persons"; break;
            }

            if (authMethod == "login")
            {
                // Ищем пользователя по логину
                User user = null;
                switch (userType)
                {
                    case "Сотрудник": user = User.LoadFromFile<Employee>(login, folder); break;
                    case "Абитуриент": user = User.LoadFromFile<Abiturient>(login, folder); break;
                    case "Гость": user = User.LoadFromFile<Person>(login, folder); break;
                }

                if (user != null && user.AuthorizeByLogin(login, password))
                    return user;
            }
            else if (authMethod == "code")
            {
                // Ищем пользователя по коду
                string folderPath = folder;
                if (!Directory.Exists(folderPath))
                    return null;

                foreach (string file in System.IO.Directory.GetFiles(folderPath, "*.usr"))
                {
                    User user = null;
                    switch (userType)
                    {
                        case "Сотрудник": user = User.LoadFromFile<Employee>(System.IO.Path.GetFileNameWithoutExtension(file), folder); break;
                        case "Абитуриент": user = User.LoadFromFile<Abiturient>(System.IO.Path.GetFileNameWithoutExtension(file), folder); break;
                        case "Гость": user = User.LoadFromFile<Person>(System.IO.Path.GetFileNameWithoutExtension(file), folder); break;
                    }

                    if (user != null && user.AuthorizeByCode(authCode))
                        return user;
                }
            }

            return null;
        }

        private void ClearRegistrationFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtLogin.Clear();
            txtPassword.Clear();
            txtAuthCode.Clear();
            txtPosition.Clear();
            txtFaculty.Clear();
            txtSpecialization.Clear();
            dtpBirthDate.Value = DateTime.Now.AddYears(-25);
        }
    }
}