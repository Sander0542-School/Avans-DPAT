using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Loaders;

public class FileSystemFileLoader : IFileLoader
{
    public File Load(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            throw new FileNotFoundException("The given file does not exist.", path);
        }

        return new(path, System.IO.File.ReadAllText(path));
    }
}
