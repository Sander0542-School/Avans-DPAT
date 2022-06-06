using System.Drawing;

namespace Avans.DPAT.Sudoku.Game.Grid.Common;

public interface IGridComponent
{
    IEnumerable<IGridComponent> ToList();

    bool IsValid(Point point, int number);
    
    bool Contains(Point point);
}
