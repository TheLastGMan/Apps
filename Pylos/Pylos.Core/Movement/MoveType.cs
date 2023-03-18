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
	public struct MoveType
	{
		public MoveAction Action;
		public Positions Position;
	}
}
