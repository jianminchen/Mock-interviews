using System;

class Solution
{
    public static int NumOfPathsToDest(int n)
    {
        if (n <= 0)
            return 0;

        var currentRow = new int[n];
        var previousRow = new int[n];

        for (int col = 0; col < n; col++)
        {
            currentRow[col] = 1;
            previousRow[col] = 1;
        }

        for (int row = 1; row < n; row++)  // start from second row, row = 1
        {
            // handle by currentRow, previousRow
            for (int col = 0; col < row; col++)
                currentRow[col] = 0; // dark area

            for (int col = row; col < n; col++)
            {
                currentRow[col] = previousRow[col] + currentRow[col - 1];
            }

            // set currentRow to previousRow
            for (int col = 0; col < n; col++)
            {
                previousRow[col] = currentRow[col];
            }
        }

        return currentRow[n - 1];
    }

    public static int NumOfPathsToDest_usingTwoRows(int n)
    {
        if (n <= 0)
            return 0;

        var currentRow = new int[n];
        var previousRow = new int[n];

        for (int col = 0; col < n; col++)
        {
            currentRow[col] = 1;
            previousRow[col] = 1;
        }

        for (int row = 1; row < n; row++)  // start from second row, row = 1
        {
            // handle by currentRow, previousRow
            for (int col = 0; col < row; col++)
                currentRow[col] = 0; // dark area

            for (int col = row; col < n; col++)
            {
                currentRow[col] = previousRow[col] + currentRow[col - 1];
            }

            // set currentRow to previousRow
            for (int col = 0; col < n; col++)
            {
                previousRow[col] = currentRow[col];
            }
        }

        return currentRow[n - 1];
    }

    public static int NumOfPathsToDest_usingNxN(int n)
    {
        if (n <= 0)
            return 0;

        var path = new int[n, n];

        for (int col = 0; col < n; col++)
            path[0, col] = 1;

        for (int row = 1; row < n; row++)
        {
            for (int col = row; col < n; col++)
            {
                path[row, col] = path[row - 1, col] + path[row, col - 1];
            }
        }

        return path[n - 1, n - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:

rule: cannot cross diagonal line 
      only go to right - East  (right)
           go to up    - North (up)
  
ask: number of path to Dest(4,4) from start (0,0)
  
  
  x  x  x  x x
  x  x  x  x x
  x  x  x  x x
  x  x  x  x x
  x  x  x  x x
  --------------->
  
  x  x  x  x 14
  x  x  x  5 14     Dest(4, 4) = 5 = matrix(3, 3)
  x  x  2  5 9
  x  1  2  3 4
  1  1  1  1 1 (0,4)
  --------------->
  
  n = 4, output 5    EEENNN -> go east 3 times, go north 3 times
  
  Extra space -> matrix -> one row -> a few variables (I cannot recall!)
  
  */