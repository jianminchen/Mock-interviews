using System;
using System.Collections.Generic;

class Solution
{
    const int LastColumn = 8;

    public static bool SudokuSolve(char[,] board)  // 9 * 8
    {
        if (board == null || board.GetLength(0) != 9 || board.GetLength(1) != 9)  // false 
        {
            return false;
        }

        return sudokuSolveHelper(board, 0, 0);
    }

    private static bool sudokuSolveHelper(char[,] board, int startRow, int startCol)
    {
        // base case
        if (startRow == 9)
        {
            return true;
        }

        var current = board[startRow, startCol]; // '5'
        var isDot = current == '.'; // false

        var nextRow = startCol == LastColumn ? (startRow + 1) : startRow; // 0
        var nextColumn = startCol == LastColumn ? 0 : (startCol + 1);  // 1, 2

        if (!isDot)
        {
            return sudokuSolveHelper(board, nextRow, nextColumn); // 0, 1
        }
        else
        {
            var set = getAvailableChars(board, startRow, startCol); // 

            foreach (var number in set)
            {
                board[startRow, startCol] = number;

                if (sudokuSolveHelper(board, nextRow, nextColumn))
                {
                    return true;
                }

                board[startRow, startCol] = '.';
            }

            return false;
        }
    }

    private static HashSet<char> getAvailableChars(char[,] board, int startRow, int startCol)
    {
        var avaiable = new HashSet<char>("123456789".ToCharArray());

        //check row
        for (int col = 0; col < 9; col++)
        {
            avaiable.Remove(board[startRow, col]);
        }

        //check column
        for (int row = 0; row < 9; row++)
        {
            avaiable.Remove(board[row, startCol]);
        }

        //check 3*3 matrix 
        int smallMatrixRow = startRow / 3 * 3;  // 0, 3, 6
        int smallMatrixCol = startCol / 3 * 3;

        for (int row = smallMatrixRow; row < smallMatrixRow + 3; row++)
        {
            for (int col = smallMatrixCol; col < smallMatrixCol + 3; col++)
            {
                avaiable.Remove(board[row, col]);
            }
        }

        return avaiable;
    }

    static void Main(string[] args)
    {

    }
}

/*
9 * 9  10 option '1', '2', ...'9', '.'
Constraint:  each row there is no duplicated char, each column there is no duplicated char, 
3 * 3 you can not repeat 

DFS + backtracking 

(0, 0) '5' ->(0, 1 ) :'3'-> '.', 3, 5, 6, 7, 8, 9 -> try set: {1, 2, 4}
   '1' -> true- > return true, subproblem
   
Time complexity
9^81 -> backtracking 
 
Space complexity
*/