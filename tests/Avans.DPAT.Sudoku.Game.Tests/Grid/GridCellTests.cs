using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests;

public class GridCellTests
{
    [Fact]
    public void Test_Constructor()
    {
        var cell = new GridCell(new(5, 8), 4, 8);
        Assert.Equal(new(5, 8), cell.Position);
        Assert.Equal(4, cell.GridId);
        Assert.Equal(8, cell.Value);
        Assert.True(cell.Final);
        Assert.Null(cell.Hint);
    }

    [Fact]
    public void Test_ToString()
    {
        var cell = new GridCell(new(5, 8), 4, 8);
        Assert.Equal("GridCell(5,8)[8]", cell.ToString());
    }

    [Fact]
    public void Test_Hint()
    {
        var cell = new GridCell(new(5, 8), 4, 8);
        Assert.Null(cell.Hint);
        cell.Hint = 5;
        Assert.Equal(5, cell.Hint);
    }

    [Fact]
    public void Test_Equality_True()
    {
        var cell1 = new GridCell(new(5, 8), 4, 8);
        var cell2 = new GridCell(new(5, 8), 4, 8);
        Assert.True(cell1.Equals(cell2));
        Assert.Equal(cell1, cell2);
        Assert.Equal(cell1.GetHashCode(), cell2.GetHashCode());
    }

    [Fact]
    public void Test_Equality_False_TwoGridCells()
    {
        var cell1 = new GridCell(new(5, 8), 4, 8);
        var cell2 = new GridCell(new(8, 5), 8, 4);
        Assert.False(cell1.Equals(cell2));
        Assert.NotEqual(cell1, cell2);
        Assert.NotEqual(cell1.GetHashCode(), cell2.GetHashCode());
    }

    [Fact]
    public void Test_Equality_False_DifferentObjects()
    {
        var cell = new GridCell(new(5, 8), 4, 8);
        var point = new Point(5, 8);
        Assert.False(cell.Equals(point));
        Assert.NotEqual(cell.GetHashCode(), point.GetHashCode());
    }
}
