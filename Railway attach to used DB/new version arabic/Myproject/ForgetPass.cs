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
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApplication6
{
    public partial class ForgetPass : Form
    {
        static long icode;
       public  static string username;
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (num.ToString() == textBox2.Text)
            {
                SetNewPass f1 = new SetNewPass();
                f1.Show();
                this.Hide();

            }else
            {
                MessageBox.Show("رمز اعاده التعيين غير صحيح");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int num;


        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                account.connection();
                string s = "select email from account where username ='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(s, account.cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                NetworkCredential login = new NetworkCredential("TrainService2020", "T17121999");
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = login;
                MailMessage msg = new MailMessage { From = new MailAddress("TrainService2020" + "@gmail.com", " Train Station ", Encoding.UTF8) };
                msg.To.Add(new MailAddress(r.GetString("email")));
                Random rand = new Random();
                num = rand.Next(10000000, 99999999);
                msg.Subject = "إعاده تعيين كلمه المرور";
                msg.Body = num + " : رمز إعاده تعيين كلمه المرور ";
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.Normal;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.SendAsync(msg, "sending..");

                panel2.Visible = false;
                username = textBox1.Text;
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
