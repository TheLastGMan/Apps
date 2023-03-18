using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements.Helpers
{
	public class RAW : IStatement
	{
		public RAW(string description = "Raw Value")
		{
			Description = description;
		}

		public RAW(int value, string description)
		{
			RawValue = value;
			Description = description;
		}

		public RAW(int value) : this()
		{
			RawValue = value;
		}

		public List<DebugStatement> DebugCode()
		{
			if (RawValue.HasValue)
				return new List<DebugStatement>() { new DebugStatement(RawValue.Value, Description) };
			else
				return new List<DebugStatement>();
		}

		public string Description { get; set; }

		public int? RawValue { get; set; }
	}
}
