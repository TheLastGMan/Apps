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
	public class AudioSetMute : AudioBaseChannel
	{
		public AudioSetMute() : this(new Constant(0), new Constant(0))
		{ }

		public AudioSetMute(IExpression channel, IExpression muteSelection) : base(channel)
		{
			MuteSelection = muteSelection;
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.AudioSetMute;
			}
		}

		public IExpression MuteSelection { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				Channel,
				new COMMENT(", "),
				MuteSelection,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
