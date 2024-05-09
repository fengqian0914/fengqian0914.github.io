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
        int computer;
        int[] score = {0,0,0};
        bool ans = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ans == false)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.Image = Image.FromFile("1.png");
                Random random = new Random();
                computer = random.Next(1, 4); //1=剪刀 2=石頭 3=布

                pictureBox2.Image = Image.FromFile(computer + ".png");
         
                if (computer == 1)
                {
                    label3.Text = "結果為： 平手";
                }
                else if (computer == 2)
                {
                    if (count == 0)
                        score[0] = -1;
                    else if (count == 1)
                        score[1] = -1;
                    else
                    {
                        score[2] = -1;
                    }
                    label3.Text = "結果為： 你輸了";
                    count++;

                    label8.Text += "X";
                }
                else
                {
                    if (count == 0)
                        score[0] = 1;
                    else if (count == 1)
                        score[1] = 1;
                    else
                    {
                        score[2] = 1;
                    }
                    label3.Text = "結果為： 你贏了";
                    count++;
                    label8.Text += "O";

                }
                result();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (ans == false)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                pictureBox1.Image = Image.FromFile("2.png");

                Random random = new Random();
                computer = random.Next(1, 4); //1=剪刀 2=石頭 3=布

                pictureBox2.Image = Image.FromFile(computer + ".png");
                if (computer == 1)
                {
                    if (count == 0)
                        score[0] = 1;
                    else if (count == 1)
                        score[1] = 1;
                    else
                    {
                        score[2] = 1;
                    }
                    label3.Text = "結果為： 你贏了";
                    count++;

                    label8.Text += "O";
                }
                else if (computer == 2)
                {
                    label3.Text = "結果為： 平手";
                }
                else
                {
                    if (count == 0)
                        score[0] = -1;
                    else if (count == 1)
                        score[1] = -1;
                    else
                    {
                        score[2] = -1;
                    }
                    label3.Text = "結果為： 你輸了";
                    count++;
                    label8.Text += "X";
                }
                    result();
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ans == false)   //當結果未產生 執行
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.Image = Image.FromFile("3.png");//3為布的圖片
                Random random = new Random();
                computer = random.Next(1, 4); //1=剪刀 2=石頭 3=布
                pictureBox2.Image = Image.FromFile(computer + ".png");//將亂數寫回照片
                if (computer == 1)   //當亂數=1 代表是剪刀
                {
                    if (count == 0)  //當沒點過時 次數為0
                        score[0] = -1; //將本次紀錄在陣列第0位 -1代表輸 1代表贏
                    else if (count == 1)  //當已點過一次 放在第1位
                        score[1] = -1;
                    else                   //當已點過兩次 放在第2位
                        score[2] = -1; 
                    label3.Text = "結果為： 你輸了";  //因按鈕選布 因電腦出現剪刀 結果為輸
                    count++;                 //場數+1
                    label8.Text += "X";      //將歷次結果顯示 可用appendtext
                }
                else if (computer == 2)   //當亂數=2 代表是石頭
                {
                    if (count == 0)
                        score[0] = 1;
                    else if (count == 1)
                        score[1] = 1;
                    else
                        score[2] = 1;
                    label3.Text = "結果為： 你贏了";//因按鈕選布 因電腦出現石頭 結果為贏
                    count++;
                    label8.Text += "O";
                }
                else  //因亂數為1-3 所以最後只可能出現3 代表是布
                {
                    label3.Text = "結果為： 平手";//因按鈕選布 因電腦出現布 結果為平手
                }
                result();
                }
        }
        void result()
        {
            if (score[0] == score[1] &&count==2)  //當 前兩場 是 OO 或XX
            {
                if (score[0] == -1)  //因前兩場相同 所以可只判定第0位  當值紀錄是-1 則代表本輪輸
                    label9.Text = "三戰兩勝結果為：你輸了";
                else                //當兩場就結果出爐 但值不是-1 則代表值為1 代表本輪贏
                    label9.Text = "三戰兩勝結果為：你贏了";
                ans = true;        //使答案變成真 使前方的按鈕不可再執行

            }
            else if (score[0] == score[2]&&count==3)  //當 三場 是 OXO 或XOX
            {
                if (score[0] == -1) //因第1場和第3場相同 所以可只判定第0位(陣列-1)
                    label9.Text = "三戰兩勝結果為：你輸了";
                else
                    label9.Text = "三戰兩勝結果為：你贏了";
                ans = true;

            }
            else if (score[1] == score[2]&&count==3)  //當 三場 是 XOO 或OXX
            {
                if (score[1] == -1)//因第2場和第3場相同 所以可只判定第1位(陣列-1)
                    label9.Text = "三戰兩勝結果為：你輸了";
                else
                    label9.Text = "三戰兩勝結果為：你贏了";
                ans = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //重新按鈕 將所有值變成預設
            score[0] = 0;
            score[1] = 0;
            score[2] = 0;
            count = 0;

            label3.Text = "結果為：";
            label8.Text = "";
            label9.Text = "三戰兩勝結果為：";
            ans = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
