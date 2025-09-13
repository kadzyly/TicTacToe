using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Cell", menuName = "Scriptable Objects/Cell")]
public class Cell : ScriptableObject
{
    public int Id;
    public int Value; // 0: blank, 1: X, 2: O
    public bool IsInteractive = true;

    public event Action<int, int> OnValueChanged;
    public event Action<bool> OnGameFinished;

    public void SetValue(int value)
    {
        Value = value;
        OnValueChanged?.Invoke(Id, Value);
    }

    public void SetResults(bool isWin)
    {
        OnGameFinished?.Invoke(isWin);
        IsInteractive = false;
    }

    public void Reset()
    {
        IsInteractive = true;
        SetValue(0);
    }
}
