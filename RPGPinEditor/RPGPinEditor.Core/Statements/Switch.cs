using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Expressions;
using RPGPinEditor.Core.Expressions.Assignment;
using RPGPinEditor.Core.Expressions.Comparator;
using RPGPinEditor.Core.Expressions.Variable;
using RPGPinEditor.Core.Keywords;
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
	public class Switch : IKeyword
	{
		public Switch()
		{ }

		public Switch(IExpression value)
		{
			Value = value;
		}

		public Switch(IExpression value, IEnumerable<Case> cases, StatementBlock defaultCase) : this(value)
		{
			Cases.AddRange(cases);
			DefaultCase = defaultCase;
		}

		public CommandCode Command
		{
			get
			{
				return CommandCode.Switch;
			}
		}

		public List<DebugStatement> DebugCode()
		{
			//Format
			//Command Code
			//BreakOffset -> Length
			//[convert cases into if/else]
			var result = new StatementBlock();

			if (Cases.Any())
			{
				var caseTracker = createCaseBlock(Cases[0]);
				result.Add(new COMMENT($"case {Cases[0].Constant}:"));
				result.Add(caseTracker);

				for (int i = 1; i < Cases.Count; i++)
				{
					Case c = Cases[i];
					var nextCase = createCaseBlock(c);
					caseTracker.ElseBlock.Add(new COMMENT($"case {Cases[i].Constant}:"));
					caseTracker.ElseBlock.Add(nextCase);
					caseTracker = nextCase;
				}

				//add in default case
				if (DefaultCase != null)
				{
					caseTracker.ElseBlock.Add(new COMMENT("default:"));
					caseTracker.ElseBlock.AddRange(DefaultCase);
				}
			}

			//check for content to add in command and skip size
			var switchBlock = new StatementBlock();
			if(Value != null && result.Count > 0)
			{
				switchBlock.Add(new VariableCreate(Value));
				switchBlock.Add(new CMD(Command, $"switch({(new VariableGet(new VariableUpperBound())).PrettyPrint}) {{"));
				switchBlock.Add(new BLOCKSIZE(result));
				switchBlock.Add(new EndBlock());
				switchBlock.Add(new VariableDelete());
			}

			return switchBlock.DebugCode();
		}

		private IfElse createCaseBlock(Case checkCase)
		{
			var ifElse = new IfElse();
			ifElse.Conditional = new Equals(new VariableGet(new VariableUpperBound()), new Constant(checkCase.Constant));
			ifElse.IfBlock.AddRange(checkCase);
			return ifElse;
		}

		IExpression Value { get; set; }
		public List<Case> Cases { get; } = new List<Case>();
		public StatementBlock DefaultCase { get; set; } = new StatementBlock();
	}
}
