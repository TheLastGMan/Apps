using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Audio
{
	public abstract class AudioBaseChannel : BaseKeywordExpression
	{
		public AudioBaseChannel(IExpression channel)
		{
			Channel = channel;
		}

		public IExpression Channel { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				Channel,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
