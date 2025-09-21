using System.Collections.Generic;
using System.Linq;
using Constants;
using Managers;
using UnityEngine;

namespace Board
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField] private int boardSize = 3;

        private BoardModel _model;
        private BoardBuilder _builder;
        private List<Cell.CellController> _controllers;

        private void Awake()
        {
            _builder = GetComponent<BoardBuilder>();
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _model = new BoardModel(boardSize);
            _controllers = _builder.CreateBoard(_model.Cells);

            foreach (var controller in _controllers)
            {
                controller.OnCellClicked += HandleCellClicked;
            }
        }

        private void OnDestroy()
        {
            foreach (var controller in _controllers)
            {
                controller.OnCellClicked -= HandleCellClicked;
            }
        }

        private void HandleCellClicked(Cell.CellModel model)
        {
            var newValue = PlayerTurnManager.Instance.CrossUserTurn
                ? Constants.CellValue.Cross
                : Constants.CellValue.Circle;

            _model.MakeMove(model, newValue);

            CheckWin(_model.Cells, model.Id, newValue);
        }

        private void CheckWin(List<Cell.CellModel> cells, int id, Constants.CellValue value)
        {
            List<int> winIndexed = WinChecker.GetWinningLine(cells, id, value);
            
            // winner
            if (winIndexed != null)
            {
                foreach (var index in winIndexed)
                {
                    _model.Cells[index].SetStatus(Constants.CellWinStatus.Win);
                }

                bool isWin = PlayerTurnManager.Instance.CrossUserTurn;
                GameManager.Instance.SetGameMode(isWin ? GameStatus.Win : GameStatus.Loss);
            }
            // end without winners
            else if (_model.Cells.All(c => c.Value != Constants.CellValue.Empty))
            {
                foreach (var cell in _model.Cells)
                {
                    cell.SetStatus(Constants.CellWinStatus.Lose);
                }
                
                GameManager.Instance.SetGameMode(GameStatus.Draw);
            }
            // continue game
            else
            {
                PlayerTurnManager.Instance.SetTurn(!PlayerTurnManager.Instance.CrossUserTurn);
            }
        }

        public void ResetBoard()
        {
            _model.Reset();
        }
    }
}
