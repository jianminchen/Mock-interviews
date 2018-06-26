using System;
using System.Collections.Generic;

class Solution
{
    // -2, -1, 0, 1, 2 k = 2
    // [-2, 0], [-1, 1], [0, 2]  
    // -2, -1  1 < 2, move right pointer, 
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
        // your code goes here
        if (arr == null || arr.Length == 0 || k <= 0)
        {
            return new int[0, 0];
        }

        Array.Sort(arr);  // ascending order

        var pairs = new List<int[]>();
        var length = arr.Length; //  5

        var start = 0;
        var end = 1;
        var startValue = arr[0]; //-2
        while (end < length)
        {
            var current = arr[end]; // -1, 0, 1

            if (start == end)
            {
                end++;
                continue;
            }

            startValue = (start < length) ? arr[start] : startValue; // possible issue              

            var difference = current - startValue;  // 1, 2
            var isEqual = difference == k;
            var isSmaller = difference < k;  // 1 < 2
            // var isBigger  = difference > k;

            if (isEqual)
            {
                pairs.Add(new int[] { current, startValue }); // [-2, 0]

                start++;
                end++;
            }
            else if (isSmaller)
            {
                end++;
                continue;
            }
            else   // isBigger 
            {
                start++;
            }
        }

        var size = pairs.Count;

        // added after mocking, understand the difference between int[0, 0] and int[2, 0]
        if (size == 0)
        {
            return new int[0, 0];
        }

        // store pair to two dimensional array
        var result = new int[size, 2];
        int index = 0;
        foreach (int[] item in pairs)
        {
            result[index, 0] = item[0];
            result[index, 1] = item[1];
            index++;
        }

        return result;
    }

    static void Main(string[] args)
    {

    }
}

/// [0, -1, -2, 2, 1], k = 1 > 0 
/// x - y = k 
// sorted array O(nlogn)
// -2, -1, 0, 1, 2
// two pointer technicqu -2, 2 -> 4, 1 -> 
// -2, , -1 vs 2 -> 
// -2, -1 -> 1, find one of them, [-2, -1]
// -1, 0, -> [-1, 0], 5 pairs for 1
// 1, 3, 5, 7, 12, 17, 32
// k = 1
// 1 vs 3, 2 > 1, 3 vs 3, -> 3 vs 5 -> move both 2 > 1 5 vs 7, , 7 vs 12, 12 vs 17 
// O(n) + O(nlogn) -> O(1)
// -2, -1, 0, 1, 2 k = 2
// [-2, 0], [-1, 1], [0, 2]  
// -2, -1  1 < 2, move right pointer, 