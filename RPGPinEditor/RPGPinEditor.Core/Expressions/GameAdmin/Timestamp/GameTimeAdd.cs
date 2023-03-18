using RPGPinEditor.Core.Expressions.GameAdmin.Audit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.GameAdmin.Timestamp
{
	public class GameTimeAdd : GameAuditAdd
	{
		public GameTimeAdd(IExpression index, IExpression amount) : base(index, amount)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.GameTimeStampAdd;
			}
		}
	}
}
