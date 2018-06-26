using System;

class Solution
{
    public static int GetNumberOfIslands(int[,] binaryMatrix) // 
    {
        if (binaryMatrix == null || binaryMatrix.GetLength(0) == 0 ||
          binaryMatrix.GetLength(1) == 0) // false
        {
            return 0;
        }

        var rows = binaryMatrix.GetLength(0); // 5
        var columns = binaryMatrix.GetLength(1);  //5

        var islandCount = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.WriteLine("test is here " + row + "," + col + "," + binaryMatrix[row, col]);

                if (binaryMatrix[row, col] != 1)
                {
                    continue;
                }

                islandCount++;

                visitIslandNode(binaryMatrix, row, col);
            }
        }

        return islandCount;
    }

    private static void visitIslandNode(int[,] binaryMatrix, int startRow, int startCol)
    {
        var rows = binaryMatrix.GetLength(0);
        var columns = binaryMatrix.GetLength(1);

        if (startRow < 0 || startRow >= rows || startCol < 0 || startCol >= columns || binaryMatrix[startRow, startCol] != 1)
        {
            return;
        }

        binaryMatrix[startRow, startCol] = -1;

        visitIslandNode(binaryMatrix, startRow, startCol - 1);
        visitIslandNode(binaryMatrix, startRow, startCol + 1);
        visitIslandNode(binaryMatrix, startRow + 1, startCol);
        visitIslandNode(binaryMatrix, startRow - 1, startCol);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetNumberOfIslands(new int[,] { { 1 } }));
    }
}

/*
count++ - 6 islands
BFS/ DFS 

recursive function - 
 0,    -1,    0,    -1,    0],
 0,    0,     -1,   -1,    -1],
 [-1,    0,    0,    -1,    0],
 [0,    -1,    -1,    0,    0],
 [-1,    0,    -1,    0,    -1] 
 
 */