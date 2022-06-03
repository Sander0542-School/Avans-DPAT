using System;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;
using Avans.DPAT.Sudoku.Persistence.Models;
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

    [Fact]
    public void Test_Jigsaw_Loads()
    {
        var file = new FileSystemFileLoader().Load("Puzzles/puzzle.jigsaw");

        var factory = new JigsawSudokuFactory();
        var sudoku = factory.CreateSudoku(file);

        Assert.Equal(81, sudoku.Cells.Length);
    }

    [Theory]
    [InlineData("Puzzles/puzzle.4x4")]
    [InlineData("Puzzles/puzzle.6x6")]
    [InlineData("Puzzles/puzzle.9x9")]
    [InlineData("Puzzles/puzzle.samurai")]
    [InlineData("Puzzles/puzzle.jigsaw")]
    public void Test_Factory_Loads(string filePath)
    {
        var file = new FileSystemFileLoader().Load(filePath);

        var factory = new SudokuFactory();
        Assert.True(factory.Supports(file));

        var sudoku = factory.CreateSudoku(file);

        Assert.NotNull(sudoku);
    }

    [Fact]
    public void Test_Factory_DoesntSupport_InvalidExtension()
    {
        var file = new File("Puzzles/puzzle.invalid", "01024274300");

        var factory = new SudokuFactory();
        Assert.False(factory.Supports(file));
    }

    [Fact]
    public void Test_Factory_ThrowException_InvalidExtension()
    {
        var file = new File("Puzzles/puzzle.invalid", "01024274300");

        var factory = new SudokuFactory();
        Assert.Throws<NotImplementedException>(() => factory.CreateSudoku(file));
    }
}
