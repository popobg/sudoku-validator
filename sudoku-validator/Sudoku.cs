namespace Sudoku
{
    // equivalent to the constructor `public string[][] Sudoku(string[][] sgrid)`
    internal class Sudoku(string[][] sgrid)
    {
        private string[][] _sudokuGrid = sgrid;
        private const int _LENGTH_DIMENSION = 9;

        public string[][] SudokuGrid
        {
            get => this._sudokuGrid;
            set => this._sudokuGrid = value;
        }

        public int LENGTH_DIMENSION
        {
            get => _LENGTH_DIMENSION;
        }

        public string GetItem(int line, int column)
        {
            return this._sudokuGrid[line][column];
        }

        public void SetItem(int line, int column, string value)
        {
            this._sudokuGrid[line][column] = value;
        }

        public List<string> GetLine(int index)
        {
            return this._sudokuGrid[index].ToList();
        }

        public List<string> GetColumn(int index)
        {
            List<string> column = new();

            foreach (string[] line in this._sudokuGrid)
            {
                column.Add(line[index]);
            }

            return column;
        }

        // y = line index, x = column index
        public List<string> GetSubbox(int line, int column)
        {
            List<string> subbox = new();

            for (int i = line; i <= line + 2; i++)
            {
                for (int j = column; j <= column + 2; j++)
                {
                    subbox.Add(this._sudokuGrid[i][j]);
                }
            }

            return subbox;
        }
    }
}
