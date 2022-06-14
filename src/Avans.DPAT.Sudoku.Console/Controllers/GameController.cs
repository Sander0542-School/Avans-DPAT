using System.Drawing;
using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Console.Views;

namespace Avans.DPAT.Sudoku.Console;

public class GameController
{
    private readonly SudokuView _view;
    private readonly GameModel _model;

    public GameController(GameModel model)
    {
        _view = new SudokuView(model);
        _model = model;
        
        _view.Render();
    }
    
    public void Update(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                _model.Move(new Size(0, -1));
                _view.Render();
                break;
            case ConsoleKey.DownArrow:
                _model.Move(new Size(0, 1));
                _view.Render();
                break;
            case ConsoleKey.LeftArrow:
                _model.Move(new Size(-1, 0));
                _view.Render();
                break;
            case ConsoleKey.RightArrow:
                _model.Move(new Size(1, 0));
                _view.Render();
                break;
            // case ConsoleKey.Enter:
            //     _model.SetValue();
            //     break;
            //     case ConsoleKey.Backspace:
            //         _model.SwitchEditMode();
            //         break;
            //     case ConsoleKey.Spacebar:
            //         _model.SwitchEditMode();
            //         break;
            //     // Placing number
            case ConsoleKey.D1:
            case ConsoleKey.D2:
            case ConsoleKey.D3:
            case ConsoleKey.D4:
            case ConsoleKey.D5:
            case ConsoleKey.D6:
            case ConsoleKey.D7:
            case ConsoleKey.D8:
            case ConsoleKey.D9:
            {
                try
                {
                    _model.Game.PlaceNumber(_model.Position, (int) key - (int) ConsoleKey.D0);
                }
                catch (Exception ex)
                {
                    _model.ErrorMessage = ex.Message;
                }
                break;
            }
            default: return;
            // }
        }
    }
}