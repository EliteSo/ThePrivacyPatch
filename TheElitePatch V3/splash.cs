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
        bool check = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check == false)
            {
                check = true;
                backgroundWorker1.RunWorkerAsync();
            }
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
            }
            else
            {
                timer1.Stop();
                Form1 home = new Form1();
                home.Show();
                this.Dispose(false);
            }
        }
        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void checkNet()
        {
            if (!CheckForInternetConnection())
            {
                foreach (string resource_name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    string filetocheck = Directory.GetCurrentDirectory() + @"\" + resource_name.Substring((resource_name.IndexOf(".") + 1), (resource_name.Length - (resource_name.IndexOf(".") + 1)));
                    filetocheck = filetocheck.Substring((filetocheck.IndexOf(".") + 1), (filetocheck.Length - (filetocheck.IndexOf(".") + 1)));
                    if (filetocheck.Contains(".png") || filetocheck.Contains(".html"))
                    {
                        filetocheck = Directory.GetCurrentDirectory() + @"\" + filetocheck;
                        if (!File.Exists(filetocheck))
                        {
                            ExtractFileResource(resource_name, filetocheck);
                        }
                    }
                }
                TheElitePatch_V3.Properties.Settings.Default.customonlinemode = "file://" + Directory.GetCurrentDirectory() + @"\tep.html";
            }
            else
            {
                if (String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.productkey))
                {
                    TheElitePatch_V3.Properties.Settings.Default.customonlinemode = "http://tep.theelitepatch.com";
                }
                else
                {
                    if (String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.customonlinemode))
                    {
                        TheElitePatch_V3.Properties.Settings.Default.customonlinemode = "http://tep.theelitepatch.com";
                    }
                }
            }
        }
        private bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://tep.theelitepatch.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        static void ExtractFileResource(string resource_name, string file_name)
        {
            try
            {
                if (File.Exists(file_name))
                    File.Delete(file_name);

                if (!Directory.Exists(Path.GetDirectoryName(file_name)))
                    Directory.CreateDirectory(Path.GetDirectoryName(file_name));

                using (Stream sfile = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource_name))
                {
                    byte[] buf = new byte[sfile.Length];
                    sfile.Read(buf, 0, Convert.ToInt32(sfile.Length));

                    using (FileStream fs = File.Create(file_name))
                    {
                        fs.Write(buf, 0, Convert.ToInt32(sfile.Length));
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can't extract resource '{0}' to file '{1}': {2}", resource_name, file_name, ex.Message), ex);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            checkNet();
        }
    }
}
