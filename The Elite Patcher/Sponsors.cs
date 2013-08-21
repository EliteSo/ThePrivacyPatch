using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace The_Elite_Patcher
{
    public partial class Sponsors : Form
    {
        public Sponsors()
        {
            InitializeComponent();
        }

        private void Sponsors_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Splash splash = new Splash();
            splash.Show();
            this.Dispose(false);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("http://adminspot.net");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://elite.so");
        }
    }
}
