using System;
using Gtk;

namespace TheElitePatchBeta
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			Home win = new Home ();
			win.Show ();
			Application.Run ();
		}
	}
}
