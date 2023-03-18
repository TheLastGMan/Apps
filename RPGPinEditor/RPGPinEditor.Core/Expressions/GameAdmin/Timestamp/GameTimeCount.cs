using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.GameAdmin.Timestamp
{
	public class GameTimeCount : BaseKeywordExpression
	{
		public override CommandCode Command
		{
			get
			{
				return CommandCode.GameTimeStampCount;
			}
		}
	}
}
