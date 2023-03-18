using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Keywords
{
	public class Continue : Keyword
	{
		public Continue() : base("continue;")
		{ }

		public override CommandCode Command
		{
			get
			{
				return CommandCode.Continue;
			}
		}
	}
}
