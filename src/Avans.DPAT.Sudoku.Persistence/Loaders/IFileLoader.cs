using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Loaders;

public interface IFileLoader
{
    public File Load(string path);
}
