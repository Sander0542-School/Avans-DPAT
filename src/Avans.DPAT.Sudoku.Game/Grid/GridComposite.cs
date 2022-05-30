using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class GridComposite : IGridComponent
{
    private readonly IList<IGridComponent> _children;

    public GridComposite(IList<IGridComponent> children)
    {
        _children = children;
    }

    public void Flatten(GridCell[,] grid)
    {
        foreach (var component in _children)
        {
            component.Flatten(grid);
        }
    }
}
