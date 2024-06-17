namespace Sudoku
{
    internal static class SudokuValidator
    {
        private static bool CheckValues(List<string> values)
        {
            foreach (string value in values)
            {
                if (value != "." && values.Count(x => x == value) > 1)
                {
                    return false;
                }
            }

            return true;
        }

        // future improvement : more info about the location and the number concerned by the error.
        private static void DisplayError(string cell, int index)
        {
            Console.WriteLine($"There is an error in the {cell} {index}.");
        }

        public static bool Validate(Sudoku sudoku)
        {
            for (int i = 0; i < sudoku.LENGTH_DIMENSION; i++)
            {
                if (!CheckValues(sudoku.GetLine(i)))
                {
                    DisplayError("line", i + 1);
                    return false;
                }

                if (!CheckValues(sudoku.GetColumn(i)))
                {
                    DisplayError("column", i + 1);
                    return false;
                }

                for (int j = 0; j < sudoku.LENGTH_DIMENSION; j += 3)
                {
                    if (i % 3 != 0)
                    {
                        continue;
                    }

                    if (!CheckValues(sudoku.GetSubbox(i, j)))
                    {
                        Console.WriteLine($"There is an error in the subbox starting line {i + 1} and column {j + 1}.");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
