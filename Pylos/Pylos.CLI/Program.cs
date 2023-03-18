using Pylos.Core.Board;
using Pylos.Core.Movement;
using Pylos.Core.Position;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length % 2 > 0)
            {
                //invalid key value pairs
                Console.WriteLine("Invalid input argument length. must be divisible by 2.");
            }

            new Program().AIInitTest();
            return;
        }

        public void AIInitTest()
        {
            var testAI = new AISolver(1024);
            var bi = new BoardInfo();
            bi.Balls.WhiteBalls = 15;
            bi.Balls.BlackBalls = 15;
            bool allowLines = false;
            var res = testAI.MakeMove(bi, PieceType.White, (bPos) => debugResult(bPos), (zPos) => exportResult(zPos), allowLines, true, 51);
            exportResult(res);
        }

        private void exportResult(PositionInfo res)
        {
            Console.WriteLine("===========================");
            Console.WriteLine("EV: " + res.LastEvaluation);
            for (int i = 0; i < res.MoveHistory.Count; i++)
            {
                var history = res.MoveHistory[i];
                Console.WriteLine("D: " + (i + 1) + " | P: " + history.Player.ToString() + " | EV: " + history.Evaluation + " | " + String.Join(" | ", history.ActionsApplied.Select(f => $"{f.Action.ToString()} - {f.Position.ToString()}")) + "| Balls: " + res.Board.Balls.WhiteBalls + "/" + res.Board.Balls.BlackBalls);
            }
        }

        Positions lastPosition = 0;
        byte lastD = 0;
        private void debugResult(PositionInfo bPos)
        {
            var lp = bPos.MoveHistory.First().ActionsApplied.First(f => f.Action == MoveAction.Place).Position;
            var ld = (byte)bPos.MoveHistory.Count;
            if (lp != lastPosition || (lp == lastPosition && lastD != ld))
            {
                lastPosition = lp;
                lastD = ld;
                Console.WriteLine("D: " + bPos.MoveHistory.Count + " / EV: " + bPos.LastEvaluation + " @ " + bPos.MoveHistory.First().ActionsApplied[0].Position.ToString() + " > "
                    + String.Join(" -> ", bPos.MoveHistory.Select(f => String.Join(", ", f.ActionsApplied.Select(g => $"{g.Action.ToString()} {g.Position.ToString()}")))) + "| Balls: " + bPos.Board.Balls.WhiteBalls + "/" + bPos.Board.Balls.BlackBalls);
            }
        }
    }
}
