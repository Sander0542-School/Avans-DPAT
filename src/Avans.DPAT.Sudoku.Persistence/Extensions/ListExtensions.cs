using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid;

namespace Avans.DPAT.Sudoku.Persistence.Extensions;

public static class ListExtensions
{
    public static GridCell GetOrAdd(this List<GridCell> cells, Point point, int gridId, int value)
    {
        var cell = cells.FirstOrDefault(cell => cell.Position == point);
        if (cell == null)
        {
            cell = new(point, gridId, value);
            cells.Add(cell);
        }

        return cell;
    }
}
