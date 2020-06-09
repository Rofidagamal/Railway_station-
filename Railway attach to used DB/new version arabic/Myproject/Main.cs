using Myproject;
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

namespace WindowsFormsApplication6
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show s = new show();
            s.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            show s = new show();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            getprice f = new getprice();
            f.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }
       
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            try
            {
                string connetionString;
                connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string s = "select count(*) from ticket where username='" + Login.username + "' and  reserverd_date='"+ DateTime.Today.ToString("yyyy-MM-dd")+"'";
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                MySqlDataReader d = cmd.ExecuteReader();
                while (d.Read())
                {
                    cnt = int.Parse(d.GetString("count(*)"));
                }
                cmd.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (cnt < 3)
            {
                user_content b = new user_content();
                b.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("لا يمكن حجز اكثر من ثلاثه تذاكر من نفس الحساب ");
            }

           
          
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            getprice f = new getprice();
            f.Show();
            this.Hide();
        }
     
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Cancel c = new Cancel();
            c.Show();
            this.Hide();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            show s = new show();
            s.Show();
            this.Hide();
        }
        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            send_ticket s = new send_ticket();
            s.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            print s = new print();
            s.Show();
            this.Hide();
        }
    }
}
