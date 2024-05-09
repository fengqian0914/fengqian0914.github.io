using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace keyboradgame
{
    public partial class Form1 : Form
    {
        Random rd = new Random();
        int[] random = new int[5];
        int []score=new int[5];
        int miss = 0;
        int press_error = 0;
        int errornum = -1;
        int times = 10;
        string []num_name = new string[5];
        int num_count = 0;
        int[] rank = new int[5];
        int[] rank_soft = new int[5];
        int[] rank_result = new int[5];

        string []score_log = new string[5];
        string []rank_log = new string[5];

        bool start = false;
        bool gameover = false;
        public Form1()
        {
            InitializeComponent();
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
            Label[] labels = { label1, label2, label3, label4, label5 };
            for (int i = 0; i <5; i++)
            {
                panels[i].BackgroundImage = Image.FromFile("img/bg4.png");
                panels[i].Controls.Add(labels[i]);
            }
            this.BackgroundImage = Image.FromFile("img/background.png");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            install();
            Label[] labels_font = { label6, label7, label8, label9, label10, label11,label12 };
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile("font/SuperMario256.ttf");

            Font font = new Font(privateFonts.Families[0], 18);
            for(int i = 0; i < labels_font.Length; i++)
            {
                labels_font[i].Font = font;
            }

            Form3 newForm3 = new Form3();
            newForm3.ShowDialog();

        }
        void install()
        {
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
            Panel[] panels2 = { panel6, panel7, panel8, panel9, panel10 };

            for (int i = 0; i < random.Length; i++)
            {
                panels[i].BackgroundImage = Image.FromFile("img/bg4.png");
                panels2[i].BackgroundImage = imageList1.Images[i];
            }
            panel11.BackgroundImage = Image.FromFile("img/coin.png");
            panel12.BackgroundImage = Image.FromFile("img/error_1.png");
            panel13.BackgroundImage = Image.FromFile("img/error_2.png");
            panel14.BackgroundImage = Image.FromFile("img/time.png");

            Refresh();
        }
        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file_log();

            timer1.Enabled = false;
            object name;
            name = Interaction.InputBox("請輸入名字", "登入");
            if ((string)name == "")
            {
                MessageBox.Show("請重新輸入", "系統通知");
                return;
            }
            random_number();
            file((string)name);

        }
        void file_log()
        {
            if (!File.Exists("num.txt")|| !File.Exists("result_rank.txt") || !File.Exists("result_score.txt") )
            {
                    return;
            }
            num_count = Convert.ToInt32(File.ReadAllText("num.txt"));
            string readText_name = File.ReadAllText("number.txt");
            string[] strArray_name = readText_name.Split('\n');

            string readText_rank = File.ReadAllText("result_rank.txt");
            string[] strArray_rank = readText_rank.Split('\n');


            string readText_Score = File.ReadAllText("result_score.txt");
            string[] strArray_score = readText_Score.Split('\n');
            string[] strArray_name_log = new string[5];
            for (int i=0;i<num_count;i++)
                    strArray_name_log[i] = strArray_name[i].Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");

                try
                {
                    for (int i = 0; i < num_count; i++)
                    {
                        num_name[i] = strArray_name_log[i];
                        score[i] = Convert.ToInt32(strArray_score[i]);

                    }
                }
                catch  (Exception ex)
                {
                    MessageBox.Show("由於因不當結束程式因此發生錯誤，因此將刪除紀錄檔案，已方便遊戲進行", "系統通知");
                    File.Delete("result_rank.txt");
                    File.Delete("result_score.txt");
                    File.Delete("number.txt");
                    File.Delete("num.txt");
                    num_count = 0;
                for (int i = 0; i < score.Length; i++)
                    score[i] = 0;


                }


        }
        void random_number()
        {

                Label[] labels = { label1, label2, label3, label4, label5 };
                Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
                Panel[] panels2 = { panel6, panel7, panel8, panel9, panel10 };

                axWindowsMediaPlayer2.URL = "mp3/level.mp3";
                axWindowsMediaPlayer2.settings.setMode("loop", true);
                for(int i=0;i<5;i++)
                    panels2[i].BackgroundImage = imageList1.Images[i];

                miss = 0;
                errornum = -1;
                times = 10;
                press_error = 0;
                label9.Text = "0";
                label10.Text = "5";
                label11.Text = "10";
                gameover = false;
                start = true;
                for (int i = 0; i < 5; i++)
                    panels[i].Top = 80;

                for (int i = 0; i < random.Length; i++)
                {
                    if (errornum != -1)
                    {
                        i = errornum;
                    }
                    random[i] = rd.Next(33, 127);
                    for (int j = 0; j < i; j++)
                    {
                        if (random[i] == random[j])
                        {
                            random[i] = rd.Next(33, 127);
                            i = 0;
                        }
                    }
                    labels[i].UseMnemonic = false;
                    labels[i].Text = ((char)random[i]).ToString();
                    errornum = -1;
                }
                this.Focus();
            
        }
        void file(string name)
        {
            num_count++;
            if (num_count > 5)
            {
                MessageBox.Show("已達人數上限", "系統通知");
                timer1.Enabled = false;
                return;
            }
            else
                num_name[num_count-1] = (string)name;
            try
            {
                File.WriteAllLines("number.txt", num_name);
                File.WriteAllText("num.txt", num_count.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("發生錯誤", "系統通知");
            }
            timer1.Enabled = true;


        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gameover == true)
            {
                MessageBox.Show("遊戲結束 結果：你輸了", "失敗訊息");

                return;
            }
            int key;
            key = e.KeyChar;
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
            Label[] labels = { label1, label2, label3, label4, label5 };
            Panel[] panels2 = { panel6, panel7, panel8, panel9, panel10 };
            for(int i = 0; i < 5; i++)
            {
                panels2[i].BackgroundImage = imageList1.Images[i];
            }
            for (int i = 0; i < 5; i++)
            {
                if (key == random[i])
                {
                    score[num_count-1]+=5;
                    random[i] = rd.Next(33, 127);
                    labels[i].Text= ((char)random[i]).ToString();
                    panels[i].Top = 80;
                    panels2[i].BackgroundImage = imageList1.Images[i + 5];

                    break;
                }
                else if(key!= random[i] &&i==4)
                {
                    score[num_count-1] -= 5;
                    press_error++;
                    label11.Text = (10 - press_error).ToString();
                    if (press_error >= 10)
                    {
                        gameover = true;
                        timer1.Enabled = false;
                        axWindowsMediaPlayer1.URL = "mp3/lose.mp3";
                        axWindowsMediaPlayer1.settings.setMode("loop", false);
                        axWindowsMediaPlayer2.Ctlcontrols.stop();
                        label9.Text = score[num_count - 1].ToString();
                        for(int u=0;u<5;u++)
                            panels2[u].BackgroundImage = imageList1.Images[u + 10];
                        result();
                        MessageBox.Show("遊戲結束 結果：你輸了", "失敗訊息");

                        return;
                    }
                }
            }
            label9.Text = score[num_count-1].ToString();


        }


        void result()
        {
            try
            {
                for(int i = 0; i < num_count; i++)
                {
                    rank[i] = score[i];
                    rank_soft[i] = score[i];
                }
                Array.Sort(rank_soft);
                Array.Reverse(rank_soft);
                for(int i = 0; i < num_count; i++)
                {
                    int j = Array.IndexOf(rank_soft, rank[i]);
                    rank_result[i] = j + 1;
                }
                for(int i = 0; i < num_count; i++)
                {
                    score_log[i] = score[i].ToString();
                    rank_log[i] = rank_result[i].ToString();

                }
                start = false;
                File.WriteAllLines("result_score.txt", score_log);
                File.WriteAllLines("result_rank.txt", rank_log);
            }
            catch (Exception e)
            {
                MessageBox.Show("發生錯誤", "系統通知");
            }
        }
        void down()
        {
            Panel[] panels = { panel1, panel2, panel3, panel4, panel5 };
            Panel[] panels2 = { panel6, panel7, panel8, panel9, panel10 };

            if (miss >= 5)
            {
                timer1.Enabled = false;
                axWindowsMediaPlayer1.URL = "mp3/lose.mp3";
                axWindowsMediaPlayer1.settings.setMode("loop", false);
                axWindowsMediaPlayer2.Ctlcontrols.stop();
                for(int i=0;i<5; i++)
                    panels2[i].BackgroundImage = imageList1.Images[i + 10];

                label10.Text = 0.ToString();

                result();
                MessageBox.Show("遊戲結束 結果：你輸了", "失敗訊息");
                return;
            }
                
            for (int i = 0; i < 5; i++)
                if (panels[i].Bottom >= 574)
                {
                    panels[i].Top = 80;
                    errornum = i;
                    miss++;
                    score[num_count - 1] -= 5;
                    axWindowsMediaPlayer1.URL = "mp3/false.mp3";
                    axWindowsMediaPlayer1.settings.setMode("loop", false);


                    panels2[i].BackgroundImage = imageList1.Images[i + 10];
                    label10.Text = (5-miss).ToString();
                    label9.Text = score[num_count - 1].ToString();

                }
                else
                {
                    panels[i].Top += 40;
                }
            Refresh();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            times--;
            label12.Text = times.ToString();
            if (times <=0)
            {
                Panel[] panels2 = { panel6, panel7, panel8, panel9, panel10 };

                timer1.Enabled = false;
                result();
                gameover = true;
                axWindowsMediaPlayer1.URL = "mp3/win.mp3";
                axWindowsMediaPlayer1.settings.setMode("loop", false);
                axWindowsMediaPlayer2.Ctlcontrols.stop();
                for(int i=0;i<5;i++)
                    panels2[i].BackgroundImage = imageList1.Images[i + 5];

                MessageBox.Show("遊戲結束 結果：你贏了","通關訊息");
                return;
            }
            down();



        }

        private void stopitem(object sender, EventArgs e)
        {
            if (start == false)
            {
                MessageBox.Show("尚未開始遊戲", "系統通知");
                return;
            }

            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;

                stop.Text = "繼續遊戲";
                axWindowsMediaPlayer2.Ctlcontrols.stop();

            }
            else
            {
                timer1.Enabled =true;

                stop.Text = "暫停遊戲";
                axWindowsMediaPlayer2.Ctlcontrols.play();


            }
        }

        private void close(object sender, EventArgs e)
        {
            DialogResult re;

            timer1.Enabled = false;
 

            re= MessageBox.Show("是否關閉遊戲?", "關閉遊戲", MessageBoxButtons.YesNo);

            if (re == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                stop.Text = "繼續遊戲";

            }


        }

        private void Leaderboard(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Form2 newForm2 = new Form2();
            newForm2.ShowDialog();
            stop.Text = "繼續遊戲";

        }
        void return_1()
        {
            DialogResult de;

            timer1.Enabled = false;


            de = MessageBox.Show("是否刪除所有紀錄檔", "清除紀錄", MessageBoxButtons.YesNo);

            if (de == DialogResult.Yes)
            {
                File.Delete("result_rank.txt");
                File.Delete("result_score.txt");
                File.Delete("number.txt");
                File.Delete("num.txt");
                num_count = 0;
                times = 60;
                miss = 0;
            }
            else if(de==DialogResult.No)
            {
                stop.Text = "繼續遊戲";


            }
            MessageBox.Show("刪除成功", "系統通知");
        }
        private void returnitem(object sender, EventArgs e)
        {
            return_1();
        }

        private void aboutitem(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            Form3 newForm3 = new Form3();
            newForm3.ShowDialog();
            stop.Text = "繼續遊戲";

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
