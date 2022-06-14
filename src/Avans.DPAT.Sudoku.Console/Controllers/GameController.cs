using System.Drawing;
using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Console.Views;
using Avans.DPAT.Sudoku.Game.Exceptions;
using Avans.DPAT.Sudoku.Game.Solvers;
using Avans.DPAT.Sudoku.Game.States;

namespace Avans.DPAT.Sudoku.Console;

public class GameController
{
    private readonly SudokuView _view;
    private readonly GameModel _model;

    public GameController(GameModel model)
    {
        _view = new(model);
        _model = model;

        _view.Render();
    }

    public void Start()
    {
        while (_model.Game.Finished == false)
        {
            Update(System.Console.ReadKey(true).Key);
            _view.Render();
        }
    }

    public void Update(ConsoleKey key)
    {
        if (key == ConsoleKey.H)
        {
            _model.Game.ChangeState(new HintState(_model.Game));
        }
        else if (key == ConsoleKey.N)
        {
            _model.Game.ChangeState(new NormalState(_model.Game));
        }
        else if (key == ConsoleKey.S)
        {
            _model.Game.Accept(new BacktrackingSolver());
        }
        else if (key == ConsoleKey.C)
        {
            _model.Game.Validate();
        }
        else if (key == ConsoleKey.UpArrow)
        {
            _model.Move(new(0, -1));
        }
        else if (key == ConsoleKey.DownArrow)
        {
            _model.Move(new(0, 1));
        }
        else if (key == ConsoleKey.LeftArrow)
        {
            _model.Move(new(-1, 0));
        }
        else if (key == ConsoleKey.RightArrow)
        {
            _model.Move(new(1, 0));
        }
        else if (key is >= ConsoleKey.D1 and <= ConsoleKey.D9)
        {
            var number = (int)key - (int)ConsoleKey.D0;
            try
            {
                _model.Game.PlaceNumber(_model.Position, number);
            }
            catch (SudokuPlacementException e)
            {
                _model.ErrorMessage = e.Message;
            }
        }
    }
}
