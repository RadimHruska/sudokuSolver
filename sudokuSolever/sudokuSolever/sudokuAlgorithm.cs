using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuSolever
{
    public class sudokuAlgorithm
    {
        private int[,] Matrix = new int[9,9];
        private bool IsPosible (int num, int row, int column)
        {

            for (int i = 0; i < 9; i++)
            {
                if (Matrix[row, i] == num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (Matrix[i, column] == num)
                {
                    return false;
                }
            }

            int startRow = row - row % 3;
            int startColumn = column - column % 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startColumn; j < startColumn + 3; j++)
                {
                    if (Matrix[i,j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
       
        }

        private bool isSudoku() 
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!IsPosible(Matrix[i, j], i, j))
                    {
                        return false;
                    }
                }
               
            }
            return true;
        }

        private bool SolveSudoku()
        {
            int row = -1;
            int column = -1;
            bool isFill = true;


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i,j] == 0)
                    {
                        row = i;
                        column = j;
                        isFill = false;
                        break;
                    }
                }
                if (!isFill)
                {
                    break;
                }
            }

            if (isFill)
            {
                return true;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (IsPosible(i, row, column))
                {
                    Matrix[row,column] = i;
               
                    if (SolveSudoku())
                    {
                        return true;
                    }
                    else 
                    {
                        Matrix[row,column] = 0;
                    }
                }
            }

            return false;
        }
        public NumericUpDown[,] SolvedSudoku(NumericUpDown[,] numericUpDowns)
           {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var numeric = numericUpDowns[i, j] as NumericUpDown;
                    Matrix[i,j] = (int)numeric.Value;
                }
            }

            if (isSudoku() && SolveSudoku() )
            {
                NumericUpDown[,] listOfSolvedNumerics = new NumericUpDown[9, 9];
                listOfSolvedNumerics = numericUpDowns;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var numeric = listOfSolvedNumerics[i, j] as NumericUpDown;
                        numeric.Value = Matrix[i,j];
                    }
                }
                return listOfSolvedNumerics;
            }
            else
            {
                MessageBox.Show("Nelze vyřešit");
                return numericUpDowns;
            }

            
           }
    }
}
