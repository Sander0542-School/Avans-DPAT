namespace Avans.DPAT.Sudoku.Persistence.Models;

public class File
{
    public File(string path, string contents)
    {
        Path = path;
        Contents = contents;
    }

    public string Path { get; }

    public string Contents { get; }

    public string Extension => System.IO.Path.GetExtension(Path);
}
