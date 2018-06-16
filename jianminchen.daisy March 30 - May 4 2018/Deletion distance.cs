using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2)
    {
        if (str1 == null || str2 == null)
            return -1;

        var length1 = str1.Length;
        var length2 = str2.Length;

        var dp = new int[length1 + 1, length2 + 1];

        for (int col = 0; col < length2 + 1; col++)
        {
            dp[0, col] = col;
        }

        for (int row = 0; row < length1 + 1; row++)
        {
            dp[row, 0] = row;
        }

        for (int row = 1; row < length1 + 1; row++)
        {
            for (int col = 1; col < length2 + 1; col++)
            {
                var char1 = str1[row - 1];
                var char2 = str2[col - 1];

                var isSame = char1 == char2;

                if (isSame)
                {
                    dp[row, col] = dp[row - 1, col - 1];
                }
                else
                {
                    dp[row, col] = 1 + Math.Min(dp[row - 1, col], dp[row, col - 1]);
                }
            }
        }

        return dp[length1, length2];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(DeletionDistance("heat", "hit"));
    }
}

/*
heat -> hit   3, delete e, a, i from hit -> ht

work on "heat", "hit"
  
          ""   'h'  'e'   'a'    't'
          ""   "h"  "he"  "hea"  "heat"
          ---------------------------------
 '' ""     0    1    2     3      4
 'h' "h"   1    0   0 + 1  2      3   
 'i' "hi"  2
 't' "hit" 3                      ?
 
 Space complexity: O(length1 * length2) -> O(min(length2, length1)
 Time complexity: O(length1 * length2)
 */