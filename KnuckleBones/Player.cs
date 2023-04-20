using System;
using System.Linq;

namespace KnuckleBones
{
    class Player
    {
        int[,] _gameMatrix;
        int rows, columns, offset = 0;
        string name;

        public string Name
        {
            get { return name; }
        }

        public int[,] GameMatrix
        {
            get { return _gameMatrix; }
        }

        public int Score
        {
            get { return Total(); }
        }

        public int Offset
        {
            get { return offset; }
        }

        public Player(int columns, int rows)
        {
            _gameMatrix = new int[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }

        public Player(int columns, int rows, int offset)
        {
            _gameMatrix = new int[rows, columns];
            this.offset = offset;
            this.rows = rows;
            this.columns = columns;
        }

        public Player(int columns, int rows, string name)
        {
            _gameMatrix = new int[rows, columns];
            this.name = name;
            this.rows = rows;
            this.columns = columns;
        }

        public Player(int columns, int rows, int offset, string name)
        {
            _gameMatrix = new int[rows, columns];
            this.name = name;
            this.offset = offset;
            this.rows = rows;
            this.columns = columns;
        }

        #region Private
        private bool isDuplicated(int[] WorkingCol)
        {
            for (int i = 0; i < rows - 1; i++)
            {
                if (WorkingCol[i] == WorkingCol[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool isAllSame(int[] WorkingCol)
        {
            if (WorkingCol[0] == WorkingCol.Last())
                return true;
            return false;
        }

        private int Total()
        {
            int totalValue = 0;

            for (int column = 0; column < columns; column++)
                totalValue += ReColTotal(0, 0, Convert(_gameMatrix, column), false);
            return totalValue;
        }

        private int ReColTotal(int i, int sum, int[] workingCol, bool isADouble)
        {
            if (i == 0)
            {
                Array.Sort(workingCol);

                if (isAllSame(workingCol))
                {
                    foreach (int num in workingCol)
                        sum += num * 3;
                    return sum;
                }

                if (!isDuplicated(workingCol))
                {
                    foreach (int num in workingCol)
                        sum += num;
                    return sum;
                }
            }
            try
            {
                if (workingCol[i] == workingCol[i + 1] || isADouble)
                {
                    isADouble = false;
                    if (workingCol[i] == workingCol[i + 1])
                        isADouble = true;
                    workingCol[i] *= 2;
                }
                sum += workingCol[i];
                i++;
                return ReColTotal(i, sum, workingCol, isADouble);
            }
            catch (IndexOutOfRangeException)
            {
                if (isADouble)
                    workingCol[i] *= 2;
                return sum += workingCol[i];
            }
        }
        #endregion

        #region Public
        public bool isFull(int column)
        {
            for (int r = 0; r < rows; r++)
            {
                if (_gameMatrix[r, column] == 0)
                    return false;
            }
            return true;
        }
        public bool isFull()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (_gameMatrix[r, c] == 0)
                        return false;
                }
            }
            return true;
        }
        public int[] Convert(int[,] array, int column)
        {
            int[] result = new int[rows];
            for (int r = 0; r < rows; r++)
            {
                result[r] = array[r, column];
            }
            return result;
        }
        public void CheckRemove(int column, int value)
        {
            for (int r = 0; r < rows; r++)
            {
                if (_gameMatrix[r, column] == value)
                    _gameMatrix[r, column] = 0;
            }

            for (int x = 0; x < rows; x++)
                for (int r = 0; r < rows - 1; r++)
                    if (_gameMatrix[r, column] == 0)
                    {
                        _gameMatrix[r, column] = _gameMatrix[r + 1, column];
                        if (r < rows) _gameMatrix[r + 1, column] = 0;
                    }
        }
        public void AddValue(int column, int value)
        {
            for (int r = 0; r < rows; r++)
            {
                if (_gameMatrix[r, column] == 0)
                {
                    _gameMatrix[r, column] = value;
                    return;
                }
            }
        }
        #endregion
    }
}
