using System;

class Solution
{
    static int getNumberOfIslands(int[,] binaryMatrix)
    { // 
        if (binaryMatrix == null || binaryMatrix.GetLength(0) == 0 || binaryMatrix.GetLength(1) == 0) // false 
        {
            return 0;
        }

        int rows = binaryMatrix.GetLength(0); // 5
        int cols = binaryMatrix.GetLength(1); // 5

        int islandFound = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                var current = binaryMatrix[row, col]; // 0 , -1
                if (current != 1)
                {
                    continue;
                }

                visitIsland(binaryMatrix, row, col);
                islandFound++;
            }
        }
    }

    private void visitIsland(int[,] binaryMatrix, int startRow, int startCol) // 0, 1
    {
        int rows = binaryMatrix.GetLength(0); // 5
        int cols = binaryMatrix.GetLength(1); // 5


        if (binaryMatrix[startRow, startCol] != 1)
        {
            return;
        }

        // mark visit 
        binaryMatrix[startRow, startCol] = -1; // -1

        // clockwise 4 neigbhors
        var leftCol = startCol - 1;
        if (leftCol >= 0) // false
        {
            visitIsland(binaryMatrix, startRow, leftCol);
        }

        // right
        var rightCol = startCol + 1;

        if (startCol < (cols - 1)) // false 
        {
            visitIsland(binaryMatrix, startRow, rightCol);
        }

        // top
        var topRow = startRow - 1;
        if (startRow > 0) // false 
        {
            visitIsland(binaryMatrix, topRow, startCol);
        }

        // down 
        var downRow = startRow + 1;
        if (startRow < rows - 1)//false 
        {
            visitIsland(binaryMatrix, downRow, startCol);
        }
    }

    public static void main(String[] args)
    {

    }
}

