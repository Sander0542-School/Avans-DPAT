using File=Avans.DPAT.Sudoku.Persistence.Models.File;

namespace Avans.DPAT.Sudoku.Persistence.Extensions;

public static class FileExtensions
{
    public static string[] Lines(this File file)
    {
        return file.Contents.Split(Environment.NewLine);
    }
}
