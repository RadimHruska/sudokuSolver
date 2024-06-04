﻿using System;
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
    }
}
