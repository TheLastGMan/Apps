using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Expressions;
using RPGPinEditor.Core.Expressions.Variable;
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
	public class GotoCase : Keyword
	{
		public GotoCase() : base("")
		{ }

		public GotoCase(int constant) : this()
		{
			Constant = constant;
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.GotoCase;
			}
		}

		public override List<DebugStatement> DebugCode()
		{
			var block = new StatementBlock();
			block.Add(new VariableSet(new VariableUpperBound(), new Constant(Constant)));
			block.Add(new CMD(Command, $"goto case {Constant};"));
			var debugCode = block.DebugCode();
			debugCode.Insert(0, new DebugStatement(0, $"// goto case {Constant};", true, false));
			return debugCode;
		}

		public int Constant { get; set; }
	}
}
