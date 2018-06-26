using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k) // [0, -1, -2, 2, 1]
    {
        if (arr == null || arr.Length == 0 || k < 0) // false
        {
            return new int[0, 0];
        }

        Array.Sort(arr); // -2, -1, 0, 1, 2

        var left = 0;
        var right = 1;
        var length = arr.Length; // 5
        var pair = new List<int[]>();

        while (left < length && right < length && left <= right)
        {
            var current = arr[right]; // 
            var leftValue = arr[left];

            var diff = current - leftValue;

            if (diff == k)
            {
                pair.Add(new int[] { current, leftValue });
                left++;
            }
            else if (diff > k)
            {
                left++;
            }
            else
            {
                right++;
            }
        }

        // go over the list and put to two dimension array 
        int size = pair.Count;
        var result = new int[size, 2];
        for (int i = 0; i < size; i++)
        {
            result[i, 0] = pair[i][0];
            result[i, 1] = pair[i][1];
        }

        return result;
    }

    static void Main(string[] args)
    {

    }
}

/*
Constraint:  distinct integers, array, nonnegative k >= 0, 
Find all pairs, such that         [x, y]   x - y = k, x >= y
Reduce memory usage 
         
         
0, -1, -2, 2, 1, k = 1
  
brute force - pairs - go over each pair, diff = k , put List<int[]> , O(n^2)
  0 - (-1) = 1
  -1 - (-2) = 1
  
  Sort the array
  -2 -1 0 1  2  -> given 1 
  
  -2, -1 -> add to result 
     -> -1, 0 -> add to result 
  two pointers 
  -2, -1, 

Time complexity: O(nlogn), O(n)
  
  */