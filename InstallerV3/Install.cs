using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using IWshRuntimeLibrary;
using System.Threading;

namespace InstallerV3
{
    public partial class Install : Form
    {
        public Install()
        {
            InitializeComponent();
        }
        int totprog = 0;
        private void Install_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void install(string dir)
        {
            string[] resource = new string[] { "DevComponents.DotNetBar.Design.dll", "DevComponents.DotNetBar2.dll", "DevComponents.Instrumentation.Design.dll", "DevComponents.Instrumentation.dll", "NDL.dll", "The Elite Patcher.exe", "update.lock", "updater.exe" };
            foreach (string instfile in resource)
            {
                progressBar1.Value += 10;
                label1.Text = "Status: Extracting Files... ";
                string file = dir + @"\"+instfile;
                string totrec = "InstallerV3.Resources."+instfile;
                CopyResource(totrec, file);
                Thread.Sleep(1000);
            }
            totprog = progressBar1.Value;
            shortcut();
        }

        private void shortcut()
        {
            label1.Text = "Status: Installing Shortcuts... " + progressBar1.Value.ToString() + "%";
            #region shortcut installer
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\The Elite Patch.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "The Elite Patcher";
            shortcut.TargetPath = InstallerV3.Properties.Settings.Default.installdir;
            shortcut.TargetPath = InstallerV3.Properties.Settings.Default.installdir +"The Elite Patcher.exe";
            shortcut.WorkingDirectory = InstallerV3.Properties.Settings.Default.installdir;
            shortcut.Save();
            progressBar1.Value += 10;
            Thread.Sleep(1000);
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
            progressBar1.Value += 10;
            label1.Text = "Status: Installing Shortcuts... " + progressBar1.Value.ToString() + "%";
            label1.Text = "Status: Finished!";
            Thread.Sleep(1000);
            exit();
        }

        private void exit()
        {
            InstallerV3.Properties.Settings.Default.curstep += 1;
            InstallerV3.Properties.Settings.Default.Save();
            this.Dispose();
            this.Close();
        }

        private void CopyResource(string resourceName, string file)
        {
            using (Stream resource = GetType().Assembly.GetManifestResourceStream(resourceName))
            {
                if (resource == null)
                {
                    throw new ArgumentException("No such resource", resourceName);
                }
                using (Stream output = System.IO.File.OpenWrite(file))
                {
                    resource.CopyTo(output);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            install(InstallerV3.Properties.Settings.Default.installdir);
        }
    }
}
