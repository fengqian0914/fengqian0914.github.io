using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace keyboradgame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
                
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            soft();
        }
        void soft()
        {
            if (!File.Exists("num.txt") || !File.Exists("result_rank.txt") || !File.Exists("result_score.txt") || !File.Exists("number.txt")) 
            {
                MessageBox.Show("檔案缺失");
                return;

            }
            string lines = File.ReadAllText("num.txt");
            string[] readText = File.ReadAllLines("result_rank.txt");

            string readText_rank = File.ReadAllText("result_rank.txt");
            string[] strArray_rank = readText_rank.Split('\n');


            string readText_Score = File.ReadAllText("result_score.txt");
            string[] strArray_score = readText_Score.Split('\n');


            string readText_name = File.ReadAllText("number.txt");
            string[] strArray_name = readText_name.Split('\n');

            string[] rank_log_n = new string[Convert.ToInt32(lines)];
            var query = readText.Take(Convert.ToInt32(lines)).ToArray();

            for (int i = 0; i < Convert.ToInt32(lines); i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[2].Value = strArray_score[i];
                dataGridView1.Rows[i].Cells[0].Value = "第 "+strArray_rank[i]+"名";
                dataGridView1.Rows[i].Cells[1].Value = strArray_name[i];
            }
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);


        }
        private void softclick(object sender, EventArgs e)
        {
            soft();
        }

        private void close_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
