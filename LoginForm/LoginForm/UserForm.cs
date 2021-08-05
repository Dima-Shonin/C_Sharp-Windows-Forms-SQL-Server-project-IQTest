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
    public partial class UserForm : Form
    {
        public UserForm(string _login)
        {
            InitializeComponent();
            answer = new int[10];
            log = _login;
        }
        Point lastPoint;
        string log;
        int n = 0;
        int[] answer;
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            var bmp = new Bitmap(Properties.Resources._1);
            pictureBox1.BackgroundImage = bmp;
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



        private void ButtonNext_Click(object sender, EventArgs e)
        {
            n++;
            if (n > 9)
            {
                n = 9;
            }
            show(n);
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            n--;
            if (n < 0)
            {
                n = 0;
            }
            show(n);
        }

        public void show(int _n)
        {
            int n1 = n + 1;
            label1.Text = "Вопрос № " + n1;
            switch (answer[n])
            {
                case 0:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;                   
                    break;
                case 1:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 2:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 3:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 4:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = true;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 5:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 6:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 7:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 8:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
                case 9:
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;
                    break;
            }
            switch (n)
            {
                case 0:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._1);
                    break;
                case 1:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._2);
                    break;
                case 2:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._3);
                    break;
                case 3:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._4); 
                    break;
                case 4:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._5); 
                    break;
                case 5:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._6);
                    break;
                case 6:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._7); 
                    break;
                case 7:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._8); 
                    break;
                case 8:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._9); 
                    break;
                case 9:
                    pictureBox1.BackgroundImage = new Bitmap(Properties.Resources._10); 
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            answer[n] = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            answer[n] = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            answer[n] = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            answer[n] = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            answer[n] = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            answer[n] = 6;
        }

        private void ButtonEnd_Click(object sender, EventArgs e)
        {
            int corect = 0;
            if (answer[0]==1)
            {
                corect++;
            }
            if (answer[1] == 5)
            {
                corect++;
            }
            if (answer[2] == 1)
            {
                corect++;
            }
            if (answer[3] == 2)
            {
                corect++;
            }
            if (answer[4] == 4)
            {
                corect++;
            }
            if (answer[5] == 2)
            {
                corect++;
            }
            if (answer[6] == 5)
            {
                corect++;
            }
            if (answer[7] == 2)
            {
                corect++;
            }
            if (answer[8] == 6)
            {
                corect++;
            }
            if (answer[9] == 5)
            {
                corect++;
            }
            int prc = corect * 100 / 10;
            string msg = "Вы не прошли тест";
            if (prc >= 65)
            {
                msg = "Вы прошли тест";
                MessageBox.Show("Вы ответили  на тест " + prc + " % верно . "+ msg);
            }
            else
            {
                MessageBox.Show("Вы ответили  на тест " + prc + " % верно . " + msg);
            }


            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `IQ` =  @IQ WHERE `users`.`login` = @log;", db.GetConnection());
            command.Parameters.Add("@IQ", MySqlDbType.Int32).Value = prc;
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            db.openConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.closeConnection();

            this.Close();
            LoginForm logForm = new LoginForm();
            logForm.Show();
            
        }
    }
}
