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
            return true;

        var current = board[startRow, startCol];
        var isDot = current == '.'; // here... 
        var isLastColumn = startCol == 8;

        var nextRow = isLastColumn ? (startRow + 1) : startRow;
        var nextCol = isLastColumn ? 0 : (startCol + 1);

        if (!isDot)
        {
            return sudokuSolveHelper(board, nextRow, nextCol);
        }
        else
        {
            foreach (char item in getAvailable(board, startRow, startCol))
            {
                board[startRow, startCol] = item;
                var result = sudokuSolveHelper(board, nextRow, nextCol);
                if (result)
                {
                    return true;
                }

                board[startRow, startCol] = '.';
            }

            return false;
        }
    }

    private static HashSet<char> getAvailable(char[,] board, int startRow, int startCol)
    {
        var numbers = new HashSet<char>("123456789");

        // by row
        for (int index = 0; index < 9; index++)
        {
            numbers.Remove(board[startRow, index]); // check by row
            numbers.Remove(board[index, startCol]);
        }

        // 0 - 8 -> 0 - 2 -> 0, 3, 6
        int smallRow = startRow / 3 * 3;
        int smallCol = startCol / 3 * 3;
        for (int row = smallRow; row <= smallRow + 2; row++)
        {
            for (int col = smallCol; col <= smallCol + 2; col++)
            {
                numbers.Remove(board[row, col]);
            }
        }

        return numbers;
    }

    static void Main(string[] args)
    {

    }
}
/*
  9 * 9 
  digits from 1 to 9
  . blank space -> 1 to 9
  constraints: check row, no duplication
               check column, no duplication
               check 3 * 3 matrix 
  
  asked for if there is an existing solution 
  
  DFS - recursive - backtracking 
  
  0,0 -> row = 0, col = 2, each from 1 - 9, if there is availble -> check row/ col/ 3 * 3 matrix -> number available -> hashset -> 
     recusive call -> subproblem with row, col -> nextRow, nextCol -> return true -> find a solution
     _> backtracking, try next number
     
     all numbers from 1 - 9, return false; // 
     
  Base case:
    row = 9, row 0 - 8 -> true 
    */