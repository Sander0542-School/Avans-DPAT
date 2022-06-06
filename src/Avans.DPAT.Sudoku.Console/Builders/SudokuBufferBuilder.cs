using System.Drawing;
using Avans.DPAT.Sudoku.Console.Extensions;
using Avans.DPAT.Sudoku.Game.Grid.Common;
using Pastel;

namespace Avans.DPAT.Sudoku.Console.Builders;

public class SudokuBufferBuilder
{
    private const string HorizontalSeparator = "―";
    private const string VerticalSeparator = "|";

    private readonly string[,] _buffer;
    private readonly List<Func<ICell, string, string>> _rules;

    public SudokuBufferBuilder(int height, int width, int offset = 2)
    {
        var bufferHeight = height * offset - 1;
        var bufferWidth = width * offset - 1;

        _buffer = new string[bufferHeight, bufferWidth];
        _rules = new();
    }

    public SudokuBufferBuilder AddRule(Func<ICell, string, string> rule)
    {
        _rules.Add(rule);

        return this;
    }

    public SudokuBufferBuilder SetCell(ICell cell, ICell[,] cells)
    {
        var bufferPoint = new Point(cell.Position.X * 2, cell.Position.Y * 2);

        var value = cell.Value.HasValue ? cell.Value.Value.ToString() : ".";

        value = _rules.Aggregate(value, (value1, rule) => rule(cell, value1));
        _buffer.Set(bufferPoint.X, bufferPoint.Y, value);

        SetLine(cell, cell.Below(cells), true);
        SetLine(cell, cell.Right(cells), false);

        return this;
    }

    public SudokuBufferBuilder SetLine(ICell cell, ICell? otherCell, bool horizontal)
    {
        var value = horizontal ? HorizontalSeparator : VerticalSeparator;

        if (otherCell == null || cell.GridId == otherCell.GridId)
        {
            value = " ";
        }

        var bufferPoint = new Point(cell.Position.X * 2 + (horizontal ? 0 : 1), cell.Position.Y * 2 + (horizontal ? 1 : 0));
        _buffer.Set(bufferPoint, value.Pastel(Color.Purple));

        return this;
    }

    public SudokuBufferBuilder AddCells(ICell[,] cells)
    {
        foreach (var cell in cells)
        {
            if (cell != null)
            {
                SetCell(cell, cells);
            }
        }

        return this;
    }

    public string[,] Build()
    {
        return _buffer;
    }
}
