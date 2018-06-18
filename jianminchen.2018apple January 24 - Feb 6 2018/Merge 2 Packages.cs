using System;
using System.Collections.Generic;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit) // [4, 6, 10,1 5, 16], lim = 21
    {
        if (arr == null || arr.Length < 2 || limit < 0) // false
        {
            return new int[0];
        }

        var dict = new Dictionary<int, int>();
        var length = arr.Length; // 6

        for (int index = 0; index < length; index++)
        {
            var current = arr[index]; // 4, 6, 10, 15
            var search = limit - current; // 17, 15, 11, 6

            if (dict.ContainsKey(search)) // false, true 
            {
                var value = dict[search]; // 1
                return new int[] { Math.Max(value, index), Math.Min(value, index) };
            }
            else
            {
                dict[current] = index; // [4, 0], [6, 1], [10, 2]
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords: 
given limit - limit
  
  integer array - not sorted 
  
search two indexes [i, j], i > j, arr[i] + arr[j] = limit

Find one pair only 

scan the array from left to array, 

[4, 6, 10, 15, 16]  limit = 21
  
  dictionary<int, int> 
  4 -> [4, 0]
  6 -> 15 in dict -> [6, 1]
  10 ->11 in dict -> [10, 2] 
  15 -> 6 in dict ? [6, 1], [3, 1] 
  
  O(1) -> hashset, dictionary 
  look up by value, find its index -> 
  
  Time space: O(n) - 

*/
