using System;

class Solution
{
    public const int LastCol = 8;
    public static bool SudokuSolve(char[,] board) //
    {
        if (board == null || board.GetLength(0) != 9 || board.GetLength(1) != 9) //false
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

        var visit = board[startRow, startCol]; // '5'
        var isDot = visit == '.'; // false 
        var isLastCol = startCol == LastCol; // false 

        var nextRow = isLastCol ? (startRow + 1) : startRow; // 0
        var nextCol = isLastCol ? 0 : (startCol + 1); // 1

        if (!isDot)
        {
            return sudokuSolveHelper(board, nextRow, nextCol); // 0, 1
        }
        else
        {
            for (int i = 1; i <= 9; i++) // 1, 2,.., 9
            {
                var isAvailable = checkAvailable(board, startRow, startCol, i);

                if (!isAvailable)
                {
                    continue;
                }

                board[startRow, startCol] = (char)(i + '0');
                var search = sudokuSolveHelper(board, nextRow, nextCol);
                if (search)
                {
                    return true;
                }

                board[startRow, startCol] = '.';
            }

            return false;
        }
    }

    private static bool checkAvailable(char[,] board, int startRow, int startCol, int trial)
    {
        // check by row
        for (int col = 0; col < 9; col++)
        {
            var visit = board[startRow, col];
            var number = (int)(visit - '0');

            if (number == trial)
            {
                return false;
            }
        }

        // check by col
        for (int row = 0; row < 9; row++)
        {
            var visit = board[row, startCol];
            var number = (int)(visit - '0');

            if (number == trial)
            {
                return false;
            }
        }

        // check by 3 * 3 matrix 
        int matrixStartRow = startRow / 3 * 3;   // 0, 3, 6
        int matrixStartCol = startCol / 3 * 3;   // 0, 3, 6
        for (int row = matrixStartRow; row < matrixStartRow + 3; row++)
        {
            for (int col = matrixStartCol; col < matrixStartCol + 3; col++)
            {
                var visit = board[row, col];
                var number = (int)(visit - '0');

                if (number == trial)
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

5 3 - - 7 - - - -    9 cells in a row  3 * 3 , 3, 5, 6, 8, 9 -> 1, 2, 4, 7, -> 1, 2, 4 

depth first search -> recursive 
-> backtrack -> 
-> base case -> terminate the search 
int startRow, int startCol -> (0, 0) -> (0, 1) -> (0, 8) -> (1, 0)

base case: 
startRow == 9 -> all 0 - 8 
true


*/