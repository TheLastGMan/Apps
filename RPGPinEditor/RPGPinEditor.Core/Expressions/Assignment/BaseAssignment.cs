using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Expressions.Variable;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions.Assignment
{
	public abstract class BaseAssignment : IExpression, IKeyword
	{
		public BaseAssignment()
		{ }

		public BaseAssignment(IExpression index, IExpression value)
		{
			Index = index;
			Value = value;
		}

		public abstract CommandCode Command { get; }

		public abstract string AssignKey { get; }

		public IExpression Index { get; set; }

		public IExpression Value { get; set; }

		public string PrettyPrint
		{
			get
			{
				return DebugCode().PrettyView();
			}
		}

		public List<DebugStatement> DebugCode()
		{
			return new StatementBlock()
			{
				new CMD(Command, "@Variable["),
				Index,
				new COMMENT($"] {AssignKey} "),
				Value
			}.DebugCode();
		}
	}
}
