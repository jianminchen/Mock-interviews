using System;
using System.Collections.Generic;

class Solution
{
    public static int GetNumberOfIslands(int[,] binaryMatrix) // 5 * 5 matrix 
    {
        if (binaryMatrix == null || binaryMatrix.GetLength(0) == 0 || binaryMatrix.GetLength(1) == 0) // false
        {
            return 0;
        }

        var rows = binaryMatrix.GetLength(0); // 5
        var columns = binaryMatrix.GetLength(1); // 5          

        int islands = 0; // 0 

        for (int row = 0; row < rows; row++) // 0 - 4
        {
            for (int col = 0; col < columns; col++) // 0 - 4
            {
                var visit = binaryMatrix[row, col]; // 0, 1
                var isZero = visit == 0;
                if (isZero)
                {
                    continue; // true
                }

                visitIsland(binaryMatrix, row, col); // row = 0, col = 1
                islands++;
            }
        }

        return islands;
    }

    private static void visitIsland(int[,] matrix, int startRow, int startCol)
    {
        var queue = new Queue<int[]>();

        matrix[startRow, startCol] = 0; // mark it visited, (0, 1)

        queue.Enqueue(new int[] { startRow, startCol }); // [0, 1]

        while (queue.Count > 0) // 1 
        {
            var current = queue.Dequeue(); // int[]{0, 1}
            var currentRow = current[0]; // 0 
            var currentCol = current[1]; // 1

            /// copy the idea from code review:
            /// https://codereview.stackexchange.com/a/157207/123986
            visitFourNeighbors(queue, matrix, currentRow - 1, currentCol); // 0, 1  
            visitFourNeighbors(queue, matrix, currentRow + 1, currentCol);
            visitFourNeighbors(queue, matrix, currentRow, currentCol - 1);
            visitFourNeighbors(queue, matrix, currentRow, currentCol + 1);
        }
    }

    /// <summary>
    /// code review - 
    /// copy the idea from code review:
    /// https://codereview.stackexchange.com/a/157207/123986
    /// </summary>
    /// <param name="queue"></param>
    /// <param name="matrix"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    private static void visitFourNeighbors(Queue<int[]> queue, int[,] matrix, int row, int column)
    {
        var rows = matrix.GetLength(0); // 5
        var columns = matrix.GetLength(1); // 5

        var rowIsInrange = row >= 0 && row < rows;
        var colInInrange = column >= 0 && column < columns;

        if (!(rowIsInrange && colInInrange) || matrix[row, column] == 0)
        {
            return;
        }

        // it is in range 
        matrix[row, column] = 0; // mark visit 
        queue.Enqueue(new int[] { row, column }); //         
    }

    static void Main(string[] args)
    {
        var matrix = new int[1, 1];
        matrix[0, 0] = 1;
        var number = GetNumberOfIslands(matrix);
    }
}

// 1 1 1 0 0    // 1 + 1 (0, 3) + 1 (2, 0) + 1(3, 1) + 1 (3, 4) + 1 (4, 0) = 6 islands
// 0 0 0 0 0
// 0 0 0 0 0
// 0 0 0 0 0
// 0 0 0 0 0

// BFS, scan matrix -> in place -> 0 , queue, 
// rows * cols -> 
//O(m*n) + O(m*n) = o(m*n)