using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuSolever
{
    public partial class Form1 : Form
    {
        public NumericUpDown [,] listOfNumerics = new NumericUpDown[9,9];
        public sudokuAlgorithm SudokuSolver = new sudokuAlgorithm();
        public Form1()
        {
            InitializeComponent();
            generateGrid();
        }
        private int[,] board = new int[,] {
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
        };

        private void generateGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var numeric = new NumericUpDown();
                    numeric.Value = board[i,j];
                    numeric.Maximum = 9;
                    numeric.Minimum = 0;
                    numeric.Width = 50;
                    numeric.Location = new Point((numeric.Width+5) * i, (numeric.Height +5) * j);
                    listOfNumerics[i, j] = numeric;
                    Controls.Add(listOfNumerics[i, j]);
                }
            }

        }

        private void Solve(object sender, EventArgs e)
        {
            listOfNumerics = SudokuSolver.SolvedSudoku(listOfNumerics);
        }
    }
}
