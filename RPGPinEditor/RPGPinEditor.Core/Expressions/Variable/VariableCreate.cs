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
	public class VariableCreate : IExpression, IKeyword
	{
		public VariableCreate() : this(new Constant(0))
		{ }

		public VariableCreate(IExpression initialValue)
		{
			InitialValue = initialValue;
		}

		public VariableCreate(IExpression initialValue, string name) : this(initialValue)
		{
			Name = name;
		}

		public IExpression InitialValue { get; set; }

		public string Name { get; set; } = String.Empty;

		public CommandCode Command
		{
			get
			{
				return CommandCode.VariableCreate;
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
				new CMD(Command, $"@Variable[{Name}].Create("),
				InitialValue,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
