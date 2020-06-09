using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Myproject;

namespace WindowsFormsApplication6
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void search_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        { account.connection();
           string ss = "select type,begnamecountry,endnamecountry,duration from train where idtrain='" + textBox1.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(ss, account.cnn);
            MySqlDataReader r2 = cmd2.ExecuteReader();
            r2.Read();
            textBox2.Text = r2.GetString("type");
            textBox3.Text = r2.GetString("begnamecountry");
            textBox4.Text = r2.GetString("endnamecountry");
            textBox5.Text = r2.GetString("duration");
            account.cnn.Close();
            account.connection();
            string ss2 = "select conname from country order by id";
            MySqlCommand cmd3 = new MySqlCommand(ss2, account.cnn);
            MySqlDataReader r3 = cmd3.ExecuteReader();
            List<string> countries = new List<string>();
            while (r3.Read())
            {
                countries.Add(r3.GetString("conname"));
            }
            account.cnn.Close();
            int g = countries.IndexOf(textBox3.Text);
            int t = countries.IndexOf(textBox4.Text);
            if (g < t)
            {
                account.connection();
                string ss4 = "select pridge.conname,time from pridge inner join country on pridge.conname=country.conname " +
                    "where idtrain='" + textBox1.Text + "' order by country.id";
                MySqlDataAdapter a6 = new MySqlDataAdapter(ss4, account.cnn);
                DataTable d6 = new DataTable();
                a6.Fill(d6);
                dataGridView1.DataSource = d6;
                dataGridView1.Columns[0].HeaderCell.Value = "محطه القيام";
                dataGridView1.Columns[1].HeaderCell.Value = "وقت القيام";
                account.cnn.Close();
            }
            else
            {
                account.connection();
                string ss0 = "select pridge.conname,time from pridge inner join country on pridge.conname=country.conname " +
                    "where idtrain='" + textBox1.Text + "'  order by country.id DESC";
                MySqlDataAdapter a9 = new MySqlDataAdapter(ss0, account.cnn);
                DataTable d9 = new DataTable();
                a9.Fill(d9);
                dataGridView1.DataSource = d9;
                dataGridView1.Columns[0].HeaderCell.Value = "المحطه";
                dataGridView1.Columns[1].HeaderCell.Value = "وقت القيام";
                account.cnn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString;
                MySqlConnection cnn;
                connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string s = "select count(conname) from country";
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                string[] arr = new string[Int32.Parse(r.GetString("count(conname)"))];
                cnn.Close();
                cnn.Open();
                int ind = 0;
                string s2 = "select conname from country order by id";
                MySqlCommand cmd2 = new MySqlCommand(s2, cnn);
                MySqlDataReader r2 = cmd2.ExecuteReader();
                while (r2.Read())
                {
                    arr[ind] = r2.GetString("conname");
                    ind++;
                }
                cnn.Close();
                string w1 = comboBox1.Text, w2 = comboBox2.Text;
                if (w1 == w2)
                {
                    MessageBox.Show("لا يمكن ان تكون مدينه الذهاب مثل مدينه العوده ");
                }
                else
                {
                    List<string> idtrainsarr = new List<string>();
                    int f1 = Array.IndexOf(arr, w1);
                    int f2 = Array.IndexOf(arr, w2);
                    if (f1 > f2)
                    {
                        for (int i = f1; i < arr.Length; i++)
                        {
                            cnn.Open();
                            string s3 = "select idtrain from train where begnamecountry = '" + arr[i] + "'";
                            MySqlCommand cmd3 = new MySqlCommand(s3, cnn);
                            MySqlDataReader r3 = cmd3.ExecuteReader();
                            while (r3.Read())
                            {
                                idtrainsarr.Add(r3.GetString("idtrain"));
                            }
                            cnn.Close();
                        }

                    }
                    else
                    {

                        for (int i = f1; i >= 0; i--)
                        {
                            cnn.Open();
                            string s3 = "select idtrain from train where begnamecountry = '" + arr[i] + "'";
                            MySqlCommand cmd3 = new MySqlCommand(s3, cnn);
                            MySqlDataReader r3 = cmd3.ExecuteReader();
                            while (r3.Read())
                            {
                                idtrainsarr.Add(r3.GetString("idtrain"));
                            }
                            cnn.Close();
                        }



                    }


                    account.connection();
                    DataTable data = new DataTable();
                    string x = "(";
                    for (int i = 0; i < idtrainsarr.Count() - 1; i++)
                    {
                        x += "s.idtrain = '" + idtrainsarr[i] + "' or ";
                    }
                    x += "s.idtrain ='" + idtrainsarr[idtrainsarr.Count() - 1] + "')";
                    string s4 = "select  DISTINCT s.idtrain,s.conname,s.time,e.conname,e.time from pridge s ,pridge e , train  where " +
                        "s.idtrain= e.idtrain and " + x + " and s.conname='" + w1 + "' and e.conname='" + w2 + "' and train.idtrain=e.idtrain and train.type = '" + comboBox3.Text + "'";
                    MySqlCommand cmd4 = new MySqlCommand(s4, cnn);
                    MySqlDataAdapter n = new MySqlDataAdapter(s4, cnn);
                    n.Fill(data);
                    cnn.Close();
                    dataGridView1.DataSource = data;
                    dataGridView1.Columns[0].HeaderCell.Value = "رقم القطار";
                    dataGridView1.Columns[1].HeaderCell.Value = "محطه القيام";
                    dataGridView1.Columns[2].HeaderCell.Value = "وقت القيام";
                    dataGridView1.Columns[3].HeaderCell.Value = "محطه الوصول";
                    dataGridView1.Columns[4].HeaderCell.Value = "وقت الوصول";
                    //dataGridView1.Columns[5].HeaderCell.Value = "نوع القطار";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
    