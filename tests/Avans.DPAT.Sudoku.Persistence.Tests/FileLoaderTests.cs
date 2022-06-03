using System.IO;
using Avans.DPAT.Sudoku.Persistence.Loaders;
using Xunit;

namespace Avans.DPAT.Sudoku.Persistence.Tests;

public class FileLoaderTests
{
    [Fact]
    public void Test_Load_ThrowException_InvalidPath()
    {
        var fileLoader = new FileSystemFileLoader();

        Assert.Throws<FileNotFoundException>(() => fileLoader.Load("Puzzles/puzzle.notfound"));
    }
}
