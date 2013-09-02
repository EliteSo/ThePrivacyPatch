using System;
using Gtk; 
using Mono.Unix.Native;
using System.IO;

namespace TheElitePatchBeta
{
	public partial class Home : Gtk.Window
	{
		string hosts = "/etc/hosts";
		public Home () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			 if (Syscall.getuid() == 0) {
				label4.Text = "I'm running as root!";
        } else {
				label4.Text = "Not root...";
        }
			loadHosts(hosts);
		}
		private void backupHosts (string hosts)
		{
			File.Copy (hosts, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "/hosts.bak");
		}
		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			writeHosts(hosts, "192.168.1.1 elite.so");
		}
		private void writeHosts (string file, string line)
		{
			//backupHosts(file);
			//get root access

			StreamWriter SW = new StreamWriter(file);
			SW.WriteLine(line);
			SW.Close();
		}
		private void loadHosts (string file)
		{
			foreach (string line in File.ReadAllLines (file)) {
				 TextIter mIter = textview3.Buffer.EndIter;
				textview3.Buffer.Insert(ref mIter, line+Environment.NewLine);
			}
		}
	}
}