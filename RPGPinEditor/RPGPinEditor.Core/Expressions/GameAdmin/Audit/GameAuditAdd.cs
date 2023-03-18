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
	public class GameAuditAdd : IKeyword, IExpression
	{
		public GameAuditAdd(IExpression index, IExpression amount)
		{
			Index = index;
			Amount = amount;
		}

		public IExpression Index { get; set; }
		public IExpression Amount { get; set; }

		public virtual CommandCode Command
		{
			get
			{
				return CommandCode.GameAuditAdd;
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
				new CMD(Command, $"{Command.ToString().Replace("Add", "")}["),
				Index,
				new COMMENT("] += "),
				Amount
			}.DebugCode();
		}
	}
}
