namespace Avans.DPAT.Sudoku.Console.Models;

public class MenuModel
{
    public string SudokuPath { get; set; }
    public string ErrorMessage { get; set; }

    public MenuModel()
    {
        SudokuPath = "Puzzles/puzzle.9x9";
        ErrorMessage = "";
    }
}