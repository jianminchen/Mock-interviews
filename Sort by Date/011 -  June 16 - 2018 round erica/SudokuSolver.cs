using System;
using System.Collections.Generic;

class Solution
{
    public static bool SudokuSolve(char[,] board)
    {
        if (board == null || board.GetLength(0) != 9 || board.GetLength(1) != 9)
            return false;

        return sudokuSolverHelp(board, 0, 0);
    }

    private static bool sudokuSolverHelp(char[,] board, int currentRow, int currentCol)
    {
        if (currentRow == 9)
            return true;

        var current = board[currentRow, currentCol];
        var isDot = current == '.';

        // define nextRow, nextCol
        var isLastColumn = currentCol == 8;
        var nextRow = isLastColumn ? (currentRow + 1) : currentRow;
        var nextCol = isLastColumn ? 0 : (currentCol + 1); 

        if (!isDot)
        {
            return sudokuSolverHelp(board, nextRow, nextCol);
        }

        foreach (var digit in getAvaiableDigits(board, currentRow, currentCol))
        {
            board[currentRow, currentCol] = digit; // char type

            if (sudokuSolverHelp(board, nextRow, nextCol))
            {
                return true;
            }

            board[currentRow, currentCol] = '.';
        }

        return false;
    }

    private static IEnumerable<char> getAvaiableDigits(char[,] board, int currentRow, int currentCol)
    {
        var hashSet = new HashSet<char>("123456789".ToCharArray());

        for (int index = 0; index < 9; index++)
        {
            // remove current row used char
            hashSet.Remove(board[currentRow, index]);
            hashSet.Remove(board[index, currentCol]); 
        }

        // small 3 x 3 matrix 
        var smallRow = currentRow / 3 * 3; // 0, 3, 6
        var smallCol = currentCol / 3 * 3; // 0, 3, 6
        for (int row = smallRow; row < smallRow + 3; row++)
        {
            for (int col = smallCol; col < smallCol + 3; col++)
            {
                hashSet.Remove(board[row, col]); 
            }
        }

        return hashSet; 
    }

    static void Main(string[] args)
    {

    }
}

