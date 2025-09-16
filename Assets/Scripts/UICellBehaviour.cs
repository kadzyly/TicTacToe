using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UICellBehaviour : MonoBehaviour
{
    [SerializeField] private CellData cellData; 
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
        cellData.OnValueChanged += OnValueChanged;
        cellData.OnGameFinished += OnGameFinished;
    }

    private void OnDisable()
    {
        cellData.OnValueChanged -= OnValueChanged;
        cellData.OnGameFinished -= OnGameFinished;
    }

    private void OnValueChanged(int _, Constants.CellValue newValue)
    {
        image.sprite = newValue == Constants.CellValue.Cross ? xImage : oImage;

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
        if (!cellData.IsInteractive) return;
        if (cellData.Value != 0) return;
        
        bool isXTurn = TurnManager.Instance.crossUserTurn;
        
        Constants.CellValue newValue = isXTurn ? Constants.CellValue.Cross : Constants.CellValue.Circle;
        cellData.SetValue(newValue);
        
        TurnManager.Instance.ChangeTurn();
    }
}
