using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace update
{
    public partial class Form1 : Form
    {
        #region globals
        private string listurl;
        string filedling = "";
        string folder = Directory.GetCurrentDirectory();
        #endregion
        public Form1(string username)
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(username))
            {
                listurl = "http://tep.theelitepatch.com/api.php?apikey=thisistep&request=getupdater&username=none";
            }
            else
            {
                listurl = "http://tep.theelitepatch.com/api.php?apikey=thisistep&request=getupdater&username=" + username;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private Queue<string> _downloadUrls = new Queue<string>();
        private void dlfiles()
        {
            string updateurl = listurl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
            WebResponse response = request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
            string test = sr.ReadToEnd();
            string[] parts = test.Split('~');
            IEnumerable<string> urls = parts;
            foreach (string url in urls)
            {
                string urlfix = url.Remove(url.IndexOf("<"));
                Match match = Regex.Match(urlfix, @"([A-Za-z0-9\-]+)\.([A-Za-z0-9\-]+)$", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    _downloadUrls.Enqueue(urlfix);
                    listBox1.Items.Add(urlfix);
                }
            }
            DownloadFile();
        }
        private void DownloadFile()
        {
            if (_downloadUrls.Any())
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);


                var url = _downloadUrls.Dequeue();
                string FileName = url.Substring(url.LastIndexOf("/") + 1, (url.Length - url.LastIndexOf("/") - 1));
                string filepath = GetParentUriString(new Uri(url));
                filedling = FileName;
                client.DownloadFileAsync(new Uri(url), folder + @"\" + FileName);
                return;
            }
            end();
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw e.Error;
            }
            if (e.Cancelled)
            {
                MessageBox.Show("User Canceled!");
            }
            DownloadFile();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        static string GetParentUriString(Uri uri)
        {
            return uri.AbsoluteUri.Remove(uri.AbsoluteUri.Length - uri.Segments.Last().Length);
        }

        private void end()
        {
            //MessageBox.Show("Done!");
            //Pandoras_box.Properties.Settings.Default.updated = true;
            Process.Start("TheElitePatch.exe");
            Environment.Exit(0);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Process[] pname = Process.GetProcessesByName("TheElitePatch");
                if (pname.Length == 0)
                {
                    timer1.Stop();
                    dlfiles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error downloading the update! Exact Error Message:" + Environment.NewLine + ex.Message);
            }
        }
    }
}
