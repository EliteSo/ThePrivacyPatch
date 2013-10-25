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

namespace TheElitePatch_V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }
        string[] loadfiles = new string[] { Directory.GetCurrentDirectory() + @"\tep.html", Directory.GetCurrentDirectory() + @"\bg.png", Directory.GetCurrentDirectory() + @"\spriteh.png" };
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string resource_name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                string filetocheck = Directory.GetCurrentDirectory() + @"\" + resource_name.Substring((resource_name.IndexOf(".") + 1), (resource_name.Length - (resource_name.IndexOf(".") + 1)));
                filetocheck = filetocheck.Substring((filetocheck.IndexOf(".") +1), (filetocheck.Length - (filetocheck.IndexOf(".") + 1)));
                if (filetocheck.Contains(".png") || filetocheck.Contains(".html"))
                {
                    filetocheck = Directory.GetCurrentDirectory() + @"\" + filetocheck;
                    if (!File.Exists(filetocheck))
                    {
                        //MessageBox.Show(filetocheck);
                        ExtractFileResource(resource_name, filetocheck);
                    }
                }
            }
            webBrowser1.Navigate("file://" + Directory.GetCurrentDirectory() + @"\tep.html");
        }

        [ComVisible(true)]
        public class ScriptManager
        {
            Form1 _form;
            public ScriptManager(Form1 form)
            {
                _form = form;
            }
            public void ShowMessage(object obj)
            {
                MessageBox.Show(obj.ToString());
            }
            public void PatchHost(object hoststring)
            {
                string hosts = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
                try
                {
                    string[] patchdata = hoststring.ToString().Split('=');
                    foreach (string contents in patchdata)
                    {
                        System.IO.File.AppendAllText(hosts, contents + Environment.NewLine);
                    }
                    MessageBox.Show("Successfully patched!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error patching!" +Environment.NewLine + "Exact Error: " + ex.Message);
                }
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
