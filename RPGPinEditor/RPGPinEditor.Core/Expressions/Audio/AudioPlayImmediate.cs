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
	public class AudioPlayImmediate : BaseKeywordExpression
	{
		public AudioPlayImmediate() : this(new Constant(0), new Constant(100))
		{ }

		public AudioPlayImmediate(IExpression audioId, IExpression volume)
		{
			AudioId = audioId;
			Volume = volume;
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.AudioPlayImmediate;
			}
		}

		IExpression AudioId { get; set; }

		IExpression Volume { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, $"{Command.ToString()}("),
				AudioId,
				new COMMENT(", "),
				Volume,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}