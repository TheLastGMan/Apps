using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class Card
    {
        public byte Id;
        public string Title;
        public string Description;
        public string LogoFilePath;
        public CardColor CardColor;
        public Color PieceColor;
        public BitBoard Moves;

        public Card(byte id, string title, string description, string logoFilePath, CardColor cColor, Color pColor, BitBoard moves)
        {
            Id = id;
            Title = title;
            Description = description;
            LogoFilePath = logoFilePath;
            CardColor = cColor;
            PieceColor = pColor;
            Moves = moves;
        }
    }
}
