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
        System.Console.Clear();
        System.Console.WriteLine("Welkom bij de beste Sudoku.\n");

        if (_model.SudokuPath == "")
        {
            System.Console.Write("Vul file path in: ");
            _model.SudokuPath = System.Console.ReadLine();
        }
        System.Console.Clear();
        System.Console.WriteLine("Welkom bij de beste Sudoku.\n");
            
        System.Console.WriteLine("Instellingen:");
        System.Console.WriteLine($"1) Weergave: {(_model.SimpleDisplay ? "Simple" : "Advanced")}");
        System.Console.WriteLine($"2) File Path: '{_model.SudokuPath ?? "None"}'");
        if (_model.ErrorMessage != "")
        {
            System.Console.WriteLine(_model.ErrorMessage.Pastel(Color.OrangeRed));
        }
            
        System.Console.WriteLine("Opties:");
        System.Console.WriteLine(" - To toggle the display mode press 'D'");
        System.Console.WriteLine(" - To change the file path mode press 'F'");
        System.Console.WriteLine(" - Press 'S' to start the game");
    }
}
