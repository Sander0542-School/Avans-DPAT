using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Persistence.Builders;

public class GridBuilder
{
    private readonly int _gridId;

    private readonly List<GridBuilder> _builders;
    private readonly List<Func<int, IGridComponent>> _leaves;

    public GridBuilder(int gridId)
    {
        _gridId = gridId;

        _builders = new();
        _leaves = new();
    }

    public GridBuilder AddGrid(GridBuilder builder)
    {
        _builders.Add(builder);

        return this;
    }

    public GridBuilder AddCell(Point location, int value)
    {
        _leaves.Add(gridId => new GridCell(location, gridId, value));

        return this;
    }

    public GridComposite Build()
    {
        var children = new List<IGridComponent>(_builders.Select(builder => builder.Build()));
        children.AddRange(_leaves.Select(func => func(_gridId)));

        return new(children);
    }
}
