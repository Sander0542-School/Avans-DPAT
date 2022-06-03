using Avans.DPAT.Sudoku.Game.Grid;

namespace Avans.DPAT.Sudoku.Game;

public class Sudoku
{
    public readonly int Numbers;

    public readonly GridComposite Grid;

    public Sudoku(int numbers, GridComposite grid)
    {
        Numbers = numbers;
        Grid = grid;
    }
}
