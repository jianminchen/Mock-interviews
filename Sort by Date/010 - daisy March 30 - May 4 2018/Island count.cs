using System;
using System.Collections.Generic;

class Solution
{
    public static int GetNumberOfIslands(int[,] binaryMatrix)
    {
        if (binaryMatrix == null)
            return 0;

        var rows = binaryMatrix.GetLength(0);
        var columns = binaryMatrix.GetLength(1);

        int countIsland = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                var current = binaryMatrix[row, col];
                if (current != 1)
                    continue;

                visitNeighbors(binaryMatrix, row, col);

                countIsland++;
            }
        }

        return countIsland;
    }

    private static void visitNeighbors(int[,] matrix, int startRow, int startCol)
    {
        var queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startRow, startCol });

        while (queue.Count > 0)
        {
            var visitNode = queue.Dequeue();

            var visitRow = visitNode[0];
            var visitCol = visitNode[1];

            matrix[visitRow, visitCol] = -1; // mark visited

            pushNeighborToQueue(queue, matrix, visitRow, visitCol - 1); // left
            pushNeighborToQueue(queue, matrix, visitRow, visitCol + 1); // right
            pushNeighborToQueue(queue, matrix, visitRow - 1, visitCol); // up
            pushNeighborToQueue(queue, matrix, visitRow + 1, visitCol); // down
        }
    }

    private static void pushNeighborToQueue(Queue<int[]> queue, int[,] matrix, int startRow, int startCol)
    {
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);

        if (startRow < 0 || startRow >= rows || startCol < 0 || startCol >= columns || matrix[startRow, startCol] != 1)
        {
            return;
        }

        queue.Enqueue(new int[] { startRow, startCol });
    }

    static void Main(string[] args)
    {

    }
}

/*
0 -1   0  -1   0 
0  0  -1  -1   -1
C  0  0   -1  0
0 D   -1    0 0 
E 0  -1 0 F
  
  
  countOfIsland  1 - A
                 1 - B
                 
                 6 - A, B, C, D, E, F
                 BFS search / queue -> 
  */

