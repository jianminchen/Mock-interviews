using System;

class Solution
{
    public static int GetNumberOfIslands(int[,] binaryMatrix)
    {
        if(binaryMatrix == null )      
        {
          return 0; 
        }
      
        var rows    = binaryMatrix.GetLength(0); 
        var columns = binaryMatrix.GetLength(1); 
      
        int islandCount = 0; 
      
        for(int row = 0; row < rows; row++)
        {
          for(int col = 0; col < columns; col++)
          {
            var current = binaryMatrix[row, col]; 
            
            if(current != 1)
              continue; 
            
            islandCount++; 
            visitIsland(binaryMatrix, row, col); 
          }
        }
      
      return islandCount; 
    }
  
    private static void visitIsland(int[,] binaryMatrix, int startRow, int startCol)
    {
        var rows    = binaryMatrix.GetLength(0); 
        var columns = binaryMatrix.GetLength(1); 
      
        var outOfRange = startRow < 0 || startRow >= rows || startCol < 0 || startCol >= columns;
      
        if(outOfRange || binaryMatrix[startRow, startCol] != 1)
        {
          return; 
        }
      
        binaryMatrix[startRow, startCol] = -1; 
      
        visitIsland(binaryMatrix, startRow, startCol - 1); 
        visitIsland(binaryMatrix, startRow, startCol + 1);
        visitIsland(binaryMatrix, startRow - 1, startCol);
        visitIsland(binaryMatrix, startRow + 1, startCol);
    }

    static void Main(string[] args)
    {

    }
}

/*

0  A  0   B  0 
0  0  B   B  B
C  0  0   B  0
0  D  D   0  0
E  0  D   0  F 
  
  
  -1  mark visited
  
  6   island count 
  
  DFS/ BFS visit the island 
  
  */