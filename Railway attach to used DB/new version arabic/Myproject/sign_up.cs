using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication6;

namespace Myproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool HasSpecialCharacter(string s) // this function show if this string s has special char like , . or not 
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
        public static bool ContainsArabicLetters(string text)// this function show if this string text has arabic chars  or not 

        {

            foreach (char character in text.ToCharArray())

            {

                if (character >= 0x600 && character <= 0x6ff)

                    return true;



                if (character >= 0x750 && character <= 0x77f)

                    return true;



                if (character >= 0xfb50 && character <= 0xfc3f)

                    return true;



                if (character >= 0xfe70 && character <= 0xfefc)

                    return true;

            }

            return false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            username_chk.Visible = false;
            f_name_chk.Visible = false;
            l_name_chk.Visible = false;
            m_name_chk.Visible = false;
            nationality_chk.Visible = false;
            id_chk.Visible = false;
            re_email_chk.Visible = false;
            re_pass_chk.Visible = false;
            method_id_chk.Visible = false;
            pass_chk.Visible = false;
            email_chk.Visible = false;
            gender_chk.Visible = false;

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox1.SelectedIndex.ToString().Equals("-1"))

                nationality_chk.Visible = false;

            else

                nationality_chk.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (HasSpecialCharacter(textBox1.Text) || ContainsArabicLetters(textBox1.Text))
            {
                username_chk.Visible = true;

            }
            else
            {
                if (!account.chkname(textBox1.Text))
                {
                    MessageBox.Show("هذه بيانات مشابهه لمستخدم اخر . من فضلك ادخل بيانات اخري");
                    textBox1.Text = "";
                }
                if (textBox1.Text.Any(Char.IsDigit) && textBox1.Text.Any(Char.IsUpper) && textBox1.Text.Any(Char.IsLower))
                    username_chk.Visible = false;
                else
                    username_chk.Visible = true;

              
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Any(char.IsDigit) || ((HasSpecialCharacter(textBox2.Text))))
            {
                f_name_chk.Visible = true;
            }
            else
            {
                f_name_chk.Visible = false;

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Any(char.IsDigit) || ((HasSpecialCharacter(textBox5.Text))))
            {
                m_name_chk.Visible = true;
            }
            else
            {
                m_name_chk.Visible = false;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Any(char.IsDigit) || ((HasSpecialCharacter(textBox2.Text))))
            {
                l_name_chk.Visible = true;
            }
            else
            {
                l_name_chk.Visible = false;

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox3.SelectedIndex.ToString().Equals("-1"))

                gender_chk.Visible = false;

            else

                gender_chk.Visible = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.All(char.IsDigit) && textBox6.Text.Length == 14)
            {
                method_id_chk.Visible = false;
            }
            else
            {
                method_id_chk.Visible = true;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox2.SelectedIndex.ToString().Equals("-1"))

                id_chk.Visible = false;

            else

                id_chk.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (account.chkpass(textBox4.Text))
            {
                pass_chk.Visible = false;
            }
            else
            {
                pass_chk.Visible = true;

            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(textBox7.Text))
                re_pass_chk.Visible = false;
            else
                re_pass_chk.Visible = true;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(textBox8.Text);
                email_chk.Visible = false;



            }
            catch (Exception)
            {
                email_chk.Visible = true;

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(textBox10.Text))
                re_email_chk.Visible = false;
            else
                re_email_chk.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (email_chk.Visible || f_name_chk.Visible || gender_chk.Visible
           || id_chk.Visible || method_id_chk.Visible || l_name_chk.Visible || m_name_chk.Visible ||
           nationality_chk.Visible || pass_chk.Visible || re_pass_chk.Visible || re_email_chk.Visible ||
           username_chk.Visible)
            {
                MessageBox.Show("من فضلك . ادخل كل البيانات المطلوبه ");

            }

            else
            {
                try
                {
                    account.insert(textBox1.Text, (textBox2.Text +" "+ textBox5.Text +" "+ textBox3.Text), comboBox3.Text,
                        comboBox1.Text, comboBox2.Text, textBox6.Text, textBox4.Text, textBox8.Text, textBox9.Text);
                    MessageBox.Show("تم حفظ البيانات بنجاح");
                    account.passwords.Add(textBox4.Text);
                    account.names.Add(textBox1.Text);
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox3.Text = "";
                    textBox9.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox2.Text = "";
                    comboBox1.Text = "";
                    textBox8.Text = "";
                    textBox10.Text = "";
                    textBox7.Text = "";
                    Login l = new Login();
                    l.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
