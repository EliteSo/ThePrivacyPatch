using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace TheElitePatch_V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }
        string[] loadfiles = new string[] { Directory.GetCurrentDirectory() + @"\tep.html", Directory.GetCurrentDirectory() + @"\bg.png", Directory.GetCurrentDirectory() + @"\spriteh.png", Directory.GetCurrentDirectory() + @"\update.exe" };
        private void Form1_Load(object sender, EventArgs e)
        {
            #region set title
            string os = "Windows Edition";
            if (isLinux())
            {
                os = "Linux Edition";
            }
            else if (isMacOS())
            {
                os = "Mac OSX Edition";
            }
            else if (isWindows())
            {
                os = "Windows Edition";
            }
            this.Text = "The Elite Patch - V" + TheElitePatch_V3.Properties.Settings.Default.buildver + " - " + os;
            #endregion
            #region choose running mode
            webBrowser1.Navigate(TheElitePatch_V3.Properties.Settings.Default.customonlinemode);
            #endregion
        }
        [ComVisible(true)]
        #region web interactions
        public class ScriptManager
        {
            Form1 _form;
            public ScriptManager(Form1 form)
            {
                _form = form;
            }
            public string isAlpha()
            {
                return "true";
            }
            public void OpenUrl(object obj)
            {
                Process.Start(obj.ToString());
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
            public string LoggedInUser()
            {
                return TheElitePatch_V3.Properties.Settings.Default.user;
            }
            public void setUser(object user)
            {
                TheElitePatch_V3.Properties.Settings.Default.user = user.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void logout()
            {
                TheElitePatch_V3.Properties.Settings.Default.user = "";
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void VerifSite(object Veriflink)
            {
                Process.Start(Veriflink.ToString());
            }
            public void VersSite(object verlnk)
            {
                Process.Start(verlnk.ToString());
            }
            public void VisitSite(object site)
            {
                Process.Start(site.ToString());
            }
            public int programversion()
            {
                return TheElitePatch_V3.Properties.Settings.Default.progver;
            }
            public bool checklogins()
            {
                bool loggedin = false;
                if (!String.IsNullOrEmpty(TheElitePatch_V3.Properties.Settings.Default.user))
                {
                    loggedin = true;
                }
                return loggedin;
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
                WC.DownloadFileAsync(new Uri("http://download.theelitepatch.com/update.exe"), Directory.GetCurrentDirectory() + @"\update.exe");
            }
            void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
                string file = Process.GetCurrentProcess().ProcessName + ".exe";
                file = file.Replace(" ", "_");
                file = file.Replace(".vshost", "");
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.Arguments = updurl + " " + file;
                psi.FileName = "update.exe";
                p.StartInfo = psi;
                p.Start();
                Environment.Exit(0);
            }
            public void setOfflineMode(object mode)
            {
                string offlinemode = mode.ToString();
                if (offlinemode == "False")
                {
                    TheElitePatch_V3.Properties.Settings.Default.offlinemode = false;
                }
                else
                {
                    TheElitePatch_V3.Properties.Settings.Default.offlinemode = true;
                }
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void setBeta(object mode)
            {
                string betamode = mode.ToString();
                if (betamode == "False")
                {
                    TheElitePatch_V3.Properties.Settings.Default.usebeta = false;
                }
                else
                {
                    TheElitePatch_V3.Properties.Settings.Default.usebeta = true;
                }
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void setCusUrl(object urltoset)
            {
                TheElitePatch_V3.Properties.Settings.Default.customonlinemode = urltoset.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
            public void setProdKey(object key)
            {
                TheElitePatch_V3.Properties.Settings.Default.productkey = key.ToString();
                TheElitePatch_V3.Properties.Settings.Default.Save();
            }
        }
        #endregion
        #region closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string loadfile in loadfiles)
            {
                if (File.Exists(loadfile))
                {
                    File.Delete(loadfile);
                }
            }
            Environment.Exit(0);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string loadfile in loadfiles)
            {
                if (File.Exists(loadfile))
                {
                    File.Delete(loadfile);
                }
            }
            Environment.Exit(0);
        }
        #endregion
        #region system checks
        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }
        public static bool isLinux()
        {
            return false;
        }
        public static bool isWindows()
        {
            return true;
        }
        public static bool isMacOS()
        {
            return false;
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
        #endregion
        
    }
}
