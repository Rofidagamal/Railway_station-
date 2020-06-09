using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;
using Myproject;

namespace WindowsFormsApplication6
{
    public partial class revision : Form
    {
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
        public revision()
        {

            InitializeComponent();
            label33.Visible = false;
            label34.Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true; ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_from.Text = Train_chooser.arr[1];
            lbl_to.Text = Train_chooser.arr[3];
            if (label34.Visible || label33.Visible)
            {
                MessageBox.Show("من فضلك ادخل بيانات صحيحه ");
            }
            else
            {
                try
                {       
                    Program.reserve1(int.Parse(lbl_idtrain.Text), lbl_class.Text, Train_chooser.arr[1], Train_chooser.arr[3], lbl_date.Text,"go");

                    Ticket t1 = new Ticket();
                    t1.label42.Text = "ذهاب";
                    t1.label43.Text = lbl_from.Text;
                    t1.label34.Text = lbl_to.Text;
                    t1.label33.Text = lbl_date.Text;
                    t1.label32.Text = Train_chooser.arr[2];
                    t1.label40.Text = Program.carr.ToString();
                    t1.label35.Text = Program.idticket1.ToString();
                    t1.label36.Text = Login.username;
                    t1.label37.Text = user_content.textBox3.Text;
                    t1.label38.Text = lbl_idtrain.Text;
                    t1.label39.Text = Booking.Class.ToString();
                    t1.label41.Text = Program.seatt.ToString();
                    t1.Show();
                   
                    if (Booking.statues)
                    {
                        Program.reserve1(int.Parse(label23.Text), label22.Text, label21.Text, label20.Text, label14.Text, "arrive");
                        label20.Text = Train_chooser.brr[1];
                        label21.Text = Train_chooser.brr[3];
                        t1.label18.Text = "عوده";
                        t1.label17.Text = Train_chooser.brr[1];
                        t1.label26.Text = Train_chooser.brr[3];
                        t1.label27.Text = label14.Text;
                        t1.label28.Text = Train_chooser.brr[2];
                        t1.label20.Text = Program.carr.ToString();
                        t1.label25.Text = Program.idticket1.ToString();
                        t1.label24.Text = Login.username;
                        t1.label23.Text = user_content.textBox3.Text;
                        t1.label22.Text = label23.Text;
                        t1.label21.Text = Booking.Class2.ToString();
                        t1.label19.Text = Program.seatt.ToString();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private static void check(object s, System.ComponentModel.AsyncCompletedEventArgs c)
        {
            if (c.Cancelled)
                Console.WriteLine("nooooooooooooooo");
            if (c.Error != null)
                Console.WriteLine("ERRROR");
            else
                Console.WriteLine("succees");
        }



    
              

            
        

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void revision_Load(object sender, EventArgs e)
        {
            if(Booking.statues==false)
            {
                button2.Visible = false;
                button5.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            
        }

        private void lbl_type_Click(object sender, EventArgs e)
        {

        }

        private void lbl_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Train_chooser t1 = new Train_chooser();
            t1.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Any(Char.IsLetter) || HasSpecialCharacter(textBox1.Text))
            {
                label34.Visible = true;
            }
            else
            {
                if (textBox1.Text.Length != 16)
                    label34.Visible = true;
                else
                    label34.Visible = false;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Any(Char.IsLetter) || HasSpecialCharacter(textBox2.Text) )
            {
                label33.Visible = true;
            }
            else
            {
                if (textBox2.Text.Length != 4)
                    label33.Visible = true;
                else
                    label33.Visible = false;

            }
        }
    }
}
