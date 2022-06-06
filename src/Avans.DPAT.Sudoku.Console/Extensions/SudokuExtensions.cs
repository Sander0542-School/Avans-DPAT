namespace Avans.DPAT.Sudoku.Console.Extensions;

public static class SudokuExtensions
{
    public static int Height(this Game.Sudoku sudoku)
    {
        return sudoku.Cells.GetLength(0);
    }

    public static int Width(this Game.Sudoku sudoku)
    {
        return sudoku.Cells.GetLength(1);
    }
}
