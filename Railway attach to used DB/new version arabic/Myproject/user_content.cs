using Myproject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class user_content : Form
    {
        public static string name,id;

        public user_content()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            name = textBox1.Text + " " + textBox2.Text;
            if ((label7.Text == "" && label8.Text == "")&& !(textBox1.Text=="" || textBox2.Text == ""|| textBox3.Text == ""))
            {
                Booking f =  new Booking();
                f.Show();
                this.Hide();
            }
           
            else
            {
                MessageBox.Show("الرجاء إكمال البيانات ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main l = new Main();
            l.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool t = textBox1.Text.Any(char.IsDigit);
            bool s = Form1.HasSpecialCharacter(textBox1.Text);
            bool a = Form1.HasSpecialCharacter(textBox1.Text);
            if (t || s || a)
            {
                label7.Text = "يجب ان لايحتوى الاسم على ارقام ";
            }
            else
                label7.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool t = textBox2.Text.Any(char.IsDigit);
            bool s = Form1.HasSpecialCharacter(textBox2.Text);
            bool a = Form1.HasSpecialCharacter(textBox2.Text);
            if (t || s || a)
            {
                label7.Text = "يجب ان لايحتوى الاسم على ارقام ";
            }
            else
                label7.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bool n = textBox3.Text.Any(char.IsLetter);
            bool l = (textBox3.Text.Length != 14);
            bool a = Form1.HasSpecialCharacter(textBox3.Text);
            bool s = Form1.ContainsArabicLetters(textBox3.Text);
            if (s || n || l || a)
                label8.Text = "التأكد من الرقم القومى";
            else
                label8.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void user_content_Load(object sender, EventArgs e)
        {
            label7.Text = null;
            label8.Text = null;
        }
    }
}
