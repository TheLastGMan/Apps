using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe.Data.BoardInfo;
using TicTacToe.Logic;

namespace TicTacToe.GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			/*var bi = new BoardLayout((BoardPositions)BoardMasks.ROW, (BoardPositions)BoardMasks.ROW);
			var result = new BoardService().IsWin(bi, PieceType.X);

			BoardPositions basicSetup = BoardPositions.LOW_C | BoardPositions.LOW_R;
			var bin = new BoardLayout(basicSetup, basicSetup);
			var bestMove = new AI().MakeMove(bin, PieceType.X, 9);
			Debugger.Break();*/
		}
	}
}
