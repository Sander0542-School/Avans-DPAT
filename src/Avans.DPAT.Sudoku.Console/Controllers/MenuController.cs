using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Console.Views;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;

namespace Avans.DPAT.Sudoku.Console;

public class MenuController: IController
{
    private readonly MenuView _view;
    private readonly MenuModel _model;
    private readonly FileSystemFileLoader _gameLoader;

    public MenuController()
    {
        _model = new MenuModel();
        _view = new MenuView(_model);
        _gameLoader = new FileSystemFileLoader();
        
        _view.Render();
    }
    

    public void Update(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.F: // Change file path
                _model.SudokuPath = "";
                _model.ErrorMessage = "";
                break;
            case ConsoleKey.S: // Start game (if file is set)
                if (_model.SudokuPath != null)
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
                break;
            default: return;
        }

        _view.Render();
    }

    private void CreateNewGame()
    {
        ConsoleKey key;
        var file = _gameLoader.Load(_model.SudokuPath);

        var factory = new SudokuFactory();
        var sudoku = factory.CreateSudoku(file);
        var model = new GameModel(sudoku);
        var controller = new GameController(model);

        while ((key = System.Console.ReadKey(true).Key) != ConsoleKey.Escape)
        {
            controller.Update(key);
        }
    }
}