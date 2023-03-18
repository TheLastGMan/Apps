using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Keywords
{
	public class Break : Keyword
	{
		public Break() : base("break;")
		{ }

		public override CommandCode Command
		{
			get { return CommandCode.Break; }
		}
	}
}
