using System;
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
        
        public event Action OnButtonClicked;

        private void Awake()
        {
            xImage = Resources.Load<Sprite>("Cross");
            oImage = Resources.Load<Sprite>("Circle");
            blankImage = Resources.Load<Sprite>("Empty");
        }

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        public void DisplayCross()
        {
            image.sprite = xImage;
        }
        
        public void DisplayCircle()
        {
            image.sprite = oImage;
        }
        
        public void DisplayEmpty()
        {
            image.sprite = blankImage;
            image.color = defaultColor;
        }

        public void DisplayWinColor()
        {
            image.color = winColor;
        }
        
        public void DisplayFailColor()
        {
            image.color = failedColor;
        }

        private void OnButtonClick()
        {
            OnButtonClicked?.Invoke();
        }
    }
}