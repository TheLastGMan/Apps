using RPGPinEditor.Core.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements
{
	public class Case : StatementBlock
	{
		public Case()
		{ }

		public Case(int constant) : this(constant, new StatementBlock())
		{
		}

		public Case(int constant, StatementBlock body) : base(body)
		{
			Constant = constant;
		}

		public int Constant { get; set; }
	}
}
