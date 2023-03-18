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
	public class While : DoWhile
	{
		public While()
		{
		}

		public While(ExpressionBlock conditionals, StatementBlock bodyBlock)
			: base(bodyBlock, conditionals)
		{
		}


		public override List<DebugStatement> DebugCode()
		{
			return new For(new StatementBlock(), ConditionalBlock, new ExpressionBlock(), BodyBlock).DebugCode();
		}
	}
}
