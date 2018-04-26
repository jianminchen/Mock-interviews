using System;

class Solution
{
    public static readonly int SIZE = 8;
    public static bool SudokuSolve(char[,] board)
    {

        if (board == null || board.GetLength(0) <= SIZE || board.GetLength(1) <= SIZE)  // 8
        {
            return false;
        }

        return SudokuSolveHeler(board, 0, 0); // 
    }

    private static bool SudokuSolveHeler(char[,] board, int row, int col)
    {
        // base case 
        if (row == 9) // false 
        {
            return true;
        }

        var visit = board[row, col]; // '5', '3'
        var isDot = visit == '.';  // false 
        var lastColumn = col == SIZE; // 0 != 8

        var nextRow = lastColumn ? (row + 1) : row; // 0, 0, 
        var nextCol = lastColumn ? 0 : (col + 1); // 1, 2

        if (!isDot)
        {
            return SudokuSolveHeler(board, nextRow, nextCol);  // (0, 1)       
        }

        // 
        for (int number = 1; number <= 9; number++) // 1, 2, 4
        {
            char current = (char)(number + '0'); // '0'
            if (isAvailable(board, row, col, current)) // 1, true, false 
            {
                // DFS
                board[row, col] = current; // 1
                var result = SudokuSolveHeler(board, nextRow, nextCol);
                if (result)
                {
                    return true;
                }

                board[row, col] = '.';
            }
        }

        return false;
    }

    private static bool isAvailable(char[,] board, int row, int col, char current) // row = 0, col = 2
    {
        // check row
        for (int column = 0; column <= SIZE; column++)
        {
            if (board[row, column] == current)
            {
                return false;
            }
        }

        // check col
        for (int rowIndex = 0; rowIndex <= SIZE; rowIndex++)
        {
            if (board[rowIndex, col] == current)
            {
                return false;
            }
        }

        // check 3 * 3 matrix 
        int startRow = row / 3 * 3; // 0
        int startCol = col / 3 * 3; // 0 
        for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++) // 0, < 3
        {
            for (int colIndex = startCol; colIndex < startCol + 3; colIndex++) // 0, 3
            {
                if (board[rowIndex, colIndex] == current)
                {
                    return false;
                }
            }
        }

        return true;
    }

    static void Main(string[] args)
    {

    }
}

/*
5 3 4 ? 7 ? ? ? ? 



what is possible number for this element - check row/ column, 3 * 3 matrix -> 3, 5,6, 7, 8, 9, try  1, 2, 4,
All options - 3 options 
return false
DFS/ backtracking 
(0,0)
base case: 8 * 8 
row = 9 , finish all 8 rows/ 8 columns -> return true; 
*/