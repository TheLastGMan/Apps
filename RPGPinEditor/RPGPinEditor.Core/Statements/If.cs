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
	public class If : IStatement
	{
		public If()
		{ }

		public If(IExpression conditional, StatementBlock ifBlock)
		{
			Conditional = conditional;
			IfBlock.AddRange(ifBlock);
		}

		public virtual List<DebugStatement> DebugCode()
		{
			return new IfElse(Conditional, IfBlock, new StatementBlock()).DebugCode();
		}

		public IExpression Conditional { get; set; }

		public StatementBlock IfBlock { get; } = new StatementBlock();
	}
}
