using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Extensions;

public static class CellExtensions
{
    public static ICell? Below(this ICell cell, ICell[,] cells)
    {
        var newPoint = cell.Position with
        {
            Y = cell.Position.Y + 1
        };
        return cells.Get(newPoint);
    }

    public static ICell? Right(this ICell cell, ICell[,] cells)
    {
        var newPoint = cell.Position with
        {
            X = cell.Position.X + 1
        };
        return cells.Get(newPoint);
    }
}
