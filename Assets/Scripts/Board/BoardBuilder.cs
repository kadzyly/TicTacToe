using System;
using System.Collections.Generic;
using UnityEngine;


namespace Board
{
    public class BoardBuilder : MonoBehaviour
    {
        [SerializeField] private Transform cellWrapper;
        [SerializeField] private GameObject cellPrefab;
        private int columnCount = 3;

        public List<Cell.CellModel> CreateBoard()
        {
            var cells = new List<Cell.CellModel>();
            int cellCount = columnCount * columnCount;

            for (int i = 0; i < cellCount; i++)
            {
                var model = new Cell.CellModel(i);
                cells.Add(model);

                var newCell = Instantiate(cellPrefab, cellWrapper);
                var uiCell = newCell.GetComponent<Cell.CellView>();
                uiCell.Init(model);
            }

            return cells;
        }
    }
}

