using Avans.DPAT.Sudoku.Persistence.Extensions;
using Avans.DPAT.Sudoku.Persistence.Utils;
using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class NormalSudokuFactory : BaseNormalSudokuFactory
{
    protected override (int, int) Build(File file)
    {
        var line = file.Lines()[0];
        AddSudoku(line);

        var length = SizeUtil.CalcLength(line.Length);

        return (length, length);
    }

    public override bool Supports(File file)
    {
        return file.Extension switch
        {
            ".4x4" => true,
            ".6x6" => true,
            ".9x9" => true,
            _ => false
        };
    }
}
