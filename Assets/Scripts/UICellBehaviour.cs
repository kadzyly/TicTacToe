using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UICellBehaviour : MonoBehaviour
{
    [SerializeField] private Cell cell; 
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color winColor;
    [SerializeField] private Color failedColor;
    private Sprite xImage;
    private Sprite oImage;
    private Sprite blankImage;
    
    private void Awake()
    {
        xImage = Resources.Load<Sprite>("x");
        oImage = Resources.Load<Sprite>("o");
        blankImage = Resources.Load<Sprite>("b");
    }
    
    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnEnable()
    {
        cell.OnValueChanged += OnValueChanged;
        cell.OnGameFinished += OnGameFinished;
    }

    private void OnDisable()
    {
        cell.OnValueChanged -= OnValueChanged;
        cell.OnGameFinished -= OnGameFinished;
    }

    private void OnValueChanged(int _, int newValue)
    {
        image.sprite = newValue == 1 ? xImage : oImage;

        if (newValue != 0) return; // game restart
        image.sprite = blankImage;
        image.color = defaultColor;
    }

    private void OnGameFinished(bool isGameWin)
    {
        image.color = isGameWin ? winColor : failedColor;
    }

    private void OnButtonClick()
    {
        if (!cell.IsInteractive) return;
        if (cell.Value != 0) return;
        
        bool isXTurn = TurnManager.Instance.xUserTurn;
        
        int newValue = isXTurn ? 1 : 2;
        cell.SetValue(newValue);
        
        TurnManager.Instance.ChangeTurn();
    }
}
