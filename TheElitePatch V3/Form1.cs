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

namespace TheElitePatch_V3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }
    }
}
