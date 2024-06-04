using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuSolever
{
    internal class solveSudoku
    {
        public NumericUpDown[,] SolveSudoku(NumericUpDown[,] numericUpDowns)
           {
            int[,] matrix = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var numeric = numericUpDowns[i, j] as NumericUpDown;
                    matrix[i,j] = (int)numeric.Value;
                }
            }



            NumericUpDown[,] listOfSolvedNumerics = new NumericUpDown[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var numeric = listOfSolvedNumerics[i, j] as NumericUpDown;
                    numeric.Value = matrix[i,j];
                }
            }
            return listOfSolvedNumerics;
           }
    }
}
