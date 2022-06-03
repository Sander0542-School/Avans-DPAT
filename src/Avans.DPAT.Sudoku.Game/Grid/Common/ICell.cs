using System.Drawing;

namespace Avans.DPAT.Sudoku.Game.Grid.Common;

public interface ICell
{
    public Point Position { get; }

    public int? Value { get; }

    public int? Hint { get; set; }
}
