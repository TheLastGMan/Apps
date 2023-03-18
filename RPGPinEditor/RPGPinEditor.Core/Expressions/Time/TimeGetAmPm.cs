using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Time
{
	public class TimeGetAmPm : BaseTime
	{
		public TimeGetAmPm() : this(new Constant(0))
		{ }

		public TimeGetAmPm(IExpression epoch) : base(epoch)
		{ }

		public override CommandCode Command
		{
			get
			{
				return CommandCode.TimeGetAmPm;
			}
		}
	}
}
