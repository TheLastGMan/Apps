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
	public class VariableGet : IExpression, IKeyword
	{
		public VariableGet()
		{ }

		public VariableGet(IExpression index)
		{
			Index = index;
		}

		public CommandCode Command
		{
			get
			{
				return CommandCode.VariableGet;
			}
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, "@Variable["),
				Index,
				new COMMENT("]")
			}.DebugCode();
		}

		public IExpression Index { get; set; }

		public string PrettyPrint
		{
			get
			{
				return DebugCode().PrettyView();
			}
		}
	}
}
