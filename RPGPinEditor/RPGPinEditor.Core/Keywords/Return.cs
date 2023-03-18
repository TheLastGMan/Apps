using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Expressions;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Keywords
{
	public class Return : IKeyword
	{
		public Return() : this(new Constant(0))
		{ }

		public Return(IExpression value)
		{
			Value = value;
		}

		public CommandCode Command
		{
			get
			{
				return CommandCode.Return;
			}
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, "return ("),
				Value,
				new COMMENT(");")
			}.DebugCode();
		}

		public IExpression Value { get; set; }
	}
}
