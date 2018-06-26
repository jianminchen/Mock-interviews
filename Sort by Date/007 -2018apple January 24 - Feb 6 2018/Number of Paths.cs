using System;

class Solution
{
    public static int NumOfPathsToDest(int n) // n = 4
    {
        if (n == 0)  // false
        {
            return 0;
        }

        var current = new int[n]; // 0 to n - 1

        // Arrays.fill(current, 1);

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (row > col)
                {
                    current[col] = 0;
                }

                if (row == 0)
                {
                    current[col] = 1;
                }
                else if (row < col)
                {
                    current[col] = current[col - 1] + current[col];
                }
            }
        }

        return current[n - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:

go north or go east
go up or go right
cross diagnal 

Ask: number of paths to (n - 1, n - 1)
  
  
  * *  * * *
  * *  * 5 *
  * *  2 5 9
  0 1  2 3 4
  1 1  1 1 1
  
  
  matrix(3, 3) = 5
  Time complexity: (n * n)
  Space complexity: O(n)
    
    Do not need previous row - advised by the peer 
  */