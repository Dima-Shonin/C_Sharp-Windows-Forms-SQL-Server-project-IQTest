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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            
            InitializeComponent(); 
            SelectU();
        }

        Point lastPoint;

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void CloseLabel_MouseEnter(object sender, EventArgs e)
        {
            CloseLabel.ForeColor = Color.Red;
        }

        private void CloseLabel_MouseLeave(object sender, EventArgs e)
        {
            CloseLabel.ForeColor = Color.White;
        }

        public void SelectU()
        {
           
            DB db = new DB();            
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users`", db.GetConnection());
            db.openConnection();
            MySqlDataReader read = command.ExecuteReader();
            
            while (read.Read()) 
            {
                string[] row = { read.GetValue(0).ToString(), read.GetValue(1).ToString(), read.GetValue(2).ToString(), read.GetValue(3).ToString(), read.GetValue(4).ToString(), read.GetValue(5).ToString() };                
                listView1.Items.Add("Data").SubItems.AddRange(row);   
            }         
            db.closeConnection();
                      
        }
        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm log = new LoginForm();
            log.Show();
        }
        private void labelBack_MouseEnter(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.OrangeRed;
        }
        private void labelBack_MouseLeave(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.White;
        }

    }
}
