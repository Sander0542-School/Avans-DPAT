using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class NormalSudokuFactory : BaseNormalSudokuFactory
{
    public override Game.Sudoku CreateSudoku(File file)
    {
        throw new NotImplementedException();
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
