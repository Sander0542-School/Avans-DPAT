using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Persistence.Builders;
using Avans.DPAT.Sudoku.Persistence.Utils;
using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public abstract class BaseNormalSudokuFactory : ISudokuFactory
{
    private readonly SudokuBuilder _sudokuBuilder;

    protected BaseNormalSudokuFactory()
    {
        _sudokuBuilder = new();
    }

    public abstract bool Supports(File file);

    protected abstract int Build(File file);

    public Game.Sudoku CreateSudoku(File file)
    {
        return _sudokuBuilder.Build(Build(file));
    }

    public void AddSudoku(string line)
    {
        var length = (int)Math.Sqrt(line.Length);
        var (width, height) = SizeUtil.CalcWithHeight(length);

        var subBuilders = new Dictionary<int, List<GridBuilder>>(3);
        for (var i = 0; i < 3; i++)
        {
            var builders = new List<GridBuilder>(length);
            for (var j = 0; j < builders.Capacity; j++)
            {
                builders.Add(new());
            }
            subBuilders.Add(i, builders);
        }

        for (var row = 0; row < length; row++)
        {
            for (var col = 0; col < length; col++)
            {
                var value = int.Parse(line[row * length + col].ToString());

                var cell = new GridCell(new(row, col), value);

                var rowOffset = row / height;
                var colOffset = col / width;
                var groupId = rowOffset * height + colOffset;

                _sudokuBuilder.AddCell(cell);
                subBuilders[0][row].AddLeaf(cell);
                subBuilders[1][col].AddLeaf(cell);
                subBuilders[2][groupId].AddLeaf(cell);
            }
        }

        _sudokuBuilder.AddGrid(new GridBuilder().AddGrids(subBuilders.SelectMany(pair => pair.Value)));
    }
}
