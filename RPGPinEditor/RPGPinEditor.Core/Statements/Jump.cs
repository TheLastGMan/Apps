using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements
{
	public class Jump : IKeyword
	{
		public Jump()
		{
		}

		public Jump(int offset)
		{
			Offset = offset;
		}

		public CommandCode Command
		{
			get { return CommandCode.Jump; }
		}

		public List<DebugStatement> DebugCode()
		{
			var result = new StatementBlock();
			if(Offset != 0)
			{
				//only generate output if there is a non zero offset
				result.Add(new CMD(Command, ""));
				result.Add(new RAW(Offset, $"Jump {Offset + 1}; // lines to jump"));
			}
			return result.DebugCode();
		}

		public int Offset { get; set; }
	}
}
