using System;

class Solution
{
    public static int NumOfPathsToDest(int n) // n = 4
    {
        if (n < 0)  // false 
        {
            return -1;
        }

        if (n == 0) // false 
        {
            return 1;
        }

        var paths = new int[n, n];

        for (int col = 0; col < n; col++)
        {
            paths[0, col] = 1; // first row all 1 
        }

        for (int row = 1; row < n; row++) // second row and up 
        {
            for (int col = row; col < n; col++) // col >= row , left to right 
            {
                // col >= row
                paths[row, col] = paths[row - 1, col] + paths[row, col - 1];
            }
        }

        return paths[n - 1, n - 1];
    }

    static void Main(string[] args)
    {
        var paths = NumOfPathsToDest(-1);
        var paths1 = NumOfPathsToDest(0);
        var paths2 = NumOfPathsToDest(4);

        Console.WriteLine("-1 is" + paths + " and input is 0 with path" + paths1 + " and input 4 with paths " + paths2);
    }
}

/*

x x x x 14
x x x 5 14
x x 2 5 9
x 1 2 3 4
1 1 1 1 1 

Line 21, first column (0,0)
n = 4 , value is 5 

recurrence formula 
rows -> row 0 line 21, bottom -> up 
cols -> col 0 left to right, col 0 -> col 4

path(0, col) = 1, any col >= 0
path(row, col) = 0 , row > col 
path(row, col) = path(row - 1, col) + path(row, col - 1)  , row < col, row > 0, col > 0 
space complexity -> O(n * n )
time compllexity -> n * n , O(n*n)

*/