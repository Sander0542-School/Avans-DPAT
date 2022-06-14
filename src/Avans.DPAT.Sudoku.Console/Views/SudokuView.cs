using System.Drawing;
using Avans.DPAT.Sudoku.Console.Builders;
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
        var height = _model.Game.Height;
        var width = _model.Game.Width;

        var builder = new SudokuBufferBuilder(height, width, _model.Game.GetCellDisplay);
        builder.AddRule((cell, value) => !cell.Valid ? value.Pastel(Color.Red) : value);
        builder.AddRule((cell, value) => cell.Position == _model.Position ? value.Pastel(Color.Black).PastelBg(Color.DimGray) : value);
        builder.AddRule((cell, value) => cell.Final ? value.Pastel(Color.Black).PastelBg(Color.Yellow) : value);

        builder.AddCells(_model.Game.Cells);

        var buffer = builder.Build();

        System.Console.Clear();
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
