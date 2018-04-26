using System;

class Solution
{
    public static int NumOfPathsToDest(int n)
    {
        // your code goes here
        if (n < 0)
        {
            return -1;
        }

        if (n == 0)
        {
            return 1;
        }

        var paths = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            var isFirstRow = row == 0;

            for (int col = 0; col < n; col++)
            {
                if (isFirstRow)
                {
                    paths[0, col] = 1; // only by going right
                }
                else if (row > col)
                {
                    paths[row, col] = 0;
                }
                else if (row == col)
                {
                    paths[row, col] = paths[row - 1, col];
                }
                else if (row < col)  // (4,5) -> (3, 5) go north, (4, 4) -> right
                {
                    paths[row, col] = paths[row - 1, col] + paths[row, col - 1];
                }
            }
        }

        return paths[n - 1, n - 1];
    }

    static void Main(string[] args)
    {

    }
}

// n = 4, output = 5 
//NOT accepted (i >= j: xVal >= yVal)
// (1,0) -> (0,0) -> right NPD(1,0) = NPD(0,0)
// NPD(n, 0) = NPD(0,0) = 1, n from 0 to 5
// NPD(row, col), col > row , NPD(rol, col) = 0
// NPD(row, row) = NPD( row, row -1 ), row >= 1, on the red line 
// NPD(row, col), if col < row, then NPD(row, col) = NPD(row -1, col) + NPD(row, col -1)
//
// int[n,n]                                                   -> right
// base case -> row = 0