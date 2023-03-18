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
	public class VariableSet : IExpression, IKeyword
	{
		public VariableSet() : this(new Constant(0), new Constant(0))
		{ }

		public VariableSet(IExpression index, IExpression value)
		{
			Index = index;
			Value = value;
		}

		public IExpression Index { get; set; }

		public IExpression Value { get; set; }

		public CommandCode Command
		{
			get
			{
				return CommandCode.VariableSet;
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
				new CMD(Command, "@Variable["),
				Index,
				new COMMENT("] = "),
				Value
			}.DebugCode();
		}
	}
}
