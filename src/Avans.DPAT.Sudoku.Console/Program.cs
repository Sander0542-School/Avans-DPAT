using System.Text;
using Avans.DPAT.Sudoku.Console;
using Avans.DPAT.Sudoku.Console.Models;
using Avans.DPAT.Sudoku.Console.Views;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;

Console.OutputEncoding = Encoding.UTF8;

ConsoleKey key;
MenuController controller = new MenuController();
while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape)
{
    controller.Update(key);
}