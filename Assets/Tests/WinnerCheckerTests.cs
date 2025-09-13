using NUnit.Framework;
using Core;

namespace Tests
{
    public class WinnerCheckerTests
    {

        [Test]
        public void EmptyBoard_HasNoWinner()
        {
            var cells = new PlayerSymbol[3, 3];
            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(PlayerSymbol.None, winner);
        }
        
        [Test]
        public void RowWin_XWinsInFirstRow()
        {
            var cells = new PlayerSymbol[3, 3]
            {
                { PlayerSymbol.X, PlayerSymbol.X, PlayerSymbol.X },
                { PlayerSymbol.None, PlayerSymbol.None, PlayerSymbol.None },
                { PlayerSymbol.None, PlayerSymbol.None, PlayerSymbol.None }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(PlayerSymbol.X, winner);
        }

        [Test]
        public void ColumnWin_OWinsInSecondColumn()
        {
            var cells = new PlayerSymbol[3, 3]
            {
                { PlayerSymbol.None, PlayerSymbol.O, PlayerSymbol.None },
                { PlayerSymbol.None, PlayerSymbol.O, PlayerSymbol.None },
                { PlayerSymbol.None, PlayerSymbol.O, PlayerSymbol.None }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(PlayerSymbol.O, winner);
        }

        [Test]
        public void DiagonalWin_XWinsOnMainDiagonal()
        {
            var cells = new PlayerSymbol[3, 3]
            {
                { PlayerSymbol.X, PlayerSymbol.None, PlayerSymbol.None },
                { PlayerSymbol.None, PlayerSymbol.X, PlayerSymbol.None },
                { PlayerSymbol.None, PlayerSymbol.None, PlayerSymbol.X }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(PlayerSymbol.X, winner);
        }

        [Test]
        public void AntiDiagonalWin_OWinsOnOtherDiagonal()
        {
            var cells = new PlayerSymbol[3, 3]
            {
                { PlayerSymbol.None, PlayerSymbol.None, PlayerSymbol.O },
                { PlayerSymbol.None, PlayerSymbol.O, PlayerSymbol.None },
                { PlayerSymbol.O, PlayerSymbol.None, PlayerSymbol.None }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(PlayerSymbol.O, winner);
        }

        [Test]
        public void NoWinner_FullBoardDraw()
        {
            var cells = new PlayerSymbol[3, 3]
            {
                { PlayerSymbol.X, PlayerSymbol.O, PlayerSymbol.X },
                { PlayerSymbol.O, PlayerSymbol.X, PlayerSymbol.O },
                { PlayerSymbol.O, PlayerSymbol.X, PlayerSymbol.O }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(PlayerSymbol.None, winner);
        }
    }
}
