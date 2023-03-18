using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Connect4.Core;

namespace Connect4.Console
{
    class TeamAI : IPlayer
    {
        private int _Depth = 0;
        private PieceType _Piece;
        //private AI _AI = new AI();
        private AIV2 _AI = new AIV2();

        public TeamAI(PieceType piece)
        {
            _Piece = piece;
        }

        public string Type
        {
            get { return "AI"; }
        }

        public void PreGame()
        {
            while(_Depth == 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("--- Select AI Difficulty (" + _Piece.ToString() + ") ---");
                System.Console.WriteLine("0: Easy");
                System.Console.WriteLine("1: Medium");
                System.Console.WriteLine("2: Hard");
                System.Console.WriteLine("3: Expert");
                System.Console.WriteLine("4: Master");
                System.Console.WriteLine("5: Sensei");
                char diff = System.Console.ReadKey().KeyChar;
                if (diff < '0' || diff > '5')
                    continue;

                //set depth search
                switch (diff)
                {
                    case '0':
                        _Depth = 1;
                        break;
                    case '1':
                        _Depth = 3;
                        break;
                    case '2':
                        _Depth = 5;
                        break;
                    case '3':
                        _Depth = 7;
                        break;
                    case '4':
                        _Depth = 17;
                        break;
                    default:
                        _Depth = -1;
                        break;
                }
            }
        }

        public sbyte MakeMove(Board board)
        {
            //check
            if (!board.ColumnsAvailable)
                return -1;

            //make AI move
            AIMoveSummary move = _AI.MakeMove(board, _Piece, _Depth);
            return (sbyte)move.Move.Column;
        }
    }
}
