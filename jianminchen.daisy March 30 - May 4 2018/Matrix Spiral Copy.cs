using System;
using System.Collections.Generic;

class Solution
{
    public static int[] SpiralCopy(int[,] inputMatrix)
    {
      if(inputMatrix == null)
        return new int[0]; 
      
      var rows    = inputMatrix.GetLength(0); 
      var columns = inputMatrix.GetLength(1); 
      
      var totalNumber = rows * columns; 
      var directions = new List<int[]>(); 
      directions.Add(new int[]{0, 1}); // go right
      directions.Add(new int[]{1, 0}); // go down
      directions.Add(new int[]{0, -1}); // go left
      directions.Add(new int[]{-1, 0}); // go up
      
      var visited = new bool[rows, columns]; // false 
      
      var direction = 0; 
      
      // 0, -1 -> 
      int row = 0; 
      int col = -1; 
      int index = 0; 
      
      var spiral = new int[totalNumber]; 
      
      while(index < totalNumber)
      {
          // go right -> 1, 2, 3, 4, 5
          var nextRow = row + directions[direction][0];  // 0 1 + 0
          var nextCol = col + directions[direction][1];  // 0 0 + 1
        
          if(nextRow >= 0 && nextRow < rows && nextCol >= 0 && nextCol < columns && !visited[nextRow, nextCol])// 
          {
            spiral[index++] = inputMatrix[nextRow, nextCol];  
            
            visited[nextRow, nextCol] = true; 
            
            row = nextRow; 
            col = nextCol; 
          }
          else 
          {
            direction = (direction + 1) % 4; // 0 
          }
      }
      
      return spiral;       
    }

    static void Main(string[] args)
    {

    }
}

/*
1 2 3 4 5 -> automatically -> visited 1 2 3 4 5 -> change direction -> 
  right: [0, 1] 
  down:  [1, 0]
  left:  [0, -1]
  up: [-1, 0]
  */
/* the peer shared his code:
 * 
 if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            return new int[]{};
        
        int r1 = 0, r2 = matrix.GetLength(0) - 1;
        int c1 = 0, c2 = matrix.GetLength(1) - 1;
        int[] ans = new int[(r2 + 1) * (c2+1)];
        int k =0;
        while (r1 <= r2 && c1 <= c2) 
        {
            for (int c = c1; c <= c2; c++) 
                ans[k++] = matrix[r1, c];
            
            for (int r = r1 + 1; r <= r2; r++) 
                ans[k++] = matrix[r, c2];
            
            if (r1 < r2 && c1 < c2) 
            {
                for (int c = c2 - 1; c > c1; c--) 
                    ans[k++] = matrix[r2, c];
                
                for (int r = r2; r > r1; r--) 
                    ans[k++] = matrix[r, c1];
            }
            
            r1++;
            r2--;
            c1++;
            c2--;
        }
  */    