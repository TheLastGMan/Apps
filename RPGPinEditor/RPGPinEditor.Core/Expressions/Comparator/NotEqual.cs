using RPGPinEditor.Core.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Comparator
{
	public class NotEqual : ComparableKeywordCommand
	{
		public NotEqual()
		{ }

		public NotEqual(IExpression leftHand, IExpression rightHand) : base(leftHand, rightHand)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.NotEqual;
			}
		}

		public override string ComparatorKey
		{
			get
			{
				return "!=";
			}
		}
	}
}
