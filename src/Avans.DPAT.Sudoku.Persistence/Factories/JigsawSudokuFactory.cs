using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class JigsawSudokuFactory : ISudokuFactory
{
    public Game.Sudoku CreateSudoku(File file)
    {
        throw new NotImplementedException();
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
