using Avans.DPAT.Sudoku.Game.Extensions;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests.Extensions;

public class CellExtensionTests
{
    [Fact]
    public void Test_Below_Returns_Cell()
    {
        var cells = new ICell[2, 2];
        cells[0, 0] = new GridCell(new(0, 0), 1, 1);
        cells[1, 0] = new GridCell(new(1, 0), 1, 2);
        cells[0, 1] = new GridCell(new(0, 1), 2, 2);
        cells[1, 1] = new GridCell(new(1, 1), 2, 1);

        var otherCell = cells[0, 0].Below(cells);

        Assert.NotNull(otherCell);
        Assert.Same(cells[1, 0], otherCell);
    }
    
    [Fact]
    public void Test_Right_Returns_Cell()
    {
        var cells = new ICell[2, 2];
        cells[0, 0] = new GridCell(new(0, 0), 1, 1);
        cells[1, 0] = new GridCell(new(1, 0), 1, 2);
        cells[0, 1] = new GridCell(new(0, 1), 2, 2);
        cells[1, 1] = new GridCell(new(1, 1), 2, 1);

        var otherCell = cells[0, 0].Right(cells);

        Assert.NotNull(otherCell);
        Assert.Same(cells[0, 1], otherCell);
    }
}
