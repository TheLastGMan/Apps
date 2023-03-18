using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Comparator
{
	public class LessThanOrEqual : ComparableKeywordCommand
	{
		public LessThanOrEqual()
		{ }

		public LessThanOrEqual(IExpression leftHand, IExpression rightHand) : base(leftHand, rightHand)
		{
		}

		public override string ComparatorKey
		{
			get
			{
				return "<=";
			}
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.LessThanEqual;
			}
		}
	}
}
