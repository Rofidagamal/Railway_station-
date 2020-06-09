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
using WindowsFormsApplication6;
using System.Net.Mail;
using System.Net;

namespace Myproject
{
    public partial class send_ticket : Form
    {
        string ssss="";
        string ticket;
        public send_ticket()
        {
            InitializeComponent();

            try
            {
                account.connection();
                DataTable data = new DataTable();
                string s4 = "select idticket from ticket,account where account.username=ticket.username and ticket.username='" + Login.username + "'";
                MySqlCommand cmd4 = new MySqlCommand(s4, account.cnn);
                MySqlDataAdapter n = new MySqlDataAdapter(s4, account.cnn);
                n.Fill(data);
                dataGridView1.DataSource = data;
                account.cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sss = "";
            try
            {
                string connetionString;
                MySqlConnection cnn;
                connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                sss = "select email from account where username='" + Login.username.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(sss, cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    sss = r.GetString("email");
                }
            }
            catch (Exception)
            { }
            //MessageBox.Show("ارجو الانتظار بضع دقائق و سيتم ارسال التذكره علي حسابك");

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail = new MailMessage { From = new MailAddress("TrainService2020" + "@gmail.com", " Train Station ", Encoding.UTF8) };
                mail.To.Add(sss);
                mail.Subject = "Your Ticket";
                mail.Body = "mail with attachment of your ticket";
                System.Net.Mail.Attachment attachment;
                //MessageBox.Show(ticket);
                attachment = new System.Net.Mail.Attachment(ticket + ".pdf");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("TrainService2020", "T17121999");
                SmtpServer.Send(mail);
                MessageBox.Show("لقد تم ارسال التذكره علي بريدك الالكتروني ");
                Main m = new Main();
                m.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                MessageBox.Show("the email is not founded");
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void send_ticket_Load(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            ticket += selectedRow.Cells[0].Value.ToString();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
