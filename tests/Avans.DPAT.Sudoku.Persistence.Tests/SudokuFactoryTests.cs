using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;
using Xunit;

namespace Avans.DPAT.Sudoku.Persistence.Tests;

public class SudokuFactoryTests
{
    [Fact]
    public void Test_Factory_Works()
    {
        var file = new FileSystemFileLoader().Load("Puzzles/puzzle.9x9");
        
        var factory = new SudokuFactory();
        var sudoku = factory.CreateSudoku(file);
        
        Assert.NotNull(sudoku);
    }
}
