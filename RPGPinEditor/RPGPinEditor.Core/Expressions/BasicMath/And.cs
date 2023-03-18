using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.BasicMath
{
	public class And : ComparableKeywordCommand
	{
		public And()
		{ }

		public And(IExpression leftHand, IExpression rightHand) : base(leftHand, rightHand)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.And;
			}
		}

		public override string ComparatorKey
		{
			get
			{
				return "&";
			}
		}
	}
}
