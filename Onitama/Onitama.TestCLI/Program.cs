using Onitama.Core;
using Onitama.Core.GameXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.TestCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sr = new StreamReader("cards.xml");
            //var cards = XMLGenerator.Deserialize<CardXml>(sr.BaseStream).Cards.Select((f, idx) => f.GenerateCard((byte)idx)).ToArray();
            var cards = generateCards().Select((f, idx) => f.GenerateCard((byte)idx)).ToArray();
            //sr.Close();

            //pick starting cards
            Card[] gameCards = new Card[5];
            /*int cardLen = cards.Length;
            var rnd = new Random();
            for (int i = 0; i < gameCards.Length; i++)
            {
                //grab card and assign it to next slot
                int index = rnd.Next(cardLen);
                Card card = cards[index];
                gameCards[i] = card;

                //swap with last and decrease allowed length of search
                cardLen -= 1;
                cards[index] = cards[cardLen];
                cards[cardLen] = card;
            }*/

            //setup initial position
            gameCards = new Card[] { cards[0], cards[1], cards[2], cards[3], cards[4]};
            var position = new Position();
            //position.AddPiece(Square.A1, Color.Red, PieceType.Pawn);
            //position.AddPiece(Square.B1, Color.Red, PieceType.Pawn);
            position.AddPiece(Square.C1, Color.Red, PieceType.Master);
            //position.AddPiece(Square.D1, Color.Red, PieceType.Pawn);
            position.AddPiece(Square.E1, Color.Red, PieceType.Pawn);
            //position.AddPiece(Square.A5, Color.Blue, PieceType.Pawn);
            //position.AddPiece(Square.B5, Color.Blue, PieceType.Pawn);
            position.AddPiece(Square.C5, Color.Blue, PieceType.Master);
            //position.AddPiece(Square.D5, Color.Blue, PieceType.Pawn);
            position.AddPiece(Square.E5, Color.Blue, PieceType.Pawn);
            //var moves = MoveGenerator.GenerateMoves(position, Color.Red, gameCards.Take(2).ToArray());

            //show what cards we are working with
            showCards(gameCards);

            //search
            var bestMoveState = Search.DepthSearch(position, gameCards[4].PieceColor, gameCards, 24, (bm) => showMoves(bm));
            var bestMove = bestMoveState;
            showMoves(bestMove);
        }

        private static void showMoves(StateInfo bestMove)
        {
            do
            {
                string vDisp = bestMove.Value.ToString();
                if(Math.Abs(bestMove.Value) >= 30000)
                {
                    short value = (short)(Math.Abs(bestMove.Value) - 30000);
                    if (vDisp[0] == '-')
                        vDisp = "-";
                    else
                        vDisp = "";

                    vDisp += "M" + (countStates(bestMove) / 2).ToString();
                }
                Console.Write(vDisp.PadLeft(5, ' ') + " | ");
                Console.Write(bestMove.MoveInfo.Move.Card.Title.Substring(0, Math.Min(4, bestMove.MoveInfo.Move.Card.Title.Length)).PadLeft(4, ' ') + " | ");
                Console.Write(bestMove.MoveInfo.Move.PieceColor.ToString()[0]);
                Console.Write(bestMove.MoveInfo.Move.PieceType.ToString()[0]);
                Console.Write(bestMove.MoveInfo.Move.From.ToString().ToLower());
                if (bestMove.MoveInfo.Move.CapturedPiece != Piece.None)
                {
                    Console.Write("x");
                    Console.Write(Position.GetPieceType(bestMove.MoveInfo.Move.CapturedPiece).ToString()[0]);
                }
                else
                    Console.Write("- ");
                Console.Write(bestMove.MoveInfo.Move.To.ToString().ToLower() + " | ");
                showCards(CardCache.GetCards(bestMove.MoveInfo.CardCacheIndex));
            } while ((bestMove = bestMove.Previous).MoveInfo.Move.From != Square.None);
            Console.WriteLine(@"------------------------------------------------------------");
        }

        private static int countStates(StateInfo state)
        {
            int count = 0;
            do
            {
                count += 1;
            } while ((state = state.Previous) != null);
            return count;
        }

        private static void showCards(Card[] cards)
        {
            Console.Write(String.Join(", ", cards.Take(2).Select(f => f.Title.Substring(0, Math.Min(4, f.Title.Length)).PadLeft(4, ' ')).ToArray()) + " | ");
            Console.Write(String.Join(", ", cards.Skip(2).Take(2).Select(f => f.Title.Substring(0, Math.Min(4, f.Title.Length)).PadLeft(4, ' ')).ToArray()) + " | ");
            Console.WriteLine(cards.Last().Title.Substring(0, Math.Min(4, cards.Last().Title.Length)).PadLeft(4, ' '));
        }

        private static IList<GameCard> generateCards(bool save = false)
        {
            //generate game cards
            var cards = new List<GameCard>(32);
            cards.Add(new GameCard() { Title = "TIGER", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Blue, Moves = "0000000100001000000000100" });
            cards.Add(new GameCard() { Title = "CRAB", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Blue, Moves = "0000000000101010010000000" });
            cards.Add(new GameCard() { Title = "MONKEY", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Blue, Moves = "0000001010001000101000000" });
            cards.Add(new GameCard() { Title = "CRANE", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Blue, Moves = "0000001010001000010000000" });
            cards.Add(new GameCard() { Title = "DRAGON", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Red, Moves = "0000001010001001000100000" });
            cards.Add(new GameCard() { Title = "ELEPHANT", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Red, Moves = "0000000000011100101000000" });
            cards.Add(new GameCard() { Title = "MANTIS", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Red, Moves = "0000000100001000101000000" });
            cards.Add(new GameCard() { Title = "BOAR", Description = "", LogoFilePath = "", CardColor = CardColor.Green, PieceColor = Color.Red, Moves = "0000000000011100010000000" });
            cards.Add(new GameCard() { Title = "FROG", Description = "", LogoFilePath = "", CardColor = CardColor.Blue, PieceColor = Color.Red, Moves = "0000000010101000100000000" });
            cards.Add(new GameCard() { Title = "GOOSE", Description = "", LogoFilePath = "", CardColor = CardColor.Blue, PieceColor = Color.Blue, Moves = "0000000010011100100000000" });
            cards.Add(new GameCard() { Title = "HORSE", Description = "", LogoFilePath = "", CardColor = CardColor.Blue, PieceColor = Color.Red, Moves = "0000000100011000010000000" });
            cards.Add(new GameCard() { Title = "EEL", Description = "", LogoFilePath = "", CardColor = CardColor.Blue, PieceColor = Color.Blue, Moves = "0000001000001100100000000" });
            cards.Add(new GameCard() { Title = "RABBIT", Description = "", LogoFilePath = "", CardColor = CardColor.Red, PieceColor = Color.Blue, Moves = "0000001000001010001000000" });
            cards.Add(new GameCard() { Title = "ROOSTER", Description = "", LogoFilePath = "", CardColor = CardColor.Red, PieceColor = Color.Red, Moves = "0000001000011100001000000" });
            cards.Add(new GameCard() { Title = "OX", Description = "", LogoFilePath = "", CardColor = CardColor.Red, PieceColor = Color.Blue, Moves = "0000000100001100010000000" });
            cards.Add(new GameCard() { Title = "COBRA", Description = "", LogoFilePath = "", CardColor = CardColor.Red, PieceColor = Color.Red, Moves = "0000000010011000001000000" });

            if (save)
            {
                var xml = new CardXml() { Cards = cards.ToArray() };
                var content = XMLGenerator.Serialize(xml);
                using (var sw = new StreamWriter("cards.xml"))
                    sw.Write(content);
            }

            return cards;
        }
    }
}
