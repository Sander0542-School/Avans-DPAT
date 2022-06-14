using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Game.Exceptions;

namespace Avans.DPAT.Sudoku.Console.Commands;

public class PlaceCommand : ICommand
{
    private readonly int _number;

    public PlaceCommand(int number)
    {
        _number = number;
    }

    public void Execute(GameModel model)
    {
        try
        {
            model.Game.PlaceNumber(model.Position, _number);
        }
        catch (SudokuPlacementException e)
        {
            model.ErrorMessage = e.Message;
        }
    }
}
