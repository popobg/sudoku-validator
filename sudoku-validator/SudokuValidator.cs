using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuValidator
{
    internal class SudokuValidator
    {
        // default value if no array is given to the constructor
        private string[][] _sudoku =
            [
              ["8", "3", ".", ".", "7", ".", ".", ".", "."],
              ["6", ".", ".", "1", "9", "5", ".", ".", "." ],
              [ ".", "9", "8", ".", ".", ".", ".", "6", "." ],
              [ ".", ".", ".", ".", "6", ".", ".", ".", "3" ],
              [ "4", ".", ".", "8", ".", "3", ".", ".", "1" ],
              [ "7", ".", ".", ".", "2", ".", ".", ".", "6" ],
              [ ".", "6", ".", ".", ".", ".", "2", "8", "." ],
              [ ".", ".", ".", "4", "1", "9", ".", ".", "5" ],
              [ ".", ".", ".", ".", "8", ".", ".", "7", "9" ]
            ];

        public SudokuValidator() { }

        public SudokuValidator(string[][] sudokuBoard)
        {
            this._sudoku = sudokuBoard;
        }

        public bool IsValid => this.CheckValidityArray();

        private bool CheckLine(List<string> line)
        {
            foreach (string entry in line)
            {
                if (entry != "." && line.Count(x => x == entry) > 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckColumn(int position)
        {
            List<string> listColumn = new();

            foreach (string[] line in this._sudoku)
            {
                if (line[position] != "." && listColumn.Contains(line[position]))
                {
                    return false;
                }
                listColumn.Add(line[position]);
            }

            return true;
        }

        private bool CheckSubBox(int i, int j)
        {
            List<string> valuesInSubbox = new();

            // check the number in the subbox (not in the same line and column)
            for (int line = i; line <= i + 2; line++)
            {
                for (int column = j; column <= j + 2; column++)
                {
                    string currentValue = this._sudoku[line][column];

                    if ( currentValue != "." && valuesInSubbox.Contains(currentValue))
                    {
                        return false;
                    }

                    valuesInSubbox.Add(currentValue);
                }
            }

            return true;
        }

        private bool CheckValidityArray()
        {
            for (int i = 0; i < this._sudoku.GetLength(0); i++)
            {
                if (!this.CheckLine(this._sudoku[i].ToList()))
                {
                    Console.WriteLine($"same number in the line[{i}].");
                    return false;
                }

                if (!this.CheckColumn(i))
                {
                    Console.WriteLine($"same number in a column.");
                    return false;
                }

                // réfléchir pour checker seulement une fois pour chaque cellule 3x3
                for (int j = 0; j < (this._sudoku[0].Count() - 2); j++)
                {
                    // take only the first, fourth and seventh lines and columns
                    if (i % 3 != 0 && j % 3 != 0)
                    {
                        continue;
                    }

                    if (!this.CheckSubBox(i, j))
                    {
                        Console.WriteLine($"Same number in a subbox.");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
