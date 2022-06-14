using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Game.States;

namespace Avans.DPAT.Sudoku.Console.Commands;

public class HintStateCommand : ICommand
{
    public void Execute(GameModel model)
    {
        model.Game.ChangeState(new HintState(model.Game));
    }
}
