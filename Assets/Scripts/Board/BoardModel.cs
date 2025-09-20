using UnityEngine;
using System;
using System.Collections.Generic;
using Managers;


namespace Board
{
    public class BoardModel
    {
        public List<Cell.CellModel> Cells { get; private set; } = new();

        public event Action OnReset;

        public BoardModel(int size)
        {
            int cellCount = size * size;
            for (int i = 0; i < cellCount; i++)
            {
                Cells.Add(new Cell.CellModel(i));
            }
        }

        public void MakeMove(Cell.CellModel cell, Constants.CellValue newValue)
        {
            cell.SetValue(newValue);
        }

        public void Reset()
        {
            foreach (var cell in Cells)
            {
                cell.Reset();
            }
            
            OnReset?.Invoke();
        }
    }
}


