namespace Avans.DPAT.Sudoku.Game.Exceptions;

public class SudokuPlacementException : InvalidOperationException
{
    public SudokuPlacementException(string? message) : base(message)
    {
    }

    public SudokuPlacementException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
