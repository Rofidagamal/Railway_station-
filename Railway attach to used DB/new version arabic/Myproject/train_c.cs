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
    public  class train_c
    {
       public int idtrain;
 
        public bool[,] one = new bool[3,45];
        public bool[,] two = new bool[6,60];
     

        public static int traincount()
        {
            account.connection();
            string q = "select count(idtrain) from train";
            MySqlCommand cmd = new MySqlCommand(q, account.cnn);
            MySqlDataReader r = cmd.ExecuteReader();
            r.Read();
            int x = int.Parse(r.GetString("count(idtrain)"));
            account.cnn.Close();
            return x;
        }
     
        public void select()
        {
            account.connection();

        }
    }
}
