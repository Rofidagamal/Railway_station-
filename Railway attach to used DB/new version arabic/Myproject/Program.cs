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
      public class Program
    {
        public  struct days
        {
            public train_c[] arr;
            public DateTime date;

        };
         public static days[] arrd;
       public static int idticket1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void reserve1(int trainid, string CLASS, string to, string from, string date,string uu)
        {
            int ind = 0, ind2 = 0;
            if (CLASS == "اولى مكيفه")
                CLASS = "one";
            else
                CLASS = "two";

            for (int i = 0; i < arrd.Length; i++)
            {

                if (arrd[i].date.ToString("yyyy-M-d") == date)
                {
                    ind = i;
                    break;
                }
            }
            for (int i = 0; i < arrd[ind].arr.Length; i++)
            {

                if (arrd[ind].arr[i].idtrain == trainid)
                {
                    ind2 = i;
                    break;
                }
            }

                reverse2(CLASS, ind2, ind, 0, 0,uu,from,to);
          
        }

        public static bool flag = false;
        public static int seatt ;
        public static int carr ;
        public static void reverse2(string CLASS, int indt, int inds, int fromm, int too,string uu,string from,string to)
        {
            flag = false;
            carr = 0;
            seatt = 0;
            if (CLASS == "one")
            {

                for (int car = 0; car < 3; car++)
                {
                    for (int seat = 0; seat < 45; seat++)
                    {

                        if (arrd[inds].arr[indt].one[car, seat] == false)
                        {
                            arrd[inds].arr[indt].one[car, seat] = true;
                            seatt=seat+1;
                            carr = car + 1;
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        break;
                }

            }
          
        else
            {
                for (int car = 0; car < 6; car++)
                {
                    for (int seat = 0; seat < 60; seat++)
                    {
                       

                            if (arrd[inds].arr[indt].two[car, seat] == false)
                            {

                                arrd[inds].arr[indt].two[car, seat] = true;
                                seatt = seat + 1;
                                carr = car + 1 + 3;
                                flag = true;
                                break;
                            }
                        
                    }
                    if (flag)
                        break;

                }
            }
            if (!flag)
            {
                MessageBox.Show(" .  لا يوجد قطار متاحه الرجاء تغيير القطار او الدرجه ");
                /*Booking f2 = new Booking();
                f2.Show();*/
            }
            else
            {
                string dd = DateTime.Today.ToString("yyyy-MM-dd");
                try
                {
                    revision r = new revision();
                    idticket1 = new Random().Next(1000000, 9000000);
                    if (uu == "go")
                    {
                        tickets.insert(idticket1.ToString(), user_content.name, seatt.ToString(),
                        Booking.date, to, from,
                        Login.username, Train_chooser.arr[0], carr.ToString(),dd);
                        MessageBox.Show("تم الحجز بنجاح");

                    }
                    else
                    {
                        tickets.insert(idticket1.ToString(), user_content.name, seatt.ToString(),
                       Booking.date2, to,from,
                       Login.username, Train_chooser.brr[0], carr.ToString(),dd);
                        MessageBox.Show("تم الحجز بنجاح");

                    }
                }
                catch(Exception)
                {

                }
            }
        }
        public static void cancel(string textBox1)
        {
            try
            {
                account.connection();
                string q = "select username,date,idtrain,seatnum,carriagenum from ticket where idticket ='" + textBox1 + "'";
                MySqlCommand cmd = new MySqlCommand(q, account.cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                r.Read();
                string un = r.GetString("username");
                string d = r.GetString("date");
                string idtrain = r.GetString("idtrain");
                string seatnum = r.GetString("seatnum");
                string carriagenum = r.GetString("carriagenum");
                account.cnn.Close();
                if (un != Login.username)
                {
                    MessageBox.Show("انت لا تمتلك هذه التذكره فى حسابك");
                }
                else
                {
                    int d1 = 0;
                    for (int i = 0; i < 15; i++)
                    {
                        string[] xx = d.Split(' ');
                        string[] xxx = xx[0].Split('/');
                        if (Program.arrd[i].date.ToString("yyyy-M-d") == (xxx[2] + "-" + xxx[0] + "-" + xxx[1]))
                        {
                            d1 = i;
                            break;
                        }
                    }
                    int t = 0;
                    for (int i = 0; i < Program.arrd[d1].arr.Length; i++)
                    {
                        if (Program.arrd[d1].arr[i].ToString() == idtrain)
                        {
                            t = i;
                            break;
                        }
                    }

                    int c = Convert.ToInt32(carriagenum) - 1;
                    int s = Convert.ToInt32(seatnum) - 1;
                    if (c <= 2)
                        Program.arrd[d1].arr[t].one[c, s] = false;
                    else
                        Program.arrd[d1].arr[t].two[c-2, s] = false;

                    account.connection();
                    string del = "delete from ticket where idticket ='" + textBox1 + "'";
                    MySqlCommand cmd2 = new MySqlCommand(del, account.cnn);
                    MySqlDataAdapter adabter = new MySqlDataAdapter();
                    adabter.DeleteCommand = new MySqlCommand(del, account.cnn);
                    adabter.DeleteCommand.ExecuteNonQuery();
                    cmd2.Dispose();
                    account.cnn.Close();

                    MessageBox.Show("تم حذف التذكره بنجاح");
                   
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static void Main()
        {
            arrd = new days[15];
            for (int i = 0; i < 15; i++)
            {
                arrd[i].arr = new train_c[train_c.traincount()];
            }
            for (int i = 0; i < 15; i++)
            {
                account.connection();
                string q = "select idtrain from train ";
                MySqlCommand cmd = new MySqlCommand(q, account.cnn);
                MySqlDataReader r = cmd.ExecuteReader();
                DateTime d = DateTime.Now;
                arrd[i].date = (DateTime)d.AddDays(i);
                for (int j = 0; j < train_c.traincount(); j++)
                {

                    r.Read();
                    //arrd[i].arr[j] = new train_c(Int32.Parse(r.GetString("idtrain")),arrd[i].date);
                    arrd[i].arr[j] = new train_c();
                    arrd[i].arr[j].idtrain = int.Parse(r.GetString("idtrain"));
                }
                account.cnn.Close();
            }
            account.connection();
            string w = "select * from ticket";
            MySqlCommand smd = new MySqlCommand(w, account.cnn);
            MySqlDataReader add = smd.ExecuteReader();
            string DATE;
            int IDtrain, seatnummm, carrigenummm;
            int day = 0, xx = 0;

            while (add.Read())
            {
                DATE = add.GetString("date");
                IDtrain = int.Parse(add.GetString("idtrain"));
                seatnummm = int.Parse(add.GetString("seatnum"));
                carrigenummm = int.Parse(add.GetString("carriagenum"));
                for (int i = 0; i < arrd.Length; i++)
                {
                    if (arrd[i].date.ToString("yyyy-M-d") == DATE)
                    {
                        day = i;
                        break;
                    }
                }
                for (int i = 0; i < arrd[day].arr.Length; i++)
                {
                    if (arrd[day].arr[i].idtrain == IDtrain)
                    {
                        xx = i;
                        break;
                    }
                }
                if (carrigenummm <= 3)
                    arrd[day].arr[xx].one[carrigenummm - 1, seatnummm - 1] = true;
                else
                    arrd[day].arr[xx].one[carrigenummm - 4, seatnummm - 1] = true;



            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

        }
    }

}

