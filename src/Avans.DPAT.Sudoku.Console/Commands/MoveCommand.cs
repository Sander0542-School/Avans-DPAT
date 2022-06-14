using System.Drawing;
using Avans.DPAT.Sudoku.Console.Models;

namespace Avans.DPAT.Sudoku.Console.Commands;

public class MoveCommand : ICommand
{
    private readonly Size _size;

    public MoveCommand(Size size)
    {
        _size = size;
    }

    public void Execute(GameModel model)
    {
        model.Move(_size);
    }
}
