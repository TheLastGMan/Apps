using RPGPinEditor.Core.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements.Helpers
{
	public class JUMPBLOCK : StatementBlock, IStatement
	{
		public enum Direction : sbyte
		{
			Forward = 1,
			Backward = -1
		}

		public JUMPBLOCK(StatementBlock block) : this(block, Direction.Forward)
		{ }

		public JUMPBLOCK(StatementBlock block, Direction direction) : base(block)
		{
			JumpDirection = direction;
		}

		Direction JumpDirection { get; set; }

		public override List<DebugStatement> DebugCode()
		{
			var result = base.DebugCode();
			_BlockSize = result.Count(f => !f.IsComment) * (sbyte)JumpDirection;

			if (JumpDirection == Direction.Forward)
				result.InsertRange(0, new Jump(_BlockSize).DebugCode());
			else if (JumpDirection == Direction.Backward)
				//working backwards we need to subtract size of a jump statement as we read past it before jumping
				result.AddRange(new Jump(_BlockSize * (sbyte)Direction.Backward - new Jump(0).DebugCode().Count).DebugCode());

			return result;
		}

		private int _BlockSize;

		public int JumpCommandSize
		{
			get { return new Jump(base.DebugCode().Count(f => !f.IsComment)).DebugCode().Count; }
		}
	}
}
