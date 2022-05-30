using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public abstract class BaseNormalSudokuFactory : ISudokuFactory
{
    public abstract Game.Sudoku CreateSudoku(File file);

    public abstract bool Supports(File file);
}
