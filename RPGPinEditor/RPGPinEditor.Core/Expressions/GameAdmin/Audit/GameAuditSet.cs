using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.GameAdmin.Audit
{
	public class GameAuditSet : IExpression, IKeyword
	{
		public GameAuditSet(IExpression index, IExpression value)
		{
			Index = index;
			Value = value;
		}

		public virtual CommandCode Command
		{
			get
			{
				return CommandCode.GameAuditSet;
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

		public IExpression Value { get; set; }

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString().Replace("Set", "")}["),
				Index,
				new COMMENT("] = "),
				Value
			}.DebugCode();
		}
	}
}
