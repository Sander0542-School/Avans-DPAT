using Avans.DPAT.Sudoku.Console.Models;

namespace Avans.DPAT.Sudoku.Console.Commands;

public class CheckCommand : ICommand
{
    public void Execute(GameModel model)
    {
        model.Game.Validate();
    }
}
