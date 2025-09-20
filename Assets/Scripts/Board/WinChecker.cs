using System.Collections.Generic;
using Cell;
using UnityEngine;

namespace Board
{
    public static class WinChecker
    {
        public static List<int> GetWinningLine(List<CellModel> cells, int cellIndex, Constants.CellValue playerValue)
        {
            int size = (int)Mathf.Sqrt(cells.Count);
            int row = cellIndex / size;
            int col = cellIndex % size;

            List<int> line;

            // row
            line = new List<int>();
            for (int c = 0; c < size; c++)
            {
                if (cells[row * size + c].Value != playerValue)
                {
                    line = null;
                    break;
                }
                line.Add(cells[row * size + c].Id);
            }
            if (line != null) return line;

            // column
            line = new List<int>();
            for (int r = 0; r < size; r++)
            {
                if (cells[r * size + col].Value != playerValue)
                {
                    line = null;
                    break;
                }
                line.Add(cells[r * size + col].Id);
            }
            if (line != null) return line;

            // diagonal \
            if (row == col)
            {
                line = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    if (cells[i * size + i].Value != playerValue)
                    {
                        line = null;
                        break;
                    }
                    line.Add(cells[i * size + i].Id);
                }
                if (line != null) return line;
            }

            // diagonal /
            if (row + col == size - 1)
            {
                line = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    if (cells[i * size + (size - 1 - i)].Value != playerValue)
                    {
                        line = null;
                        break;
                    }
                    line.Add(cells[i * size + (size - 1 - i)].Id);
                }
                if (line != null) return line;
            }

            return null;
        }
    }
}