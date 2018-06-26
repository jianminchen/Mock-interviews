using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2)
    {
        // your code goes here
        if ((str1 == null || str1.Length == 0) && (str2 == null || str2.Length == 0))
        {
            return 0;
        }

        // assume that one of is not empty
        if (str1 == null || str1.Length == 0)
        {
            return str2.Length;
        }

        if (str2 == null || str2.Length == 0)
        {
            return str1.Length;
        }

        var length1 = str1.Length;
        var length2 = str2.Length;

        var memo = new int[length1][];
        for (int row = 0; row < length1; row++)
        {
            memo[row] = new int[length2];

            for (int col = 0; col < length2; col++)
            {
                memo[row][col] = -1; // not set
            }
        }

        return DeletionDistanceHelper(str1, str2, 0, 0, memo);
    }

    private static int DeletionDistanceHelper(string str1, string str2, int index1, int index2, int[][] memo)
    {
        var length1 = str1.Length;
        var length2 = str2.Length;

        if (index1 == length1)
        {
            return length2 - index2;  // outside -> 
        }

        if (index2 == length2)
        {
            return length1 - index1;
        }

        var hasMemo = memo[index1][index2] != -1;

        if (hasMemo)
        {
            return memo[index1][index2];
        }

        var visit1 = str1[index1];
        var visit2 = str2[index2];

        var isEqual = visit1 == visit2;

        // check if need to update memo
        var distance = 0;

        if (isEqual)
        {
            distance = DeletionDistanceHelper(str1, str2, index1 + 1, index2 + 1, memo);
        }
        else
        {
            // delete one of chars in two strings 
            distance = 1 + Math.Min(DeletionDistanceHelper(str1, str2, index1 + 1, index2, memo),
                                    DeletionDistanceHelper(str1, str2, index1, index2 + 1, memo));
        }

        memo[index1][index2] = distance; // do not calculate twice 

        return distance;
    }

    static void Main(string[] args)
    {

    }
}

// dynamic program -> recursive -> memo 
// heat -> hit distance 3
// 'h' == 'h', 
// index1 for heat -> distance same, index1 ++
// index2 for hit                    index2 ++
// 'e' ?= 'i', delete 'e' or delete 'i'
// Min(dist("at", "it"), dist("eat", "t")) + 1, count deletion, increment one 
// memo   use jagged array to express memo 
// "heat" - 4
// "hit"   - 3
// memo[4][3], 
// memo[row][0] = row, for any row from 0 to 3
// memo[0][col] = col, for any column for o to 2
// recursive, memoization 
// n * m , n is length of str1, m is length of str2 - wrong 
// 2^max(n, m) - without memoization -> 
// with memoization, n * m 


