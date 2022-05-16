using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public interface ISudokuFactory
{
    public Game.Sudoku CreateSudoku(File file);
}
