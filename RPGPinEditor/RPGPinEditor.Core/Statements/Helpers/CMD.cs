using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements.Helpers
{
	public class CMD : RAW
	{
		public CMD(CommandCode code)
		{
			RawValue = (int)code;
			Description = $"[{code.ToString()}]";
		}

		public CMD(CommandCode code, string description)
		{
			RawValue = (int)code;
			Description = description;
		}
	}
}
