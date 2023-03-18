using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Expressions;
using RPGPinEditor.Core.Expressions.Comparator;
using RPGPinEditor.Core.Keywords;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core.Statements
{
	public class DoWhile : IStatement
	{
		public DoWhile()
		{ }

		public DoWhile(StatementBlock bodyBlock, ExpressionBlock conditionalBlock)
		{
			BodyBlock.AddRange(bodyBlock);
			ConditionalBlock.AddRange(conditionalBlock);
		}

		public virtual List<DebugStatement> DebugCode()
		{
			//while(1)
			//{
			//@Body
			//@Conditionals-1
			//@if(!@Conditional)
			//{break;}
			//}
			//continue;

			//outer while loop wrapper
			var whileLoop = new While();
			whileLoop.ConditionalBlock.Add(new Constant(1));
			whileLoop.BodyBlock.Add(PreConditionals);

			//ending conditional check (inversed to check for break)
			var ifBlock = new If(new Not(ConditionalStatement), new StatementBlock());
			ifBlock.IfBlock.Add(new Break());
			whileLoop.BodyBlock.Add(ifBlock);

			return whileLoop.DebugCode();
		}

		public StatementBlock BodyBlock { get; } = new StatementBlock();
		public ExpressionBlock ConditionalBlock { get; } = new ExpressionBlock();

		protected ExpressionBlock PreConditionals
		{
			get { return new ExpressionBlock(ConditionalBlock.Take(ConditionalBlock.Count - 1)); }
		}

		protected IExpression ConditionalStatement
		{
			get { return ConditionalBlock.Last(); }
		}
	}
}
