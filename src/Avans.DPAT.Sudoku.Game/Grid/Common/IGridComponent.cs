namespace Avans.DPAT.Sudoku.Game.Grid.Common;

public interface IGridComponent
{
    void Flatten(GridCell[,] grid);
    
    IEnumerable<IGridComponent> ToList();
}
