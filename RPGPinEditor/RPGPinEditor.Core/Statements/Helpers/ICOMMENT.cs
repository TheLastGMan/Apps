using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements.Helpers
{
	public class ICOMMENT : COMMENT
	{
		public ICOMMENT(int value, string description, bool showPrettyPrint = true) : base(description, showPrettyPrint)
		{
			Value = value;
		}

		public int Value { get; set; } = 0;

		public override List<DebugStatement> DebugCode()
		{
			return new List<DebugStatement>()
			{
				new DebugStatement(Value, Description, false, ShowPrettyPrint)
			};
		}
	}
}
