using System;
using System.Collections.Generic;

class Solution
{
    public static bool SudokuSolve(char[,] board)
    {
        if (board == null || board.GetLength(0) != 9 || board.GetLength(1) != 9)
            return false;

        return sudokuSolveHelper(board, 0, 0);

    }

    private static bool sudokuSolveHelper(char[,] board, int startRow, int startCol)
    {
        // base case
        if (startRow == 9)
        {
            return true;
        }

        var visit = board[startRow, startCol];
        var isDot = visit == '.';
        var isLastColumn = startCol == 8;

        var nextRow = isLastColumn ? (startRow + 1) : startRow;
        var nextCol = isLastColumn ? 0 : (startCol + 1);

        if (!isDot)
        {
            return sudokuSolveHelper(board, nextRow, nextCol);
        }
        else
        {
            var avaiableDigits = getAvailableDigits(board, startRow, startCol);

            foreach (var digit in avaiableDigits)   // digit from 1 to 9, check if it is available 
            {
                board[startRow, startCol] = digit;
                if (sudokuSolveHelper(board, nextRow, nextCol))
                {
                    return true;
                }

                board[startRow, startCol] = '.';
            }

            return false;
        }
    }

    private static HashSet<char> getAvailableDigits(char[,] board, int startRow, int startCol)
    {
        var digits = new HashSet<char>("123456789".ToCharArray());

        // check by row 
        for (int index = 0; index < 9; index++)
        {
            digits.Remove(board[startRow, index]);

            digits.Remove(board[index, startCol]);
        }

        // 3 * 3 matrix
        var matrixRow = startRow / 3 * 3; // 0, 3, 6
        var matrixCol = startCol / 3 * 3; // 0, 3, 6
        for (int row = matrixRow; row < matrixRow + 3; row++)
        {
            for (int col = matrixCol; col < matrixCol + 3; col++)
            {
                digits.Remove(board[row, col]);
            }
        }

        return digits;
    }

    static void Main(string[] args)
    {

    }
}

/*
memorize -> challenging 


keywords:

given 9 * 9 board, digit 1 - 9, char - '1' to '9', '.' blank space 
contraints: 
Every row - '1' to '9' appear once, same applies every column, applies to 3 * 3 matrix, starting from 
  9 matrix 
  row 0 ->col 0, 3, 6
  row 3
  row 6 
ask: return true/ false
  
  
  depth first search, recursive, backtracking 
  
  (0,0) -> 5 -> nextIteartion -> 3 -> (0, 2) '.', try to get avaiable digits  1, 2, .., 9, hashset, remove row/column/9 3*3 matrix, left 
  3, 5,6, 7,8, 9 -> 1, 2, 4, avaiable to try 
    try one by one
    1 -> recursive - subproblem 
    if(true of subproblem)
      return true;
    backtracking [0,2] = '.'
      
    return false 
    
    9 * 9 
    '.' we have to fill 
    
    9 * 9 at most 81 '.'
    
    ['.', 1, '.'] -> getAvailableDigits(0,0) * getAvailableDigits(0, 2) * getAvailableDigits(i, j),
      for every i and j, where board[i][j] = '.'
    
    9 * 8 * ... 1 = 9! -> 9^9 upper bound -> make it smaller -> 
    8 * 7 *     1 = 8!
    ...
    1 .........   = 
    
    time complexity 9!*8!*.. 1! = exponential 
    space complexity: 81 steps - recurisive 
    
    space complexity 
    
    https://codereview.stackexchange.com/questions/179725/sudoku-solver-recursive-solution-with-clear-structure
    
    */