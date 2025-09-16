using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Cell", menuName = "Scriptable Objects/CellData")]
public class CellData : ScriptableObject
{
    public int Id;
    public Constants.CellValue Value; // 0: blank, 1: X, 2: O
    public bool IsInteractive = true;

    public event Action<int, Constants.CellValue> OnValueChanged;
    public event Action<bool> OnGameFinished;


    public void SetValue(Constants.CellValue value)
    {
        Value = value;
        OnValueChanged?.Invoke(Id, Value);
    }

    public void SetResult(bool isWin)
    {
        OnGameFinished?.Invoke(isWin);
        IsInteractive = false;
    }

    public void Reset()
    {
        IsInteractive = true;
        Value = Constants.CellValue.Empty;
    }
}
