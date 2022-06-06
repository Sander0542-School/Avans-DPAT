using System.Drawing;
using Avans.DPAT.Sudoku.Console.Builders;
using Avans.DPAT.Sudoku.Console.Extensions;
using Pastel;

namespace Avans.DPAT.Sudoku.Console.Views;

public class SudokuView
{
    public void Render(Game.Sudoku sudoku)
    {
        var height = sudoku.Height();
        var width = sudoku.Width();

        var builder = new SudokuBufferBuilder(height, width);
        builder.AddRule((cell, value) => {
            if (cell.Final)
            {
                return value.Pastel(Color.Black).PastelBg(Color.Yellow);
            }
            return value;
        });
        builder.AddCells(sudoku.Cells);

        var buffer = builder.Build();

        for (var row = 0; row < buffer.GetLength(0); row++)
        {
            for (var col = 0; col < buffer.GetLength(1); col++)
            {
                System.Console.Write(buffer[row, col] ?? " ");
            }
            System.Console.Write(Environment.NewLine);
        }
    }
}
