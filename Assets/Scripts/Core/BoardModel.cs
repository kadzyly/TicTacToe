using System;

namespace Core
{
    public class BoardModel
    {
        private readonly PlayerSymbol[,] _cells;
        public int Size { get; }
        
        
        public BoardModel(int size = 3)
        {
            Size = size;
            _cells = new PlayerSymbol[Size, Size];
            Reset();
        }
        
        public PlayerSymbol GetWinner()
        {
            return WinnerChecker.GetWinner(_cells);
        }

        public void Reset()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    _cells[row, col] = PlayerSymbol.None;
                }
            }
        }
        
        public PlayerSymbol GetAt(int row, int column)
        {
            ValidateCoordinates(row, column);
            
            return _cells[row, column];
        }

        public bool TryMakeMove(int row, int column, PlayerSymbol playerSymbol)
        {
            ValidateCoordinates(row, column);

            if (playerSymbol == PlayerSymbol.None)
            {
                throw new ArgumentOutOfRangeException(nameof(playerSymbol), "PlayerSymbol cannot be None");
            }

            if (_cells[row, column] != PlayerSymbol.None)
            {
                return false;
            }
            
            _cells[row, column] = playerSymbol;
            return true;
        }
        
        public bool IsFull()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (_cells[row, col] == PlayerSymbol.None)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public bool IsDraw()
        {
            return IsFull() && GetWinner() == PlayerSymbol.None;
        }
        
        public PlayerSymbol[,] GetCopy()
        {
            var copy = new PlayerSymbol[Size, Size];
            
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    copy[row, col] = _cells[row, col];
                }
            }
            return copy;
        }
        
        private void ValidateCoordinates(int row, int column)
        {
            const int MIN_CELL = 0;

            if (row < MIN_CELL || row >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(row), $"Row must be in [{MIN_CELL},{Size-1}], got {row}");
            }

            if (column < MIN_CELL || column >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(column), $"Column must be in [{MIN_CELL},{Size-1}], got {column}");
            }
        }
        
        public override string ToString()
        {
            var lines = new string[Size];
            
            for (int r = 0; r < Size; r++)
            {
                var cols = new string[Size];
                for (int c = 0; c < Size; c++)
                    cols[c] = _cells[r,c] == PlayerSymbol.None ? "." : _cells[r,c].ToString();
                lines[r] = string.Join(" ", cols);
            }
            
            return string.Join("\n", lines);
        }
    }
}
