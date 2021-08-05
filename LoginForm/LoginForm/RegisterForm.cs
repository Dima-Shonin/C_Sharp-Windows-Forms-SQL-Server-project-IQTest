using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            NameBox.Text = "Имя";
            NameBox.ForeColor = Color.Gray;
            SnameBox.Text = "Фамилия";
            SnameBox.ForeColor = Color.Gray;
            this.PassBox.AutoSize = false;
            this.PassBox.Size = new Size(this.PassBox.Size.Width, 64);
        }
        Point lastPoint;
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseLabel_MouseEnter(object sender, EventArgs e)
        {
            CloseLabel.ForeColor = Color.Red;
        }

        private void CloseLabel_MouseLeave(object sender, EventArgs e)
        {
            CloseLabel.ForeColor = Color.White;
        }


        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void NameBox_Enter(object sender, EventArgs e)
        {
            if (NameBox.Text == "Имя")
            {
                NameBox.Text = "";
                NameBox.ForeColor = Color.Black;
            }

        }
        private void NameBox_Leave(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
            {
                NameBox.Text = "Имя";
                NameBox.ForeColor = Color.Gray;
            }
        }
        private void SnameBox_Enter(object sender, EventArgs e)
        {
            if (SnameBox.Text == "Фамилия")
            {
                SnameBox.Text = "";
                SnameBox.ForeColor = Color.Black;
            }
        }
        private void SnameBox_Leave(object sender, EventArgs e)
        {
            if (SnameBox.Text == "")
            {
                SnameBox.Text = "Фамилия";
                SnameBox.ForeColor = Color.Gray;
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {

            if (NameBox.Text == "Имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (SnameBox.Text == "Фамилия")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (LoginBox.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (PassBox.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (CheckUser())
            {
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `sname`) VALUES (@login, @pass , @name, @sname)", db.GetConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginBox.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassBox.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameBox.Text;
            command.Parameters.Add("@sname", MySqlDbType.VarChar).Value = SnameBox.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Акаунт был создан");
            }
            else
            {
                MessageBox.Show("Акаунт не был создан");
            }
            db.closeConnection();
        }


        public Boolean CheckUser()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginBox.Text;
            

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть введите другой");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
