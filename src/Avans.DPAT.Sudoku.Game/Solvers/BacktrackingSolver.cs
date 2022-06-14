using Avans.DPAT.Sudoku.Game.Extensions;

namespace Avans.DPAT.Sudoku.Game.Solvers;

public class BacktrackingSolver : ISolver
{
    public void Visit(Sudoku sudoku)
    {
        Solve(sudoku);
    }

    public bool Solve(Sudoku sudoku)
    {
        var cell = sudoku.Cells.FirstEmptyCell();
        if (cell == null) return true;

        for (var i = 1; i <= sudoku.Numbers; i++)
        {
            if (!sudoku.Grid.IsValid(cell.Position, i)) continue;

            cell.Value = i;
            if (Solve(sudoku)) return true;

            cell.Value = null;
        }
        return false;
    }
}
