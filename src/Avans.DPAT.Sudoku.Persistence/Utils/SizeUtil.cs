namespace Avans.DPAT.Sudoku.Persistence.Utils;

public static class SizeUtil
{
    public static (int, int) CalcWithHeight(int length)
    {
        return length switch
        {
            4 => (2, 2),
            6 => (3, 2),
            9 => (3, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(length), $"The length of the sudoku must be 4, 6, or 9. It is {length}")
        };
    }
}
