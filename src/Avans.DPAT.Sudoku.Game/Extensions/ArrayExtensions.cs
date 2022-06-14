using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Extensions;

public static class ArrayExtensions
{
    public static ICell? FirstEmptyCell(this ICell[,] cells)
    {
        return cells.OfType<ICell>().FirstOrDefault(cell => cell.Value.HasValue == false);
    }
}
