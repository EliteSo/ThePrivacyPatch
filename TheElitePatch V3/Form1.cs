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
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(
            int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        const int URLMON_OPTION_USERAGENT = 0x10000001;
        const int URLMON_OPTION_USERAGENT_REFRESH = 0x10000002;

        public void ChangeUserAgent()
        {
            List<string> userAgent = new List<string>();
            string ua = "TEPBot (+http://www.theelitepatch.com/bot.html)";

            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT_REFRESH, null, 0, 0);
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, ua, ua.Length, 0);
        }
        string[] loadfiles = new string[] { Directory.GetCurrentDirectory() + @"\tep.html", Directory.GetCurrentDirectory() + @"\bg.png", Directory.GetCurrentDirectory() + @"\spriteh.png" };
        private void Form1_Load(object sender, EventArgs e)
        {
            /*if (CheckForInternetConnection())
            {
                ChangeUserAgent();
                webBrowser1.Navigate("http://tep.theelitepatch.com/tep.php");
            }
            else
            {*/
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
                webBrowser1.Navigate("file://" + Directory.GetCurrentDirectory() + @"\tep.html");
            }
        //}

        [ComVisible(true)]
        public class ScriptManager
        {
            /*
            function DoVisitSite(site) {
                return window.external.VisitSite(site);
            }

             */
            Form1 _form;
            public ScriptManager(Form1 form)
            {
                _form = form;
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
                return "Gigawiz";
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
        }

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

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void checkPageUpdate()
        {

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
    }
}
