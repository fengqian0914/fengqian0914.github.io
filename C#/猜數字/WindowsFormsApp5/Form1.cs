using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        int[] pcnum = new int[4];
        int a = 0;
        int b = 0;
        int count = 0;
        int[] usernum = new int[4];
        bool start = false;
        public Form1()
        {
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Random ra = new Random();
            int j = 0;
            count = 0;
            for(int i = 0; i < 4; i++)
            {
                pcnum[i] = ra.Next(0, 10);
                while (j < i) 
                    for(j = 0; j < i; j++)
                    {
                        if(pcnum[i]== pcnum[j])
                        {
                            pcnum[i] = ra.Next(0, 10);
                            j = 0;
                            break;
                        }
                    }
            }
            label1.Text = "答案為：****";
            start = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count++;
            a = 0;
            b = 0;
            if (start == false)
            {
                MessageBox.Show("尚未產生新數字");
                return;
            }
            for (int i = 0; i < 4; i++)
                usernum[i] = Convert.ToInt32(textBox1.Text.Substring(i, 1));
            for (int i = 0; i < 4; i++)
                if (usernum[i] == pcnum[i])
                    a++;
                else if (pcnum.Contains(usernum[i]) == true)
                    b++;
            textBox2.Text += "\r\n--------------\r\n第" + count + "次猜測數字：" + usernum[0] + usernum[1] + usernum[2] + usernum[3] + "   " + a + "A" + b + "B";
            if (a == 4)
            {
                textBox2.Text += "\r\n--------------\r\n成功猜測共使用" + count + "次";
                label1.Text = "答案為："+ pcnum[0] + pcnum[1] + pcnum[2] + pcnum[3];
                start = false;
            }
        }
    }
}
