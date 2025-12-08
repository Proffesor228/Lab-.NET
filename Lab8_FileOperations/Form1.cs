using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace Lab8_FileOperations
{
    public partial class Form1 : Form
    {
        private TabControl tabControl1;
        private TabPage tabPage1, tabPage2, tabPage3, tabPage4;

        // Задача 1 - Произведение чисел
        private Label label1;
        private Button btnGenerateNumbers;
        private Button btnCalculate;
        private Label labelResult1;
        private ListBox listBoxNumbers;

        // Задача 2 - Создание папки
        private Label label2;
        private TextBox txtFolderName;
        private Button btnCreateFolder;
        private Label labelResult2;

        // Задача 3 - Создание файла
        private Label label3;
        private TextBox txtFileName;
        private TextBox txtFileContent;
        private Button btnCreateFileWriteAll;
        private Button btnCreateFileStream;
        private Button btnCreateFileAppend;
        private Label labelResult3;

        // Задача 4 - Чтение файла
        private Label label4;
        private TextBox txtReadFileName;
        private Button btnReadFile;
        private Button btnBrowseFile;
        private Label labelResult4;
        private ListBox listBoxFileContent;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Основная форма
            this.SuspendLayout();
            this.Text = "Лаба 8 - Операции с файлами";
            this.Size = new System.Drawing.Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // TabControl
            this.tabControl1 = new TabControl();
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Controls.AddRange(new TabPage[] {
                this.tabPage1 = new TabPage() { Text = "Задача 1" },
                this.tabPage2 = new TabPage() { Text = "Задача 2" },
                this.tabPage3 = new TabPage() { Text = "Задача 3" },
                this.tabPage4 = new TabPage() { Text = "Задача 4" }
            });

            // ===== ЗАДАЧА 1 - Произведение чисел =====
            this.label1 = new Label()
            {
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(300, 20),
                Text = "1. Произведение целых чисел в файле",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold)
            };

            this.btnGenerateNumbers = new Button()
            {
                Location = new System.Drawing.Point(15, 45),
                Size = new System.Drawing.Size(150, 30),
                Text = "Сгенерировать числа"
            };
            this.btnGenerateNumbers.Click += new EventHandler(this.btnGenerateNumbers_Click);

            this.btnCalculate = new Button()
            {
                Location = new System.Drawing.Point(15, 85),
                Size = new System.Drawing.Size(150, 30),
                Text = "Найти произведение"
            };
            this.btnCalculate.Click += new EventHandler(this.btnCalculate_Click);

            this.labelResult1 = new Label()
            {
                Location = new System.Drawing.Point(15, 125),
                Size = new System.Drawing.Size(300, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            this.listBoxNumbers = new ListBox()
            {
                Location = new System.Drawing.Point(180, 45),
                Size = new System.Drawing.Size(150, 200)
            };

            this.tabPage1.Controls.AddRange(new Control[] {
                label1, btnGenerateNumbers, btnCalculate, labelResult1, listBoxNumbers
            });

            // ===== ЗАДАЧА 2 - Создание папки =====
            this.label2 = new Label()
            {
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(300, 20),
                Text = "2. Создание папки",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold)
            };

            this.txtFolderName = new TextBox()
            {
                Location = new System.Drawing.Point(15, 45),
                Size = new System.Drawing.Size(200, 20),
                Text = "НоваяПапка"
            };

            this.btnCreateFolder = new Button()
            {
                Location = new System.Drawing.Point(15, 75),
                Size = new System.Drawing.Size(200, 30),
                Text = "Создать папку"
            };
            this.btnCreateFolder.Click += new EventHandler(this.btnCreateFolder_Click);

            this.labelResult2 = new Label()
            {
                Location = new System.Drawing.Point(15, 115),
                Size = new System.Drawing.Size(400, 80),
                BorderStyle = BorderStyle.FixedSingle
            };

            this.tabPage2.Controls.AddRange(new Control[] {
                label2, txtFolderName, btnCreateFolder, labelResult2
            });

            // ===== ЗАДАЧА 3 - Создание файла =====
            this.label3 = new Label()
            {
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(300, 20),
                Text = "3. Создание текстового файла",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold)
            };

            this.txtFileName = new TextBox()
            {
                Location = new System.Drawing.Point(15, 45),
                Size = new System.Drawing.Size(200, 20),
                Text = "example.txt"
            };

            this.txtFileContent = new TextBox()
            {
                Location = new System.Drawing.Point(15, 75),
                Size = new System.Drawing.Size(300, 80),
                Multiline = true,
                Text = "Это содержимое файла.\nВторая строка.\nТретья строка."
            };

            this.btnCreateFileWriteAll = new Button()
            {
                Location = new System.Drawing.Point(15, 165),
                Size = new System.Drawing.Size(200, 30),
                Text = "Создать (File.WriteAllText)"
            };
            this.btnCreateFileWriteAll.Click += new EventHandler(this.btnCreateFileWriteAll_Click);

            this.btnCreateFileStream = new Button()
            {
                Location = new System.Drawing.Point(15, 200),
                Size = new System.Drawing.Size(200, 30),
                Text = "Создать (FileStream)"
            };
            this.btnCreateFileStream.Click += new EventHandler(this.btnCreateFileStream_Click);

            this.btnCreateFileAppend = new Button()
            {
                Location = new System.Drawing.Point(15, 235),
                Size = new System.Drawing.Size(200, 30),
                Text = "Добавить (Append)"
            };
            this.btnCreateFileAppend.Click += new EventHandler(this.btnCreateFileAppend_Click);

            this.labelResult3 = new Label()
            {
                Location = new System.Drawing.Point(15, 275),
                Size = new System.Drawing.Size(400, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            this.tabPage3.Controls.AddRange(new Control[] {
                label3, txtFileName, txtFileContent, btnCreateFileWriteAll,
                btnCreateFileStream, btnCreateFileAppend, labelResult3
            });

            // ===== ЗАДАЧА 4 - Чтение файла =====
            this.label4 = new Label()
            {
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(300, 20),
                Text = "4. Чтение из файла",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold)
            };

            this.txtReadFileName = new TextBox()
            {
                Location = new System.Drawing.Point(15, 45),
                Size = new System.Drawing.Size(200, 20),
                Text = "example.txt"
            };

            this.btnBrowseFile = new Button()
            {
                Location = new System.Drawing.Point(220, 43),
                Size = new System.Drawing.Size(80, 25),
                Text = "Обзор..."
            };
            this.btnBrowseFile.Click += new EventHandler(this.btnBrowseFile_Click);

            this.btnReadFile = new Button()
            {
                Location = new System.Drawing.Point(15, 75),
                Size = new System.Drawing.Size(285, 30),
                Text = "Прочитать файл"
            };
            this.btnReadFile.Click += new EventHandler(this.btnReadFile_Click);

            this.listBoxFileContent = new ListBox()
            {
                Location = new System.Drawing.Point(15, 115),
                Size = new System.Drawing.Size(400, 150)
            };

            this.labelResult4 = new Label()
            {
                Location = new System.Drawing.Point(15, 275),
                Size = new System.Drawing.Size(400, 60),
                BorderStyle = BorderStyle.FixedSingle
            };

            this.tabPage4.Controls.AddRange(new Control[] {
                label4, txtReadFileName, btnBrowseFile, btnReadFile,
                listBoxFileContent, labelResult4
            });

            // Добавляем TabControl на форму
            this.Controls.Add(this.tabControl1);
            this.ResumeLayout(false);
        }

        // ===== ЗАДАЧА 1 - Произведение чисел =====
        private void btnGenerateNumbers_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "numbers.txt";
                Random rand = new Random();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    listBoxNumbers.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        int number = rand.Next(1, 10);
                        writer.WriteLine(number);
                        listBoxNumbers.Items.Add(number);
                    }
                }

                labelResult1.Text = $"Файл создан: {filePath}\nЗаписано 10 случайных чисел.";
                labelResult1.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult1.Text = $"Ошибка: {ex.Message}";
                labelResult1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "numbers.txt";
                if (!File.Exists(filePath))
                {
                    labelResult1.Text = "Файл не существует! Сначала сгенерируйте числа.";
                    return;
                }

                long product = 1;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            product *= number;
                        }
                    }
                }

                labelResult1.Text = $"Произведение всех чисел в файле: {product}";
                labelResult1.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult1.Text = $"Ошибка: {ex.Message}";
                labelResult1.ForeColor = System.Drawing.Color.Red;
            }
        }

        // ===== ЗАДАЧА 2 - Создание папки =====
        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string folderName = txtFolderName.Text.Trim();
                if (string.IsNullOrEmpty(folderName))
                {
                    labelResult2.Text = "Введите имя папки!";
                    labelResult2.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (Directory.Exists(folderName))
                {
                    labelResult2.Text = $"Папка '{folderName}' уже существует!";
                    labelResult2.ForeColor = System.Drawing.Color.Orange;
                    return;
                }

                Directory.CreateDirectory(folderName);
                labelResult2.Text = $"Папка успешно создана: {Path.GetFullPath(folderName)}";
                labelResult2.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult2.Text = $"Ошибка создания папки: {ex.Message}";
                labelResult2.ForeColor = System.Drawing.Color.Red;
            }
        }

        // ===== ЗАДАЧА 3 - Создание файла =====
        private void btnCreateFileWriteAll_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtFileName.Text.Trim();
                string content = txtFileContent.Text;

                File.WriteAllText(fileName, content);
                labelResult3.Text = $"Файл создан методом WriteAllText: {fileName}";
                labelResult3.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult3.Text = $"Ошибка: {ex.Message}";
                labelResult3.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnCreateFileStream_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtFileName.Text.Trim();
                string content = txtFileContent.Text;

                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(content);
                }

                labelResult3.Text = $"Файл создан методом FileStream: {fileName}";
                labelResult3.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult3.Text = $"Ошибка: {ex.Message}";
                labelResult3.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnCreateFileAppend_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtFileName.Text.Trim();
                string content = txtFileContent.Text;

                File.AppendAllText(fileName, "\n" + content);
                labelResult3.Text = $"Текст добавлен в файл: {fileName}";
                labelResult3.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult3.Text = $"Ошибка: {ex.Message}";
                labelResult3.ForeColor = System.Drawing.Color.Red;
            }
        }

        // ===== ЗАДАЧА 4 - Чтение файла =====
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtReadFileName.Text = dialog.FileName;
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = txtReadFileName.Text.Trim();
                if (!File.Exists(fileName))
                {
                    labelResult4.Text = $"Файл не существует: {fileName}";
                    labelResult4.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                listBoxFileContent.Items.Clear();

                // Чтение разными методами
                string contentAll = File.ReadAllText(fileName);
                string[] lines = File.ReadAllLines(fileName);

                // Вывод в ListBox
                listBoxFileContent.Items.Add($"=== Содержимое файла: {fileName} ===");
                foreach (string line in lines)
                {
                    listBoxFileContent.Items.Add(line);
                }

                // Статистика
                labelResult4.Text = $"Прочитано успешно!\n" +
                                  $"Количество строк: {lines.Length}\n" +
                                  $"Общее количество символов: {contentAll.Length}";
                labelResult4.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                labelResult4.Text = $"Ошибка чтения: {ex.Message}";
                labelResult4.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}