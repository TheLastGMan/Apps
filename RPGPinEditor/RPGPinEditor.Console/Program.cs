using RPGPinEditor.Core;
using RPGPinEditor.Core.Commands;
using RPGPinEditor.Core.Expressions;
using RPGPinEditor.Core.Expressions.Assignment;
using RPGPinEditor.Core.Expressions.BasicMath;
using RPGPinEditor.Core.Expressions.Comparator;
using RPGPinEditor.Core.Expressions.GameAdmin;
using RPGPinEditor.Core.Expressions.GameAdmin.Setting;
using RPGPinEditor.Core.Expressions.Variable;
using RPGPinEditor.Core.Keywords;
using RPGPinEditor.Core.Statements;
using RPGPinEditor.Core.Statements.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var dtStart = new DateTime(2000, 1, 1, 0, 0, 0);
			var dtEndSec2Int = dtStart.AddSeconds(((long)int.MaxValue) * 2); //this will do


			//generate code
			var block = generateStatements();

			//update list, add comments for each expression
			int c = 0;
			while (c < block.Count)
			{
				if (block[c] as IExpression != null)
				{
					block.Insert(c, new COMMENT(((IExpression)block[c]).PrettyPrint));
					c += 1;
				}

				c += 1;
			}

			var result = block.DebugCode();
			int[] output = result.Where(f => !f.IsComment).Select(f => f.Value).ToArray();

			//write binary file
			using (var wrbin = new System.IO.BinaryWriter(new System.IO.StreamWriter("c:/users/rgau1/desktop/out.bin", false).BaseStream))
				foreach (int i in output)
					wrbin.Write(i);

			//write cs version
			using (var wr = new System.IO.StreamWriter("c:/users/rgau1/desktop/out.c"))
			{
				wr.Write("byte dataStream[] = {");
				wr.Write(String.Join(",", output.SelectMany(f => BitConverter.GetBytes(f))));
				wr.WriteLine("};");
				wr.Write("int dataLength = " + (output.Length * 4) + ";");
			}

			//indentations
			var indentations = new List<KeyValuePair<string, string>>()
			{
				new KeyValuePair<string, string>("(", ")"),
				new KeyValuePair<string, string>("[", "]"),
				new KeyValuePair<string, string>("{", "}")
			};

			//show disassembly-ish view
			int lineNumber = 1;
			int offset = 0;

			using (var wrdis = new System.IO.StreamWriter("c:/users/rgau1/desktop/out.txt", false))
				foreach (DebugStatement ds in result)
				{
					//check to decrement offset
					foreach (var ind in indentations)
						if (!(ds.Description.Contains(ind.Key) && ds.Description.Contains(ind.Value)))
							if (ds.Description.Contains(ind.Value))
								offset -= 4;

					//log statement
					if (ds.IsComment)
					{
						string cline = $"{"".PadLeft(4, ' ')}  {"".PadRight(8, ' ')} // {"".PadLeft(Math.Max(offset, 0), ' ')}{ds.Description}";
						System.Console.WriteLine(cline);
						wrdis.WriteLine(cline);
					}
					else
					{
						string nline = $"{lineNumber.ToString().PadLeft(4, ' ')}: {ds.Value.ToString().PadRight(8, ' ')} // {"".PadLeft(offset, ' ')}{ds.Description}";
						System.Console.WriteLine(nline);
						wrdis.WriteLine(nline);
						lineNumber++;
					}

					//check to increment offset
					foreach (var ind in indentations)
						if (!(ds.Description.Contains(ind.Key) && ds.Description.Contains(ind.Value)))
							if (ds.Description.Contains(ind.Key))
								offset += 4;
				}

			System.Console.WriteLine("-----");
		}

		private static StatementBlock generateStatements()
		{
			StatementBlock block = new StatementBlock();

			//some variables
			block.Add(new VariableCreate(new Constant(6), "x"));
			block.Add(new VariableCreate(new Constant(14), "y"));

			var switchBlock = new Switch(new Add(new Constant(4000), new Constant(97)));
			switchBlock.Cases.Add(new Case(1023, new StatementBlock() { new VariableSet(new Constant(0, "x"), new Constant(1023)) }));
			switchBlock.Cases.Add(new Case(2047, new StatementBlock() { new VariableSet(new Constant(0, "x"), new Constant(2047)) }));
			switchBlock.Cases.Add(new Case(4097, new StatementBlock()
			{
				new VariableSet(new Constant(1, "y"), new Constant(4097)),
				new GotoCase(1023)
			}));
			switchBlock.DefaultCase.Add(new VariableSet(new Constant(0, "x"), new Constant(-1)));
			block.Add(switchBlock);

			/*var whileBlock = new While();
			whileBlock.ConditionalBlock.Add(new Constant(7));
			whileBlock.ConditionalBlock.Add(new Constant(15));
			whileBlock.ConditionalBlock.Add(new GreaterThanOrEqual(new Constant(999), new Constant(1024)));
			whileBlock.BodyBlock.Add(new Nop());
			whileBlock.BodyBlock.Add(new Constant(99999));
			whileBlock.BodyBlock.Add(new Nop());
			block.Add(whileBlock);*/

			/*var ifElseBlock = new IfElse();
			ifElseBlock.Conditional = new LessThanOrEqual(new Constant(5), new Constant(20));
			ifElseBlock.IfBlock.Add(new Nop());
			ifElseBlock.IfBlock.Add(new GotoCase(4));
			ifElseBlock.IfBlock.Add(new Nop());
			ifElseBlock.ElseBlock.Add(new Return(new Constant(1000)));
			block.Add(ifElseBlock);*/

			//FOR
			block.Add(new For(new StatementBlock() { new VariableSet(new Constant(0), new Constant(0)) }, new ExpressionBlock() { new LessThan(new VariableGet(new Constant(0)), new Constant(10)) }, new ExpressionBlock() { new AddAssignment(new Constant(0), new Constant(1)) }, new StatementBlock() { new Nop() }));

			//Spacing
			block.Add(new Nop());
			block.Add(new Nop());
			block.Add(new Nop());
			block.Add(new Nop());
			block.Add(new Nop());

			//Other
			block.Add(new VariableCreate(new Constant(6)));
			block.Add(new VariableCreate(new Constant(14)));
			block.Add(new IfElse(
				new GreaterThanOrEqual(new Add(new VariableGet(new Constant(0, "x")), new VariableGet(new Constant(1, "y"))), new Constant(15)),
				new StatementBlock()
				{
					new VariableSet(new Constant(0, "x"), new Constant(128))
				}, new StatementBlock()
				{
					new VariableSet(new Constant(1, "y"), new Constant(255))
				})
			);
			block.Add(new Nop());
			block.Add(new If(new AndAlso(new Constant(1), new AndAlso(new Constant(1), new AndAlso(new GreaterThan(new GameSettingGet(new Constant(0, "MultiBallDifficultyLevel")), new Add(new Constant(32), new Constant(64))), new Constant(1)))), new StatementBlock() { new VariableSet(new Constant(1, "y"), new Constant(511)) }));
			block.Add(new VariableSet(new Constant(1, "y"), new AndAlso(new Constant(1), new OrElse(new Constant(1), new AndAlso(new Constant(1), new Constant(1))))));
			block.Add(new Nop());
			block.Add(new VariableSet(new Constant(0, "x"), new Call("MyMethod", new Constant(1), new List<IExpression>() { new Constant(1024), new Mul(new Constant(1024), new Constant(2)) })));
			block.Add(new Return(new Constant(159)));

			return block;
		}
	}
}
