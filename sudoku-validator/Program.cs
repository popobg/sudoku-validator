namespace SudokuValidator
{
    internal class Program
    {
        enum ReturnCodes
        {
            SUCCESS,
            INVALID_GRID
        }
        static int Main()
        {
            string[][] sudoku =
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

            SudokuValidator validator = new SudokuValidator();
            
            if (validator.IsValid)
            {
                Console.WriteLine("The grid is valid.");
                return (int) ReturnCodes.SUCCESS;
            }
            Console.WriteLine("The grid is not valid !");
            return (int) ReturnCodes.INVALID_GRID;

            
        }
    }
}
