using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TicTacToe.Logic.BoardInfo;

namespace TicTacToe.GUI
{
	/// <summary>
	/// Interaction logic for Board.xaml
	/// </summary>
	public partial class Board : UserControl, INotifyPropertyChanged
	{
		public Board()
		{
			InitializeComponent();
		}

		private static BoardLayout _BoardLayout;
		private static IDictionary<string, string> _RowMap = new Dictionary<string, string>() { { "U", "UPR" }, { "M", "MID" }, { "L", "LOW" } };

		public event PropertyChangedEventHandler PropertyChanged;

		public void raiseChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#region Properties
		private string _UL = String.Empty;
		private string _UC = String.Empty;
		private string _UR = String.Empty;
		private string _ML = String.Empty;
		private string _MC = String.Empty;
		private string _MR = String.Empty;
		private string _LL = String.Empty;
		private string _LC = String.Empty;
		private string _LR = String.Empty;

		public string DUL
		{
			get { return _UL; }
			set { raiseChanged(nameof(DUL)); _UL = value; }
		}
		public string DUC
		{
			get { return _UC; }
			set { raiseChanged(nameof(DUC)); _UC = value; }
		}
		public string DUR
		{
			get { return _UR; }
			set { raiseChanged(nameof(DUR)); _UR = value; }
		}
		public string DML
		{
			get { return _ML; }
			set { raiseChanged(nameof(DML)); _ML = value; }
		}
		public string DMC
		{
			get { return _MC; }
			set { raiseChanged(nameof(DMC)); _MC = value; }
		}
		public string DMR
		{
			get { return _UR; }
			set { raiseChanged(nameof(DMR)); _MR = value; }
		}
		public string DLL
		{
			get { return _LL; }
			set { raiseChanged(nameof(DLL)); _LL = value; }
		}
		public string DLC
		{
			get { return _LC; }
			set { raiseChanged(nameof(DLC)); _LC = value; }
		}
		public string DLR
		{
			get { return _LR; }
			set { raiseChanged(nameof(DLR)); _LR = value; }
		}
		#endregion

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			if (btn.Content != null && !String.IsNullOrEmpty(btn.Content.ToString()))
				return;

			//load info
			string row = _RowMap[btn.Name[0].ToString()];
			string col = btn.Name[1].ToString();

			//set piece
			BoardPositions position = (BoardPositions)Enum.Parse(typeof(BoardPositions), $"{ row }_{ col }");
			_BoardLayout = new BoardService().MakeMove(_BoardLayout, new MoveInfo(position, PieceType.X));
			var prop = this.GetType().GetProperties().First(f => f.Name.Equals("D" + row[0].ToString() + col));
			Dispatcher.Invoke(() => prop.SetValue(this, PieceType.X.ToString()));

			//make AI move
			Stopwatch sw = Stopwatch.StartNew();
			var aiMove = new AI().MakeMove(_BoardLayout, PieceType.O, 15);
			_BoardLayout = new BoardService().MakeMove(_BoardLayout, aiMove.Move);
			sw.Stop();

			//update display with move
			string friendlyName = Enum.GetName(typeof(BoardPositions), aiMove.Move.Position);
			row = friendlyName[0].ToString();
			col = friendlyName.Last().ToString();
			this.GetType().GetProperties().First(f => f.Name.Equals("D" + row + col)).SetValue(this, aiMove.Move.Piece.ToString());
		}
	}
}
