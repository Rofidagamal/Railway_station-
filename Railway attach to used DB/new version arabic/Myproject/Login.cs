using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication6;
using MySql.Data.MySqlClient;
namespace Myproject
{
    public partial class Login : Form
    {
        public static string username;
        public static ForgetPass FB;
        public Login()
        {
            InitializeComponent();
            try
            {
                string connetionString;
                connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
                MySqlConnection cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string s = "select * from account";
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                MySqlDataReader d = cmd.ExecuteReader();
                while (d.Read())
                {
                    account.names.Add(d["username"].ToString());
                    account.passwords.Add(d["password"].ToString());

                }
                cmd.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!account.valid(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Wrong user");
                textBox1.Text = "";
                textBox2.Text = "";
              
            }
            else
            {
                username = textBox1.Text;
                Main u = new Main();
                u.Show();
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
             FB = new ForgetPass();
            FB.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "كلمه المرور")
                textBox2.Text = "";
            textBox2.PasswordChar = '*';
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        { 
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            search s = new search();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
