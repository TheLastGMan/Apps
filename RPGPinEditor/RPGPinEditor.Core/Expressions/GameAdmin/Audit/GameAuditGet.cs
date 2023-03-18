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
	public class GameAuditGet : IExpression, IKeyword
	{
		public GameAuditGet(IExpression index)
		{
			Index = index;
		}

		public IExpression Index { get; set; }

		public virtual CommandCode Command
		{
			get
			{
				return CommandCode.GameAuditGet;
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
				new CMD(Command, $"{Command.ToString().Replace("Get", "")}["),
				Index,
				new COMMENT("]")
			}.DebugCode();
		}
	}
}
