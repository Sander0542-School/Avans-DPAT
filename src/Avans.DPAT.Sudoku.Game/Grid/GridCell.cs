using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class GridCell : IGridComponent, ICell
{
    public Point Position { get; }

    public int GridId { get; }

    public int? Value { get; }

    public int? Hint { get; set; } = null;

    public GridCell(Point location, int gridId, int value)
    {
        Position = location;
        GridId = gridId;
        Value = value == 0 ? null : value;
    }

    public IEnumerable<IGridComponent> ToList()
    {
        return new List<IGridComponent> { this };
    }

    public override bool Equals(object? obj)
    {
        if (obj is GridCell other)
        {
            return other.Position == Position && other.Value == Value;
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, Value);
    }

    public override string ToString()
    {
        return $"GridCell({Position.X}, {Position.Y})[{Value}]";
    }
}
