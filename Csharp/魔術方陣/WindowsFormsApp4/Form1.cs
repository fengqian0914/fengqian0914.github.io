using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = ""; //結果輸出
            double num = Convert.ToInt32(textBox1.Text);//輸入數字
            int result = Convert.ToInt32(Math.Floor(num/ 2));//計算第一個數字位置
            int[,] array = new int[Convert.ToInt32(num), Convert.ToInt32(num)];//矩陣呼叫
           for (int i = 0; i < num; i++)
                for (int j = 0; j < num; j++)//將矩陣內容先設為0
                    array[i, j] = 0;
            int temp_r = 0; //設行為0
            int temp_c = result;//設列為第一數字位置
            int temp = (int)num; //轉為數字
            array[0, result] = 1; //設第一個數字位置 為1
            int a = 1;        //結果輸出時判斷是否需要換行    
            for(int i=2;i< (num*num)+1; i++) //從2開始
            {          
                if (temp_r == 0) //如行在0時執行
                { 
                    if (temp_c == 0) //如行列都在0 則 行+1
                        temp_r += 1;
                    else  //如行在0 列不在0則代表需要去左行最底下
                    { 
                        temp_r = temp - 1; //依據輸入值-1判斷總高度 往下
                        temp_c -= 1; //去左行
                    }                     
                }
                else if (temp_c == 0)//如列在0 行不在0 則代表需要最右邊的右上位置
                {
                    temp_r -= 1; //往上
                    temp_c = temp - 1;//依據輸入值-1判斷總寬度  往右
                }
                else if(array[temp_r-1, temp_c-1]!=0) //如這邊值已經被寫入則往下寫
                    temp_r += 1;
                else //如這邊沒有值 也行列皆不在0 則往左上
                {
                    temp_r -= 1;//往上
                    temp_c -= 1;//往左
                }
                array[temp_r, temp_c] = i; //寫入值
            }
            foreach (int i in array)
            {
                str+=string.Format(" {0:00} ", i); //輸出字
                if (a % num == 0) //當可整除則換行
                    str += string.Format("\r\n");
                a++;
            }
            textBox2.Text = str;
        }
    }
}