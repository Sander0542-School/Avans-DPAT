using Avans.DPAT.Sudoku.Persistence.Builders;
using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public abstract class BaseNormalSudokuFactory : ISudokuFactory
{
    private readonly GridBuilder _gridBuilder;
    private int _gridId;

    protected BaseNormalSudokuFactory()
    {
        _gridBuilder = new(0);
        _gridId = 0;
    }

    public abstract bool Supports(File file);
    
    protected abstract int Build(File file);

    public Game.Sudoku CreateSudoku(File file)
    {
        var numbers = Build(file);
        return Game.Sudoku(numbers, _gridBuilder.Build());
    }

    public void AddSudoku(string line)
    {
        var length = (int)Math.Sqrt(line.Length);

        var (width, height) = length switch
        {
            4 => (2, 2),
            6 => (3, 2),
            9 => (3, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(length), $"The length of the sudoku must be 4, 6, or 9. It is {length}")
        };

        var subBuilders = new List<GridBuilder>();
        for (var i = 0; i < length; i++)
        {
            subBuilders.Add(new(_gridId++));
        }

        for (var row = 0; row < length; row++)
        {
            for (var col = 0; col < length; col++)
            {
                var value = int.Parse(line[row * length + col].ToString());

                var rowOffset = row / height;
                var colOffset = col / width;

                subBuilders[rowOffset * height + colOffset].AddCell(new(row, col), value);
            }
        }

        foreach (var subBuilder in subBuilders)
        {
            _gridBuilder.AddGrid(subBuilder);
        }
    }
}
