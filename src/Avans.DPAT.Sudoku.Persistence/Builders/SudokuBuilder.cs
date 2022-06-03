using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Persistence.Builders;

public class SudokuBuilder
{
    private readonly List<GridBuilder> _grids;
    private readonly List<ICell> _cells;

    public SudokuBuilder()
    {
        _grids = new();
        _cells = new();
    }

    public SudokuBuilder AddGrid(GridBuilder grid)
    {
        _grids.Add(grid);

        return this;
    }

    public SudokuBuilder AddCell(ICell cell)
    {
        _cells.Add(cell);

        return this;
    }

    public Game.Sudoku Build(int length)
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

        return new(length, gridBuilder.Build());
    }
}
