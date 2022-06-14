using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Avans.DPAT.Sudoku.Game.Solvers;

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

    public int Height => Cells.GetLength(0);

    public int Width => Cells.GetLength(1);

    public void Accept(ISolver solver)
    {
        solver.Visit(this);
    }
}
