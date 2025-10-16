namespace HelloApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonConsoleTasks = new System.Windows.Forms.Button();
            this.buttonFormsTasks = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConsoleTasks
            // 
            this.buttonConsoleTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConsoleTasks.Location = new System.Drawing.Point(50, 50);
            this.buttonConsoleTasks.Name = "buttonConsoleTasks";
            this.buttonConsoleTasks.Size = new System.Drawing.Size(200, 40);
            this.buttonConsoleTasks.TabIndex = 0;
            this.buttonConsoleTasks.Text = "Консольные задания";
            this.buttonConsoleTasks.UseVisualStyleBackColor = true;
            this.buttonConsoleTasks.Click += new System.EventHandler(this.buttonConsoleTasks_Click);
            // 
            // buttonFormsTasks
            // 
            this.buttonFormsTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFormsTasks.Location = new System.Drawing.Point(50, 100);
            this.buttonFormsTasks.Name = "buttonFormsTasks";
            this.buttonFormsTasks.Size = new System.Drawing.Size(200, 40);
            this.buttonFormsTasks.TabIndex = 1;
            this.buttonFormsTasks.Text = "Задания Windows Forms";
            this.buttonFormsTasks.UseVisualStyleBackColor = true;
            this.buttonFormsTasks.Click += new System.EventHandler(this.buttonFormsTasks_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(60, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тип заданий";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 170);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFormsTasks);
            this.Controls.Add(this.buttonConsoleTasks);
            this.Name = "MainMenuForm";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button buttonConsoleTasks;
        private System.Windows.Forms.Button buttonFormsTasks;
        private System.Windows.Forms.Label label1;
    }
}