using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class getprice : Form
    {
        public getprice()
        {
            InitializeComponent();
        }
        public static string[] getCountry()
        {
            List<string> countryarr = new List<string>();
            string s = "select conname from country order by id";
            account.connection();
            MySqlCommand cmd = new MySqlCommand(s, account.cnn);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                countryarr.Add(r.GetString("conname"));
            }
            return countryarr.ToArray();
            account.cnn.Close();
        }
        public static string[] getTrainType()
        {
            List<string> typearr = new List<string>();
            string s = "select distinct type from train ";
            account.connection();
            MySqlCommand cmd = new MySqlCommand(s, account.cnn);
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                typearr.Add(r.GetString("type"));
            }
            return typearr.ToArray();
            account.cnn.Close();

        }
        public string[] arr;
        public void getprice_Load(object sender, EventArgs e)
        {
            arr = getCountry();
            comboBox1.Items.AddRange(arr);
            comboBox2.Items.AddRange(arr);
            comboBox4.Items.AddRange(new string[] { "درجه ثانيه", "درجه اولى" });
            comboBox3.Items.AddRange(getTrainType());


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("  لا يمكن ان تكون محطه الذهاب مثل محطه الوصول");
            }

            else
            {
                int f = Array.IndexOf(arr, comboBox1.Text);
                int t = Array.IndexOf(arr, comboBox2.Text);
                textBox1.Text = Convert.ToString(getprice1(f, t, comboBox3.Text, comboBox4.Text));
            }
        }
        static double getprice1(int from, int to, string type, string CLASS)
        {
            int price = (Math.Abs(from - to))*20;
            if (CLASS == "درجه اولى")
            {
                price += 30;
            }
            if (type.Trim().ToUpper() == "VIP")
            {
                price += 30;
            }
          
            return price;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}
