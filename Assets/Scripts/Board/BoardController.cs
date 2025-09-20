using System.Collections.Generic;
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

            PlayerTurnManager.Instance.SetTurn(!PlayerTurnManager.Instance.CrossUserTurn);
        }

        public void ResetGame()
        {
            _model.Reset();
        }
    }
}
