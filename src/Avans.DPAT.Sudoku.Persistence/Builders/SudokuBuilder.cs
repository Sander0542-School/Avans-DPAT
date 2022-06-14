using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Persistence.Builders;

public class SudokuBuilder
{
    private readonly List<GridBuilder> _grids;

    public SudokuBuilder()
    {
        _grids = new();
    }

    public SudokuBuilder AddGrid(GridBuilder grid)
    {
        _grids.Add(grid);

        return this;
    }

    public SudokuBuilder AddSubGrids<T>(Dictionary<T, List<GridBuilder>> subGrids) where T : notnull
    {
        foreach (var builder in subGrids.SelectMany(pair => pair.Value))
        {
            AddGrid(builder);
        }

        return this;
    }

    public Game.Sudoku Build(int numbers, int length)
    {
        var gridBuilder = new GridBuilder();
        if (_grids.Count == 1)
        {
            gridBuilder = _grids[0];
        }
        else
        {
            gridBuilder.AddGrids(_grids);
        }

        return new(numbers, length, gridBuilder.Build());
    }
}
