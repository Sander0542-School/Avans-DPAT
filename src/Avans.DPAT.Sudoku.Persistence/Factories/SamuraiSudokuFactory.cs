using Avans.DPAT.Sudoku.Persistence.Extensions;
using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class SamuraiSudokuFactory : BaseNormalSudokuFactory
{
    protected override (int, int) Build(File file)
    {
        var lines = file.Lines();
        AddSudoku(lines[0], 0, 0);
        AddSudoku(lines[0], 12, 0);
        AddSudoku(lines[0], 6, 6);
        AddSudoku(lines[0], 0, 12);
        AddSudoku(lines[0], 12, 12);

        return (9, 21);
    }

    public override bool Supports(File file)
    {
        return file.Extension switch
        {
            ".samurai" => true,
            _ => false
        };
    }
}
