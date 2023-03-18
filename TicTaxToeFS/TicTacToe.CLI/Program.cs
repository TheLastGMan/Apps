using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core;
using TicTacToe.Data.BoardInfo;
using TicTacToe.Logic;
using TicTacToe.Logic.BoardInfo;

namespace TicTacToe.CLI
{
	class Program
	{
		private static void drawBoard(Board2D bi)
		{
			Console.WriteLine("");
			Console.WriteLine($"{bi.UL} | {bi.UC} | {bi.UR}");
			Console.WriteLine("---------");
			Console.WriteLine($"{bi.ML} | {bi.MC} | {bi.MR}");
			Console.WriteLine("---------");
			Console.WriteLine($"{bi.LL} | {bi.LC} | {bi.LR}");
			Console.WriteLine("");
		}

		private static BoardPositions mapInput(int cell)
		{
			int mask = (int)BoardPositions.UPR_L;
			int pos = mask >>= (cell - 1);
			return (BoardPositions)pos;
		}

		static void Main(string[] args)
		{
			while (true)
			{
				BoardLayout _BoardLayout = new BoardLayout();
				Board2D _BoardImage = new Board2D();

				//show board
				drawBoard(_BoardImage);

				while (true)
				{
					Console.WriteLine("");
					Console.Write("Enter cell number: ");

					//get user input
					int cell = -1;
					while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out cell)) { }

					//update
					var bp = mapInput(cell);
					string cellName = bp.ToString();
					_BoardLayout = new BoardService().MakeMove(_BoardLayout, new MoveInfo(bp, PieceType.X));
					_BoardImage.GetType().GetProperties().First(f => f.Name.Equals(cellName[0].ToString() + cellName.Last().ToString())).SetValue(_BoardImage, PieceType.X.ToString());

					if (new BoardService().IsWin(_BoardLayout, PieceType.X))
					{
						Console.WriteLine("");
						Console.WriteLine("=== YOU WIN ===");
						break;
					}

					//make AI move and update
					var aiMove = new AI().MakeMove(_BoardLayout, PieceType.O, 9);
					cellName = aiMove.Move.Position.ToString();
					_BoardLayout = new BoardService().MakeMove(_BoardLayout, new MoveInfo(aiMove.Move.Position, PieceType.O));

					if (aiMove.Move.Position == BoardPositions.NONE)
					{
						Console.WriteLine("");
						Console.WriteLine("=== DRAW ===");
						break;
					}

					_BoardImage.GetType().GetProperties().First(f => f.Name.Equals(cellName[0].ToString() + cellName.Last().ToString())).SetValue(_BoardImage, "*");

					//update display
					drawBoard(_BoardImage);

					if (aiMove.Eval == 100)
					{
						Console.WriteLine("");
						Console.WriteLine("=== AI WINS ===");
						break;
					}
				}

				Debugger.Break();
			}
		}
	}
}
