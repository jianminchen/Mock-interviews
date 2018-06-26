using System;
using System.Collections.Generic;

class Solution
{
    public static int GetNumberOfIslands(int[,] binaryMatrix)
    {
        if (binaryMatrix == null || binaryMatrix.GetLength(0) == 0) // false
        {
            return 0;
        }

        // base case
        if (binaryMatrix.GetLength(0) == 1 && binaryMatrix.GetLength(1) == 1)
        {
            Console.WriteLine("code is here " + binaryMatrix[0, 0]);
            return binaryMatrix[0, 0] == 1 ? 1 : 0;
        }

        var rows = binaryMatrix.GetLength(0); // 5, 5
        var columns = binaryMatrix.GetLength(1);

        var countIslands = 0;

        // BFS visit all nodes on the island and then mark them as 0
        var queue = new Queue<int[]>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                var visit = binaryMatrix[row, col];
                var isIsland = visit == 1;

                if (!isIsland)
                {
                    continue;
                }

                countIslands++; // 1                    

                binaryMatrix[row, col] = 0; // mark visit before pushing to queue
                queue.Enqueue(new int[] { row, col }); // new int[]{0, 1}

                while (queue.Count > 0) // 1 > 0 true
                {
                    var node = queue.Dequeue(); // int[]{0. 1}

                    var currentRow = node[0]; // 0
                    var currentCol = node[1]; // 1

                    // four neighbors - check if it 1, then mark it 0, push to queue
                    getNeighborsAndPushQueue(queue, binaryMatrix, currentRow, currentCol, rows, columns);
                }
            }
        }

        return countIslands;
    }

    private static void getNeighborsAndPushQueue(Queue<int[]> queue, int[,] binaryMatrix, int currentRow, int currentCol, int rows, int cols)
    {
        // left
        if (currentCol >= 1 && binaryMatrix[currentRow, currentCol - 1] == 1) // 0, false
        {
            binaryMatrix[currentRow, currentCol - 1] = 0;
            queue.Enqueue(new int[] { currentRow, currentCol - 1 });
        }

        // right
        if (currentCol < (cols - 1) && binaryMatrix[currentRow, currentCol + 1] == 1) // false 
        {
            binaryMatrix[currentRow, currentCol + 1] = 0;
            queue.Enqueue(new int[] { currentRow, currentCol + 1 });
        }

        // top 
        if (currentRow > 0 && binaryMatrix[currentRow - 1, currentCol] == 1) // false 
        {
            binaryMatrix[currentRow - 1, currentCol] = 0;
            queue.Enqueue(new int[] { currentRow - 1, currentCol });
        }

        // bottom
        if (currentRow < rows - 1 && binaryMatrix[currentRow + 1, currentCol] == 1) // false
        {
            binaryMatrix[currentRow + 1, currentCol] = 0;
            queue.Enqueue(new int[] { currentRow + 1, currentCol });
        }
    }

    static void Main(string[] args)
    {

    }
}

/*
0 A 0  B 0  - 0 1 -> 2 -> 0 -> 0 -> count ++ 5 row * 5 column 
0 0    0 0 0
0 C    0 0 0 
0 D 0 0 0
E 0     0 0 F -> 6 

more easy -> recursive depth of stack 100 * 100 = 10000 - stack size 
*/