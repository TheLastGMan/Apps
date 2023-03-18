using RPGPinEditor.Core.Keywords;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements
{
	public class Nop : Keyword
	{
		public Nop() : base("Nop();")
		{ }

		public override CommandCode Command
		{
			get
			{
				return CommandCode.Nop;
			}
		}
	}
}
