using System.Collections.Generic;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests;

public class SudokuTests
{
    [Fact]
    public void Test_Constructor()
    {
        var leaf1 = new GridCell(new(0, 0), 1, 1);
        var leaf2 = new GridCell(new(1, 0), 1, 2);
        var leaf3 = new GridCell(new(0, 1), 2, 2);
        var leaf4 = new GridCell(new(1, 1), 2, 1);
        var sudoku = new Sudoku(2, 2, new(new List<IGridComponent>
        {
            leaf1, leaf2, leaf3, leaf4
        }));

        Assert.NotNull(sudoku);
        Assert.Equal(4, sudoku.Cells.Length);
    }
}
