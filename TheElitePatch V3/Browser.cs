using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;

namespace TheElitePatch_V3
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }
        bool firstload = true;
        private void Browser_Load(object sender, EventArgs e)
        {
            #region set title
            this.Text = "The Elite Patch - V" + TheElitePatch_V3.Properties.Settings.Default.buildver;
            #endregion
            #region navigate browser
            webBrowser1.Navigate("http://tep.theelitepatch.com");
            #endregion
        }
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (firstload)
            {
                firstload = false;
                if (!String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.user))
                {
                    try
                    {
                        HtmlDocument d = this.webBrowser1.Document;
                        d.GetElementById("usrnm").SetAttribute("value", TheElitePatch_V3.Properties.Settings.Default.user);
                        if (TheElitePatch_V3.Properties.Settings.Default.autologin)
                        {
                            d.GetElementById("pass").SetAttribute("value", CryptorEngine.Decrypt(TheElitePatch_V3.Properties.Settings.Default.pass));
                            HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
                            foreach (HtmlElement el in elc)
                            {
                                if (el.GetAttribute("type").Equals("submit"))
                                {
                                    el.InvokeMember("Click");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        [ComVisible(true)]
        #region web interactions
        public class ScriptManager
        {
            Browser _form;
            public ScriptManager(Browser form)
            {
                _form = form;
            }
            public string checkTEP()
            {
                return "isTEP";
            }
            public void PatchHost(object hoststring)
            {
                string hosts = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
                try
                {
                    string[] patchdata = hoststring.ToString().Split('=');
                    foreach (string contents in patchdata)
                    {
                        System.IO.File.AppendAllText(hosts, Environment.NewLine + contents + Environment.NewLine);
                    }
                    MessageBox.Show("Successfully patched!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error patching!" + Environment.NewLine + "Exact Error: " + ex.Message);
                }
            }
            public void RemoveHost(object instring)
            {
                string[] line = instring.ToString().Split('=');
                string file = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
                try
                {
                    if (!System.IO.File.Exists(file) && System.IO.File.Exists(file + "bak"))
                        System.IO.File.Copy(file + "bak", file);
                    string[] strArray = System.IO.File.ReadAllLines(file);
                    System.IO.File.WriteAllText(file + "tmp", "");
                    if (System.IO.File.Exists(file + "new"))
                        System.IO.File.Delete(file + "new");
                    if (System.IO.File.Exists(file + "bak"))
                        System.IO.File.Delete(file + "bak");
                    else
                        System.IO.File.Copy(file, file + "bak");
                    foreach (string str in strArray)
                    {
                        string lines = str;
                        if (!Enumerable.Any<string>((IEnumerable<string>)line, (Func<string, bool>)(s => lines.Contains(s))))
                            System.IO.File.AppendAllText(file + "tmp", lines + Environment.NewLine);
                    }
                    System.IO.File.Delete(file);
                    System.IO.File.Copy(file + "tmp", file);
                    MessageBox.Show("Host Removed Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error removing this host!" + Environment.NewLine + "Exact Error: " + ex.Message);
                }
            }
            public void setUser(object user)
            {
                TheElitePatch_V3.Properties.Settings.Default.user = user.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void setPass(object pass)
            {
                TheElitePatch_V3.Properties.Settings.Default.pass = CryptorEngine.Encrypt(pass.ToString());
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void setAutoLogin(object valu)
            {
                if (!String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.user))
                {
                    if (!String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.pass))
                    {
                        if (valu.ToString().ToLower() == "yes")
                        {
                            TheElitePatch_V3.Properties.Settings.Default.autologin = true;
                        }
                        else
                        {
                            TheElitePatch_V3.Properties.Settings.Default.autologin = false;
                        }
                        TheElitePatch_V3.Properties.Settings.Default.Save();
                    }
                }
            }
            public void logout()
            {
                TheElitePatch_V3.Properties.Settings.Default.user = "";
                TheElitePatch_V3.Properties.Settings.Default.pass = "";
                TheElitePatch_V3.Properties.Settings.Default.autologin = false;
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public int programversion()
            {
                return TheElitePatch_V3.Properties.Settings.Default.progver;
            }
            public void setFriendlyVersion(object verstring)
            {
                TheElitePatch_V3.Properties.Settings.Default.buildver = verstring.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            string updurl = "";
            public void update(object updateurl)
            {
                updurl = updateurl.ToString();
                WebClient WC = new WebClient();
                WC.DownloadFileCompleted += new AsyncCompletedEventHandler(WC_DownloadFileCompleted);
                WC.DownloadFileAsync(new Uri(updurl), Directory.GetCurrentDirectory() + @"\update.exe");
            }
            void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.Arguments = updurl;
                psi.FileName = "update.exe";
                p.StartInfo = psi;
                p.Start();
                Environment.Exit(0);
            }
        }
        #endregion
        #region closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
        #region optionsbuttons
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://tep.theelitepatch.com/tep.php?p=progprefs");
        }
        #endregion
        #region helpbuttons
        private void aboutTheElitePatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://tep.theelitepatch.com/tep.php?p=about");
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://tep.theelitepatch.com/tep.php?p=support");
        }
        #endregion
    }
}
