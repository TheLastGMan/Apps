using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions
{
	public abstract class ComparableKeywordCommand : ComparableCommand, IKeyword
	{
		public ComparableKeywordCommand()
		{ }

		public ComparableKeywordCommand(IExpression leftHand, IExpression rightHand)
			: base(leftHand, rightHand)
		{ }

		public abstract CommandCode Command { get; }

		public abstract string ComparatorKey { get; }

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, "("),
				LeftHand,
				new COMMENT($" {ComparatorKey} "),
				RightHand,
				new COMMENT(")")
			}.DebugCode();
		}
	}
}
