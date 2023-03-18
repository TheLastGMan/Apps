using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core
{
	public class DebugStatement
	{
		public DebugStatement()
		{ }

		public DebugStatement(int value, string description, bool isComment = false, bool showInPrettyPrint = true)
		{
			Value = value;
			Description = description;
			IsComment = isComment;
			ShowInPrettyPrint = showInPrettyPrint;
		}

		public bool ShowInPrettyPrint { get; set; }
		public bool IsComment { get; set; }
		public int Value { get; set; }
		public string Description { get; set; }
	}
}
