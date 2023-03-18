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
	public class AudioSetVolume : AudioBaseChannel
	{
		public AudioSetVolume() : this(new Constant(0), new Constant(100))
		{ }

		public AudioSetVolume(IExpression channel, IExpression volume) : base(channel)
		{
			Volume = volume;
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.AudioSetVolume;
			}
		}

		public IExpression Volume { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				Channel,
				new COMMENT(", "),
				Volume,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
