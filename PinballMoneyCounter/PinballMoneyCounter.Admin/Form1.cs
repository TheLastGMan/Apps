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

namespace PinballMoneyCounter.Admin
{
	public partial class Form1 : Form
	{
		private string _pinballFileName = "VPinballMoneySpent.txt";
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				using (var sr = new StreamReader(_pinballFileName, true))
				{
					decimal cost = Decimal.Parse(sr.ReadLine().TrimStart('$'));
					numericUpDownDollars.Value = Math.Floor(cost);
					numericUpDownCents.Value = (cost - numericUpDownDollars.Value) * 100;
				}
			}
			catch
			{ }
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//add 0.25
			addSpent(0.25M);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//add 0.50
			addSpent(0.50M);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//add 0.75
			addSpent(0.75M);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			//add 1.00
			addSpent(1.00M);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//set spent
			decimal cost = numericUpDownDollars.Value + numericUpDownCents.Value / 100;
			setSpent(cost);
		}

		private void addSpent(decimal cost)
		{
			decimal newCost = cost + totalCost();
			setSpent(newCost);
		}

		private void setSpent(decimal value)
		{
			numericUpDownDollars.Value = Math.Floor(value);
			numericUpDownCents.Value = (value - numericUpDownDollars.Value) * 100;
			try
			{
				using (var sw = new StreamWriter(_pinballFileName, false))
					sw.WriteLine(value.ToString("C"));
			}
			catch
			{ }
		}

		private decimal totalCost()
		{
			return numericUpDownDollars.Value + numericUpDownCents.Value / 100;
		}
	}
}
