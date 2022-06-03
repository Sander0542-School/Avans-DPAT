using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;
using Xunit;

namespace Avans.DPAT.Sudoku.Persistence.Tests;

public class SudokuFactoryTests
{
    [Fact]
    public void Test_Normal_9_Loads()
    {
        var file = new FileSystemFileLoader().Load("Puzzles/puzzle.9x9");

        var factory = new NormalSudokuFactory();
        var sudoku = factory.CreateSudoku(file);

        Assert.Equal(81, sudoku.Cells.Length);
    }

    [Fact]
    public void Test_Normal_6_Loads()
    {
        var file = new FileSystemFileLoader().Load("Puzzles/puzzle.6x6");

        var factory = new NormalSudokuFactory();
        var sudoku = factory.CreateSudoku(file);

        Assert.Equal(36, sudoku.Cells.Length);
    }

    [Fact]
    public void Test_Normal_4_Loads()
    {
        var file = new FileSystemFileLoader().Load("Puzzles/puzzle.4x4");

        var factory = new NormalSudokuFactory();
        var sudoku = factory.CreateSudoku(file);

        Assert.Equal(16, sudoku.Cells.Length);
    }

    [Fact]
    public void Test_Samurai_Loads()
    {
        var file = new FileSystemFileLoader().Load("Puzzles/puzzle.samurai");

        var factory = new SamuraiSudokuFactory();
        var sudoku = factory.CreateSudoku(file);

        Assert.Equal(441, sudoku.Cells.Length);
    }
}
