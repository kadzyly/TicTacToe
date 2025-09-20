using UnityEngine;
using Managers;
using System;

namespace Cell
{
    public class CellController : MonoBehaviour
    {
        private CellView _view;
        private CellModel _model;
        
        public event Action<CellModel> OnCellClicked;


        private void Start()
        {
            _view  = GetComponent<CellView>();
            _view.OnButtonClicked += OnButtonClicked;
        }

        public void Init(CellModel cellModel)
        {
            _model = cellModel;

            _model.OnValueChanged += OnValueChanged;
            _model.OnGameFinished += OnGameFinished;
        }
        
        private void OnDestroy()
        {
            if (_model != null)
            {
                _model.OnValueChanged -= OnValueChanged;
                _model.OnGameFinished -= OnGameFinished;
            }

            if (_view != null)
            {
                _view.OnButtonClicked -= OnButtonClicked;
            }
        }
        
        private void OnValueChanged(int _, Constants.CellValue value)
        {
            switch (value)
            {
                case Constants.CellValue.Cross:
                    _view.DisplayCross();
                    break;
                case Constants.CellValue.Circle:
                    _view.DisplayCircle();
                    break;
                case Constants.CellValue.Empty:
                default:
                    _view.DisplayEmpty();
                    break;
            }
        }

        public void ChangeValue(Constants.CellValue value)
        {
            _model.SetValue(value);
        }
        
        private void OnGameFinished(bool isGameWin)
        {
            if (isGameWin)
            {
                _view.DisplayWinColor();
            }
            else
            {
                _view.DisplayFailColor();
            }
        }

        private void OnButtonClicked()
        {
            if (!_model.IsInteractive) return;
            OnCellClicked?.Invoke(_model);
        }
    }
}
