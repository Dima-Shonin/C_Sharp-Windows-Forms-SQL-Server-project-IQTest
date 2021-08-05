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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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

        private  void MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            String LoginUser = LoginBox.Text;
            String PassUser = PassBox.Text;


            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = PassUser;
           

            adapter.SelectCommand = command;
            adapter.Fill(table);
           
                       
            if (table.Rows.Count>0)
            {

                if (ChekAdmin() == true)
                {
                    this.Hide();
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    this.Hide();
                    UserForm userForm = new UserForm(LoginBox.Text);
                    userForm.Show();
                }
                
            }
            else
            {
                MessageBox.Show("Пользователь не найдет");
            }

        }

    
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }


        public Boolean ChekAdmin()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            if (LoginBox.Text == "Admin1" || LoginBox.Text == "admin1")
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());            
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginBox.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
            }

            
            if (table.Rows.Count > 0)
            {              
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
