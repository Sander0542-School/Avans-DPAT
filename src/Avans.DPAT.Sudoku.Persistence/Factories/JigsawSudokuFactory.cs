using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Persistence.Builders;
using Avans.DPAT.Sudoku.Persistence.Extensions;
using Avans.DPAT.Sudoku.Persistence.Utils;
using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class JigsawSudokuFactory : ISudokuFactory
{
    public Game.Sudoku CreateSudoku(File file)
    {
        var line = file.Lines()[0][10..];
        var parts = line.Split('=').Select(SplitPart).ToList();
        var length = SizeUtil.CalcLength(parts.Count);

        var sudokuBuilder = new SudokuBuilder();
        var subBuilders = GridBuilder.CreateSubBuilders(length);
        sudokuBuilder.AddSubGrids(subBuilders);
        var cells = new List<GridCell>();

        for (var i = 0; i < parts.Count; i++)
        {
            var part = parts[i];

            var x = i % length;
            var y = i / length;

            var cell = cells.GetOrAdd(new(x, y), part.Key, part.Value);

            subBuilders[0][x].AddLeaf(cell);
            subBuilders[1][y].AddLeaf(cell);
            subBuilders[2][part.Key].AddLeaf(cell);
        }

        return sudokuBuilder.Build(length, length);
    }

    private static KeyValuePair<int, int> SplitPart(string part)
    {
        var tmp = part.Split('J');

        return new(int.Parse(tmp[1]), int.Parse(tmp[0]));
    }

    public bool Supports(File file)
    {
        return file.Extension switch
        {
            ".jigsaw" => true,
            _ => false
        };
    }
}
