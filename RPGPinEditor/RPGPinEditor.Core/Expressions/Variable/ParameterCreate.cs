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
	public class ParameterCreate : IExpression, IKeyword
	{
		public ParameterCreate() : this(new Constant(0))
		{ }

		public ParameterCreate(IExpression initialValue)
		{
			InitialValue = initialValue;
		}

		public IExpression InitialValue { get; set; }

		public CommandCode Command
		{
			get
			{
				return CommandCode.NextParameterCreate;
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
				new CMD(Command, "@Parameter[].Create("),
				InitialValue,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
