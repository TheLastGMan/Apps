using RPGPinEditor.Core.Commands;
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
	public class OrElse : ComparableKeywordCommand
	{
		public OrElse()
		{ }

		public OrElse(IExpression leftHand, IExpression rightHand) : base(leftHand, rightHand)
		{
		}

		public override string ComparatorKey
		{
			get
			{
				return "||";
			}
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.OrElse;
			}
		}

		public override List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new ICOMMENT((int)Command, "/* OrElse */", false),
				LeftHand,
				new COMMENT($" {ComparatorKey} "),
				new BLOCKSIZE(new StatementBlock() { RightHand }, "/* RValue code size [lines] */"),
			}.DebugCode();
		}
	}
}
