using System;
using System.IO;
using System.Windows.Forms;

namespace Lab10_Authorization
{
    public partial class Form1 : Form
    {
        private TabControl tabControl1;
        private TabPage tabRegister, tabLogin;

        // Регистрация
        private Label lblRegisterTitle;
        private TextBox txtFullName, txtEmail, txtPhone, txtLogin, txtPassword, txtAuthCode;
        private ComboBox cmbPosition, cmbFaculty, cmbGender;
        private DateTimePicker dtpBirthDate;
        private Button btnRegister;
        private Label lblRegisterResult;

        // Авторизация
        private Label lblLoginTitle;
        private TabControl tabLoginMethods;
        private TabPage tabLoginPass, tabLoginCode, tabLoginKey;
        private TextBox txtLoginLogin, txtLoginPassword, txtLoginCode, txtLoginKeyFile;
        private Button btnLoginByPass, btnLoginByCode, btnLoginByKey, btnBrowseKey;
        private Label lblLoginResult;
        private Label lblCurrentUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Основная форма
            this.SuspendLayout();
            this.Text = "Система авторизации сотрудников";
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
                Text = "Регистрация нового сотрудника",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
            };

            // Поля ввода
            int y = 60;
            this.txtFullName = CreateTextBox("ФИО:", ref y);
            this.cmbPosition = CreateComboBox("Должность:", new string[] { "Преподаватель", "Доцент", "Профессор", "Декан", "Ректор" }, ref y);
            this.cmbFaculty = CreateComboBox("Факультет:", new string[] { "ИТ", "Экономика", "Юриспруденция", "Медицина", "Строительство" }, ref y);
            this.cmbGender = CreateComboBox("Пол:", new string[] { "Мужской", "Женский" }, ref y);
            this.dtpBirthDate = CreateDatePicker("Дата рождения:", ref y);
            this.txtEmail = CreateTextBox("Email:", ref y);
            this.txtPhone = CreateTextBox("Телефон:", ref y);
            this.txtLogin = CreateTextBox("Логин:", ref y);
            this.txtPassword = CreateTextBox("Пароль:", ref y); this.txtPassword.PasswordChar = '*';
            this.txtAuthCode = CreateTextBox("Код авторизации (6 цифр):", ref y);

            // Кнопка регистрации
            this.btnRegister = new Button()
            {
                Location = new System.Drawing.Point(150, y + 10),
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

            // Добавляем контролы на вкладку регистрации
            this.tabRegister.Controls.AddRange(new Control[] {
    lblRegisterTitle, txtFullName, cmbPosition, cmbFaculty, cmbGender,
    dtpBirthDate, txtEmail, txtPhone, txtLogin, txtPassword, txtAuthCode,
    btnRegister, lblRegisterResult });

            // ===== АВТОРИЗАЦИЯ =====
            this.lblLoginTitle = new Label()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 25),
                Text = "Авторизация сотрудника",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
            };

            // TabControl для методов авторизации
            this.tabLoginMethods = new TabControl()
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(500, 250)
            };

            // Вкладка Логин/Пароль
            this.tabLoginPass = new TabPage() { Text = "Логин/Пароль" };
            this.txtLoginLogin = CreateAuthTextBox("Логин:", 20, 20);
            this.txtLoginPassword = CreateAuthTextBox("Пароль:", 20, 70);  this.txtPassword.PasswordChar = '*';
            this.btnLoginByPass = CreateAuthButton("Войти", 20, 120);
            this.btnLoginByPass.Click += new EventHandler(this.btnLoginByPass_Click);
            this.tabLoginPass.Controls.AddRange(new Control[] {
    txtLoginLogin, txtLoginPassword, btnLoginByPass
});

            // Вкладка Код авторизации
            this.tabLoginCode = new TabPage() { Text = "Код авторизации" };
            this.txtLoginCode = CreateAuthTextBox("Код авторизации:", 20, 20);
            this.btnLoginByCode = CreateAuthButton("Войти по коду", 20, 70);
            this.btnLoginByCode.Click += new EventHandler(this.btnLoginByCode_Click);
            this.tabLoginCode.Controls.AddRange(new Control[] {
    txtLoginCode, btnLoginByCode
});

            // Вкладка Файл-ключ
            this.tabLoginKey = new TabPage() { Text = "Файл-ключ" };
            this.txtLoginKeyFile = CreateAuthTextBox("Путь к файлу:", 20, 20);
            this.btnBrowseKey = new Button()
            {
                Location = new System.Drawing.Point(350, 18),
                Size = new System.Drawing.Size(80, 23),
                Text = "Обзор..."
            };
            this.btnBrowseKey.Click += new EventHandler(this.btnBrowseKey_Click);
            this.btnLoginByKey = CreateAuthButton("Войти по ключу", 20, 70);
            this.btnLoginByKey.Click += new EventHandler(this.btnLoginByKey_Click);
            this.tabLoginKey.Controls.AddRange(new Control[] {
    txtLoginKeyFile, btnBrowseKey, btnLoginByKey
});
            this.tabLoginMethods.Controls.AddRange(new TabPage[] {
                tabLoginPass, tabLoginCode, tabLoginKey
            });

            // Результат авторизации
            this.lblLoginResult = new Label()
            {
                Location = new System.Drawing.Point(20, 320),
                Size = new System.Drawing.Size(500, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Текущий пользователь
            this.lblCurrentUser = new Label()
            {
                Location = new System.Drawing.Point(20, 390),
                Size = new System.Drawing.Size(500, 30),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkGreen
            };

            // Добавляем контролы на вкладку авторизации
            this.tabLogin.Controls.AddRange(new Control[] {
                lblLoginTitle, tabLoginMethods, lblLoginResult, lblCurrentUser
            });

            // Добавляем TabControl на форму
            this.Controls.Add(this.tabControl1);
            this.ResumeLayout(false);
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
            // ДОБАВЛЯЕМ ЛЕЙБЛ В КОНТРОЛЫ
            this.tabRegister.Controls.Add(label);
            y += 30;
            return textBox;
        }

        private ComboBox CreateComboBox(string labelText, string[] items, ref int y)
        {
            Label label = new Label()
            {
                Location = new System.Drawing.Point(20, y),
                Size = new System.Drawing.Size(120, 20),
                Text = labelText
            };
            ComboBox combo = new ComboBox()
            {
                Location = new System.Drawing.Point(150, y),
                Size = new System.Drawing.Size(200, 20)
            };
            combo.Items.AddRange(items);
            combo.SelectedIndex = 0;
            // ДОБАВЛЯЕМ ЛЕЙБЛ В КОНТРОЛЫ
            this.tabRegister.Controls.Add(label);
            y += 30;
            return combo;
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
            // ДОБАВЛЯЕМ ЛЕЙБЛ В КОНТРОЛЫ
            this.tabRegister.Controls.Add(label);
            y += 30;
            return picker;
        }

        private TextBox CreateAuthTextBox(string labelText, int x, int y)
        {
            Label label = new Label()
            {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(120, 20),
                Text = labelText
            };
            TextBox textBox = new TextBox()
            {
                Location = new System.Drawing.Point(x + 130, y),
                Size = new System.Drawing.Size(200, 20)
            };
            return textBox;
        }

        private Button CreateAuthButton(string text, int x, int y)
        {
            return new Button()
            {
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(150, 30),
                Text = text,
                BackColor = System.Drawing.Color.LightGreen
            };
        }

      

        // Обработчики событий
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Employee newEmployee = new Employee();

                // Валидация через свойства
                newEmployee.FullName = txtFullName.Text;
                newEmployee.Position = cmbPosition.SelectedItem.ToString();
                newEmployee.Faculty = cmbFaculty.SelectedItem.ToString();
                newEmployee.Gender = cmbGender.SelectedItem.ToString();
                newEmployee.BirthDate = dtpBirthDate.Value;
                newEmployee.Email = txtEmail.Text;
                newEmployee.Phone = txtPhone.Text;
                newEmployee.Login = txtLogin.Text;
                newEmployee.Password = txtPassword.Text;
                newEmployee.AuthCode = txtAuthCode.Text;

                // Сохранение в файл
                newEmployee.SaveToFile();

                lblRegisterResult.Text = $"Регистрация успешна!\nФайл сохранен: employees/{newEmployee.Login}.emp";
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

        private void btnLoginByPass_Click(object sender, EventArgs e)
        {
            Employee user = Employee.AuthorizeByLogin(txtLoginLogin.Text, txtLoginPassword.Text);
            ProcessAuthorizationResult(user, "Логин/Пароль");
        }

        private void btnLoginByCode_Click(object sender, EventArgs e)
        {
            Employee user = Employee.AuthorizeByCode(txtLoginCode.Text);
            ProcessAuthorizationResult(user, "Код авторизации");
        }

        private void btnLoginByKey_Click(object sender, EventArgs e)
        {
            Employee user = Employee.AuthorizeByKey(txtLoginKeyFile.Text);
            ProcessAuthorizationResult(user, "Файл-ключ");
        }

        private void btnBrowseKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtLoginKeyFile.Text = dialog.FileName;
            }
        }

        private void ProcessAuthorizationResult(Employee user, string method)
        {
            if (user != null)
            {
                lblLoginResult.Text = $"Авторизация успешна! ({method})\nДобро пожаловать, {user.FullName}";
                lblLoginResult.ForeColor = System.Drawing.Color.DarkGreen;
                lblCurrentUser.Text = $"Текущий пользователь: {user.FullName} ({user.Position})";

                // Очистка полей авторизации
                ClearLoginFields();
            }
            else
            {
                lblLoginResult.Text = $"Ошибка авторизации! ({method})\nПроверьте введенные данные";
                lblLoginResult.ForeColor = System.Drawing.Color.Red;
                lblCurrentUser.Text = "";
            }
        }

        private void ClearRegistrationFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtLogin.Clear();
            txtPassword.Clear();
            txtAuthCode.Clear();
            cmbPosition.SelectedIndex = 0;
            cmbFaculty.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            dtpBirthDate.Value = DateTime.Now.AddYears(-25);
        }

        private void ClearLoginFields()
        {
            txtLoginLogin.Clear();
            txtLoginPassword.Clear();
            txtLoginCode.Clear();
            txtLoginKeyFile.Clear();
        }


    }
}