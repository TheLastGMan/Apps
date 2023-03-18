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
	public class GameSettingGet : GameAuditGet
	{
		public GameSettingGet(IExpression index) : base(index)
		{
		}

		public override CommandCode Command
		{
			get
			{
				return CommandCode.GameSettingGet;
			}
		}
	}
}
