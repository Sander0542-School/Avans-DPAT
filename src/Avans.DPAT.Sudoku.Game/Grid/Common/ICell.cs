using System.Drawing;

namespace Avans.DPAT.Sudoku.Game.Grid.Common;

public interface ICell
{
    public Point Position { get; }

    public int GridId { get; }

    public int? Value { get; set; }

    public bool Final { get; }

    public int? Hint { get; set; }
    
    public bool Valid { get; set; }
}
