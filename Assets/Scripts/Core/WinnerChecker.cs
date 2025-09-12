using System;

namespace TicTacToe.Core
{
    public static class WinnerChecker
    {
        public static Player GetWinner(Player[,] cells)
        {
            int size = cells.GetLength(0);

            // rows
            for (int row = 0; row < size; row++)
            {
                var candidate = cells[row, 0];
                if (candidate == Player.None) continue;

                bool rowWin = true;
                for (int col = 1; col < size; col++)
                {
                    if (cells[row, col] != candidate)
                    {
                        rowWin = false;
                        break;
                    }
                }
                if (rowWin) return candidate;
            }

            // columns
            for (int col = 0; col < size; col++)
            {
                var candidate = cells[0, col];
                if (candidate == Player.None) continue;

                bool colWin = true;
                for (int row = 1; row < size; row++)
                {
                    if (cells[row, col] != candidate)
                    {
                        colWin = false;
                        break;
                    }
                }
                if (colWin) return candidate;
            }

            // diagonals
            {
                var candidate = cells[0, 0];
                if (candidate != Player.None)
                {
                    bool diagWin = true;
                    for (int i = 1; i < size; i++)
                    {
                        if (cells[i, i] != candidate)
                        {
                            diagWin = false;
                            break;
                        }
                    }
                    if (diagWin) return candidate;
                }
            }

            // diagonals
            {
                var candidate = cells[0, size - 1];
                if (candidate != Player.None)
                {
                    bool diagWin = true;
                    for (int i = 1; i < size; i++)
                    {
                        if (cells[i, size - 1 - i] != candidate)
                        {
                            diagWin = false;
                            break;
                        }
                    }
                    if (diagWin) return candidate;
                }
            }

            return Player.None;
        }
    }
}
