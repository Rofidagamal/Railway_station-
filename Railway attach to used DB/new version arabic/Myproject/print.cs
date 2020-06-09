using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Printing;
using WindowsFormsApplication6;
using MySql.Data.MySqlClient;

namespace Myproject
{
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();
            List<string>arr=new List<string>();
            string sss = "";
            try
            {
                string connetionString;
                MySqlConnection cnn;
                connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                sss = "select idticket from ticket where username='" + Login.username.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(sss, cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    arr.Add(r.GetString("idticket"));
                }
                for(int i=0;i<arr.Count;i++)
                {
                    comboBox1.Items.Add(arr[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                PrintDialog printDlg = new PrintDialog();
                PrintDocument printDoc = new PrintDocument();
                printDoc.DocumentName = comboBox1.Text.Trim() + ".pdf";
                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void print_Load(object sender, EventArgs e)
        {

        }
    }
    
}
