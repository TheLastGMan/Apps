using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.BasicMath
{
	public class Add : ComparableKeywordCommand
	{
		public Add()
		{ }

		public Add(IExpression leftHand, IExpression rightHand) : base(leftHand, rightHand)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.Addition;
			}
		}

		public override string ComparatorKey
		{
			get
			{
				return "+";
			}
		}
	}
}
