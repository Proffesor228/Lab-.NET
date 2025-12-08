using System;
using System.Windows.Forms;

namespace Lab11_Inheritance
{
    public partial class Form2 : Form
    {
        private User user;
        private Label lblUserDetails;
        private Button btnClose;

        public Form2(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Text = $"Детали пользователя - {user.GetUserType()}";
            this.Size = new System.Drawing.Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Детали пользователя
            this.lblUserDetails = new Label()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(350, 300),
                Text = user.GetDetails()
            };

            // Кнопка закрытия
            this.btnClose = new Button()
            {
                Location = new System.Drawing.Point(150, 330),
                Size = new System.Drawing.Size(100, 30),
                Text = "Закрыть"
            };
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new Control[] { lblUserDetails, btnClose });
            this.ResumeLayout(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}