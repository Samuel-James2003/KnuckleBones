using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnuckleBones
{
    class Player
    {
        int[,] _gameMatrix;
        int rows, columns, offset=0;
        
        public int[,] GameMatrix
        {
            get { return _gameMatrix; }
            set { _gameMatrix = value; }
        }

        public int Score
        {
            get { return Total(); }
        }

        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public Player(int columns, int rows)
        {
            _gameMatrix = new int[columns, rows];
            this.rows = rows;
            this.columns = columns;
            //_gameMatrix.Initialize();
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
                totalValue += ReColTotal(0, 0, Convert(GameMatrix, column), false);
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
            for (int i = 0; i < rows; i++)
            {
                if (GameMatrix[column, i] == 0)
                    return false;
            }
            return true;
        }
        public bool isFull()
        {
            for (int c = 0; c < columns; c++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (GameMatrix[c, i] == 0)
                        return false;
                }
            }
            return true;
        }
        public int[] Convert(int[,] array, int column)
        {
            int[] result = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                result[i] = array[i, column];
            }
            return result;
        }
        public void CheckRemove(int column, int value)
        {
            for (int i = 0; i < rows; i++)
            {
                if (GameMatrix[column, i] == value)
                    GameMatrix[column, i] = 0;
            }

            for (int x = 0; x < rows; x++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (GameMatrix[column, i] == 0)
                    {
                        GameMatrix[column, i] = GameMatrix[column, i + 1];
                        if (i < rows)
                        {
                            GameMatrix[column, i + 1] = 0;
                        }
                    }
                }
            }
        }
        public void AddValue(int column, int value)
        {
            for (int i = 0; i < rows; i++)
            {
                if(GameMatrix[i,column]==0)
                {
                    GameMatrix[i, column] = value;
                    return;
                }
            }
        }
        #endregion




    }
}
