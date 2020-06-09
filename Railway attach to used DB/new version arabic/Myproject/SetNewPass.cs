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
    public partial class SetNewPass : Form
    {
        public SetNewPass()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                if (account.chkpass(textBox1.Text))
                {
                    account.updatepass(textBox1.Text, ForgetPass.username);
                    MessageBox.Show("تم تعيين كلمه المرور بنجاح");
                    this.Hide();
                    Login l = new Login();
                    l.Show();

                }
                else
                {
                    label4.Text = "كلمه المرور غير صالحه للاستخدام";
                }

            }
            else
            {
                label4.Text = "كلمتا المرور غير متطابقان ";
            }
        }

        private void SetNewPass_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ForgetPass f = new ForgetPass();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
