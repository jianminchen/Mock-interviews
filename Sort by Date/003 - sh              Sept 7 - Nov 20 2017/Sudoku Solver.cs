using System;
using System.Collections.Generic;

class Solution
{
    const int SIZE = 9;
    const int SmallMatrixSize = 3;

    public static bool SudokuSolve(char[,] board)
    {
        if (board == null || board.GetLength(0) < SIZE || board.GetLength(1) < SIZE)
        {
            return false;
        }

        // Now for sure the matrix is 9 * 9
        return SudokuSolveHelper(board, 0, 0);
    }

    private static bool SudokuSolveHelper(char[,] board, int row, int col)
    {
        // base case: if the row is incremented to 9 which is bigger than maximum row value of matrix 8, 
        // then all elements are filled with correct value.", good advice to remind me to work on an explanation
        if (row >= SIZE)
        {
            return true;
        }

        var visit = board[row, col];
        var isDot = visit == '.';

        var lastColumn = (SIZE - 1);
        var nextRow = col == lastColumn ? (row + 1) : row;
        var nextCol = col == lastColumn ? 0 : (col + 1);

        if (!isDot)
        {
            return SudokuSolveHelper(board, nextRow, nextCol);
        }

        // assume that it is digit number 
        var availableNumbers = getAvailableNumbers(board, row, col);

        foreach (var option in availableNumbers)
        {
            board[row, col] = option;

            var result = SudokuSolveHelper(board, nextRow, nextCol);

            if (result)
            {
                return true;
            }

            board[row, col] = '.';
        }

        return false;
    }

    private static IEnumerable<Char> getAvailableNumbers(char[,] board, int currentRow, int currentCol)
    {
        var numbers = "123456789";
        var available = new HashSet<char>(numbers);

        // check by row
        for (int col = 0; col < SIZE; col++)
        {
            var visit = board[currentRow, col];
            available.Remove(visit);
        }

        // check by col
        for (int row = 0; row < SIZE; row++)
        {
            var visit = board[row, currentCol];
            available.Remove(visit);
        }

        // check by 3 * 3 matrix 
        var startRow = currentRow / SmallMatrixSize * SmallMatrixSize;
        var startCol = currentCol / SmallMatrixSize * SmallMatrixSize;
        for (int row = startRow; row < startRow + SmallMatrixSize; row++)
        {
            for (int col = startCol; col < startCol + SmallMatrixSize; col++)
            {
                var visit = board[row, col];
                available.Remove(visit);
            }
        }

        return available;
    }

    static void Main(string[] args)
    {
        var board = new char[,]{
        {'.','.','.','7','.','.','3','.','1'},
        {'3','.','.','9','.','.','.','.','.'},
        {'.','4','.','3','1','.','2','.','.'},
        {'.','6','.','4','.','.','5','.','.'},
        {'.','.','.','.','.','.','.','.','.'},
        {'.','.','1','.','.','8','.','4','.'},
        {'.','.','6','.','2','1','.','5','.'},
        {'.','.','.','.','.','9','.','.','8'},
        {'8','.','5','.','.','4','.','.','.'}};

        Console.WriteLine(SudokuSolve(board));
    }
}

// row = 0, col = 2, 1 (yes) 2(yes) 3 4 (yes) 5 6 7 8 9 , three choices 1, 2, 4, DFS, back tracking 
// 0, 0 -> row -> 9 > 8, then succeed -> 
// row = ( col == 8)? row + 1 : row
// col = ( col == 8)? 0 : (col + 1), 
// two dimension array -> in-place - mark
// SudokuSolverHelp(board, int row, int column)
// run time complexity -> 9 * 9 = 81  elements, each elements at most 9 options, 
// BFS, backtracking, prune tree ->  9 ^81 -> maximum -> empty cells - mEmtpy cell -> 9^m, -> measure -> //DFS -> backtracking ->