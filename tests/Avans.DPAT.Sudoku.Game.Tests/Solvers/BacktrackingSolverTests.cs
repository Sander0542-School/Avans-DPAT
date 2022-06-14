using System.Linq;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Avans.DPAT.Sudoku.Game.Solvers;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests.Solvers;

public class BacktrackingSudokuSolverTests
{
    [Theory]
    [InlineData("Puzzles/puzzle.4x4")]
    [InlineData("Puzzles/puzzle.6x6")]
    [InlineData("Puzzles/puzzle.9x9")]
    // [InlineData("Puzzles/puzzle.samurai")]
    [InlineData("Puzzles/puzzle.jigsaw")]
    public void Test_Backtracking_Solves(string filePath)
    {
        var sudoku = new SudokuFactory().CreateSudoku(new FileSystemFileLoader().Load(filePath));
        var solver = new BacktrackingSolver();

        sudoku.Accept(solver);

        Assert.All(sudoku.Cells.OfType<ICell>(), cell => {
            Assert.True(cell.Value.HasValue);
        });
    }
}
