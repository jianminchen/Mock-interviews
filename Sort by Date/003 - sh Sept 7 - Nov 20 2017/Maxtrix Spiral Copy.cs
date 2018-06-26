using System;

class Solution
{
    public static int[] SpiralCopy(int[,] inputMatrix) // 
    {
        if (inputMatrix == null || inputMatrix.GetLength(0) == 0 || inputMatrix.GetLength(1) == 0) // false
        {
            return new int[0];
        }

        var rows = inputMatrix.GetLength(0); // 4
        var columns = inputMatrix.GetLength(1); // 5

        var startRow = 0; // 0
        var endRow = rows - 1;  // 3

        var startColumn = 0;
        var endColumn = columns - 1;  // 4

        var spiralCopy = new int[rows * columns]; // 4 * 5 = 20
        var index = 0;

        while (startRow <= endRow && startColumn <= endColumn) // 0 <= 3 && 0 <= 4 => true 
        {
            // if there is top row,iterate 1 -> 5
            for (int col = startColumn; col <= endColumn; col++) // 0 -> 4
            {
                spiralCopy[index] = inputMatrix[startRow, col]; // 1, 2, 3, 4, 5
                index++;
            }  // index = 5

            // if there is last column, at least one column, iterate top -> down, 10 15, 20
            for (int row = startRow + 1; row <= endRow; row++) // 1 to 3, 
            {
                spiralCopy[index] = inputMatrix[row, endColumn]; // 10 15, 20
                index++;
            } // index = 9 

            // if there is bottom row, not top row, 19, 18, 17, 16
            for (int col = endColumn - 1; col >= startColumn && endRow > startRow; col--) // 3 -> 0, 19, 18, 17, 16
            {
                spiralCopy[index] = inputMatrix[endRow, col];
                index++;
            }

            // if there is more than one column, first column -: 11 6
            for (int row = endRow - 1; row > startRow && startColumn < endColumn; row--) // 2 -> 1, 11, 6
            {
                spiralCopy[index] = inputMatrix[row, startColumn];
                index++;
            }

            // one iteration is finished
            startRow++;
            endRow--;

            startColumn++;
            endColumn--;
        }

        return spiralCopy;
    }

    static void Main(string[] args)
    {

    }
}

// clockwise 
// while(topRow <= lastRow && firstColmn <= lastColumn)
// top row -> left -> right 
// last column -> top -> down 
// last row -> right -> left
// first column -> bottom -> up 
// edge case: one row -> no duplicate output 
// one column -> no output twice
// O(rows * columns) time complexity 
// space complexity 
// declare array -> one dimension O(rows * columns), extra few variables O(1)// 
// do not do that: 
// print 1 more than once, 10, print 

