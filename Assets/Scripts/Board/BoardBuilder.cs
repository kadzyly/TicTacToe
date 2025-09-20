using System;
using System.Collections.Generic;
using UnityEngine;


namespace Board
{
    public class BoardBuilder : MonoBehaviour
    {
        [SerializeField] private Transform cellWrapper;
        [SerializeField] private GameObject cellPrefab;
        
        public List<Cell.CellController> CellControllers { get; private set; } = new();

        public List<Cell.CellModel> CreateBoard(int columnCount)
        {
            ClearBoard();
            
            var cells = new List<Cell.CellModel>();
            int cellCount = columnCount * columnCount;

            for (int i = 0; i < cellCount; i++)
            {
                var model = new Cell.CellModel(i);
                cells.Add(model);

                var newCell = Instantiate(cellPrefab, cellWrapper);
                var uiCell = newCell.GetComponent<Cell.CellController>();
                uiCell.Init(model);
                
                CellControllers.Add(uiCell);
            }

            return cells;
        }
        
        private void ClearBoard()
        {
            for (int i = cellWrapper.childCount - 1; i >= 0; i--)
            {
                var child = cellWrapper.GetChild(i).gameObject;
                Destroy(child);
            }
        
            CellControllers.Clear();
        }
    }
}

