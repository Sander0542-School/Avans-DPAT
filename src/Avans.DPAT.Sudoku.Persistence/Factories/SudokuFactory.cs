using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Factories;

public class SudokuFactory : ISudokuFactory
{
    private readonly IEnumerable<ISudokuFactory> _factories;

    public SudokuFactory()
    {
        var factories = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(ISudokuFactory).IsAssignableFrom(type) && GetType() != type && !type.IsInterface && !type.IsAbstract);

        _factories = factories.Select(factory => (ISudokuFactory)Activator.CreateInstance(factory));
    }

    public Game.Sudoku CreateSudoku(File file)
    {
        foreach (var factory in _factories)
        {
            if (factory.Supports(file))
            {
                return factory.CreateSudoku(file);
            }
        }

        throw new NotImplementedException($"The file extension {file.Extension} is not supported.");
    }

    public bool Supports(File file)
    {
        return _factories.Any(factory => factory.Supports(file));
    }
}
