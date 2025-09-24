using System.Collections.Generic;
using Cell;

namespace Board
{
    public static class WinChecker
    {
        private static readonly int[][] WinningLines =
        {
            new[] {0, 1, 2}, // 1st line
            new[] {3, 4, 5}, // 2nd line
            new[] {6, 7, 8}, // 3rd line

            new[] {0, 3, 6}, // 1st column
            new[] {1, 4, 7}, // 2nd column
            new[] {2, 5, 8}, // 3rd column

            new[] {0, 4, 8}, // diagonal \
            new[] {2, 4, 6}  // diagonal /
        };

        public static List<int> GetWinningLine(List<CellModel> cells, Constants.CellValue playerValue)
        {
            foreach (var line in WinningLines)
            {
                if (cells[line[0]].Value == playerValue &&
                    cells[line[1]].Value == playerValue &&
                    cells[line[2]].Value == playerValue)
                {
                    return new List<int> { line[0], line[1], line[2] };
                }
            }

            return null;
        }
    }
}