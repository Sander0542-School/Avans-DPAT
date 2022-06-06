using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Persistence.Builders;
using Avans.DPAT.Sudoku.Persistence.Extensions;
using Avans.DPAT.Sudoku.Persistence.Utils;
using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public abstract class BaseNormalSudokuFactory : ISudokuFactory
{
    private readonly SudokuBuilder _sudokuBuilder;
    private readonly List<GridCell> _cells;

    protected BaseNormalSudokuFactory()
    {
        _sudokuBuilder = new();
        _cells = new();
    }

    public abstract bool Supports(File file);

    protected abstract (int, int) Build(File file);

    public Game.Sudoku CreateSudoku(File file)
    {
        var (numbers, length) = Build(file);
        return _sudokuBuilder.Build(numbers, length);
    }

    public void AddSudoku(string line, int offsetX = 0, int offsetY = 0)
    {
        var length = SizeUtil.CalcLength(line.Length);
        var (width, height) = SizeUtil.CalcWithHeight(length);

        var subBuilders = GridBuilder.CreateSubBuilders(length);
        _sudokuBuilder.AddSubGrids(subBuilders);

        for (var y = 0; y < length; y++)
        {
            for (var x = 0; x < length; x++)
            {
                var value = int.Parse(line[y * length + x].ToString());

                var yScale = y / height;
                var xScale = x / width;
                var groupId = yScale * height + xScale;

                var cell = _cells.GetOrAdd(new(x + offsetX, y + offsetY), groupId, value);

                subBuilders[0][y].AddLeaf(cell);
                subBuilders[1][x].AddLeaf(cell);
                subBuilders[2][groupId].AddLeaf(cell);
            }
        }
    }
}
