using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace update
{
    public partial class Form1 : Form
    {
        string dlurl = "";
        string rebootprog = "";
        public Form1(string downloadurl, string prognam)
        {
            dlurl = downloadurl;
            rebootprog = prognam;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rebootprog = rebootprog.Replace("_", " ");
            WebClient WC = new WebClient();
            WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WC_DownloadProgressChanged);
            WC.DownloadFileCompleted += new AsyncCompletedEventHandler(WC_DownloadFileCompleted);
            WC.DownloadFileAsync(new Uri(dlurl), Directory.GetCurrentDirectory() +@"\"+rebootprog);
        }

        void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(rebootprog);
            Environment.Exit(0);
        }

        void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
