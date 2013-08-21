using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using IWshRuntimeLibrary;
using System.IO;

namespace InstallerV3
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }

        private void Download_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        string urldl = "";
        private void dlfiles()
        {
            try
            {
                string updateurl = "http://files.theelitepatch.com/filelist.txt";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updateurl);
                WebResponse response = request.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1252"));
                string test = sr.ReadToEnd();
                string[] parts = test.Split('=');
                IEnumerable<string> urls = parts;
                foreach (string url in urls)
                {
                    Match match = Regex.Match(url, @"([A-Za-z0-9\-]+)\.([A-Za-z0-9\-]+)$",
                    RegexOptions.IgnoreCase);

                    // Here we check the Match instance.
                    if (match.Success)
                    {
                        _downloadUrls.Enqueue(url);
                        count++;
                    }
                }
                DownloadFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error downloading The Elite Patch! The installer will now continue in offline mode." + Environment.NewLine + "Exact error message: " +Environment.NewLine + ex.Message);
                InstallerV3.Properties.Settings.Default.offline = true;
                InstallerV3.Properties.Settings.Default.dlerr = true;
                InstallerV3.Properties.Settings.Default.Save();
                end();
            }
        }

        private void shortcut()
        {
            label1.Text = "Status: Installing Shortcuts... ";
            #region shortcut installer
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\The Elite Patch.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "The Elite Patcher";
            shortcut.TargetPath = InstallerV3.Properties.Settings.Default.installdir;
            shortcut.TargetPath = InstallerV3.Properties.Settings.Default.installdir + "The Elite Patcher.exe";
            shortcut.WorkingDirectory = InstallerV3.Properties.Settings.Default.installdir;
            shortcut.Save();
            label1.Text = "Status: Installing Shortcuts... " + progressBar1.Value.ToString() + "%";
            string fol = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + @"\Programs\Elite.So\The Elite Patch\";
            if (!Directory.Exists(fol))
            {
                Directory.CreateDirectory(fol);
            }
            WshShell shell2 = new WshShell();
            IWshShortcut MyShortcut;
            MyShortcut = (IWshShortcut)shell2.CreateShortcut(fol + "The Elite Patch.lnk");
            MyShortcut.TargetPath = InstallerV3.Properties.Settings.Default.installdir + "The Elite Patcher.exe";
            MyShortcut.WorkingDirectory = InstallerV3.Properties.Settings.Default.installdir;
            MyShortcut.Save();
            #endregion
            label1.Text = "Status: Finished!";
        }

        private void DownloadFile()
        {
            try
            {
                if (_downloadUrls.Any())
                {
                    WebClient client = new WebClient();
                    client.DownloadProgressChanged += client_DownloadProgressChanged;
                    client.DownloadFileCompleted += client_DownloadFileCompleted;
                    var url = _downloadUrls.Dequeue();
                    urldl = url;
                    //MessageBox.Show(url);
                    string FileName = url.Substring(url.LastIndexOf("/") + 1,
                                (url.Length - url.LastIndexOf("/") - 1));
                    string filepath = InstallerV3.Properties.Settings.Default.installdir + @"\";
                    filedling = FileName;
                    client.DownloadFileAsync(new Uri(url), filepath + FileName);
                    return;
                }
                done = count;
                InstallerV3.Properties.Settings.Default.curstep += 1;
                shortcut();
                end();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error downloading The Elite Patch! The installer will now continue in offline mode." + Environment.NewLine + "File being downloaded: " + urldl + Environment.NewLine
                 + "Exact error message: " + Environment.NewLine + ex.Message);
                InstallerV3.Properties.Settings.Default.offline = true;
                InstallerV3.Properties.Settings.Default.dlerr = true;
                InstallerV3.Properties.Settings.Default.Save();
                end();
            }
        }

        private void end()
        {
            InstallerV3.Properties.Settings.Default.Save();
            this.Dispose();
            this.Close();
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                InstallerV3.Properties.Settings.Default.offline = true;
                InstallerV3.Properties.Settings.Default.dlerr = true;
                InstallerV3.Properties.Settings.Default.Save();
                end();
            }
            if (e.Cancelled)
            {
                InstallerV3.Properties.Settings.Default.offline = true;
                InstallerV3.Properties.Settings.Default.dlerr = true;
                InstallerV3.Properties.Settings.Default.Save();
                end();
            }
            done++;
            DownloadFile();
        }
        private Queue<string> _downloadUrls = new Queue<string>();
        string filedling = null;
        int count = 0;
        int done = 0;
        double bytesIn = 0;
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytescheck = double.Parse(e.TotalBytesToReceive.ToString());
            string stripped = Convert.ToString(totalBytescheck / 1024 / 1024);
            string strippedsub = stripped.Substring(stripped.LastIndexOf('.'), 3);
            double percentage = ((double)done / (double)count) * (double)100;
            string instrip = Convert.ToString(bytesIn / 1024 / 1024);
            string totendby = instrip.Substring(instrip.LastIndexOf("."), 3);
            progressBar2.Value = int.Parse(Math.Truncate(percentage).ToString());
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = "Downloading file: " + filedling + "... " + instrip.Split('.')[0] + totendby + " MB of " + stripped.Split('.')[0] + strippedsub+ " MB";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            dlfiles();
        }
    }
}
