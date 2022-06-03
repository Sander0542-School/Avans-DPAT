using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class GridCell : IGridComponent, ICell
{
    public Point Position { get; }

    public int? Value { get; }

    public int? Hint { get; set; } = null;

    public GridCell(Point location, int value)
    {
        Position = location;
        Value = value == 0 ? null : value;
    }

    public void Flatten(GridCell[,] grid)
    {
        if (grid[Position.X, Position.Y] == null)
        {
            grid[Position.X, Position.Y] = this;
        }
    }
}
