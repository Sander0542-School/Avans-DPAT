using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game;

public class Sudoku
{
    public readonly int Numbers;
    public readonly int Length;

    public readonly GridComposite Grid;

    public readonly ICell[,] Cells;

    public Sudoku(int numbers, int length, GridComposite grid)
    {
        Numbers = numbers;
        Length = length;
        Grid = grid;

        var cells = grid.ToList().OfType<ICell>().Distinct().ToList();

        var maxX = cells.Max(cell => cell.Position.X);
        var maxY = cells.Max(cell => cell.Position.Y);

        Cells = new ICell[maxX + 1, maxY + 1];
        foreach (var cell in cells)
        {
            Cells[cell.Position.Y, cell.Position.X] = cell;
        }
    }
    
    //place number on cell
    public void PlaceNumber(int number, Point point)
    {
        var cell = Cells.where(point);
        cell.SetNumber(number);
    }
    
}
