using System;

class Solution
{
    public static int NumOfPathsToDest(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        var currentRow = new int[n];
        var previousRow = new int[n];

        for (int row = 0; row < n; row++) // row = 1
        {
            var firstRow = row == 0;
            for (int col = 0; col < n; col++)
            {
                if (firstRow)
                {
                    currentRow[col] = 1;
                }
                else
                {
                    currentRow[col] = 0;

                    if (row <= col)   // underneath diagnal line 
                    {
                        currentRow[col] = currentRow[col - 1] + previousRow[col];
                    }
                }
            }

            // set previous = current
            /*
            for(int col = 0; col < n; col++)
            {
              previousRow[col] = currentRow[col]; 
            }
            */
            Array.Copy(currentRow, previousRow, n);
        }

        return currentRow[n - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
Constaints: 

 (0,0) only can go east(right) or go up (north), you cannnot cross the diagnol line 
 start from (0,0)
 Try to solve path(n-1, n-1)
 
 
 x  x  x  x  14 Dest(5 -1 , 5 -1)
 x  x  x  5  14 
 x  x  2  5  9 
 x  1  2  3  4 
 1  1  1  1  1 
 ________________
 0  1  2  3
 
 (0,0)

A[row,j] = 1; row = 0
A[row, col] = A[row, col -1] + A[row - 1, col]      row > 0, row < col 

time complexity O(n * n)
n * n -> keep two rows -> current row / previous row -> space O(n)

*/

