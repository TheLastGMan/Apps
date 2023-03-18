using RPGPinEditor.Core.Expressions.GameAdmin.Audit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.GameAdmin.Setting
{
	public class GameSettingSet : GameAuditSet
	{
		public GameSettingSet(IExpression index, IExpression value) : base(index, value)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.GameSettingSet;
			}
		}
	}
}
