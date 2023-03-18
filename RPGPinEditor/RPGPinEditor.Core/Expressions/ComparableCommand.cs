using RPGPinEditor.Core.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions
{
	public abstract class ComparableCommand : IExpression
	{
		public ComparableCommand()
		{ }

		public ComparableCommand(IExpression leftHand, IExpression rightHand)
		{
			LeftHand = leftHand;
			RightHand = rightHand;
		}

		public abstract List<DebugStatement> DebugCode();

		public IExpression LeftHand { get; set; }
		public IExpression RightHand { get; set; }

		public string PrettyPrint
		{
			get
			{
				return DebugCode().PrettyView();
			}
		}
	}
}
