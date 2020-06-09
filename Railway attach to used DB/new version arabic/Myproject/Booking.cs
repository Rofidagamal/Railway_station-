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
    public partial class Booking : Form
    {
        public static bool statues;
        public static string beg, end;
        public static string date, date2;
        public static string Class, Class2;
        //public static string time, time2;

        Label[] lbarr = new Label[2];
        ComboBox[] cbarr = new ComboBox[2];
        Label[] lbarr2 = new Label[2];
        ComboBox[] cbarr2 = new ComboBox[2];
        string[] days2 = new string[15];
        string[] days = new string[15];

        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {

            comboBox1.Items.AddRange(new string[] { "اسوان", "اسيوط", "الاقصر", "الاسكندريه", "الاسماعليه", "الجيزه", "الزقازيق", "القاهره", "المنصوره", "المنيا", "بنها", "بنى سويف", "بورسعيد", "دمنهور", "دمياط", "سوهاج", "سيدى جابر", "طنطا", "قنا" });
            comboBox2.Items.AddRange(new string[] { "اسوان", "اسيوط", "الاقصر", "الاسكندريه", "الاسماعليه", "الجيزه", "الزقازيق", "القاهره", "المنصوره", "المنيا", "بنها", "بنى سويف", "بورسعيد", "دمنهور", "دمياط", "سوهاج", "سيدى جابر", "طنطا", "قنا" });
            lbarr[1] = new Label();
            lbarr[1].Text = "تاريخ القيام";
            lbarr[1].Location = new Point(268, 200);
            lbarr[1].BackColor = Color.RosyBrown;
            lbarr[1].ForeColor = Color.White;
            lbarr[0] = new Label();
            lbarr[0].Text = "درجه مقعد الذهاب";
            lbarr[0].Location = new Point(110, 200);
            lbarr[0].BackColor = Color.RosyBrown;
            lbarr[0].ForeColor = Color.White;

            Controls.AddRange(lbarr);
            cbarr[0] = new ComboBox();
            cbarr[0].Items.AddRange(new string[] { "اولى مكيفه", "ثانيه مكيفه" });
            cbarr[0].BackColor = Color.RosyBrown;
            cbarr[0].ForeColor = Color.White;
            cbarr[0].DropDownStyle = ComboBoxStyle.DropDownList;
            string[] days = new string[15];
            for (int i = 0; i < 15; i++)
            {
                DateTime d = DateTime.Now;
                days[i] = d.AddDays(i).ToString("yyyy-M-d");
            }
            cbarr[1] = new ComboBox();
            cbarr[1].Items.AddRange(days);
            cbarr[1].BackColor = Color.RosyBrown;
            cbarr[1].ForeColor = Color.White;
            cbarr[1].DropDownStyle = ComboBoxStyle.DropDownList;

            cbarr[1].Location = new Point(215, 225);
            cbarr[0].Location = new Point(82, 225);
            cbarr[1].Size = new Size(108, 28);
            cbarr[0].Size = new Size(108, 28);
            cbarr[1].SelectedIndexChanged += cbarr_1_clk;
            cbarr[0].SelectedIndexChanged += cbarr_0_clk;
            Controls.AddRange(cbarr);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            beg = comboBox1.Text;

        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            bool flag = false;
            if (radioButton2.Checked)
            {

                statues = true;//ذهاب و عوده 

                lbarr2[1] = new Label();
                lbarr2[1].Text = "تاريخ العوده";
                lbarr2[1].Location = new Point(268, 260);
                lbarr2[1].BackColor = Color.RosyBrown;
                lbarr2[1].ForeColor = Color.White;

                lbarr2[0] = new Label();
                lbarr2[0].Text = "درجه مقعد العوده";
                lbarr2[0].Location = new Point(110, 260);
                lbarr2[0].BackColor = Color.RosyBrown;
                lbarr2[0].ForeColor = Color.White;

                Controls.AddRange(lbarr2);
                cbarr2[0] = new ComboBox();
                cbarr2[0].Items.AddRange(new string[] { "اولى مكيفه", "ثانيه مكيفه" });
                cbarr2[0].BackColor = Color.RosyBrown;
                cbarr2[0].ForeColor = Color.White;
                cbarr2[0].DropDownStyle = ComboBoxStyle.DropDownList;

                for (int i = 0; i < 15; i++)
                {
                    DateTime d = DateTime.Now;
                    days2[i] = d.AddDays(i + 1).ToString("yyyy-M-d");
                }
                cbarr2[1] = new ComboBox();
                cbarr2[1].Items.AddRange(days2);
                cbarr2[1].BackColor = Color.RosyBrown;
                cbarr2[1].ForeColor = Color.White;

                cbarr2[1].Location = new Point(215, 290);
                cbarr2[0].Location = new Point(82, 290);
                cbarr2[1].Size = new Size(108, 28);
                cbarr2[0].Size = new Size(108, 28);
                cbarr2[1].DropDownStyle = ComboBoxStyle.DropDownList;

                cbarr2[1].SelectedIndexChanged += cbarr2_1_clk;
                cbarr2[0].SelectedIndexChanged += cbarr2_0_clk;
                cbarr[0].SelectedIndexChanged += cbarr_0_clk;
                cbarr[1].SelectedIndexChanged += cbarr_1_clk;
                Controls.AddRange(cbarr2);

                //MessageBox.Show(cbarr[1].Text);

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            end = comboBox2.Text;
        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                statues = false;//ذهاب 

                try
                {
                    lbarr2[0].Visible = false;
                    lbarr2[1].Visible = false;
                    cbarr2[0].Visible = false;
                    cbarr2[1].Visible = false;
                }
                catch (Exception ex)
                { }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }
        void cbarr_1_clk(object sender, EventArgs e)
        {
            date = cbarr[1].Text;

        }
        void cbarr2_0_clk(object sender, EventArgs e)
        {
            Class2 = cbarr2[0].Text;
        }
        void cbarr2_1_clk(object sender, EventArgs e)
        {
            date2 = cbarr2[1].Text;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cancel f = new Cancel();
            f.Show();
        }

        void cbarr_0_clk(object sender, EventArgs e)
        {
            Class = cbarr[0].Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {

            bool p = false;

            if (!statues)
            {
                p = (comboBox1.Text != "" && comboBox2.Text != "" && lbarr[0].Text != "" &&
                    lbarr[1].Text != "" && cbarr[0].Text != "" && cbarr[1].Text != "");
            }
            else
            {
                p = (comboBox1.Text != "" && comboBox2.Text != "" && lbarr[0].Text != "" &&
                   lbarr[1].Text != "" && cbarr[0].Text != "" && cbarr[1].Text != "") &&
                   (lbarr2[0].Text != "" && lbarr2[1].Text != ""
                   && cbarr2[0].Text != "" && cbarr2[1].Text != "");
            }
            if (p)
            {
                if (statues)
                {
                    bool flag = false;
                    string[] arr = cbarr[1].Text.Split('-');
                    string[] brr = cbarr2[1].Text.Split('-');

                    if (int.Parse(brr[0]) == int.Parse(arr[0]))
                    {
                        if (int.Parse(brr[1]) == int.Parse(arr[1]))
                        {
                            if (int.Parse(brr[2]) == int.Parse(arr[2]))
                            {
                                flag = false;
                            }
                            else if (int.Parse(brr[2]) > int.Parse(arr[2]))
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        else if (int.Parse(brr[1]) > int.Parse(arr[1]))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else if (int.Parse(brr[0]) > int.Parse(arr[0]))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }



                    if (!flag)
                        MessageBox.Show("You should select the right data");
                    else
                    {
                        if (comboBox1.Text != comboBox2.Text)
                        {
                            Train_chooser t = new Train_chooser();
                            t.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("يجب ان لا تكون مدينه القيام تشبه مدينه الوصول ");
                        }
                    }
                }
                else
                {
                    if (comboBox1.Text != comboBox2.Text)
                    {
                        Train_chooser t = new Train_chooser();
                        t.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("يجب ان لا تكون مدينه القيام تشبه مدينه الوصول ");
                    }

                }
            }
            else
            {
                MessageBox.Show("ادخل البيانات كامله من فضلك");
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
