using System;

class Solution
{
    public static int[] SpiralCopy(int[,] inputMatrix)
    {
        if (inputMatrix == null || inputMatrix.GetLength(0) == 0 || inputMatrix.GetLength(1) == 0) // false
        {
            return new int[0];
        }

        var rows = inputMatrix.GetLength(0); // 4, 
        var columns = inputMatrix.GetLength(1); // 5

        var spiral = new int[rows * columns]; // new int[20]

        var index = 0;

        var startRow = 0;
        var startCol = 0;
        var endRow = rows - 1; // 3
        var endCol = columns - 1; // 4

        while (startRow <= endRow && startCol <= endCol) // 0 <=3 && 0 <= 4
        {
            // top row
            for (int col = startRow; col <= endCol; col++) // 1, 2, 3, 4, 5
            {
                spiral[index] = inputMatrix[startRow, col]; // 1, 2, 3, 4, 5
                index++;
            }

            // last column
            for (int row = startRow + 1; row <= endRow; row++) // 10, 15, 20
            {
                spiral[index] = inputMatrix[row, endCol]; // 1, 2, 3 -> 10, 15, 20
                index++;
            }


            // bottom row 
            for (int col = endCol - 1; col >= startCol && endRow > startRow; col--) // col=3 - value = 19, 2, 1, 0 - 16
            {
                spiral[index] = inputMatrix[endRow, col];
                index++;
            }

            // first column
            for (int row = endRow - 1; row > startRow && startCol < endCol; row--) // 11, 6 -> row= 2, row = 1
            {
                spiral[index] = inputMatrix[row, startCol]; // startCol = 0
                index++;
            }

            startRow++; // 1
            startCol++; // 1

            endRow--; // 2
            endCol--; // 3
        }

        return spiral;
    }

    static void Main(string[] args)
    {

    }
}
// time complexity O(rows * columns)  - can you hear me? 
// for loop 1: -> top row - 1, 2, 3, 4, 5
// for loop 2: last column 10, 15, 20 
// for loop 3: if there is bottom row, 19, 18, 17, 16
// for loop 4: if there is first row, visit 11, 6 
// left top -> 0, 0 -> while loop 
// startRow, startcol, endRow, endCol 
// 1 (0,0), 20 ( 3, 4) -> one node -> 
// one row -> 
// one column 
// one row matrix: 1 2 3 4 5 
// one column matrix: 5 10 15 20 
// one node matrix: 1 
// 
