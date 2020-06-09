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

namespace WindowsFormsApplication6
{

    class tickets
    {

        public static MySqlConnection cnn;
        public static void connection()
        {

            string connetionString;
            connetionString = @"Data Source=localhost;Initial Catalog=railway;User ID=root;Password=root";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
        }
        public static void insert(String text1, String text2, String text3, String text4, String text5, String text6,
            String text7, String text8, String text9, String text10)
        {
            try
            {
                connection();
                // cnn.Open();
                string Sinsert = "insert into ticket (idticket,name,seatnum,date,arrivecon,goconnvarchar "+
                    ",username,idtrain,carriagenum,reserverd_date ) values (  '" + text1 + "' , '" + text2 + "' , '" + text3
                    + "' , '" + text4 + "' , '" + text5 + "' , '" + text6 + "' , '" + text7 + "' , '" + text8 +
                    "' , '" + text9 +"' , '"+text10+"')";
                MySqlCommand cmd = new MySqlCommand(Sinsert, cnn);
                MySqlDataAdapter adabter = new MySqlDataAdapter();
                adabter.InsertCommand = new MySqlCommand(Sinsert, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
