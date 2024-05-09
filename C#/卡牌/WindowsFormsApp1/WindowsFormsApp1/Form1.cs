using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int level = 1;
        int times = 0;
        int count = 0;
        int bingo = 0;
        int number = 4;
        bool start = false;
        string[] picn = new string[2];
        string[] picsort = new string[2];

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            Label[] labeles = { label1, label2, label3, label4, label5, label6, label7 };
            for (int i = 0; i <= 15; i++)
                pictureBox17.Controls.Add(pictureBoxes[i]);          
            for (int i = 0; i <= 6; i++)
                pictureBox17.Controls.Add(labeles[i]);
            pictureBox17.Width = this.Width;
            pictureBox17.Height = this.Height - 24;
            pictureBox17.BackgroundImage = Image.FromFile(@"img\\background.png");
            for (int h = 0; h < 16; h++)
            {
                pictureBoxes[h].Image = imageList1.Images[0];
                pictureBoxes[h].Enabled = false;
            }

        }
        private void startitem_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            timer1.Start();
            timer1.Interval = 1000;
            axWindowsMediaPlayer1.URL = @"mp3\\level.mp3";
            pictureBox17.BackgroundImage = Image.FromFile(@"img\\background.png");
            start = true;
            if (level == 1)
            {
                number =4;
                label4.Text = 10.ToString();
                label2.Text = 2.ToString();
                label7.Text = "1-1";
                startitem.Text = "重新開始";
                for (int g = number; g <= 15; g++)
                    pictureBoxes[g].Visible = false;
                for(int g = 0; g <= (number-1); g++)
                {
                    pictureBoxes[g].Visible = true;
                    pictureBoxes[g].Enabled = true;
                }
            }
            else if (level == 2)
            {
                number = 16;
                label4.Text = 60.ToString();
                label2.Text = 8.ToString();
                label7.Text = "2-1";
                level = 1;
                startitem.Text = "重新開始";
                for (int g = 0; g <= (number - 1); g++)
                {
                    pictureBoxes[g].Visible = true;
                    pictureBoxes[g].Enabled = true;
                }
            }
            textBox1.Text = "";
            int[] randows = new int[number];
            for (int i = 0; i <= (number - 1); i++)
            {
                Random ra = new Random();
                randows[i] = ra.Next(1, (number + 1));
                for (int j = 0; j < i; j++)
                {
                    while (randows[i] == randows[j])
                    {
                        j = 0;
                        randows[i] = ra.Next(1, (number + 1));
                    }
                }
                double[] picra = new double[(number + 1)];
                picra[i] = Math.Ceiling((float)randows[i] / 2);
                pictureBoxes[i].Tag = picra[i].ToString();               
                for (int k = 1; k <= number; k++)
                {
                    pictureBoxes[i].Image = imageList1.Images[Convert.ToInt32(picra[i])];//開始 開牌
                    pictureBoxes[k - 1].AccessibleName = (k - 1).ToString();
                    pictureBoxes[i].Enabled = true;
                }
                if (i == 4 || i == 8 || i == 12)
                    textBox1.Text += "\r\n";
                textBox1.Text += pictureBoxes[i].Tag.ToString();
            }
            Refresh();

            System.Threading.Thread.Sleep(3000);
            for (int k = 0; k <= (number - 1); k++)
            {
                pictureBoxes[k].Image = imageList1.Images[0];//開始 開牌
            }            
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (start == true) 
            { 
                count++;
                PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };           
                ((PictureBox)(sender)).Image = imageList1.Images[Convert.ToInt32(((PictureBox)(sender)).Tag)];//抓圖片
                ((PictureBox)(sender)).Enabled = false;           
                if (count == 1)
                {
                    picn[0] = ((PictureBox)(sender)).Tag.ToString();
                    picsort[0] = ((PictureBox)(sender)).AccessibleName;
                }
                else if (count == 2)
                {
                    picn[1] = ((PictureBox)(sender)).Tag.ToString();
                    picsort[1] = ((PictureBox)(sender)).AccessibleName;
                    ((PictureBox)(sender)).Enabled = true;
                    if (picn[0] == picn[1])
                    {
                        axWindowsMediaPlayer2.URL = @"mp3\\true.mp3";
                        Refresh();                    
                        System.Threading.Thread.Sleep(1000);
                        pictureBoxes[Convert.ToInt32(picsort[0])].Visible = false;
                        pictureBoxes[Convert.ToInt32(picsort[1])].Visible = false;
                        bingo = Convert.ToInt32(label2.Text);
                        bingo-= 1;
                        label2.Text = (bingo).ToString();
                        if (bingo == 0)
                        {
                            axWindowsMediaPlayer1.URL = @"mp3\\win.mp3";
                            if (number == 16)
                            {
                                startitem.Text = "重新開始";
                            }
                            else
                            {
                                startitem.Text = "下一關";
                            }
                            for (int i = 0; i < 16; i++)
                            {
                            pictureBoxes[i].Visible = true;
                            pictureBoxes[i].Enabled = false;
                            }
                            level++;
                            timer1.Stop();
                            Refresh();
                            start = false;
                        }
                    }
                    else
                    {
                        axWindowsMediaPlayer2.URL = @"mp3\\false.mp3";
                    }
                Refresh();
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; i < number; i++)
                    {
                        pictureBoxes[i].Enabled = true;
                        pictureBoxes[i].Image = imageList1.Images[0];//蓋牌
                    }
                count = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            times = Convert.ToInt32(label4.Text);
            times -= 1;
            label4.Text = (times).ToString();
            if ((Convert.ToInt32(label4.Text)) == 0)
            {
                timer1.Stop();
                    axWindowsMediaPlayer1.URL = @"mp3\\lose.mp3";
                axWindowsMediaPlayer1.settings.setMode("loop", false);

                for (int i = 0; i < number; i++)
                    pictureBoxes[i].Enabled = false;
                times = 10;
                DialogResult result;
                result = MessageBox.Show("失敗\r\n未於時間內完成", "遊戲結束", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand,MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Retry)
                {
                    startitem.PerformClick();
                }
                else if (result == DialogResult.Abort)
                {
                    Close();
                }
            }
            if ((Convert.ToInt32(label4.Text)) == 4 &&number==4)
            {
                axWindowsMediaPlayer1.URL = @"mp3\\gameover.mp3";
                 axWindowsMediaPlayer1.settings.setMode("loop", true);
                pictureBox17.BackgroundImage = Image.FromFile(@"img\\background2.png");
            }
            else if ((Convert.ToInt32(label4.Text)) == 10 && number==16)
            {
                axWindowsMediaPlayer1.URL = @"mp3\\gameover.mp3";
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                pictureBox17.BackgroundImage = Image.FromFile(@"img\\background2.png");
            }
        }
        private void stopitem_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16 };
            if (stopitem.Text == "暫停遊戲")
            {
                for (int i = 0; i < number; i++)
                    pictureBoxes[i].Enabled = false;
                timer1.Stop();
                stopitem.Text = "繼續遊戲";
            }
            else
            {
                for (int i = 0; i < number; i++)
                    pictureBoxes[i].Enabled = true;
                timer1.Start();
                stopitem.Text = "暫停遊戲";
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(textBox1.Text);
            frm2.Show();
        }
        private void aboutitem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
        private void closeitem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
