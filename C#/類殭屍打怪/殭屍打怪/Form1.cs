using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 殭屍打怪
{
    public partial class Form1 : Form
    {
        int c = 0;
        int interval_1=500;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox1.Top = 0;
            pictureBox2.Top = 0;
            pictureBox3.Top = 0;
            c = 0;
            label2.Text = c.ToString() + "　分";
            if (textBox1.Text != "")
            {
                interval_1 = Convert.ToInt32(textBox1.Text);
                timer1.Interval = interval_1;
            }
            else
            {
                timer1.Interval = interval_1;

            }
            label6.Text = interval_1+"　毫秒";
            textBox1.Enabled = false;
            button2.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int [] ra= new int[1];
            Random random = new Random();
            ra[0] = random.Next(0, 3);
            switch (ra[0])
            {
                case 0:
                    {
                        pictureBox1.Top = 400-pictureBox1.Height;
                        break;
                    }
                case 1:
                    {
                        pictureBox2.Top = 400 - pictureBox1.Height;

                        break;
                    }
                case 2:
                    {
                        pictureBox3.Top = 400 - pictureBox1.Height;

                        break;
                    }
            }
            if (pictureBox1.Bottom == button1.Top && pictureBox2.Bottom == button1.Top /*1和2*/|| pictureBox1.Bottom == button1.Top && pictureBox3.Bottom == button1.Top /*1和3*/|| pictureBox2.Bottom == button1.Top && pictureBox3.Bottom == button1.Top  /*2和3*/) 
            {
                timer1.Stop();
                textBox1.Enabled = true;
                button2.Enabled = true;
                MessageBox.Show("loser");

                return;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad1 &&pictureBox1.Bottom==button1.Top)
            {
                pictureBox1.Top = 0;
                c += 1;
            }
            if (e.KeyCode == Keys.NumPad2 && pictureBox2.Bottom == button1.Top)
            {
                pictureBox2.Top = 0;
                c += 1;
            }
            if (e.KeyCode == Keys.NumPad3 && pictureBox3.Bottom == button1.Top)
            {
                pictureBox3.Top = 0;
                c += 1;
            }
            label2.Text = c.ToString() + "　分";
 
        }
    }
}
