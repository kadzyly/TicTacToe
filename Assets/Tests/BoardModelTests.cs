using NUnit.Framework;
using Core;

namespace Tests
{
    public class BoardModelTests
    {
        [Test]
        public void NewBoard_IsEmpty()
        {
            var board = new BoardModel();

            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    Assert.AreEqual(Player.None, board.GetAt(r, c));
                }
            }
        }

        [Test]
        public void TryMakeMove_ValidMove_SetsPlayer()
        {
            var board = new BoardModel();
            bool result = board.TryMakeMove(0, 0, Player.X);

            Assert.IsTrue(result);
            Assert.AreEqual(Player.X, board.GetAt(0, 0));
        }

        [Test]
        public void TryMakeMove_OccupiedCell_ReturnsFalse()
        {
            var board = new BoardModel();
            board.TryMakeMove(0, 0, Player.X);

            bool result = board.TryMakeMove(0, 0, Player.O);

            Assert.IsFalse(result);
            Assert.AreEqual(Player.X, board.GetAt(0, 0)); // значение не изменилось
        }

        [Test]
        public void TryMakeMove_PlayerNone_ThrowsException()
        {
            var board = new BoardModel();

            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            {
                board.TryMakeMove(0, 0, Player.None);
            });
        }

        [Test]
        public void GetWinner_RowWin_XWins()
        {
            var board = new BoardModel();
            board.TryMakeMove(0, 0, Player.X);
            board.TryMakeMove(0, 1, Player.X);
            board.TryMakeMove(0, 2, Player.X);

            Assert.AreEqual(Player.X, board.GetWinner());
        }

        [Test]
        public void GetWinner_ColumnWin_OWins()
        {
            var board = new BoardModel();
            board.TryMakeMove(0, 1, Player.O);
            board.TryMakeMove(1, 1, Player.O);
            board.TryMakeMove(2, 1, Player.O);

            Assert.AreEqual(Player.O, board.GetWinner());
        }

        [Test]
        public void GetWinner_DiagonalWin_XWins()
        {
            var board = new BoardModel();
            board.TryMakeMove(0, 0, Player.X);
            board.TryMakeMove(1, 1, Player.X);
            board.TryMakeMove(2, 2, Player.X);

            Assert.AreEqual(Player.X, board.GetWinner());
        }

        [Test]
        public void IsFull_WhenNotFull_ReturnsFalse()
        {
            var board = new BoardModel();
            board.TryMakeMove(0, 0, Player.X);

            Assert.IsFalse(board.IsFull());
        }

        [Test]
        public void IsFull_WhenFull_ReturnsTrue()
        {
            var board = new BoardModel();
            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    board.TryMakeMove(r, c, Player.X);
                }
            }

            Assert.IsTrue(board.IsFull());
        }

        [Test]
        public void IsDraw_WhenFullWithoutWinner_ReturnsTrue()
        {
            var board = new BoardModel();

            // патовая ситуация 3x3
            board.TryMakeMove(0, 0, Player.X);
            board.TryMakeMove(0, 1, Player.O);
            board.TryMakeMove(0, 2, Player.X);

            board.TryMakeMove(1, 0, Player.X);
            board.TryMakeMove(1, 1, Player.O);
            board.TryMakeMove(1, 2, Player.O);

            board.TryMakeMove(2, 0, Player.O);
            board.TryMakeMove(2, 1, Player.X);
            board.TryMakeMove(2, 2, Player.X);

            Assert.IsTrue(board.IsDraw());
        }

        [Test]
        public void Reset_ClearsBoard()
        {
            var board = new BoardModel();
            board.TryMakeMove(0, 0, Player.X);

            board.Reset();

            for (int r = 0; r < board.Size; r++)
            {
                for (int c = 0; c < board.Size; c++)
                {
                    Assert.AreEqual(Player.None, board.GetAt(r, c));
                }
            }
        }
    }
}
