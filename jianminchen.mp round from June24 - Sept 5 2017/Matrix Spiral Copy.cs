using System;

class Solution
{
    public static int[] SpiralCopy(int[,] inputMatrix)
    {
        // your code goes here
        if (inputMatrix == null || inputMatrix.GetLength(0) == 0 || inputMatrix.GetLength(1) == 0)
        {
            return new int[0];
        }

        var rows = inputMatrix.GetLength(0);
        var columns = inputMatrix.GetLength(1);

        var startRow = 0;  //0
        var startCol = 0;  // 0
        var endRow = rows - 1; // 3
        var endCol = columns - 1; // 0

        // 5
        // 10
        // 15
        // 20

        var spiral = new int[rows * columns]; // 4
        var index = 0;

        while (startRow <= endRow && startCol <= endCol) // 0 <= 3, 0 <= 0
        {
            // four loops
            // top row 
            for (var col = startCol; col <= endCol; col++)  // 5
            {
                var visit = inputMatrix[startRow, col];
                spiral[index] = visit;
                index++;
            }

            // last column
            for (var row = startRow + 1; row <= endRow; row++) // from 1 to 3 in row, 10, 15, 20
            {
                var visit = inputMatrix[row, endCol];
                spiral[index] = visit;
                index++;
            }

            // last row, check edge case: one row
            for (var col = endCol - 1; col >= startCol && endRow > startRow; col--)  // add one more condition
            {
                var visit = inputMatrix[endRow, col];
                spiral[index] = visit;
                index++;
            }

            // first column 
            for (var row = endRow - 1; row > startRow && endCol > startCol; row--)  // add one more condition
            {
                var visit = inputMatrix[row, startCol];
                spiral[index] = visit;
                index++;
            }

            startRow++;
            endRow--;
            startCol++;
            endCol--;
        }

        return spiral;
    }

    static void Main(string[] args)
    {
        var inputMatrix = new int[,] { { 1 } };
        var result = SpiralCopy(inputMatrix);
        Console.WriteLine(result[0]);
    }
}

// 0, 0 
// first row, 1 - 5, 
// last column, second row to last row , 20 is in second iteration, 
// last row, next to last column, 19 - 16
// first column, next to last row -> 6, 6 is next to first row
// start pointer 1, 1, start again 4 loops from 7
// edge case: if it is one row, we do not visit twice, one row, no two rows, left -> right
// edge case: if it is one column, we start from top to down
// one element -> 
// while loop 