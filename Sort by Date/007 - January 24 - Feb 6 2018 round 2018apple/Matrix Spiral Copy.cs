using System;
using System.Collections.Generic;

class Solution
{
    public static int[] SpiralCopy(int[,] inputMatrix)
    {
        if (inputMatrix == null || inputMatrix.GetLength(0) == 0 ||  // false
          inputMatrix.GetLength(1) == 0)
        {
            return new int[0];
        }

        var rows = inputMatrix.GetLength(0); // 4
        var columns = inputMatrix.GetLength(1);// 5

        var visited = new int[rows, columns]; // 0 

        var fourDirections = new List<int[]>();

        fourDirections.Add(new int[] { 0, 1 }); /// left to right
        fourDirections.Add(new int[] { 1, 0 }); // top to bottom
        fourDirections.Add(new int[] { 0, -1 }); // right to left
        fourDirections.Add(new int[] { -1, 0 }); // bottom to top

        var total = rows * columns;
        var index = 0;

        int row = 0;
        int col = 0;
        int direction = 0;

        var spiral = new int[total];

        while (index < total)
        {
            var current = inputMatrix[row, col];
            visited[row, col] = 1;

            spiral[index] = current;

            var nextRow = row + fourDirections[direction][0];
            var nextCol = col + fourDirections[direction][1];
            var isInRange = nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= columns;

            if (isInRange || visited[nextRow, nextCol] == 1)
            {
                direction = (direction + 1) % 4;
            }

            // next iteration 
            row = row + fourDirections[direction][0];
            col = col + fourDirections[direction][1];

            index++;
        }

        return spiral;
    }

    static void Main(string[] args)
    {

    }
}
/*
mark visited 

define four directions array - 
  left to right 
  top to bottom 
  right to left
  down to up   0 - 3
  
Define the check when to change direction 

1  2 3 4 5 -> out of bound -
        change direction -> top to bottom
        ...
  
   7 8 9 10 - change the direction, visited array, 10 is visited
 
   direction = (direction + 1) % 4 // map to 0 - 3, automatically 
  
time complexity O(n * m )   , n - rows, m - columns 

space O(n * m)
  
 write one loop 
 */

