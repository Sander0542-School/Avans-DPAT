using System.Text;
using Avans.DPAT.Sudoku.Console;

Console.OutputEncoding = Encoding.UTF8;

ConsoleKey key;
MenuController controller = new MenuController();
while ((key = Console.ReadKey(true).Key) != ConsoleKey.Escape)
{
    controller.Update(key);
}