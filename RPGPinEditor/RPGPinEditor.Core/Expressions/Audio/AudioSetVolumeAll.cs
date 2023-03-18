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
	public class AudioSetVolumeAll : BaseKeywordExpression
	{
		public AudioSetVolumeAll() : this(new Constant(100))
		{ }

		public AudioSetVolumeAll(IExpression volume)
		{
			Volume = volume;
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.AudioSetVolumeAll;
			}
		}

		public IExpression Volume { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				Volume,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
