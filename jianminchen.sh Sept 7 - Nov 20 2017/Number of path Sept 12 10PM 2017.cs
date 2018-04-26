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

        // n > 0 
        int Size = n;

        var path = new int[Size][];
        for (int row = 0; row < Size; row++)
        {
            path[row] = new int[Size]; // 4          
        }

        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)  // not col <= row, 5, 1 
            {
                var isZero = row == 0;
                if (isZero)
                {
                    path[0][col] = 1;
                }

                var blackArea = row > col;
                if (blackArea)
                {
                    path[row][col] = 0;
                }
                else
                {
                    // row - 1 >= 0, col - 1 >= 0
                    var checking = (row - 1) >= 0 && (col - 1) >= 0;
                    if (checking)
                    {
                        path[row][col] = path[row - 1][col] + path[row][col - 1]; // col - 1 >= 0, row - 1 >= 0
                    }
                }
            }
        }

        return path[n - 1][n - 1];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(NumOfPathsToDest(4));
    }
}

