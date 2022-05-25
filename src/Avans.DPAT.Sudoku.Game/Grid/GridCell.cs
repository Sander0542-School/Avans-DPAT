using System.Drawing;
using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class GridCell : IGridComponent, ICell
{
    private readonly Point _position;

    public GridCell(Point position)
    {
        _position = position;
    }
}
