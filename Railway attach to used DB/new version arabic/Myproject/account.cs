using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

    class account
    {

        public static List<string> names = new List<string>();
        public static List<string> passwords = new List<string>();
        public static MySqlConnection cnn;
        public static void connection()
        {

            string connetionString;
            connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
        }
        public static void insert(String text1, String text2, String text3, String text4, String text5, String text6,
            String text7, String text8, String text9)
        {
            
                connection();
                string Sinsert = "insert into account values (  '" + text1 + "' , '" + text2 + "' , '" + text3
                    + "' , '" + text4 + "' , '" + text5 + "' , '" + text6 + "' , '" + text7 + "' , '" + text8 + "' , '" + text9 + "')";
                MySqlCommand cmd = new MySqlCommand(Sinsert, cnn);
                MySqlDataAdapter adabter = new MySqlDataAdapter();
                adabter.InsertCommand = new MySqlCommand(Sinsert, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                names.Add(text1);
                passwords.Add(text7);
                cnn.Close();
        }
        static bool HasSpecialCharacter(string s)
        {
            foreach (var c in s)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        public static void updatepass(String s1,string s2)
        {
            connection();
            int ind = names.IndexOf(s2);
            passwords[ind] = s1;
            string d = "update account set password= '" + s1 + "' where username='" + s2 + "'";
            MySqlCommand cmd = new MySqlCommand(d, cnn);
            MySqlDataAdapter adabter = new MySqlDataAdapter();
            adabter.UpdateCommand = new MySqlCommand(d, cnn);
            adabter.UpdateCommand.ExecuteNonQuery();
            cmd.Dispose();
            cnn.Close();
        }
        public static bool chkname(string s1)
        {
            bool flag = true;
            for (int i = 0; i < names.Count; i++)
            {
                if (names.ElementAt(i).Equals(s1))
                {
                    flag = false;
                    break;
                }
            }
            return flag;

        }
        public static bool chkpass(string s1)
        {
            if (s1.Any(char.IsUpper) && s1.Any(char.IsLower) && s1.Any(char.IsDigit) &&
                 s1.Length >= 7 && (!(HasSpecialCharacter(s1))))
            {
                return true;
            }
            else
                return false;
        }
     
        public static bool valid(string s1, string s2)
        {
            bool flag = true;
            if (!(names.Contains(s1)) || !(passwords.Contains(s2)))
                return false;
            else
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].Equals(s1) && passwords[i].Equals(s2))
                    {
                        flag = true;
                       // MessageBox.Show(names[i] + " " + passwords[i]);
                        break;
                    }
                }
                return flag;
            }

        }
        public static bool Fpassreset(string user, out long resetnum)
        {
            resetnum = 0;
            try
            {
                account.connection();
                MySqlCommand cmd = new MySqlCommand("select email from account where username ='" + user + "'", cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                string email = r.GetString("email");
                resetnum = sendmail(email);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("! اسم المتخدم لم يستخدم من قبل ");

                return false;
            }
        }
        static long sendmail(string email)
        {

            NetworkCredential login = new NetworkCredential("TrainService2020", "T17121999");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            MailMessage msg = new MailMessage { From = new MailAddress("TrainService2020" + "@gmail.com", " Train Station ", Encoding.UTF8) };
            msg.To.Add(new MailAddress(email));
          
            msg.Subject = "إعاده تكوين كلمه المرور ";
            Random random = new Random();
            long rt = Convert.ToInt64(random.Next(10000000, 99999999));
            msg.Body = "رمز اعاده تكوين كلمه المرور "+ rt.ToString();
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendAsync(msg, "sending..");
            return rt;

        }
    }
}
    


