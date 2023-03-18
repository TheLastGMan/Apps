using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Commands
{
	public class StatementBlock : List<IStatement>, IStatement
	{
		public StatementBlock()
		{
		}

		public StatementBlock(IEnumerable<IStatement> statements) : base(statements)
		{
		}

		public virtual List<DebugStatement> DebugCode()
		{
			return this.SelectMany(f => f.DebugCode()).ToList();
		}
	}
}
