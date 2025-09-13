using NUnit.Framework;
using Core;

namespace Tests
{
    public class WinnerCheckerTests
    {

        [Test]
        public void EmptyBoard_HasNoWinner()
        {
            var cells = new Player[3, 3];
            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(Player.None, winner);
        }
        
        [Test]
        public void RowWin_XWinsInFirstRow()
        {
            var cells = new Player[3, 3]
            {
                { Player.X, Player.X, Player.X },
                { Player.None, Player.None, Player.None },
                { Player.None, Player.None, Player.None }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(Player.X, winner);
        }

        [Test]
        public void ColumnWin_OWinsInSecondColumn()
        {
            var cells = new Player[3, 3]
            {
                { Player.None, Player.O, Player.None },
                { Player.None, Player.O, Player.None },
                { Player.None, Player.O, Player.None }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(Player.O, winner);
        }

        [Test]
        public void DiagonalWin_XWinsOnMainDiagonal()
        {
            var cells = new Player[3, 3]
            {
                { Player.X, Player.None, Player.None },
                { Player.None, Player.X, Player.None },
                { Player.None, Player.None, Player.X }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(Player.X, winner);
        }

        [Test]
        public void AntiDiagonalWin_OWinsOnOtherDiagonal()
        {
            var cells = new Player[3, 3]
            {
                { Player.None, Player.None, Player.O },
                { Player.None, Player.O, Player.None },
                { Player.O, Player.None, Player.None }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(Player.O, winner);
        }

        [Test]
        public void NoWinner_FullBoardDraw()
        {
            var cells = new Player[3, 3]
            {
                { Player.X, Player.O, Player.X },
                { Player.O, Player.X, Player.O },
                { Player.O, Player.X, Player.O }
            };

            var winner = WinnerChecker.GetWinner(cells);
            Assert.AreEqual(Player.None, winner);
        }
    }
}
