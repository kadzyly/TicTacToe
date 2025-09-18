using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Cell
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color winColor;
        [SerializeField] private Color failedColor;
        private Sprite xImage, oImage, blankImage;

        private CellModel model;

        private void Awake()
        {
            xImage = Resources.Load<Sprite>("Cross");
            oImage = Resources.Load<Sprite>("Circle");
            blankImage = Resources.Load<Sprite>("Empty");
        }

        public void Init(CellModel cellModel)
        {
            model = cellModel;

            model.OnValueChanged += OnValueChanged;
            model.OnGameFinished += OnGameFinished;

            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            if (model != null)
            {
                model.OnValueChanged -= OnValueChanged;
                model.OnGameFinished -= OnGameFinished;
            }
        }

        private void OnValueChanged(int _, Constants.CellValue newValue)
        {
            switch (newValue)
            {
                case Constants.CellValue.Cross:
                    image.sprite = xImage; break;
                case Constants.CellValue.Circle:
                    image.sprite = oImage; break;
                default:
                    image.color = defaultColor;
                    image.sprite = blankImage;
                    break;
            }
        }

        private void OnGameFinished(bool isGameWin)
        {
            image.color = isGameWin ? winColor : failedColor;
        }

        private void OnButtonClick()
        {
            if (!model.IsInteractive) return;

            var newValue = PlayerTurnManager.Instance.crossUserTurn
                ? Constants.CellValue.Cross
                : Constants.CellValue.Circle;

            model.SetValue(newValue);
            PlayerTurnManager.Instance.ChangeTurn();
        }
    }
}