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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string sMsg) // Form2建構子
        {
            InitializeComponent();
            textBox1.Text = sMsg; //將textbox1.text設定為從From1傳過來的資料            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
