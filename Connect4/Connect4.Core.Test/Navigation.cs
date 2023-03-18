using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Connect4.Core.Test
{
    [TestClass]
    public class Navigation
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nav = new MapNavigator();
            Board b = new Board();
            b.PutPiece(0, PieceType.P1);
            nav.EndGames(b, PieceType.P2);
            Assert.Inconclusive();
        }
    }
}
