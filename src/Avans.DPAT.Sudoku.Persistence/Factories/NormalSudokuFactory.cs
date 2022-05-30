using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class NormalSudokuFactory : BaseNormalSudokuFactory
{
    protected override int Build(File file)
    {
        AddSudoku(file.Contents);

        return (int)Math.Sqrt(file.Contents.Length);
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
