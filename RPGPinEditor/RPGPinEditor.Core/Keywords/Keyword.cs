using RPGPinEditor.Core.Statements;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Keywords
{
	public abstract class Keyword : IKeyword
	{
		public Keyword()
		{ }

		public Keyword(string description)
		{
			Description = description;
		}

		public abstract CommandCode Command { get; }

		public virtual List<DebugStatement> DebugCode()
		{
			if (Description == null)
				return new CMD(Command).DebugCode();
			else
				return new CMD(Command, Description).DebugCode();
		}

		public string Description { get; set; }
	}
}
