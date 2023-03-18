using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Keywords
{
	public class EndBlock : Keyword
	{
		public EndBlock() : base("} //end block")
		{ }

		public override CommandCode Command
		{
			get
			{
				return CommandCode.EndBlock;
			}
		}
	}
}
