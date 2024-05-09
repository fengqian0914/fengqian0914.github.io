using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 剪刀石頭不
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            
           if (e.KeyCode == Keys.D1)
            {
                pictureBox1.Image = Image.FromFile("1.png");
                pictureBox1.Visible = false;
                pictureBox1.Tag = "1";
                if (count == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    count = 0;
                    if (pictureBox1.Tag == pictureBox2.Tag)
                    {
                        label3.Text = "結果為： 平手";
                    }
                    if (pictureBox1.Tag == "1" &&pictureBox2.Tag=="2")
                    {
                        label3.Text = "結果為： 藍方獲勝";
                    }
                    if (pictureBox1.Tag == "1" && pictureBox2.Tag == "3")
                    {
                        label3.Text = "結果為： 紅方獲勝";
                    }
                }
                count += 1;

            }
            if (e.KeyCode == Keys.D2)
            {
                pictureBox1.Image = Image.FromFile("2.png");
                pictureBox1.Visible = false;
                pictureBox1.Tag = "2";

                if (count == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    count = 0;
                    if (pictureBox1.Tag == pictureBox2.Tag)
                    {
                        label3.Text = "結果為： 平手";
                    }
                    if (pictureBox1.Tag == "2" && pictureBox2.Tag == "1")
                    {
                        label3.Text = "結果為： 紅方獲勝";
                    }
                    if (pictureBox1.Tag == "2" && pictureBox2.Tag == "3")
                    {
                        label3.Text = "結果為： 藍方獲勝";
                    }

                }
                count += 1;

            }
            if (e.KeyCode == Keys.D3)
            {
                pictureBox1.Image = Image.FromFile("3.png");
                pictureBox1.Visible = false;
                pictureBox1.Tag = "3";

                if (count == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    count = 0;
                    if (pictureBox1.Tag == pictureBox2.Tag)
                    {
                        label3.Text = "結果為： 平手";
                    }
                    if (pictureBox1.Tag == "3" && pictureBox2.Tag == "1")
                    {
                        label3.Text = "結果為： 藍方獲勝";
                    }
                    if (pictureBox1.Tag == "3" && pictureBox2.Tag == "2")
                    {
                        label3.Text = "結果為： 紅方獲勝";
                    }
                }
                count += 1;

            }


            if (e.KeyCode == Keys.NumPad1)
            {
                pictureBox2.Image = Image.FromFile("1.png");
                pictureBox2.Visible = false;
                pictureBox2.Tag = "1";

                if (count == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    count = 0;
                    if (pictureBox1.Tag == pictureBox2.Tag)
                    {
                        label3.Text = "結果為： 平手";
                    }
                    if (pictureBox1.Tag == "2" && pictureBox2.Tag == "1")
                    {
                        label3.Text = "結果為： 紅方獲勝";
                    }
                    if (pictureBox1.Tag == "3" && pictureBox2.Tag == "1")
                    {
                        label3.Text = "結果為： 藍方獲勝";
                    }
                }
                count += 1;

            }
            if (e.KeyCode == Keys.NumPad2)
            {
                pictureBox2.Image = Image.FromFile("2.png");
                pictureBox2.Visible = false;
                pictureBox2.Tag = "2";

                if (count == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    count = 0;
                    if (pictureBox1.Tag == pictureBox2.Tag)
                    {
                        label3.Text = "結果為： 平手";
                    }
                    if (pictureBox1.Tag == "1" && pictureBox2.Tag == "2")
                    {
                        label3.Text = "結果為： 藍方獲勝";
                    }
                    if (pictureBox1.Tag == "3" && pictureBox2.Tag == "2")
                    {
                        label3.Text = "結果為： 紅方獲勝";
                    }
                }
                count += 1;

            }
            if (e.KeyCode == Keys.NumPad3)
            {
                pictureBox2.Image = Image.FromFile("3.png");
                pictureBox2.Visible = false;
                pictureBox2.Tag = "3";

                if (count == 1)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    count = 0;
                    if (pictureBox1.Tag == pictureBox2.Tag)
                    {
                        label3.Text = "結果為： 平手";
                    }
                    if (pictureBox1.Tag == "1" && pictureBox2.Tag == "3")
                    {
                        label3.Text = "結果為： 紅方獲勝";
                    }
                    if (pictureBox1.Tag == "2" && pictureBox2.Tag == "3")
                    {
                        label3.Text = "結果為： 藍方獲勝";
                    }
                }
                count += 1;
            }

            if (e.KeyCode == Keys.Enter)
            {
                pictureBox2.Image = null;
                pictureBox1.Image = null;
                label3.Text = "結果為： ";


            }
        }
    }
}
