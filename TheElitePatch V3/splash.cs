using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Net;

namespace TheElitePatch_V3
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
            }
            else
            {
                timer1.Stop();
                Browser home = new Browser();
                home.Show();
                this.Dispose(false);
            }
        }
        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}