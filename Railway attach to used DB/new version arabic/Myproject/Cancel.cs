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

namespace WindowsFormsApplication6
{
    public partial class Cancel : Form
    {
        public Cancel()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (label34.Visible || label33.Visible)
            {
                MessageBox.Show("من فضلك ادخل بيانات صحيحه ");
            }
            else
            {
                Program.cancel(textBox1.Text);
                Main m = new Main();
                m.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cancel_Load(object sender, EventArgs e)
        {
            label34.Visible = false;
            label33.Visible = false;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Any(Char.IsLetter) || HasSpecialCharacter(textBox3.Text))
            {
                label34.Visible = true;
            }
            else
            {
                if (textBox3.Text.Length != 16)
                    label34.Visible = true;
                else
                    label34.Visible = false;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Any(Char.IsLetter) || HasSpecialCharacter(textBox2.Text))
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

