using System;
using System.Collections.Generic;
using Cell;
using Managers;
using UnityEngine;

namespace Board
{
    public class BoardController : MonoBehaviour
    {
        public List<Cell.CellModel> Cells { get; private set; }
        private int _boardSize = 3;
        
        public event Action OnReset;
        private BoardBuilder _boardBuilder;
        
        private void Awake()
        {
            _boardBuilder = GetComponent<BoardBuilder>();
        }

        private void Start()
        {
            ResetGame();
            BuildBoard(_boardSize);
        }
        
        private void BuildBoard(int size)
        {
            UnsubscribeFromCells();

            Cells = _boardBuilder.CreateBoard(size);

            foreach (var cell in _boardBuilder.CellControllers)
            {
                cell.OnCellClicked += HandleCellClicked;
            }
        }
        
        private void UnsubscribeFromCells()
        {
            if (_boardBuilder == null) return;
            foreach (var c in _boardBuilder.CellControllers)
            {
                c.OnCellClicked -= HandleCellClicked;
            }
        }
        
        private void HandleCellClicked(Cell.CellModel model)
        {
            var newValue = PlayerTurnManager.Instance.crossUserTurn
                ? Constants.CellValue.Cross
                : Constants.CellValue.Circle;

            model.SetValue(newValue);
            PlayerTurnManager.Instance.ChangeTurn();
        }
         
        
        public void ResetGame()
        {
            OnReset?.Invoke();
        }
    }
}
