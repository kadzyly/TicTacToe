using System.Collections.Generic;
using System.Linq;
using Cell;
using Constants;
using UnityEngine;

namespace Board
{
    public static class BotMovement
    {
        public static CellModel ChooseNextMove(List<CellModel> cells)
        {
            List<CellModel> emptyCells = cells.Where(cell => cell.Value == CellValue.Empty).ToList();

            if (emptyCells.Count == 0) return null;
            
            int randomCellIndex = Random.Range(0, emptyCells.Count);
            CellModel chosenCell = emptyCells[randomCellIndex];

            return chosenCell;
        }
    }
}