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
namespace WindowsFormsApplication6
{
    public partial class show : Form
    {
        public show()
        {
            InitializeComponent();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void show_Load(object sender, EventArgs e)
        {
            string[] days = new string[15];
            for (int i = 0; i < 15; i++)
            {
                DateTime d = DateTime.Now;
                days[i] = d.AddDays(i).ToString("yyyy-M-d");
            }
            comboBox1.Items.AddRange(days);
            account.connection();
            string s = "select distinct idtrain from pridge";
            MySqlCommand cmd = new MySqlCommand(s, account.cnn);
            MySqlDataReader r = cmd.ExecuteReader();
            List<string> trains = new List<string>();
            while (r.Read())
            {
                trains.Add(r.GetString("idtrain"));
            }
            cmd.Dispose();
            account.cnn.Close();
            comboBox2.Items.AddRange(trains.ToArray());
            comboBox3.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            int da = 0;
            for (int i = 0; i < 15; i++)
            {
                if (Program.arrd[i].date.ToString("yyyy-M-d") == comboBox1.Text)
                {
                    da = i;
                    break;
                }
            }
            int t = 0;
            for (int i = 0; i < Program.arrd[da].arr.Length; i++)
            {
                if (Program.arrd[da].arr[i].idtrain.ToString() == comboBox2.Text)
                {
                    t = i;
                    break;
                }
            }
            List<string> seats = new List<string>();
            if (textBox1.Text == "درجه اولى")
            {
                for (int i = 0; i < Program.arrd[da].arr[t].one.Length / 3; i++)
                {
                    if (Program.arrd[da].arr[t].one[Convert.ToInt32(comboBox3.Text) - 1, i] == false)
                        seats.Add((i + 1).ToString());
                }
            }
            else
            {
                for (int i = 0; i < Program.arrd[da].arr[t].two.Length / 6; i++)
                {
                    if (Program.arrd[da].arr[t].two[Convert.ToInt32(comboBox3.Text) - 4, i] == false)
                        seats.Add((i + 1).ToString());
                }
            }
            dataGridView1.Columns.Add("C1", "المقاعد المتاحه");
            dataGridView1.Columns["C1"].DataPropertyName = "Property1";
            dataGridView1.DataSource = seats.ToArray().Select(x => new { Property1 = x }).ToList();

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {  switch (comboBox3.Text)
            {
                case "1":
                case "2":
                case "3":
                    textBox1.Text = "درجه اولى";
                    break;
                default:
                    textBox1.Text = "درجه ثانيه";
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
