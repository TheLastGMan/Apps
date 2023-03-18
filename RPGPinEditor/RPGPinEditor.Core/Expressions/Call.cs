using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Expressions
{
	public class Call : IKeyword, IExpression
	{
		public Call() : this("Script", new Constant(0))
		{ }

		public Call(string method, IExpression scriptId) : this(method, scriptId, new List<IExpression>())
		{ }

		public Call(string method, IExpression scriptId, List<IExpression> parameters)
		{
			ScriptName = method;
			ScriptId = scriptId;
			Parameters = parameters;
		}

		public string ScriptName { get; set; }

		public IExpression ScriptId { get; set; }

		public List<IExpression> Parameters { get; set; }

		public CommandCode Command
		{
			get
			{
				return CommandCode.Call;
			}
		}

		public string PrettyPrint
		{
			get
			{
				return DebugCode().PrettyView();
			}
		}

		public List<DebugStatement> DebugCode()
		{
			var preBlock = new StatementBlock();
			preBlock.Add(new CMD(Command, $"{ScriptName}["));
			preBlock.Add(new COMMENT("/* Script Id */", false));
			preBlock.Add(ScriptId);
			preBlock.Add(new COMMENT("]"));
			//parameter count
			var postBlock = new StatementBlock();
			postBlock.Add(new COMMENT("("));
			if (Parameters.Count > 0)
			{
				postBlock.Add(new COMMENT("/* Parameters */", false));
				Parameters.ForEach(p => { postBlock.Add(p); postBlock.Add(new COMMENT(", ")); });
				postBlock.Remove(postBlock.Last());
			}
			postBlock.Add(new COMMENT(")"));

			var debug = preBlock.DebugCode();
			debug.Add(new DebugStatement(Parameters.Count, "/* Parameter Count */", false, false));
			debug.AddRange(postBlock.DebugCode());
			return debug;
		}
	}
}
