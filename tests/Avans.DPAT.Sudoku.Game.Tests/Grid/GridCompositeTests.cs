using System.Collections.Generic;
using System.Linq;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests.Grid;

public class GridCompositeTests
{
    [Fact]
    public void Test_IsValid_False_SameNumberExists()
    {
        var leaf1 = new GridCell(new(0, 0), 1, 0);
        var leaf2 = new GridCell(new(1, 0), 1, 2);
        var leaf3 = new GridCell(new(0, 1), 1, 3);
        var leaf4 = new GridCell(new(1, 1), 1, 4);
        var gridComposite = new GridComposite(new List<IGridComponent>
        {
            leaf1,
            leaf2,
            leaf3,
            leaf4
        });

        Assert.False(gridComposite.IsValid(new(0, 0), 2));
    }

    [Fact]
    public void Test_IsValid_True_NumberDoesntExists()
    {
        var leaf1 = new GridCell(new(0, 0), 1, 0);
        var leaf2 = new GridCell(new(1, 0), 1, 2);
        var leaf3 = new GridCell(new(0, 1), 1, 3);
        var leaf4 = new GridCell(new(1, 1), 1, 4);
        var gridComposite = new GridComposite(new List<IGridComponent>
        {
            leaf1,
            leaf2,
            leaf3,
            leaf4
        });

        Assert.True(gridComposite.IsValid(new(0, 0), 1));
    }

    [Fact]
    public void Test_IsValid_True_SubGridComposite()
    {
        var leaf1 = new GridCell(new(0, 0), 1, 0);
        var leaf2 = new GridCell(new(1, 0), 1, 2);
        var leaf3 = new GridCell(new(0, 1), 1, 3);
        var leaf4 = new GridCell(new(1, 1), 1, 4);
        var gridComposite = new GridComposite(new List<IGridComponent>
        {
            leaf1,
            leaf2,
            leaf3,
            leaf4
        });
        var gridComposite2 = new GridComposite(new List<IGridComponent>
        {
            gridComposite
        });

        Assert.True(gridComposite2.IsValid(new(0, 0), 1));
    }

    [Fact]
    public void Test_IsValid_True_Empty()
    {
        var gridComposite = new GridComposite(new List<IGridComponent>());

        Assert.True(gridComposite.IsValid(new(0, 0), 1));
    }

    [Fact]
    public void Test_ToList_Empty()
    {
        var gridComposite = new GridComposite(new List<IGridComponent>());

        Assert.Empty(gridComposite.ToList());
    }

    [Theory]
    [InlineData(3)]
    [InlineData(7)]
    [InlineData(12)]
    public void Test_ToList_Children(int count)
    {
        var children = new List<IGridComponent>(count);
        for (var i = 0; i < count; i++)
        {
            children.Add(new GridCell(new(1, 1), 1, 1));
        }
        var gridComposite = new GridComposite(children);

        Assert.Equal(count, gridComposite.ToList().Count());
    }
}
