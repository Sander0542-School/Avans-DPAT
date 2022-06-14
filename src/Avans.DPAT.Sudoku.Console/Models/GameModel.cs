using System.Drawing;
using Avans.DPAT.Sudoku.Game.Extensions;

namespace Avans.DPAT.Sudoku.Console.Models;

public class GameModel
{
    public Point Position { get; private set; }
    public Game.Sudoku Game { get; private set; }
    
    public string ErrorMessage { get; set; }
    
    public GameModel(Game.Sudoku game)
    {
        Game = game;
        ErrorMessage = "";
    }
    
    public void Move(Size size)
    {
        var newPos = Position + size;
        if (Game.Cells.Get(newPos) != null)
        {
            Position = newPos;
        }
    }
}