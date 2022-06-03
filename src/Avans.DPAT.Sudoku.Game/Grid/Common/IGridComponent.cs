namespace Avans.DPAT.Sudoku.Game.Grid.Common;

public interface IGridComponent
{
    IEnumerable<IGridComponent> ToList();
}
