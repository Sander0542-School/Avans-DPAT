namespace Avans.DPAT.Sudoku.Game.Solvers;

public interface ISolver
{
    void Visit(Sudoku sudoku);
    
    bool Solve(Sudoku sudoku);
}
