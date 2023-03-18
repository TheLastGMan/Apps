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
	public class Constant : IExpression, IKeyword
	{
		public Constant() { }

		public Constant(int value)
		{
			Value = value;
			Name = value.ToString();
		}

		public Constant(int value, string name)
		{
			Value = value;
			Name = name;
		}

		public int Value { get; set; }

		public string Name { get; set; } = String.Empty;

		public CommandCode Command
		{
			get { return CommandCode.Constant; }
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, ""),
				new RAW(Value, Name)
			}.DebugCode();
		}

		public string PrettyPrint
		{
			get { return Value.ToString(); }
		}
	}
}
