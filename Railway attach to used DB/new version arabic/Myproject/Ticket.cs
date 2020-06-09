using iTextSharp.text;
using iTextSharp.text.pdf;
using Myproject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();

        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            button1.Visible = false;
            panel2.Visible = true;


        }

        private void label16_Click(object sender, EventArgs e)
        {
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bitmap as System.Drawing.Image);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            bitmap.Save("test.jpg", ImageFormat.Jpeg);
            Document d = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(d, new FileStream(label35.Text + ".pdf", FileMode.Create));
            d.Open();
            try
            {
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("test.jpg");
                jpg.ScalePercent(50);
                d.Add(jpg);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            finally
            { d.Close(); }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail = new MailMessage { From = new MailAddress("TrainService2020" + "@gmail.com", " Train Station ", Encoding.UTF8) };
                mail.To.Add(sss);
                mail.Subject = "Your Ticket";
                mail.Body = "mail with attachment of your ticket";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(label35.Text + ".pdf");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("TrainService2020", "T17121999");
                SmtpServer.Send(mail);
                MessageBox.Show("Your ticket send on your email");
            }
            catch (Exception)
            {
                MessageBox.Show("the email is not founded");
            }

            if (Booking.statues)
            {
                panel2.Visible = false;
                button1.Visible = true;
                button3.Visible = false;
            }
            else
            {
                Application.Exit();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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

            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bitmap as System.Drawing.Image);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            bitmap.Save("test.jpg", ImageFormat.Jpeg);
            Document d = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(d, new FileStream(label35.Text + ".pdf", FileMode.Create));
            d.Open();
            try
            {
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("test.jpg");
                jpg.ScalePercent(50);
                d.Add(jpg);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { d.Close(); }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail = new MailMessage { From = new MailAddress("TrainService2020" + "@gmail.com", " Train Station ", Encoding.UTF8) };
                mail.To.Add(sss);
                mail.Subject = "Your Ticket";
                mail.Body = "mail with attachment of your ticket";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(label35.Text + ".pdf");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("TrainService2020", "T17121999");
                SmtpServer.Send(mail);
                MessageBox.Show("لقد تم ارسال التذكره علي بريدك الالكتروني ");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            Application.Exit();
           

        }



        private static void check(object s, System.ComponentModel.AsyncCompletedEventArgs c)
        {
            if (c.Cancelled)
                Console.WriteLine("No");
            if (c.Error != null)
                Console.WriteLine("ERRROR");
            else
                Console.WriteLine("succees");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string hh2 = "";
            try
            {
                string connetionString;
                MySqlConnection cnn;
                connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                string s = "select email from account where username='" + Login.username + "'";
                MySqlCommand cmd = new MySqlCommand(s, cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    hh2 = r.GetString("email");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            //MessageBox.Show("ارجو الانتظار بضع دقائق و سيتم ارسال التذكره علي حسابك");

            Bitmap bitmap2 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g2 = Graphics.FromImage(bitmap2 as System.Drawing.Image);
            g2.CopyFromScreen(0, 0, 0, 0, bitmap2.Size);

            bitmap2.Save("test.jpg", ImageFormat.Jpeg);
            Document d2 = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf2 = PdfWriter.GetInstance(d2, new FileStream(label25.Text + ".pdf", FileMode.Create));
            d2.Open();
            try
            {
                iTextSharp.text.Image jpg2 = iTextSharp.text.Image.GetInstance("test.jpg");
                jpg2.ScalePercent(50);
                d2.Add(jpg2);
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { d2.Close(); }
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail = new MailMessage { From = new MailAddress("TrainService2020" + "@gmail.com", " Train Station ", Encoding.UTF8) };
                mail.To.Add(hh2);
                mail.Subject = "Your Ticket";
                mail.Body = "mail with attachment of your ticket";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(label25.Text + ".pdf");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("TrainService2020", "T17121999");
                SmtpServer.Send(mail);
                MessageBox.Show("لقد تم ارسال التذكره علي بريدك الالكتروني ");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            Application.Exit();
        }
    }
}
