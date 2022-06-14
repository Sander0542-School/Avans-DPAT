namespace Avans.DPAT.Sudoku.Console.Models;

public class MenuModel
{
    public bool SimpleDisplay { get; set; }
    public string SudokuPath { get; set; }
    public string ErrorMessage { get; set; }

    public MenuModel()
    {
        SimpleDisplay = true;
        SudokuPath = "Puzzles/puzzle2.jigsaw";
        ErrorMessage = "";
    }
}