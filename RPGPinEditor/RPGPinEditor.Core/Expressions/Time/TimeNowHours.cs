using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Time
{
	public class TimeNowHours : BaseKeywordExpression
	{
		public override CommandCode Command
		{
			get { return CommandCode.TimeNowHours; }
		}
	}
}
