using Managers;
using TMPro;
using UnityEngine;


namespace UI
{
    public class PlayerUIHighlighter : MonoBehaviour
    {
        [SerializeField] private TMP_Text crossText;
        [SerializeField] private TMP_Text circleText;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color defaultColor;


        private void OnEnable()
        {
            PlayerTurnManager.OnTurnChanged += OnChangeColor;
        }

        private void OnDisable()
        {
            PlayerTurnManager.OnTurnChanged -= OnChangeColor;
        }

        private void Start()
        {
            OnChangeColor(PlayerTurnManager.Instance.CrossUserTurn);
        }

        private void OnChangeColor(bool crossTurn)
        {
            if (crossTurn)
            {
                crossText.color = activeColor;
                circleText.color = defaultColor;
            }
            else
            {
                circleText.color = activeColor;
                crossText.color = defaultColor;
            }
        }
    }
}