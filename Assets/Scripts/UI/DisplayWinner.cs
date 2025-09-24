using System;
using Constants;
using UnityEngine;
using Managers;
using TMPro;

namespace UI
{
    public class DisplayWinner : MonoBehaviour
    {
        [SerializeField] private TMP_Text winnerText;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color defaultColor;


        private void Start()
        {
            Reset();
        }

        private void OnEnable()
        {
            GameManager.OnGameStatusChanged += OnGameStatusChanged;
        }

        private void OnDisable()
        {
            GameManager.OnGameStatusChanged -= OnGameStatusChanged;
        }

        private void OnGameStatusChanged(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.Draw:
                    winnerText.text = "Draw";
                    break;
                case GameStatus.Win:
                    winnerText.text = "X win";
                    break;
                case GameStatus.Loss:
                    winnerText.text = "O win";
                    break;
                case GameStatus.InGame:
                default:
                    Reset();
                    break;
            }
        }
        
        private void Reset()
        {
            winnerText.text = string.Empty;
        }
    }
}
