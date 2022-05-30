using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class SamuraiSudokuFactory : BaseNormalSudokuFactory
{
    public override Game.Sudoku CreateSudoku(File file)
    {
        throw new NotImplementedException();
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
