using System;

class Solution
{
    public static int NumOfPathsToDest(int n)
    {
        if (n <= 0)
            return 0;

        if (n == 1)
            return 1;
        // O(n * n ) matrix -> O(n) space -> O(1) -> two variables 
        var SIZE = n;
        var currentRow = new int[SIZE];
        var previousRow = new int[SIZE];

        for (int col = 0; col < SIZE; col++)
        {
            currentRow[col] = 1;
            previousRow[col] = 1;
        }

        for (int row = 1; row < SIZE; row++)
        {
            for (int col = 0; col < SIZE; col++)
            {
                if (row <= col)
                {
                    currentRow[col] = currentRow[col - 1] + previousRow[col]; // left one + underneath 
                }
            }

            // copy array from current to previous
            for (int col = 0; col < SIZE; col++)
            {
                previousRow[col] = currentRow[col];
            }
        }

        return currentRow[SIZE - 1];
    }

    static void Main(string[] args)
    {

    }
}

