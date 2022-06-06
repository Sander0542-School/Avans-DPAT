using System.Text;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;

Console.OutputEncoding = Encoding.UTF8;

var fileLoader = new FileSystemFileLoader();
var file = fileLoader.Load("Puzzles/puzzle.9x9");

var factory = new SudokuFactory();
var sudoku = factory.CreateSudoku(file);

for (var x = 0; x < sudoku.Cells.GetLength(0); x++)
{
    for (var y = 0; y < sudoku.Cells.GetLength(1); y++)
    {
        var value = sudoku.Cells[x, y]?.Value;
        Console.Write(value.HasValue ? value.Value.ToString() : " ");
    }
    Console.WriteLine();
}
