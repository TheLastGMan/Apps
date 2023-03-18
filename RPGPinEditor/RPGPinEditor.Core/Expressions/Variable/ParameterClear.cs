using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Variable
{
	public class ParameterClear : IKeyword
	{
		public ParameterClear()
		{ }

		public CommandCode Command
		{
			get
			{
				return CommandCode.NextParameterClear;
			}
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, "@Parameter[].Clear();"),
			}.DebugCode();
		}
	}
}
