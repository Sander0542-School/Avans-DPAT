using Avans.DPAT.Sudoku.Game.Extensions;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests.Extensions;

public class ArrayExtensionsTests
{
    [Fact]
    public void Test_Get_ReturnsCell()
    {
        var grid = new ICell[1, 1];

        Assert.Null(grid.Get(new(0, 0)));

        grid[0, 0] = new GridCell(new(0, 0), 1, 1);

        Assert.NotNull(grid.Get(new(0, 0)));
    }

    [Theory]
    [InlineData(-5, -5)]// top left
    [InlineData(-5, 0)]// top middle
    [InlineData(-5, 5)]// top right
    [InlineData(0, -5)]// middle left
    [InlineData(0, 5)]// middle right
    [InlineData(5, -5)]// bottom left
    [InlineData(5, 0)]// bottom middle
    [InlineData(5, 5)]// bottom right
    public void Test_Get_ReturnsNull_OutOfRange(int y, int x)
    {
        var grid = new ICell[1, 1];
        Assert.Null(grid.Get(new(x, y)));
    }

    [Fact]
    public void Test_Set_SetsCell()
    {
        var grid = new ICell[1, 1];
        grid.Set(new(0, 0), new GridCell(new(0, 0), 1, 1));
        Assert.NotNull(grid.Get(new(0, 0)));
    }

    [Theory]
    [InlineData(-5, -5)]// top left
    [InlineData(-5, 0)]// top middle
    [InlineData(-5, 5)]// top right
    [InlineData(0, -5)]// middle left
    [InlineData(0, 5)]// middle right
    [InlineData(5, -5)]// bottom left
    [InlineData(5, 0)]// bottom middle
    [InlineData(5, 5)]// bottom right
    public void Test_Set_DoesNothing_OutOfRange(int y, int x)
    {
        var grid = new ICell[1, 1];
        grid.Set(new(x, y), new GridCell(new(x, y), 1, 1));
        Assert.Null(grid.Get(new(x, y)));
    }
}
