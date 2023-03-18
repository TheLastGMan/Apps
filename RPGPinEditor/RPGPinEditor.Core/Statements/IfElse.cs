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
	public class IfElse : If, IKeyword
	{
		public IfElse()
		{ }

		public IfElse(IExpression conditional, StatementBlock ifBlock, StatementBlock elseBlock) : base(conditional, ifBlock)
		{
			ElseBlock.AddRange(elseBlock);
		}

		public CommandCode Command
		{
			get { return CommandCode.IfElse; }
		}

		public override List<DebugStatement> DebugCode()
		{
			//Format
			//Command Code
			//Conditional
			//>IfBlockLength
			//>IfBlock
			//>Jump over ElseBlock
			//>>ElseBlock

			//load common used data
			var elseCode = ElseBlock.DebugCode();

			//calculate else block and add to end of if block
			var ifCode = new StatementBlock(IfBlock);
			ifCode.Insert(0, new COMMENT("{"));
			ifCode.Add(new Jump(elseCode.Count(f => !f.IsComment))); //jump doesn't generate if elseCode is empty
			ifCode.Add(new COMMENT("}"));

			//setup
			var result = new StatementBlock();

			//if statement conditional
			result.Add(new COMMENT($"if ({Conditional.PrettyPrint})"));
			result.Add(new CMD(Command, "if ("));
			result.Add(Conditional);
			result.Add(new COMMENT(")"));

			//if block
			result.Add(new BLOCKSIZE(ifCode));
			var code = result.DebugCode();

			//add in else statement if we have one
			if (elseCode.Count > 0)
			{
				code.AddRange(new COMMENT("else {").DebugCode());
				code.AddRange(elseCode);
				code.AddRange(new COMMENT("}").DebugCode());
			}

			//give result
			return code;
		}

		public StatementBlock ElseBlock { get; } = new StatementBlock();
	}
}
