using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements.Helpers
{
	public class COMMENT : IStatement
	{
		public COMMENT(string description, bool showPrettyPrint = true)
		{
			Description = description;
			ShowPrettyPrint = showPrettyPrint;
		}

		public virtual List<DebugStatement> DebugCode()
		{
			return new List<DebugStatement>()
			{
				new DebugStatement(0, Description, true, ShowPrettyPrint)
			};
		}

		public string Description { get; set; }

		public bool ShowPrettyPrint { get; set; }
	}
}
