using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.GameAdmin.Timestamp
{
	public class GameTimeSet : IExpression, IKeyword
	{
		public GameTimeSet(IExpression index)
		{
			Index = index;
		}

		public CommandCode Command
		{
			get
			{
				return CommandCode.GameTimeStampSet;
			}
		}

		public IExpression Index { get; set; }

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
				new CMD(Command, $"{Command.ToString().Replace("Set", "")}["),
				Index,
				new COMMENT("] = DateTime.Now")
			}.DebugCode();
		}
	}
}
