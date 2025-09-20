using System;
using System.Collections.Generic;
using UnityEngine;


namespace Board
{
    public class BoardBuilder : MonoBehaviour
    {
        [SerializeField] private Transform cellWrapper;
        [SerializeField] private GameObject cellPrefab;

        public List<Cell.CellController> CreateBoard(List<Cell.CellModel> models)
        {
            ClearBoard();

            var controllers = new List<Cell.CellController>();

            foreach (var model in models)
            {
                var newCell = Instantiate(cellPrefab, cellWrapper, false);
                var uiCell = newCell.GetComponent<Cell.CellController>();
                uiCell.Init(model);
                controllers.Add(uiCell);
            }

            return controllers;
        }

        private void ClearBoard()
        {
            for (int i = cellWrapper.childCount - 1; i >= 0; i--)
            {
                Destroy(cellWrapper.GetChild(i).gameObject);
            }
        }
    }
}

