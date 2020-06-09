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
    public partial class Train_chooser : Form
    {
       public static string sss = "",sss2="";
        public static string[] arr = new string[8] { "", "", "", "", "", "","","" }, brr = new string[8] { "", "", "", "", "", "","","" };
        public Train_chooser()
        {
            InitializeComponent();

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
                cmd.Dispose();
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
                cmd2.Dispose();
                cnn.Close();
                string w1 = Booking.beg, w2 = Booking.end;
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
                        cmd3.Dispose();
                        cnn.Close();
                    }

                }
                else
                {

                    for (int i = f1; i >= 0; i--)
                    {
                        cnn.Open();
                        string s3 = "select  idtrain from train where begnamecountry = '" + arr[i] + "'";
                        MySqlCommand cmd3 = new MySqlCommand(s3, cnn);
                        MySqlDataReader r3 = cmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            idtrainsarr.Add(r3.GetString("idtrain"));
                        }
                        cmd3.Dispose();
                        cnn.Close();
                    }



                }
                double[] prices = new double[idtrainsarr.Count()];
                for (int k = 0; k < prices.Length; k++)
                {
                    prices[k] = getprice(f1, f2, idtrainsarr[k], Booking.Class);
                }
                account.connection();
                DataTable data = new DataTable();
                string x = "(";
                for (int i = 0; i < idtrainsarr.Count() - 1; i++)
                {
                    x += "s.idtrain = '" + idtrainsarr[i] + "' or ";
                }
                x += "s.idtrain ='" + idtrainsarr[idtrainsarr.Count() - 1] + "')";

                string s4 = "select DISTINCT s.idtrain,s.conname,s.time,e.conname,e.time from pridge as s , pridge as e where s.idtrain= e.idtrain and " + x + "and s.conname='" + w1 + "' and e.conname='" + w2 + "'";
                MySqlCommand cmd4 = new MySqlCommand(s4, cnn);
                MySqlDataAdapter n = new MySqlDataAdapter(s4, cnn);
                n.Fill(data);
                int l = 0;
                data.Columns.Add("price", typeof(double));
                foreach (DataRow dr in data.Rows)
                {
                    dr["price"] = prices[l];
                    l++;
                }
                cmd4.Dispose();
                cnn.Close();
                string[] types = new string[idtrainsarr.Count()];
                for (int i = 0; i < idtrainsarr.Count(); i++)
                {
                    account.connection();

                    string g = "select type from train where idtrain='" + idtrainsarr[i] + "'";
                    MySqlCommand cmd10 = new MySqlCommand(g, account.cnn);
                    MySqlDataReader re10 = cmd10.ExecuteReader();
                    while (re10.Read())
                    {
                        types[i] = re10.GetString("type");
                    }
                    cmd10.Dispose();
                    cnn.Close();

                }
                data.Columns.Add("type", typeof(string));
                l = 0;
                foreach (DataRow dr in data.Rows)
                {
                    dr["type"] = types[l];
                    l++;
                }
                
                dataGridView1.DataSource = data;
                dataGridView1.Columns[0].HeaderCell.Value = "رقم القطار";
                dataGridView1.Columns[1].HeaderCell.Value = "محطه القيام";
                dataGridView1.Columns[2].HeaderCell.Value = "وقت القيام";
                dataGridView1.Columns[3].HeaderCell.Value = "محطه الوصول";
                dataGridView1.Columns[4].HeaderCell.Value = "وقت الوصول";
                dataGridView1.Columns[5].HeaderCell.Value = "سعر التذكره";
                dataGridView1.Columns[6].HeaderCell.Value = "نوع القطار";
            }
            catch (Exception)
            {

            }


            
            /////////////////////////////////////////////////
            if (Booking.statues)
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
                    cmd.Dispose();
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
                    cmd2.Dispose();
                    cnn.Close();

                    string w1 = Booking.beg, w2 = Booking.end;
                    List<string> idtrainsarr = new List<string>();
                    int f1 = Array.IndexOf(arr, w2);
                    int f2 = Array.IndexOf(arr, w1);
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
                            cmd3.Dispose();
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
                            cmd3.Dispose();
                            cnn.Close();
                        }



                    }
                    double[] prices = new double[idtrainsarr.Count()];
                    for (int k = 0; k < prices.Length; k++)
                    {
                        prices[k] = getprice(f1, f2, idtrainsarr[k], Booking.Class2);
                    }
                    cnn.Open();
                    DataTable data = new DataTable();
                    string x = "(";
                    for (int i = 0; i < idtrainsarr.Count() - 1; i++)
                    {
                        x += "s.idtrain = '" + idtrainsarr[i] + "' or ";
                    }
                    x += "s.idtrain ='" + idtrainsarr[idtrainsarr.Count() - 1] + "')";

                    string s4 = "select DISTINCT s.idtrain,e.conname,e.time,s.conname,s.time from pridge as s , pridge as e where s.idtrain= e.idtrain and " + x + "and s.conname='" + w1 + "' and e.conname='" + w2 + "'";
                    MySqlCommand cmd4 = new MySqlCommand(s4, cnn);
                    MySqlDataAdapter n = new MySqlDataAdapter(s4, cnn);
                    n.Fill(data);
                    int l = 0;
                    data.Columns.Add("price", typeof(double));
                    foreach (DataRow dr in data.Rows)
                    {
                        dr["price"] = prices[l];
                        l++;
                    }
                    cmd4.Dispose();
                    cnn.Close();
                    string[] types = new string[idtrainsarr.Count()];
                    for (int i = 0; i < idtrainsarr.Count(); i++)
                    {
                        account.connection();
                        string g = "select type from train where idtrain='" + idtrainsarr[i] + "'";
                        MySqlCommand cmd5 = new MySqlCommand(g, account.cnn);
                        MySqlDataReader re2 = cmd5.ExecuteReader();
                        while (re2.Read())
                        {
                            types[i] = re2.GetString("type");
                        }
                        cmd5.Dispose();
                        cnn.Close();

                    }
                    data.Columns.Add("type", typeof(string));
                    l = 0;
                    foreach (DataRow dr2 in data.Rows)
                    {
                        dr2["type"] = types[l];
                        l++;
                    }
                    dataGridView2.DataSource = data;
                    dataGridView2.Columns[0].HeaderCell.Value = "رقم القطار";
                    dataGridView2.Columns[1].HeaderCell.Value = "محطه القيام";
                    dataGridView2.Columns[2].HeaderCell.Value = "وقت القيام";
                    dataGridView2.Columns[3].HeaderCell.Value = "محطه الوصول";
                    dataGridView2.Columns[4].HeaderCell.Value = "وقت الوصول";
                    dataGridView2.Columns[5].HeaderCell.Value = "سعر التذكره";
                    dataGridView2.Columns[6].HeaderCell.Value = "نوع القطار";
                    
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




       

        private void Train_chooser_Load(object sender, EventArgs e)
        {
            
            if (!Booking.statues)
            {
                dataGridView2.Visible = false;

            }
            label3.Visible = false;
            panel2.BringToFront();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            revision r = new revision();
            r.lbl_name.Text = user_content.name;
            r.lbl_idtrain.Text = arr[0];
            r.lbl_statues.Text = "ذهاب";
            r.lbl_class.Text = Booking.Class;
            r.lbl_from.Text = arr[1];
            r.lbl_to.Text = arr[3];
            r.lbl_price.Text = arr[5];
            r.lbl_date.Text = Booking.date;
            r.lbl_trtype.Text = arr[6];



            if (Booking.statues)
            {
                r.label17.Text = user_content.name;
                r.label23.Text = brr[0];
                r.label14.Text = Booking.date2;
                r.label19.Text = "عوده";
                r.label22.Text = Booking.Class2;
                r.label21.Text = brr[1];
                r.label20.Text = brr[3];
                r.label18.Text = brr[5];
                r.label5.Text = brr[6];



            }
            if (Booking.statues)
            {
                if (!(r.lbl_idtrain.Text == "A" && r.label23.Text == "A"))
                {
                    r.Show();
                    this.Hide();
                }
                else MessageBox.Show("الرجاء تحديد القطارات");
            }
            else
            {
                if (!(r.lbl_idtrain.Text == "A"))
                {
                    r.Show();
                    this.Hide();
                }
                else MessageBox.Show("الرجاء تحديد القطار");
            }
        }
        




        static double getprice(int from, int to, string idtrain,string CLASS)
        {
            int price = Math.Abs((to - from)) * 20;
            if ( CLASS== "اولى مكيفه")
            {
                price += 30;
            }
            account.connection();
            string q = "select type from train where idtrain='" + idtrain + "'";
            MySqlCommand cmd = new MySqlCommand(q, account.cnn);
            MySqlDataReader r = cmd.ExecuteReader();
            
            r.Read();
            if (r.GetString("type").Trim().ToUpper() == "VIP")
            {
                price += 30;
            }
            cmd.Dispose();
            account.cnn.Close();

            return price;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Train_chooser_Click(object sender, EventArgs e)
        {
            
        }

    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            sss = "";
            sss += selectedRow.Cells[0].Value.ToString();
            sss += " ";
            sss += selectedRow.Cells[1].Value.ToString();
            sss += " ";
            sss += selectedRow.Cells[2].Value.ToString();
            sss += " ";
            sss += selectedRow.Cells[3].Value.ToString();
            sss += " ";
            sss += selectedRow.Cells[4].Value.ToString();
            sss += " ";
            sss += selectedRow.Cells[5].Value.ToString();
            sss += " ";
            sss += selectedRow.Cells[6].Value.ToString();
            sss += " ";
            arr = sss.Split(' ');
            if (Booking.statues)
            {
                panel2.Visible = false;
                label3.Visible = true;
                dataGridView2.Visible = true;

            }
        }

      
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            sss2 = "";
            sss2 += selectedRow.Cells[0].Value.ToString();
            sss2 += " ";
            sss2 += selectedRow.Cells[1].Value.ToString();
            sss2 += " ";
            sss2 += selectedRow.Cells[2].Value.ToString();
            sss2 += " ";
            sss2 += selectedRow.Cells[3].Value.ToString();
            sss2 += " ";
            sss2 += selectedRow.Cells[4].Value.ToString();
            sss2 += " ";
            sss2 += selectedRow.Cells[5].Value.ToString();
            sss2 += " ";
            sss2 += selectedRow.Cells[6].Value.ToString();
            sss2 += " ";
            brr = sss2.Split(' ');

        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            Booking v = new Booking();
            v.Show();
            this.Hide();
        }
    }
}
