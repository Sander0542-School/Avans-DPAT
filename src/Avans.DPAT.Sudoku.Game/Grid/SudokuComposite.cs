using Avans.DPAT.Sudoku.Game.Grid.Common;

namespace Avans.DPAT.Sudoku.Game.Grid;

public class SudokuComposite : GridComposite
{
    public SudokuComposite(IList<IGridComponent> children) : base(children)
    {
    }
}
