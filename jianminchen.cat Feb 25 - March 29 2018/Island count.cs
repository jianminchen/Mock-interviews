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

        var islandCount = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                var current = binaryMatrix[row, col];
                if (current != 1)
                {
                    continue;
                }

                islandCount++;
                applyBFSVisitNeighbors(binaryMatrix, row, col);
            }
        }

        return islandCount;
    }

    private static void applyBFSVisitNeighbors(int[,] matrix, int startRow, int startCol)
    {

        // visit four neighbors
        var queue = new Queue<int[]>();

        queue.Enqueue(new int[] { startRow, startCol });

        while (queue.Count > 0)
        {
            var visit = queue.Dequeue();
            var visitRow = visit[0];
            var visitCol = visit[1];

            matrix[visitRow, visitCol] = -1; // mark visited
            // add four neighbors into queue 
            addToQueue(queue, matrix, visitRow - 1, visitCol);  // up 
            addToQueue(queue, matrix, visitRow, visitCol + 1);  // right
            addToQueue(queue, matrix, visitRow + 1, visitCol); // down
            addToQueue(queue, matrix, visitRow, visitCol - 1); // left
        }
    }

    private static void addToQueue(Queue<int[]> queue, int[,] matrix, int startRow, int startCol)
    {
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);

        // if it not in range
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
0  -1  0  -1  0
0  0   -1  -1  -1
C  0   0  -1  0 
0  D   D  0  0 
E  0   D  0  F
  
  
 island count: 
   2 - start (0, 1)
     - start (0, 3) -> BFS/ DFS
  -1 as visit 
  
  total six island, return 6 
  */

