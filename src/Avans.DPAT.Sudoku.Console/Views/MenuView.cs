using System.Drawing;
using System.Text;
using Avans.DPAT.Sudoku.Console.Models;
using Pastel;

namespace Avans.DPAT.Sudoku.Console.Views;

public class MenuView
{
    private readonly MenuModel _model;

    public MenuView(MenuModel model)
    {
        _model = model;
    }

    public void Render()
    {
        RenderHeader();
        if (_model.SudokuPath == "")
        {
            System.Console.Write("File Path: ");
            _model.SudokuPath = System.Console.ReadLine();
        }

        RenderHeader();
        System.Console.WriteLine("Settings:");
        System.Console.WriteLine($"File: {_model.SudokuPath}");
        if (_model.ErrorMessage != "")
        {
            System.Console.WriteLine();
            System.Console.WriteLine(_model.ErrorMessage.Pastel(Color.OrangeRed));
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Keybindings:");
        System.Console.WriteLine("F: Change file path");
        System.Console.WriteLine("S: Start game");
    }

    private static void RenderHeader()
    {
        System.Console.Clear();
        System.Console.WriteLine("Sudoku App");
        System.Console.WriteLine();
    }
}
