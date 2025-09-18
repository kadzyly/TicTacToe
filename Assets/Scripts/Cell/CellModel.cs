using System;


namespace Cell
{
    public class CellModel
    {
        public int Id { get; }
        public Constants.CellValue Value { get; private set; }
        public bool IsInteractive { get; private set; } = true;

        public event Action<int, Constants.CellValue> OnValueChanged;
        public event Action<bool> OnGameFinished;

        public CellModel(int id)
        {
            Id = id;
            Reset();
        }

        public void SetValue(Constants.CellValue value)
        {
            if (!IsInteractive || Value != Constants.CellValue.Empty) return;
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
            Value = Constants.CellValue.Empty;
            IsInteractive = true;
        }
    }
}