using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Connect4.Core.Heuristics;

namespace Connect4.Core.Test
{
    [TestClass]
    public class BoardMoveTest
    {
        [TestMethod]
        public void FirstMove()
        {
            Board b = new Board();
            var result = new AI().MakeMove(b, PieceType.P1, -1);
            Assert.Inconclusive("C: " + result.Move.Column);
        }

        [TestMethod]
        public void AIMove1()
        {
            /*
             * |-------|
             * |-------|
             * |-------|
             * |-------|
             * |---O---|
             * |---XX--|
             * |=======|
             * |0123456| 
            */
            Board b = new Board();

            b.PutPiece(4, PieceType.P1);

            b.PutPiece(3, PieceType.P1);
            b.PutPiece(3, PieceType.P2);

            var nextMove = new AIV2().MakeMove(b, PieceType.P2, 9);

            Assert.Inconclusive("Column Index: " + nextMove.Move.Column);
        }

        [TestMethod]
        public void AIMove2()
        {
            /*
             * |XO-OXO-|
             * |OX-OXO-|
             * |OX-OOO-|
             * |XX-XXX-|
             * |OO-XXOX|
             * |OOXXXOX|
             * |=======|
             * |0123456| 
            */
            Board b = new Board();

            b.PutPiece(0, PieceType.P2);
            b.PutPiece(0, PieceType.P2);
            b.PutPiece(0, PieceType.P1);
            b.PutPiece(0, PieceType.P2);
            b.PutPiece(0, PieceType.P2);
            b.PutPiece(0, PieceType.P1);

            b.PutPiece(1, PieceType.P2);
            b.PutPiece(1, PieceType.P2);
            b.PutPiece(1, PieceType.P1);
            b.PutPiece(1, PieceType.P1);
            b.PutPiece(1, PieceType.P1);
            b.PutPiece(1, PieceType.P2);

            b.PutPiece(2, PieceType.P1);

            b.PutPiece(3, PieceType.P1);
            b.PutPiece(3, PieceType.P1);
            b.PutPiece(3, PieceType.P1);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(3, PieceType.P2);

            b.PutPiece(4, PieceType.P1);
            b.PutPiece(4, PieceType.P1);
            b.PutPiece(4, PieceType.P1);
            b.PutPiece(4, PieceType.P2);
            b.PutPiece(4, PieceType.P1);
            b.PutPiece(4, PieceType.P1);

            b.PutPiece(5, PieceType.P2);
            b.PutPiece(5, PieceType.P2);
            b.PutPiece(5, PieceType.P1);
            b.PutPiece(5, PieceType.P2);
            b.PutPiece(5, PieceType.P2);
            b.PutPiece(5, PieceType.P2);

            b.PutPiece(6, PieceType.P1);
            b.PutPiece(6, PieceType.P1);

            var nextMove = new AI().MakeMove(b, PieceType.P2, -1);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void AITotalLoss()
        {
            Board b = new Board();

            b.PutPiece(2, PieceType.P1);
            b.PutPiece(2, PieceType.P2);
            b.PutPiece(3, PieceType.P1);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(4, PieceType.P1);

            var nextMove = new AI().MakeMove(b, PieceType.P2, -1);

            Assert.IsTrue(nextMove.State == AIMoveState.YOU_WILL_WIN, "Total AI Loss not detected");
        }

        [TestMethod]
        public void AIShouldBlock()
        {
            Board b = new Board();
            b.PutPiece(3, PieceType.P1);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(2, PieceType.P1);

            AIMoveSummary nextMove = new AI().MakeMove(b, PieceType.P2, -1);
            List<byte> correctColumns = new List<byte>() { 1, 4 };

            Assert.IsTrue(correctColumns.Contains(nextMove.Move.Column), "Wrong move detected.");
        }

        [TestMethod]
        public void AIMoveWin()
        {
            Board b = new Board();
            b.PutPiece(0, PieceType.P1);
            b.PutPiece(0, PieceType.P1);
            b.PutPiece(0, PieceType.P1);

            AIMoveSummary nextMove = new AI().MakeMove(b, PieceType.P1, 10);

            Assert.IsTrue(nextMove.Move.Column == 0, "Best Column not picked");
        }

        [TestMethod]
        public void AIMoveBlock()
        {
            Board b = new Board();
            b.PutPiece(0, PieceType.P1);
            b.PutPiece(0, PieceType.P1);
            b.PutPiece(0, PieceType.P1);

            AIMoveSummary nextMove = new AI().MakeMove(b, PieceType.P1, 10);

            Assert.IsTrue(nextMove.Move.Column == 0, "Best Column not picked");
        }

        [TestMethod]
        public void DiagCountUR()
        {
            Board b = new Board();
            b.PutPiece(0, PieceType.P1);
            b.PutPiece(1, PieceType.P2);
            b.PutPiece(1, PieceType.P1);
            b.PutPiece(2, PieceType.P2);
            b.PutPiece(2, PieceType.P2);
            b.PutPiece(2, PieceType.P1);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(3, PieceType.P2);
            b.PutPiece(3, PieceType.P1);

            DirectionCounts counts = new DirectionCounts(b);
            byte count = counts.PiecesDiagLLUR(1, 1, PieceType.P1);

            Assert.IsTrue(count == 4);
        }
    }
}
