using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Game.Solvers;

namespace Avans.DPAT.Sudoku.Console.Commands;

public class SolveCommand : ICommand
{
    private readonly ISolver _solver;

    public SolveCommand(ISolver solver)
    {
        _solver = solver;
    }

    public void Execute(GameModel model)
    {
        model.Game.Accept(_solver);
    }
}
