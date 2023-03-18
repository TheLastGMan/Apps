using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions
{
	public abstract class BaseKeywordExpression : IExpression, IKeyword
	{
		public abstract CommandCode Command { get; }

		public string PrettyPrint
		{
			get { return DebugCode().PrettyView(); }
		}

		public virtual List<DebugStatement> DebugCode()
		{
			return new CMD(Command, $"{Command.ToString()}()").DebugCode();
		}
	}
}
