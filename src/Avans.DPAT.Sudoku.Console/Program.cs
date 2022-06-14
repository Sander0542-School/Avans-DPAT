using System.Text;
using Avans.DPAT.Sudoku.Console;
using Avans.DPAT.Sudoku.Console.Controllers;

Console.OutputEncoding = Encoding.UTF8;

ConsoleKey key;
MenuController controller = new MenuController();
while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape)
{
    controller.Update(key);
}