using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2, int index1, int index2, int[][] memo)
    {
        // your code goes here

        if ((str1 == null || str1.Length == 0) &&
           (str2 == null || str2.Length == 0))
        {
            return 0;
        }

        if (str1 == null || str1.Length == 0)
        {
            return str2.Length;
        }

        if (str2 == null || str2.Length == 0)
        {
            return str1.Length;
        }

        if (index1 == str1.Length)
        {
            return str2.Length - index2;
        }

        if (index2 == str2.Length)
        {
            return str1.Length - index1;
        }

        int length1 = str1.Length;
        int length2 = str2.Length;

        if (memo == null)  // memo "dog", "frog"
        {
            memo = new int[length1][];
            for (int i = 0; i < length1; i++)
            {
                memo[i] = new int[length2];
            }

            for (int row = 0; row < length1; row++)
            {
                for (int col = 0; col < length2; col++)
                {
                    memo[row][col] = -1;
                }
            }
        }

        bool noMemo = memo[index1][index2] == -1;

        if (!noMemo)
        {
            return memo[index1][index2];
        }

        // recursive call 
        var isEqual = str1[index1] == str2[index2];
        int distance = 0;
        if (isEqual)
        {
            distance = DeletionDistance(str1, str2, index1 + 1, index2 + 1, memo); // delete, 0 
        }
        else
        {
            var option1 = 1 + DeletionDistance(str1, str2, index1 + 1, index2, memo);  // delete one char
            var option2 = 1 + DeletionDistance(str1, str2, index1, index2 + 1, memo);  // delete one char
            distance = Math.Min(option1, option2);
        }

        memo[index1][index2] = distance;

        return distance;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(DeletionDistance("dog", "frog", 0, 0, null));
        Console.WriteLine(DeletionDistance("some", "thing", 0, 0, null));

    }
}

//dog -> frog 
// heat -> hit , h -> eat vs it , e != i, 
// remove e, dist("at","it")
// remove i, dist("eat","t")
// Math.Min(dist("at","it"), dist("eat","t")), memoization key string "at it", "it at"
// left -> right, index , index -> unique -> int[] key int[2], compare function 
//memo[i][j] jagged array i, j already store
// base case: 
// "", "abc" 

