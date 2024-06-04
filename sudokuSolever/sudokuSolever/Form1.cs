using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuSolever
{
    public partial class Form1 : Form
    {
        public NumericUpDown[,] listOfNumerics = new NumericUpDown[9, 9];
        public sudokuAlgorithm SudokuSolver = new sudokuAlgorithm();
        public Form1()
        {
            InitializeComponent();
            generateGrid();
        }

        private void generateGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var numeric = new NumericUpDown(); 
                    numeric.Value = 0;
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

        private void Save(object sender, EventArgs e)
        {
            int[] numbers = new int[81];
            int index = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    numbers[index++] = (int)listOfNumerics[i,j].Value;
                }
            }
            string data = string.Join(";", numbers);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Sudoku File|*.sf";
            saveFileDialog.Title = "Uložit sudoku";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(data);
                }
            }

               
           
        }

        private void Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sudoku File|*.sf";
            openFileDialog.Title = "Otevřít sudoku soubor";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string data = reader.ReadToEnd();
                    string[] stringNumbers = data.Split(';');
                    int[] numbers = Array.ConvertAll(stringNumbers, int.Parse);
                    int row = 0;
                    int collumn = 0;
                    foreach (var item in numbers)
                    {
                        listOfNumerics[row, collumn].Value = item;
                        collumn++;
                        if (collumn == 9)
                        {
                            collumn = 0;
                            row++;
                        }
                    }
                }
            }
        }
    }
}
