using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.States;

public interface IState
{
    void PlaceNumber(Point point, int? number);

    int? GetCellDisplay(ICell cell);
}
