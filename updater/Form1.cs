using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int totfils = 0;
        int donfils = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string fil in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Temp\", "*.*"))
            {
                totfils++;
            }
            progressBar1.Maximum = totfils;
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string filePath in filePaths)
            {
                var name = new FileInfo(filePath).Name;
                name = name.ToLower();
                if (name != "updater.exe")
                {
                    File.Delete(filePath);
                }
            }
            string[] filePaths2 = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Temp", "*.*");
            foreach (string filePath2 in filePaths2)
            {
                var name = new FileInfo(filePath2).Name;
                name = name.ToLower();
                if (name != "updater.exe")
                {
                    name = new FileInfo(filePath2).Name;
                    donfils++;
                    File.Copy(filePath2, Directory.GetCurrentDirectory()+@"\"+name);
                    File.Delete(filePath2);
                    progressBar1.Value = donfils;
                }
            }
            string[] filePaths3 = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Temp\plugins", "*.dll");
            foreach (string filePath3 in filePaths3)
            {
                var name = new FileInfo(filePath3).Name;
                name = name.ToLower();
                if (name != "updater.exe")
                {
                    name = new FileInfo(filePath3).Name;
                    donfils++;
                    File.Copy(filePath3, Directory.GetCurrentDirectory() + @"\plugins\" + name);
                    File.Delete(filePath3);
                    progressBar1.Value = donfils;
                }
            }
            progressBar1.Value = totfils;
            if (progressBar1.Value == totfils)
            {
                end();
            }
        }
        private void end()
        {
            Process.Start("The Elite Patcher.exe");
            Environment.Exit(0);
        }
    }
}
