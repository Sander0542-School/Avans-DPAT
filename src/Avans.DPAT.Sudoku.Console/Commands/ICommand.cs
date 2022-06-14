using Avans.DPAT.Sudoku.Console.Models;

namespace Avans.DPAT.Sudoku.Console.Commands;

public interface ICommand
{
    void Execute(GameModel model);
}
