using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Audio
{
	public class AudioPauseAll : BaseKeywordExpression
	{
		public override CommandCode Command
		{
			get
			{
				return CommandCode.AudioPauseAll;
			}
		}
	}
}
