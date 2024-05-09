using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyboradgame
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile("font/SuperMario256.ttf");
            Font font = new Font(privateFonts.Families[0], 30);
            label1.Font = font;
            label1.ForeColor = Color.Firebrick;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
