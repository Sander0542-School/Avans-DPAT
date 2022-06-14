using Avans.DPAT.Sudoku.Console.Commands;
using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Console.Views;
using Avans.DPAT.Sudoku.Game.Solvers;

namespace Avans.DPAT.Sudoku.Console.Controllers;

public class GameController
{
    private readonly SudokuView _view;
    private readonly GameModel _model;

    private readonly Dictionary<ConsoleKey, ICommand> _commands;

    public GameController(GameModel model)
    {
        _view = new(model);
        _model = model;

        _commands = new();
        LoadCommands();

        _view.Render();
    }

    public void Start()
    {
        while (_model.Game.IsFilled() == false)
        {
            Update(System.Console.ReadKey(true).Key);
            _view.Render();
        }

        System.Console.WriteLine(_model.Game.Validate() ? "You win!" : "You lose!");
        System.Console.WriteLine("Press any key to exit...");
        System.Console.ReadKey();
    }

    public void Update(ConsoleKey key)
    {
        if (_commands.ContainsKey(key))
        {
            _commands[key].Execute(_model);
        }
    }

    private void LoadCommands()
    {
    }
}
