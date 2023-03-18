using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Time
{
	public class TimeNowSet : BaseTime
	{
		public TimeNowSet() : base(new Constant(0))
		{ }

		public TimeNowSet(IExpression epoch) : base(epoch)
		{ }

		public override CommandCode Command
		{
			get { return CommandCode.TimeNowSet; }
		}
	}
}
