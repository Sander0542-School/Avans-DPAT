using System.Collections.Generic;
using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Xunit;

namespace Avans.DPAT.Sudoku.Game.Tests;

public class GridCompositeTests
{
    [Fact]
    public void Test_GridComposite_IsValid_False_SameNumberExists()
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
    public void Test_GridComposite_IsValid_True_NumberDoesntExists()
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
    public void Test_GridComposite_IsValid_True_SubGridComposite()
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
    public void Test_GridComposite_IsValid_True_Empty()
    {
        var gridComposite = new GridComposite(new List<IGridComponent>());

        Assert.True(gridComposite.IsValid(new(0, 0), 1));
    }
}
