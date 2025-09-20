using System;

namespace Cell
{
    public class CellModel
    {
        public int Id { get; }
        public Constants.CellValue Value { get; private set; }
        public Constants.CellWinStatus WinStatus { get; private set; }
        public bool IsInteractive { get; private set; } = true;

        public event Action<int, Constants.CellValue> OnValueChanged;
        public event Action<int, Constants.CellWinStatus> OnStatusChanged;

        public CellModel(int id)
        {
            Id = id;
            Reset();
        }

        public void SetValue(Constants.CellValue value)
        {
            Value = value;
            IsInteractive = value == Constants.CellValue.Empty;
            OnValueChanged?.Invoke(Id, Value);
        }
        
        public void SetStatus(Constants.CellWinStatus winStatus)
        {
            WinStatus = winStatus;
            OnStatusChanged?.Invoke(Id, WinStatus);
        }

        public void Reset()
        {
            Value = Constants.CellValue.Empty;
            WinStatus = Constants.CellWinStatus.None;
            IsInteractive = true;
        }
    }
}