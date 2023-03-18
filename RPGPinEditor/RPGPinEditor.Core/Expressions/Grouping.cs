using RPGPinEditor.Core.Commands;
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
	public class Grouping : IKeyword, IExpression
	{
		public Grouping(ExpressionBlock block)
		{
			Group = block;
		}

		public ExpressionBlock Group { get; set; } = new ExpressionBlock();

		public CommandCode Command
		{
			get
			{
				return CommandCode.LogicalGrouping;
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
				new COMMENT(")"),
				Group,
				new COMMENT("(")
			}.DebugCode();
		}
	}
}
