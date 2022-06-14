using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Extensions;

public static class ArrayExtensions
{
    public static ICell? FirstEmptyCell(this ICell[,] cells)
    {
        return cells.OfType<ICell>().FirstOrDefault(cell => cell.Value.HasValue == false);
    }

    public static ICell? Get(this ICell[,] array, Point point)
    {
        try
        {
            return array[point.Y, point.X];
        }
        catch (IndexOutOfRangeException)
        {
        }
        return null;
    }

    public static void Set<T>(this T[,] array, Point point, T value)
    {
        array.Set(point.X, point.Y, value);
    }

    public static void Set<T>(this T[,] array, int x, int y, T value)
    {
        try
        {
            array[y, x] = value;
        }
        catch (IndexOutOfRangeException)
        {
        }
    }
}
