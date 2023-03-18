using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements;
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
	public class Not : IExpression
	{
		public Not()
		{
		}

		public Not(IExpression toInverse)
		{
			InverseCommand = toInverse;
		}

		public CommandCode Command
		{
			get
			{
				return CommandCode.Not;
			}
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
				{
					new CMD(Command, "!("),
					InverseCommand,
					new COMMENT(")")
				}.DebugCode();
		}

		public string PrettyPrint
		{
			get { return DebugCode().PrettyView(); }
		}

		public IExpression InverseCommand { get; set; }
	}
}
