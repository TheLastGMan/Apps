using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinballMoneyCounter.Display
{
	public partial class Form1 : Form
	{
		private string _pinballFileName = "VPinballMoneySpent.txt";
		private DateTime _lastModified = new DateTime(2000, 1, 1);

		public Form1()
		{
			InitializeComponent();

			//position at bottom right
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height);

			timer1_Tick(this, new EventArgs());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			var fi = new FileInfo(_pinballFileName);
			try
			{
				if (fi.Exists && fi.LastWriteTime != _lastModified)
				{
					_lastModified = fi.LastWriteTime;
					using (var sr = new StreamReader(fi.FullName))
						DisplayText.Text = sr.ReadLine();
				}
			}catch
			{
				DisplayText.Text = "ERROR";
			}
		}
	}
}
