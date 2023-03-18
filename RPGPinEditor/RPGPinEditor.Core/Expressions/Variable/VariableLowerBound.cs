using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Variable
{
	class VariableLowerBound : IExpression, IKeyword
	{
		public CommandCode Command
		{
			get
			{
				return CommandCode.VariableLowerBound;
			}
		}

		public string PrettyPrint
		{
			get
			{
				return DebugCode().PrettyView();
			}
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, "@Variable[].LowerBound()")
			}.DebugCode();
		}
	}
}
