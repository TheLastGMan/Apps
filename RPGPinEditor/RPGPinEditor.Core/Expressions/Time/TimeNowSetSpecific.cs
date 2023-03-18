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
	public class TimeNowSetSpecific : IExpression, IKeyword
	{
		public TimeNowSetSpecific() : this(new Constant(2000), new Constant(1), new Constant(1), new Constant(0), new Constant(0), new Constant(0))
		{ }

		public TimeNowSetSpecific(IExpression year, IExpression month, IExpression day, IExpression hours, IExpression minutes, IExpression seconds)
		{

		}

		public IExpression Year { get; set; }
		public IExpression Month { get; set; }
		public IExpression Day { get; set; }
		public IExpression Hours { get; set; }
		public IExpression Minutes { get; set; }
		public IExpression Seconds { get; set; }

		public string PrettyPrint
		{
			get { return DebugCode().PrettyView(); }
		}

		public CommandCode Command
		{
			get { return CommandCode.TimeNowSetSpecific; }
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				Year,
				new COMMENT(", "),
				Month,
				new COMMENT(", "),
				Day,
				new COMMENT(", "),
				Hours,
				new COMMENT(", "),
				Minutes,
				new COMMENT(", "),
				Seconds,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
