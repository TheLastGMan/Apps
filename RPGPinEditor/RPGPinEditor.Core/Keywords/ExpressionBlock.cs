using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Commands
{
	public class ExpressionBlock : List<IExpression>, IStatement
	{
		public ExpressionBlock()
		{ }

		public ExpressionBlock(IEnumerable<IExpression> expressions) : base(expressions)
		{ }

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock(this).DebugCode();
		}
	}
}
