using System;

class Solution
{
    public static int GetNumberOfIslands(int[,] binaryMatrix) // 
    {
        if (binaryMatrix == null || binaryMatrix.GetLength(0) == 0 || binaryMatrix.GetLength(1) == 0) //false
        {
            return 0;
        }

        int rows = binaryMatrix.GetLength(0); // 5
        int cols = binaryMatrix.GetLength(1); // 5

        int islandCount = 0; // 0 

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                var visit = binaryMatrix[row, col]; // 0, 1
                if (visit == 0)
                {
                    continue;//
                }

                visitNeighbors(binaryMatrix, row, col); // 

                islandCount++;
            }
        }

        return islandCount;
    }

    private static void visitNeighbors(int[,] binaryMatrix, int row, int col)
    {
        int rows = binaryMatrix.GetLength(0); // 5
        int cols = binaryMatrix.GetLength(1); // 5

        // base case 
        if (row < 0 || row >= rows || col < 0 || col >= cols || binaryMatrix[row, col] == 0)
        {
            return;
        }


        binaryMatrix[row, col] = 0;
        visitNeighbors(binaryMatrix, row, col - 1);
        visitNeighbors(binaryMatrix, row, col + 1);

        visitNeighbors(binaryMatrix, row - 1, col);
        visitNeighbors(binaryMatrix, row + 1, col);
    }

    static void Main(string[] args)
    {

    }
}

/*
 0 1 0 1 0 
 0 0 1 1 1
 1 0 0 1 0
 0 1 1 0 0 
 1 0 1 0 1
 
 0 A 0 B 0 
 0 0 B B B
 C 0 0 B 0
 0 D D 0 0 
 E 0 D 0 F 
 
 A, B, C, D, E, F - > matrix all rows/ columns  
 
 recurisve -> depth first search m * n     
  */

