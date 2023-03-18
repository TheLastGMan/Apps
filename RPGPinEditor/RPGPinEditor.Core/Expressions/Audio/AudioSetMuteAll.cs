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
	public class AudioSetMuteAll : BaseKeywordExpression
	{
		AudioSetMuteAll() : this(new Constant(0))
		{ }

		AudioSetMuteAll(IExpression muteSelection)
		{
			MuteSelection = muteSelection;
		}

		public IExpression MuteSelection { get; set; }

		public override CommandCode Command
		{
			get
			{
				return CommandCode.AudioSetMuteAll;
			}
		}

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				MuteSelection,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
