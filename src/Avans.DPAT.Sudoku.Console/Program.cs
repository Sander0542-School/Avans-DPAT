﻿using Avans.DPAT.Sudoku.Game.Grid;
using Avans.DPAT.Sudoku.Persistence.Factories;
using Avans.DPAT.Sudoku.Persistence.Loaders;

var fileLoader = new FileSystemFileLoader();
var file = fileLoader.Load("Puzzles/puzzle.9x9");

var factory = new SudokuFactory();
var sudoku = factory.CreateSudoku(file);

var cells = new GridCell[sudoku.Numbers, sudoku.Numbers];
sudoku.Grid.Flatten(cells);

for (var x = 0; x < cells.GetLength(0); x++)
{
    for (var y = 0; y < cells.GetLength(1); y++)
    {
        var value = cells[x, y].Value;
        Console.Write(value.HasValue ? value.Value.ToString() : " ");
    }
    Console.WriteLine();
}
