
namespace keyboradgame
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.選單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stop = new System.Windows.Forms.ToolStripMenuItem();
            this.重新開始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關閉遊戲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.遊戲介紹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel14 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.選單ToolStripMenuItem,
            this.資訊ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1270, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 選單ToolStripMenuItem
            // 
            this.選單ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開始ToolStripMenuItem,
            this.stop,
            this.重新開始ToolStripMenuItem,
            this.關閉遊戲ToolStripMenuItem});
            this.選單ToolStripMenuItem.Name = "選單ToolStripMenuItem";
            this.選單ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.選單ToolStripMenuItem.Text = "選單";
            // 
            // 開始ToolStripMenuItem
            // 
            this.開始ToolStripMenuItem.Name = "開始ToolStripMenuItem";
            this.開始ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.開始ToolStripMenuItem.Text = "開始遊戲";
            this.開始ToolStripMenuItem.Click += new System.EventHandler(this.開始ToolStripMenuItem_Click);
            // 
            // stop
            // 
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(122, 22);
            this.stop.Text = "暫停遊戲";
            this.stop.Click += new System.EventHandler(this.stopitem);
            // 
            // 重新開始ToolStripMenuItem
            // 
            this.重新開始ToolStripMenuItem.Name = "重新開始ToolStripMenuItem";
            this.重新開始ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.重新開始ToolStripMenuItem.Text = "資料清除";
            this.重新開始ToolStripMenuItem.Click += new System.EventHandler(this.returnitem);
            // 
            // 關閉遊戲ToolStripMenuItem
            // 
            this.關閉遊戲ToolStripMenuItem.Name = "關閉遊戲ToolStripMenuItem";
            this.關閉遊戲ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.關閉遊戲ToolStripMenuItem.Text = "關閉遊戲";
            this.關閉遊戲ToolStripMenuItem.Click += new System.EventHandler(this.close);
            // 
            // 資訊ToolStripMenuItem
            // 
            this.資訊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.遊戲介紹ToolStripMenuItem,
            this.排行榜ToolStripMenuItem});
            this.資訊ToolStripMenuItem.Name = "資訊ToolStripMenuItem";
            this.資訊ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.資訊ToolStripMenuItem.Text = "資訊";
            // 
            // 遊戲介紹ToolStripMenuItem
            // 
            this.遊戲介紹ToolStripMenuItem.Name = "遊戲介紹ToolStripMenuItem";
            this.遊戲介紹ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.遊戲介紹ToolStripMenuItem.Text = "遊戲介紹";
            this.遊戲介紹ToolStripMenuItem.Click += new System.EventHandler(this.aboutitem);
            // 
            // 排行榜ToolStripMenuItem
            // 
            this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
            this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.排行榜ToolStripMenuItem.Text = "排行榜";
            this.排行榜ToolStripMenuItem.Click += new System.EventHandler(this.Leaderboard);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(143, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 140);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 140);
            this.label1.TabIndex = 1;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(345, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 140);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 140);
            this.label2.TabIndex = 0;
            this.label2.Text = " ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(587, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 140);
            this.panel3.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 140);
            this.label3.TabIndex = 0;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(809, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(140, 140);
            this.panel4.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 140);
            this.label4.TabIndex = 0;
            this.label4.Text = " ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(1036, 80);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(140, 140);
            this.panel5.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 140);
            this.label5.TabIndex = 0;
            this.label5.Text = " ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(69, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 27);
            this.label6.TabIndex = 20;
            this.label6.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(69, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 27);
            this.label7.TabIndex = 20;
            this.label7.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(100, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 27);
            this.label9.TabIndex = 20;
            this.label9.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(99, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 27);
            this.label10.TabIndex = 21;
            this.label10.Text = "5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(99, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 27);
            this.label11.TabIndex = 22;
            this.label11.Text = "10";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 410);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(168, 90);
            this.axWindowsMediaPlayer1.TabIndex = 23;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            this.imageList1.Images.SetKeyName(4, "5.png");
            this.imageList1.Images.SetKeyName(5, "6.png");
            this.imageList1.Images.SetKeyName(6, "7.png");
            this.imageList1.Images.SetKeyName(7, "8.png");
            this.imageList1.Images.SetKeyName(8, "9.png");
            this.imageList1.Images.SetKeyName(9, "10.png");
            this.imageList1.Images.SetKeyName(10, "11.png");
            this.imageList1.Images.SetKeyName(11, "12.png");
            this.imageList1.Images.SetKeyName(12, "13.png");
            this.imageList1.Images.SetKeyName(13, "14.png");
            this.imageList1.Images.SetKeyName(14, "15.png");
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel10.Location = new System.Drawing.Point(1036, 560);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(140, 140);
            this.panel10.TabIndex = 19;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel9.Location = new System.Drawing.Point(809, 560);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(140, 140);
            this.panel9.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel8.Location = new System.Drawing.Point(587, 560);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(140, 140);
            this.panel8.TabIndex = 17;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel7.Location = new System.Drawing.Point(365, 560);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(140, 140);
            this.panel7.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel6.Location = new System.Drawing.Point(143, 560);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(140, 140);
            this.panel6.TabIndex = 15;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel11.Location = new System.Drawing.Point(12, 29);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(51, 49);
            this.panel11.TabIndex = 16;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel12.Location = new System.Drawing.Point(12, 84);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(51, 49);
            this.panel12.TabIndex = 17;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel13.Location = new System.Drawing.Point(12, 139);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(51, 49);
            this.panel13.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(70, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 27);
            this.label8.TabIndex = 24;
            this.label8.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(1152, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 27);
            this.label12.TabIndex = 25;
            this.label12.Text = "60";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "coin.png");
            this.imageList2.Images.SetKeyName(1, "error_1.png");
            this.imageList2.Images.SetKeyName(2, "error_2.png");
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.BackgroundImage = global::keyboradgame.Properties.Resources.time;
            this.panel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel14.Location = new System.Drawing.Point(1090, 35);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(56, 43);
            this.panel14.TabIndex = 19;
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(242, 410);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(168, 90);
            this.axWindowsMediaPlayer2.TabIndex = 26;
            this.axWindowsMediaPlayer2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 795);
            this.Controls.Add(this.axWindowsMediaPlayer2);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(0, 50);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "6";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 選單ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開始ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem stop;
        private System.Windows.Forms.ToolStripMenuItem 重新開始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關閉遊戲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 資訊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 遊戲介紹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
    }
}

