using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Console.Views;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;

namespace Avans.DPAT.Sudoku.Console;

public class MenuController : IController
{
    private readonly MenuView _view;
    private readonly MenuModel _model;
    
    private readonly FileSystemFileLoader _fileLoader;

    public MenuController()
    {
        _model = new();
        _view = new(_model);
        _fileLoader = new();

        _view.Render();
    }


    public void Update(ConsoleKey key)
    {
        if (key == ConsoleKey.F)
        {
            _model.SudokuPath = "";
            _model.ErrorMessage = "";
        }
        else if (key == ConsoleKey.S)
        {
            if (string.IsNullOrWhiteSpace(_model.SudokuPath))
            {
                try
                {
                    CreateNewGame();
                    return;
                }
                catch (Exception ex)
                {
                    _model.ErrorMessage = ex.Message;
                }
            }
        }

        _view.Render();
    }

    private void CreateNewGame()
    {
        var file = _fileLoader.Load(_model.SudokuPath);

        var sudoku = new SudokuFactory().CreateSudoku(file);

        var controller = new GameController(new(sudoku));

        controller.Start();
    }
}
