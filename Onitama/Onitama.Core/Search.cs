using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class Search
    {
        public static StateInfo DepthSearch(Position pos, Color player, Card[] gameCards, byte depth, Action<StateInfo> intermediateBestMove)
        {
            StateInfo bestMoveState = new StateInfo() { MoveInfo = new MoveExt(new Move() { From = Square.None }, gameCards), Value = -32000 };
            short alpha = short.MinValue + 10;
            short beta = short.MaxValue - 10;

            //depth search
            for (byte cDepth = 0; cDepth < depth; cDepth++)
            {
                var depthState = new StateInfo() { MoveInfo = new MoveExt(new Move() { From = Square.None }, gameCards), Value = -32000 };
                var bestState = doSearch(pos, player, gameCards, player, depthState, 0, cDepth, alpha, beta);

                intermediateBestMove(bestState);
                bestMoveState = bestState;
            }

            return bestMoveState;
        }

        private static StateInfo doSearch(Position pos, Color startingPlayer, Card[] cards, Color activePlayer, StateInfo lastState, byte depth, byte maxDepth, int alpha, int beta)
        {
            //evaluate position
            short eval = Evaluate.EvalulatePosition(pos, startingPlayer);
            lastState.Value = eval;

            //check for exit condition
            byte depthExt = 0;
            bool gameOver = Evaluate.GameOver(pos);
            if (gameOver)
            {
                eval *= (short)((nextPlayer(activePlayer) == startingPlayer) ? -1 : 1);
                eval += (short)(depth * (eval < 0 ? -1 : 1));
                lastState.Value = eval;
                return lastState;
            }
            else if (depth > maxDepth && lastState.MoveInfo.Move.CapturedPiece == Piece.None)
            {
                //exit if we reached our search depth, go one more on a capture
                lastState.Value *= (short)((nextPlayer(activePlayer) == startingPlayer) ? -1 : 1);
                return lastState;
            }

            //extend search by 2 ply
            if (lastState.MoveInfo.Move.CapturedPiece != Piece.None)
                depthExt = 3;

            //store best state
            StateInfo bestState = new StateInfo() { Value = -32000 };

            //load player cards
            int playerIndex = (int)activePlayer * 2;
            Card[] playerCards = { cards[playerIndex], cards[playerIndex + 1] };

            //load moves so we can look at better ones first
            var moves = MoveGenerator.GenerateMoves(pos, activePlayer, playerCards);
            var evalMoves = new LinkedList<MoveEval>();
            foreach (var m in moves)
            {
                //make move
                pos.MakeMove(m);
                var mEval = new MoveExt(m, (Card[])cards.Clone());

                //update cards by swapping selected with last one
                int index = Array.IndexOf(cards, m.Card);
                Card tmp = cards[cards.Length - 1];
                cards[cards.Length - 1] = cards[index];
                cards[index] = tmp;

                //evaluate move
                short moveEval = Evaluate.EvalulatePosition(pos, activePlayer);
                evalMoves.AddLast(new MoveEval() { Move = m, Value = moveEval });

                //swap back
                tmp = cards[index];
                cards[index] = cards[cards.Length - 1];
                cards[cards.Length - 1] = tmp;

                //undo move
                pos.UndoMove(m);
            }

            //load our legal moves
            var sortedMoves = evalMoves.OrderByDescending(f => f.Value).ToList();
            foreach (var sm in sortedMoves)
            {
                //sore local reference
                Move m = sm.Move;
                var cardCopy = (Card[])cards.Clone();
                var mEval = new MoveExt(m, cardCopy);

                //make move
                pos.MakeMove(m);

                //update cards by swapping selected with last one
                int index = Array.IndexOf(cards, m.Card);
                Card tmp = cards[cards.Length - 1];
                cards[cards.Length - 1] = cards[index];
                cards[index] = tmp;

                //continue next tree if we haven't already searched this position
                var nextBestState = new StateInfo() { Value = -32500 };
                if (PositionCache.Store(pos, cardCopy, depth, sm.Value))
                {
                    var currentState = new StateInfo() { Value = 0, MoveInfo = mEval, Previous = lastState };
                    nextBestState = doSearch(pos, startingPlayer, cards, nextPlayer(activePlayer), currentState, (byte)(depth + 1), (byte)(maxDepth + depthExt), beta * -1, alpha * -1);
                    nextBestState.Value *= -1;

                    //update alpha/beta/max
                    if (nextBestState.Value > bestState.Value)
                        bestState = nextBestState;
                    if (nextBestState.Value > alpha)
                        alpha = nextBestState.Value;
                }

                //swap back
                tmp = cards[index];
                cards[index] = cards[cards.Length - 1];
                cards[cards.Length - 1] = tmp;

                //undo move
                pos.UndoMove(m);

                //hard alpha check
                if (alpha >= beta)
                    return nextBestState;
            }

            return bestState;
        }

        private struct MoveEval
        {
            public Move Move;
            public short Value;
        }

        private static Color nextPlayer(Color player)
        {
            return player == Color.Red ? Color.Blue : Color.Red;
        }
    }
}
