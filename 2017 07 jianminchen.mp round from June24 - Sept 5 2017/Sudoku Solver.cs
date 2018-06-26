using System;

class Solution
{
    public static bool SudokuSolve(char[,] board)
    {
        // your code goes here
        if (board == null || board.GetLength(0) == 0 || board.GetLength(1) == 0)
        {
            return false;
        }

        return SudokuSolveHelper(board, 0, 0);
    }

    // 9 * 9, row from 0 - 8
    private static bool SudokuSolveHelper(char[,] board, int row, int column)
    {
        if (row == 9)
        {
            return true;
        }

        // current visit is (row, column)
        var visit = board[row, column];
        var isDot = visit == '.';

        // move to next 
        var newRow = column < 8 ? row : (row + 1);
        var newColumn = column == 8 ? 0 : (column + 1);

        if (!isDot)
        {
            return SudokuSolveHelper(board, newRow, newColumn);
        }

        // assume that it is Dot
        var numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        foreach (var number in numbers)
        {
            var checking = isAvailable(number, board, row, column); // by row, by column, by 3 * 3 matrix 
            if (!checking)
            {
                continue;
            }

            board[row, column] = number;
            if (SudokuSolveHelper(board, newRow, newColumn))
            {
                return true;
            }

            board[row, column] = '.'; // backtracking 
        }

        return false;
    }

    private static bool isAvailable(char selected, char[,] board, int row, int column)
    {
        // check by row
        for (int colIndex = 0; colIndex < 9; colIndex++)
        {
            var visit = board[row, colIndex];
            var found = selected == visit;
            if (found)
            {
                return false;
            }
        }

        // check by column
        for (int rowIndex = 0; rowIndex < 9; rowIndex++)
        {
            var visit = board[rowIndex, column];
            var found = selected == visit;
            if (found)
            {
                return false;
            }
        }

        // check by 3 * 3 matrix 
        // rowIndex 0, 1, 2 for 3 columns 0 - 0 - 2, 1 matchs from column 3 - 5, 2 matchs from 6 - 8
        // columnIndex 
        var matrixRow = row / 3; // 0, 1, 2 
        var matrixColumn = column / 3;

        var startRow = matrixRow * 3;
        var startColumn = matrixColumn * 3;
        for (int rowIndex = startRow; rowIndex < startRow + 3; rowIndex++)
        {
            for (int colIndex = startColumn; colIndex < startColumn + 3; colIndex++)
            {
                var visit = board[rowIndex, colIndex];
                var found = selected == visit;
                if (found)
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

// DFS - recursive function
// (0,0) -> base case: row = 9, return true
// return false
// scan row by row, from left to right, 5 3 _ _ 
// available option 1 - 9, exclude 3, 5, 6 - row, exclude 8, by 3 * 3 matrix exclue 3, 5, 6, 8, 9
// 1, 2, 4, 7 -> 
// 1 -> recursive ok -> return true
// 2 -> 
// 4 -> 
// 7 -> 
// return false; 