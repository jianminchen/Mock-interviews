using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
        if (arr == null || arr.Length < 2 || k < 0)
        {
            return new int[0, 0];
        }

        Array.Sort(arr);   // added after running test 

        var length = arr.Length;

        var pairs = new List<int[]>();

        var left = 0;
        var right = 1;

        while (left <= right && right < length)
        {
            // try to find the pair for left point position
            var leftValue = arr[left];
            var rightValue = arr[right];

            var diff = rightValue - leftValue;

            if (diff == k)
            {
                pairs.Add(new int[] { arr[right], arr[left] });

                left++;
                right++;
            }
            else if (diff < k)
            {
                right++;
            }
            else
            {
                left++;
            }
        }

        var pairsInArray = new int[pairs.Count, 2];

        int index = 0;
        foreach (var item in pairs)
        {
            pairsInArray[index, 0] = item[0];
            pairsInArray[index, 1] = item[1];

            index++;
        }

        return pairsInArray;
    }

    static void Main(string[] args)
    {

    }
}
/*
keywords:
distinct 
integers
give nonnegative k, 
ask : [x, y], x - y = k 

find all pairs 

two pointers -> O(nlogn) -> scan left, right point 

2. 
memory usage -> hashset 

Time complexity: O(n) 
  O(n), n is zie of the array
 
-2, -1, 0, 1, 2 
 |   |
  -2, decide to move left point to next 
  
  Time complexity: O(n) -> O(nlogn)
  Space complexity: 
  
  */
