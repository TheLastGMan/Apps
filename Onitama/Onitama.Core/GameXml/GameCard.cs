using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Onitama.Core.GameXml
{
    public class GameCard
    {
        [XmlAttribute]
        public string Title;
        public string Description;
        public string LogoFilePath;
        public CardColor CardColor;
        public Color PieceColor;
        public string Moves; //allows special formatting of 1's and 0's to be parsed

        public Card GenerateCard(byte id)
        {
            //basic info
            var card = new Card(id, Title, Description, LogoFilePath, CardColor, PieceColor, 0);

            //validate
            if (String.IsNullOrEmpty(Moves) || Moves.Length != 25)
                throw new Exception("Invalid Moves: must have a length of 25");

            //generate squares
            BitBoard squares = 0;
            for (int i = 0; i < Moves.Length; i++)
                if (Moves[i] != '0')
                    squares += (int)Math.Pow(2, i);
            card.Moves = squares;

            return card;
        }
    }
}
