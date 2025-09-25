using System;
using UnityEngine;
using UnityEngine.UI;

namespace Cell
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        
        [SerializeField] private Color emptyColor;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color winColor;
        [SerializeField] private Color failedColor;
        private Outline _outline;
        private Sprite xImage, oImage, blankImage;
        
        public event Action OnButtonClicked;

        private void Awake()
        {
            xImage = Resources.Load<Sprite>("diamond_icon");
            oImage = Resources.Load<Sprite>("circle_icon");
            blankImage = Resources.Load<Sprite>("Empty");
        }

        private void Start()
        {
            button.onClick.AddListener(OnButtonClick);
            _outline = GetComponent<Outline>();
        }

        public void DisplayCross()
        {
            image.sprite = xImage;
            _outline.enabled = false;
            DisplayDefaultColor();
        }
        
        public void DisplayCircle()
        {
            image.sprite = oImage;
            _outline.enabled = false;
            DisplayDefaultColor();
        }
        
        public void DisplayEmpty()
        {
            image.sprite = blankImage;
            _outline.enabled = true;
            ChangeImageColor(emptyColor);
        }

        public void DisplayWinColor()
        {
            ChangeImageColor(winColor);
        }
        
        public void DisplayFailColor()
        {
            ChangeImageColor(failedColor);
        }
        public void DisplayDefaultColor()
        {
            ChangeImageColor(defaultColor);
        }

        private void ChangeImageColor(Color color)
        {
            Color current = image.color;
            image.color = new Color(color.r, color.g, color.b, current.a);
        }

        private void OnButtonClick()
        {
            OnButtonClicked?.Invoke();
        }
    }
}