using System.Drawing;
using Avans.DPAT.Sudoku.Console.Builders;
using Avans.DPAT.Sudoku.Console.Extensions;
using Avans.DPAT.Sudoku.Console.Models;
using Pastel;

namespace Avans.DPAT.Sudoku.Console.Views;

public class SudokuView
{
    private readonly GameModel _model;

    public SudokuView(GameModel model)
    {
        _model = model;
    }
    public void Render()
    {
        var height = _model.Game.Height();
        var width = _model.Game.Width();

        var builder = new SudokuBufferBuilder(height, width);
        builder.AddRule((cell, value) => {
            if (cell.Position == _model.Position)
            {
                return value.Pastel(Color.Black).PastelBg(Color.DimGray);
            }
            if (cell.Final)
            {
                return value.Pastel(Color.Black).PastelBg(Color.Yellow);
            }

            return value;
        });
        builder.AddCells(_model.Game.Cells);

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
