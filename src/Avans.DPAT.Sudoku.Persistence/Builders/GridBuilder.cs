using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Persistence.Builders;

public class GridBuilder
{
    private readonly List<GridBuilder> _builders;
    private readonly List<IGridComponent> _leaves;

    public GridBuilder()
    {
        _builders = new();
        _leaves = new();
    }

    public GridBuilder AddGrid(GridBuilder builder)
    {
        _builders.Add(builder);

        return this;
    }

    public GridBuilder AddGrids(IEnumerable<GridBuilder> builders)
    {
        _builders.AddRange(builders);

        return this;
    }

    public GridBuilder AddLeaf(IGridComponent leaf)
    {
        _leaves.Add(leaf);

        return this;
    }

    public GridComposite Build()
    {
        var children = new List<IGridComponent>(_builders.Select(builder => builder.Build()));
        children.AddRange(_leaves);

        return new(children);
    }

    public static Dictionary<int, List<GridBuilder>> CreateSubBuilders(int amount)
    {
        var subBuilders = new Dictionary<int, List<GridBuilder>>(3);
        for (var i = 0; i < 3; i++)
        {
            var builders = new List<GridBuilder>(amount);
            for (var j = 0; j < builders.Capacity; j++)
            {
                builders.Add(new());
            }
            subBuilders.Add(i, builders);
        }
        return subBuilders;
    }
}
