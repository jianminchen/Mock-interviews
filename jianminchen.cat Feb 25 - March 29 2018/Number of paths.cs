using System;

class Solution
{
    public static int NumOfPathsToDest(int n)
    {
        if (n == 0)
            return 1;

        var numberPath = new int[n];
        var previousRow = new int[n];

        for (int col = 0; col < n; col++)
        {
            numberPath[col] = 1;   // 
            previousRow[col] = 1;
        }

        for (int row = 1; row < n; row++)
        {

            for (int col = 0; col < n; col++)
                numberPath[col] = 0;

            for (int col = row; col < n; col++)  // vertical is column, col >= row
            {
                numberPath[col] = numberPath[col - 1] + previousRow[col];
            }

            // array copy 
            for (int col = 0; col < n; col++)
                previousRow[col] = 0;

            for (int col = row; col < n; col++)
                previousRow[col] = numberPath[col];
        }

        return numberPath[n - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
x x x x x x
x x x 5 14 28
x x 2 5 9 14
x 1 2 3 4 5
1 1 1 1 1 1     <- first row 

0 1 2 3 4 5
  
n = 4, value is 5 -> 
*/