using System.Drawing;
using Avans.DPAT.Sudoku.Game.Exceptions;
using Avans.DPAT.Sudoku.Game.Extensions;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.States;

public class NormalState : IState
{
    private readonly Sudoku _sudoku;

    public NormalState(Sudoku sudoku)
    {
        _sudoku = sudoku;
    }

    public void PlaceNumber(Point point, int? number)
    {
        if (number > _sudoku.Numbers) throw new SudokuPlacementException("This number cannot be placed in the sudoku");

        var cell = _sudoku.Cells.Get(point);

        if (cell == null) throw new SudokuPlacementException("Cell does not exist");
        if (cell.Final) throw new SudokuPlacementException("Cannot place number in final cell");

        cell.Value = number;
    }

    public int? GetCellDisplay(ICell cell)
    {
        return cell.Value;
    }
}
