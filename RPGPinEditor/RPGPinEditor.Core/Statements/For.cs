using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Keywords;
using RPGPinEditor.Core.Statements.Helpers;

namespace RPGPinEditor.Core.Statements
{
	public class For : While, IKeyword
	{
		public For()
		{ }

		public For(StatementBlock initBlock, ExpressionBlock conditionalBlock, ExpressionBlock loopBlock, StatementBlock bodyBlock)
			: base(conditionalBlock, bodyBlock)
		{
			InitBlock.AddRange(initBlock);
			LoopBlock.AddRange(loopBlock);
		}

		public CommandCode Command
		{
			get { return CommandCode.For; }
		}

		public override List<DebugStatement> DebugCode()
		{
			//Format:
			//InitBlock
			//Command Code
			//Break Offset -> Length
			//>Continue Offset -> Loop Block
			//>>JumpLoopBlock
			//>>>LoopBlock
			//>>ConditionalBlock
			//>>IF(ConditionalStatement) THEN
			//>>>BodyBlock
			//>>>Continue;
			//Break; (exits loop script processor)

			//blocks
			var result = new StatementBlock();
			result.Add(new COMMENT("For ([init-statements]=>"));
			result.Add(InitBlock);
			result.Add(new CMD(Command, ";"));

			//for block
			var forBlock = new StatementBlock();

			//continue offset, jump over loop block and loop block
			var jumpLoopBlock = new JUMPBLOCK(new StatementBlock(LoopBlock));
			forBlock.Add(new COMMENT($"[loop]=> {String.Join(", ", LoopBlock.Select(f => f.PrettyPrint))}"));
			forBlock.Add(new RAW(jumpLoopBlock.JumpCommandSize, "Loop Size [ints]"));
			forBlock.Add(jumpLoopBlock);

			//conditionals
			forBlock.Add(new COMMENT($"; [pre-conditionals]=> {String.Join(", ", PreConditionals.Select(f => f.PrettyPrint))}"));
			forBlock.Add(PreConditionals);

			//create success block for if statement, has continue as we are checking a pass
			var ifBlock = new StatementBlock();
			ifBlock.Add(BodyBlock);
			ifBlock.Add(new Continue());

			//add block to if statement
			forBlock.Add(new COMMENT($"; [conditional]=> {ConditionalStatement.PrettyPrint}"));
			forBlock.Add(new If(ConditionalStatement, ifBlock));

			//add in for block
			result.Add(new BLOCKSIZE(forBlock));
			result.Add(new EndBlock());

			//give output
			return result.DebugCode();
		}

		public StatementBlock InitBlock { get; } = new StatementBlock();
		public ExpressionBlock LoopBlock { get; } = new ExpressionBlock();
	}
}
