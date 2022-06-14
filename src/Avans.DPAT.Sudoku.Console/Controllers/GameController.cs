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
        _commands.Add(ConsoleKey.N, new NormalStateCommand());
        _commands.Add(ConsoleKey.H, new HintStateCommand());
        _commands.Add(ConsoleKey.S, new SolveCommand(new BacktrackingSolver()));
        _commands.Add(ConsoleKey.C, new CheckCommand());
        _commands.Add(ConsoleKey.UpArrow, new MoveCommand(new(0, -1)));
        _commands.Add(ConsoleKey.DownArrow, new MoveCommand(new(0, 1)));
        _commands.Add(ConsoleKey.LeftArrow, new MoveCommand(new(-1, 0)));
        _commands.Add(ConsoleKey.RightArrow, new MoveCommand(new(1, 0)));
        _commands.Add(ConsoleKey.D1, new PlaceCommand(1));
        _commands.Add(ConsoleKey.D2, new PlaceCommand(2));
        _commands.Add(ConsoleKey.D3, new PlaceCommand(3));
        _commands.Add(ConsoleKey.D4, new PlaceCommand(4));
        _commands.Add(ConsoleKey.D5, new PlaceCommand(5));
        _commands.Add(ConsoleKey.D6, new PlaceCommand(6));
        _commands.Add(ConsoleKey.D7, new PlaceCommand(7));
        _commands.Add(ConsoleKey.D8, new PlaceCommand(8));
        _commands.Add(ConsoleKey.D9, new PlaceCommand(9));
    }
}
