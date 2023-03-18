using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.BasicMath
{
	public class Mul : ComparableKeywordCommand
	{
		public Mul()
		{ }

		public Mul(IExpression leftHand, IExpression rightHand) : base(leftHand, rightHand)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.Multiply;
			}
		}

		public override string ComparatorKey
		{
			get
			{
				return "*";
			}
		}
	}
}
