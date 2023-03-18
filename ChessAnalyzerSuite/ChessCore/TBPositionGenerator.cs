using ChessCore.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class TBPositionGenerator
    {
        public static ColoredPiece[] CodeToPieces(string code)
        {
            var pieces = new List<ColoredPiece>(32) { ColoredPiece.White_King };
            string whiteCode = code.ToUpper();
            bool isWhite = true;
            for(int i = 1; i < code.Length; i++)
            {
                //check if we should switch to black
                if (code[i] == 'k')
                    isWhite = false;

                //covert to colored piece
                char lookAt = isWhite ? whiteCode[i] : code[i];
                pieces[i] = Position.CharToPiece(lookAt);
            }
            return pieces.ToArray();
        }
    }
}
