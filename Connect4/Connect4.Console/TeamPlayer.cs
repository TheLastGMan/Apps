using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Connect4.Core;

namespace Connect4.Console
{
    class TeamPlayer : IPlayer
    {
        public string Name { get; private set; }
        private PieceType _Piece;

        public TeamPlayer(PieceType piece)
        {
            _Piece = piece;
        }

        public string Type
        {
            get { return "Human"; }
        }

        public void PreGame()
        {
            System.Console.Clear();
            System.Console.WriteLine("-- Enter Player Name (" + _Piece.ToString() + ") --");
            Name = System.Console.ReadLine();
        }

        public sbyte MakeMove(Board board)
        {
            while (true)
            {
                System.Console.WriteLine("-- Your move human (" + Name + ") -- ");
                System.Console.Write("Column: ");
                var key = System.Console.ReadKey();
                if (key.KeyChar >= '1' && key.KeyChar <= '7')
                {
                    byte col = (byte)(key.KeyChar - '1');
                    return (sbyte)col;
                }
                else
                {
                    Program.DrawBoard(board);
                    System.Console.WriteLine("-- Invalid Column --");
                }
            }
        }
    }
}
