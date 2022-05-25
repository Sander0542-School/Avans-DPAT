using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class GridComposite : IGridComponent
{
    private readonly IList<IGridComponent> _children;
    
    public GridComposite(IList<IGridComponent> children)
    {
        _children = children;
    }
}
