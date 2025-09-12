using UnityEngine;
using System;

namespace TicTacToe.Core
{
    public class BoardModel
    {
        private readonly Player[,] _cells;
        public int Size => 3;

        public BoardModel()
        {
            _cells = new Player[Size, Size];
            Reset();
        }

        public void Reset()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    _cells[row, column] = Player.None;
                }
            }
        }
        
        public Player GetAt(int row, int column)
        {
            ValidateCoordinates(row, column);
            
            return _cells[row, column];
        }

        public bool TryMakeMove(int row, int column, Player player)
        {
            ValidateCoordinates(row, column);

            if (player == Player.None)
            {
                throw new ArgumentException("Player cannot be None");
            }

            if (_cells[row, column] != Player.None)
            {
                return false;
            }
            
            _cells[row, column] = player;
            return true;
        }
        
        public Player GetWinner()
        {
            // rows
            for (int row = 0; row < Size; row++)
            {
                if (_cells[row,0] != Player.None &&
                    _cells[row,0] == _cells[row,1] &&
                    _cells[row,1] == _cells[row,2])
                    return _cells[row,0];
            }

            // columns
            for (int column = 0; column < Size; column++)
            {
                if (_cells[0,column] != Player.None &&
                    _cells[0,column] == _cells[1,column] &&
                    _cells[1,column] == _cells[2,column])
                    return _cells[0,column];
            }

            // diagonals
            if (_cells[0,0] != Player.None &&
                _cells[0,0] == _cells[1,1] &&
                _cells[1,1] == _cells[2,2])
                return _cells[0,0];

            if (_cells[0,2] != Player.None &&
                _cells[0,2] == _cells[1,1] &&
                _cells[1,1] == _cells[2,0])
                return _cells[0,2];

            return Player.None;
        }
        
        public bool IsFull()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    if (_cells[row, column] == Player.None)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
        
        public bool IsDraw() => IsFull() && GetWinner() == Player.None;
        
        public Player[,] GetCopy()
        {
            return (Player[,])_cells.Clone();
        }
        
        private void ValidateCoordinates(int row, int column)
        {
            const int MIN_CELL = 0;
            int MAX_CELL = Size - 1;
            
            if (row < MIN_CELL || row >= Size || column < MIN_CELL || column >= Size)
            {
                string errorMessage = $"Coordinates must be in range [{MIN_CELL},{MAX_CELL}] (got [{row},{column}])";
                throw new ArgumentOutOfRangeException("row/column", errorMessage);
            }
        }
    }
}
