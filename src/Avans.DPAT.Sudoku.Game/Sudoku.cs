using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Avans.DPAT.Sudoku.Game.Solvers;
using Avans.DPAT.Sudoku.Game.States;

namespace Avans.DPAT.Sudoku.Game;

public class Sudoku : IState
{
    public readonly int Numbers;
    public readonly int Length;

    public readonly GridComposite Grid;

    public readonly ICell[,] Cells;

    public IState State { get; private set; }

    public Sudoku(int numbers, int length, GridComposite grid)
    {
        State = new NormalState(this);

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

    public bool Finished => false;

    public void Accept(ISolver solver)
    {
        solver.Visit(this);
    }

    public void PlaceNumber(Point point, int? number)
    {
        State.PlaceNumber(point, number);
    }

    public int? GetCellDisplay(ICell cell)
    {
        return State.GetCellDisplay(cell);
    }

    public void ChangeState(IState state)
    {
        State = state;
    }

    public void Validate()
    {
    }
}
