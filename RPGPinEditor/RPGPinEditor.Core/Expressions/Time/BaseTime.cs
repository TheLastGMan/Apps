using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Time
{
	public abstract class BaseTime : IExpression, IKeyword
	{
		public BaseTime() : this(new Constant(0))
		{ }

		public BaseTime(IExpression epoch)
		{
			epoch = Epoch;
		}

		public abstract CommandCode Command { get; }

		public IExpression Epoch { get; set; }

		public string PrettyPrint
		{
			get { return DebugCode().PrettyView(); }
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				Epoch,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
