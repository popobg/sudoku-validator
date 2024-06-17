namespace Sudoku
{
    internal class Program
    {
        static void Main()
        {
            string[][] validSudoku =
            [
              ["5", "3", ".", ".", "7", ".", ".", ".", "."],
              ["6", ".", ".", "1", "9", "5", ".", ".", "." ],
              [ ".", "9", "8", ".", ".", ".", ".", "6", "." ],
              [ "8", ".", ".", ".", "6", ".", ".", ".", "3" ],
              [ "4", ".", ".", "8", ".", "3", ".", ".", "1" ],
              [ "7", ".", ".", ".", "2", ".", ".", ".", "6" ],
              [ ".", "6", ".", ".", ".", ".", "2", "8", "." ],
              [ ".", ".", ".", "4", "1", "9", ".", ".", "5" ],
              [ ".", ".", ".", ".", "8", ".", ".", "7", "9" ]
            ];

            string[][] invalidSudoku =
            [
              ["8", "3", ".", ".", "7", ".", ".", ".", "."],
              ["6", ".", ".", "1", "9", "5", ".", ".", "." ],
              [ ".", "9", ".", ".", ".", ".", ".", "6", "." ],
              [ ".", ".", ".", ".", "6", ".", ".", ".", "3" ],
              [ "4", ".", ".", "8", ".", "3", ".", ".", "1" ],
              [ "7", ".", ".", ".", "2", ".", ".", ".", "6" ],
              [ ".", "6", ".", ".", ".", ".", "2", "8", "." ],
              [ ".", ".", ".", "4", "1", "9", ".", "7", "5" ],
              [ ".", ".", ".", ".", "8", ".", ".", "7", "9" ]
            ];

            Sudoku validS = new Sudoku(validSudoku);
            Sudoku invalidS = new Sudoku(invalidSudoku);

            if (!SudokuValidator.Validate(validS))
            {
                Console.WriteLine("The valid board is invalid. There is a problem.");
            }
            else
            {
                Console.WriteLine("The valid board is valid. Everything works!");
            }

            if (!SudokuValidator.Validate(invalidS))
            {
                Console.WriteLine("The invalid board is invalid. Everything works!");
            }
            else
            {
                Console.WriteLine("The invalid board is valid. There is a problem.");

            }
        }
    }
}
