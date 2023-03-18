using Pylos.Core.Board;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Movement
{
	public struct MovePositionPretty
	{
		public PieceType Piece;
		public byte Column;
		public byte Row;
		public byte Level;
	}
}
