using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab9_BinaryFiles
{
    public partial class Form1 : Form
    {
        private string dataFile = "numbers.bin";
        private Random random = new Random();

        // Объявляем все контролы вручную
        private TabControl tabControl1;
        private TabPage tabPage1, tabPage2, tabPage3, tabPage4;

        // Задача 1
        private Label label1;
        private Button btnCreateFile;
        private Button btnCalculateProduct;
        private Label labelResult1;
        private ListBox listBoxNumbers;

        // Задача 2
        private Label label2;
        private Label label3;
        private TextBox textBoxNumber;
        private Button btnInsertNumber;
        private Label labelResult2;

        // Задача 3
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxSourceFile;
        private TextBox textBoxDestFile;
        private Button btnCopyFile;
        private Label labelResult3;

        // Задача 4
        private Label label7;
        private Label label8;
        private TextBox textBoxInfoFile;
        private Button btnGetFileInfo;
        private Button btnSaveInfo;
        private Label labelResult4;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnCalculateProduct = new System.Windows.Forms.Button();
            this.labelResult1 = new System.Windows.Forms.Label();
            this.listBoxNumbers = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.btnInsertNumber = new System.Windows.Forms.Button();
            this.labelResult2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSourceFile = new System.Windows.Forms.TextBox();
            this.textBoxDestFile = new System.Windows.Forms.TextBox();
            this.btnCopyFile = new System.Windows.Forms.Button();
            this.labelResult3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxInfoFile = new System.Windows.Forms.TextBox();
            this.btnGetFileInfo = new System.Windows.Forms.Button();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.labelResult4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnCreateFile);
            this.tabPage1.Controls.Add(this.btnCalculateProduct);
            this.tabPage1.Controls.Add(this.labelResult1);
            this.tabPage1.Controls.Add(this.listBoxNumbers);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(428, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задача 1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Создание файла и произведение чисел";
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(61, 103);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(150, 30);
            this.btnCreateFile.TabIndex = 1;
            this.btnCreateFile.Text = "Создать файл";
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // btnCalculateProduct
            // 
            this.btnCalculateProduct.Location = new System.Drawing.Point(61, 139);
            this.btnCalculateProduct.Name = "btnCalculateProduct";
            this.btnCalculateProduct.Size = new System.Drawing.Size(150, 30);
            this.btnCalculateProduct.TabIndex = 2;
            this.btnCalculateProduct.Text = "Найти произведение";
            this.btnCalculateProduct.Click += new System.EventHandler(this.btnCalculateProduct_Click);
            // 
            // labelResult1
            // 
            this.labelResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult1.Location = new System.Drawing.Point(67, 252);
            this.labelResult1.Name = "labelResult1";
            this.labelResult1.Size = new System.Drawing.Size(300, 60);
            this.labelResult1.TabIndex = 3;
            this.labelResult1.Click += new System.EventHandler(this.labelResult1_Click);
            // 
            // listBoxNumbers
            // 
            this.listBoxNumbers.Location = new System.Drawing.Point(217, 38);
            this.listBoxNumbers.Name = "listBoxNumbers";
            this.listBoxNumbers.Size = new System.Drawing.Size(150, 199);
            this.listBoxNumbers.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBoxNumber);
            this.tabPage2.Controls.Add(this.btnInsertNumber);
            this.tabPage2.Controls.Add(this.labelResult2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(428, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Задача 2";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "2. Вставка числа в случайную позицию";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Число:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(120, 42);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumber.TabIndex = 2;
            // 
            // btnInsertNumber
            // 
            this.btnInsertNumber.Location = new System.Drawing.Point(15, 75);
            this.btnInsertNumber.Name = "btnInsertNumber";
            this.btnInsertNumber.Size = new System.Drawing.Size(205, 30);
            this.btnInsertNumber.TabIndex = 3;
            this.btnInsertNumber.Text = "Вставить число";
            this.btnInsertNumber.Click += new System.EventHandler(this.btnInsertNumber_Click);
            // 
            // labelResult2
            // 
            this.labelResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult2.Location = new System.Drawing.Point(15, 115);
            this.labelResult2.Name = "labelResult2";
            this.labelResult2.Size = new System.Drawing.Size(400, 100);
            this.labelResult2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.textBoxSourceFile);
            this.tabPage3.Controls.Add(this.textBoxDestFile);
            this.tabPage3.Controls.Add(this.btnCopyFile);
            this.tabPage3.Controls.Add(this.labelResult3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(192, 74);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Задача 3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "3. Копирование файла";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Исходный файл:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Куда копировать:";
            // 
            // textBoxSourceFile
            // 
            this.textBoxSourceFile.Location = new System.Drawing.Point(120, 42);
            this.textBoxSourceFile.Name = "textBoxSourceFile";
            this.textBoxSourceFile.Size = new System.Drawing.Size(200, 20);
            this.textBoxSourceFile.TabIndex = 3;
            this.textBoxSourceFile.Text = "numbers.bin";
            // 
            // textBoxDestFile
            // 
            this.textBoxDestFile.Location = new System.Drawing.Point(120, 72);
            this.textBoxDestFile.Name = "textBoxDestFile";
            this.textBoxDestFile.Size = new System.Drawing.Size(200, 20);
            this.textBoxDestFile.TabIndex = 4;
            this.textBoxDestFile.Text = "numbers_copy.bin";
            // 
            // btnCopyFile
            // 
            this.btnCopyFile.Location = new System.Drawing.Point(15, 105);
            this.btnCopyFile.Name = "btnCopyFile";
            this.btnCopyFile.Size = new System.Drawing.Size(305, 30);
            this.btnCopyFile.TabIndex = 5;
            this.btnCopyFile.Text = "Копировать файл";
            this.btnCopyFile.Click += new System.EventHandler(this.btnCopyFile_Click);
            // 
            // labelResult3
            // 
            this.labelResult3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult3.Location = new System.Drawing.Point(15, 145);
            this.labelResult3.Name = "labelResult3";
            this.labelResult3.Size = new System.Drawing.Size(400, 80);
            this.labelResult3.TabIndex = 6;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.textBoxInfoFile);
            this.tabPage4.Controls.Add(this.btnGetFileInfo);
            this.tabPage4.Controls.Add(this.btnSaveInfo);
            this.tabPage4.Controls.Add(this.labelResult4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(192, 74);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Задача 4";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "4. Информация о файле";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Файл:";
            // 
            // textBoxInfoFile
            // 
            this.textBoxInfoFile.Location = new System.Drawing.Point(120, 42);
            this.textBoxInfoFile.Name = "textBoxInfoFile";
            this.textBoxInfoFile.Size = new System.Drawing.Size(200, 20);
            this.textBoxInfoFile.TabIndex = 2;
            this.textBoxInfoFile.Text = "numbers.bin";
            // 
            // btnGetFileInfo
            // 
            this.btnGetFileInfo.Location = new System.Drawing.Point(15, 75);
            this.btnGetFileInfo.Name = "btnGetFileInfo";
            this.btnGetFileInfo.Size = new System.Drawing.Size(150, 30);
            this.btnGetFileInfo.TabIndex = 3;
            this.btnGetFileInfo.Text = "Получить информацию";
            this.btnGetFileInfo.Click += new System.EventHandler(this.btnGetFileInfo_Click);
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(170, 75);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(150, 30);
            this.btnSaveInfo.TabIndex = 4;
            this.btnSaveInfo.Text = "Сохранить в файл";
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // labelResult4
            // 
            this.labelResult4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult4.Location = new System.Drawing.Point(15, 115);
            this.labelResult4.Name = "labelResult4";
            this.labelResult4.Size = new System.Drawing.Size(400, 150);
            this.labelResult4.TabIndex = 5;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(436, 361);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Лаба 9 - Работа с бинарными файлами";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        // Остальные методы остаются без изменений
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(dataFile, FileMode.Create)))
                {
                    listBoxNumbers.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        int number = random.Next(1, 10);
                        writer.Write(number);
                        listBoxNumbers.Items.Add(number);
                    }
                }
                labelResult1.Text = $"Файл {dataFile} создан успешно!\nЗаписано 10 случайных чисел.";
            }
            catch (Exception ex)
            {
                labelResult1.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void btnCalculateProduct_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dataFile))
            {
                labelResult1.Text = "Файл не существует! Сначала создайте файл.";
                return;
            }

            try
            {
                long product = 1;
                using (BinaryReader reader = new BinaryReader(File.Open(dataFile, FileMode.Open)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        int number = reader.ReadInt32();
                        product *= number;
                    }
                }
                labelResult1.Text = $"Произведение всех чисел в файле: {product}";
            }
            catch (Exception ex)
            {
                labelResult1.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void btnInsertNumber_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dataFile))
            {
                labelResult2.Text = "Файл не существует! Сначала создайте файл в Задаче 1.";
                return;
            }

            if (!int.TryParse(textBoxNumber.Text, out int numberToInsert))
            {
                labelResult2.Text = "Введите корректное целое число!";
                return;
            }

            try
            {
                List<int> numbers = new List<int>();
                using (BinaryReader reader = new BinaryReader(File.Open(dataFile, FileMode.Open)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        numbers.Add(reader.ReadInt32());
                    }
                }

                int position = random.Next(0, numbers.Count + 1);
                numbers.Insert(position, numberToInsert);

                using (BinaryWriter writer = new BinaryWriter(File.Open(dataFile, FileMode.Create)))
                {
                    foreach (int num in numbers)
                    {
                        writer.Write(num);
                    }
                }

                labelResult2.Text = $"Число {numberToInsert} успешно вставлено\nв позицию {position} (нумерация с 0)\n\nВсего чисел в файле: {numbers.Count}";
            }
            catch (Exception ex)
            {
                labelResult2.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void labelResult1_Click(object sender, EventArgs e)
        {

        }

        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            string sourceFile = textBoxSourceFile.Text.Trim();
            string destFile = textBoxDestFile.Text.Trim();

            if (string.IsNullOrEmpty(sourceFile) || string.IsNullOrEmpty(destFile))
            {
                labelResult3.Text = "Введите имена файлов!";
                return;
            }

            if (!File.Exists(sourceFile))
            {
                labelResult3.Text = $"Исходный файл {sourceFile} не существует!";
                return;
            }

            try
            {
                File.Copy(sourceFile, destFile, true);
                labelResult3.Text = $"Файл успешно скопирован:\n{sourceFile} -> {destFile}";
            }
            catch (Exception ex)
            {
                labelResult3.Text = $"Ошибка копирования: {ex.Message}";
            }
        }

        private void btnGetFileInfo_Click(object sender, EventArgs e)
        {
            string fileName = textBoxInfoFile.Text.Trim();

            if (string.IsNullOrEmpty(fileName))
            {
                labelResult4.Text = "Введите имя файла!";
                return;
            }

            if (!File.Exists(fileName))
            {
                labelResult4.Text = $"Файл {fileName} не существует!";
                return;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(fileName);

                string info = $"Информация о файле: {fileName}\n\n" +
                            $"Время создания: {fileInfo.CreationTime}\n" +
                            $"Время последнего доступа: {fileInfo.LastAccessTime}\n" +
                            $"Время последней записи: {fileInfo.LastWriteTime}\n" +
                            $"Размер файла: {fileInfo.Length} байт\n" +
                            $"Полный путь: {fileInfo.FullName}";

                labelResult4.Text = info;
            }
            catch (Exception ex)
            {
                labelResult4.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            string fileName = textBoxInfoFile.Text.Trim();

            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                labelResult4.Text = "Сначала получите информацию о существующем файле!";
                return;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string infoFile = "file_info.txt";

                string info = $"Информация о файле: {fileName}\n" +
                            $"Время создания: {fileInfo.CreationTime}\n" +
                            $"Время последнего доступа: {fileInfo.LastAccessTime}\n" +
                            $"Время последней записи: {fileInfo.LastWriteTime}\n" +
                            $"Размер файла: {fileInfo.Length} байт\n" +
                            $"Полный путь: {fileInfo.FullName}";

                File.WriteAllText(infoFile, info);
                labelResult4.Text = $"Информация сохранена в файл: {infoFile}\n\n{info}";
            }
            catch (Exception ex)
            {
                labelResult4.Text = $"Ошибка сохранения: {ex.Message}";
            }
        }
    }
}