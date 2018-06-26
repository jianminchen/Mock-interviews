using System;
using System.Collections.Generic;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {  // [4, 6, 10, 15, 16], 21
        if (arr == null) // false 
            return new int[0];

        var length = arr.Length; // 5
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < length; i++)
        {
            var current = arr[i]; // 4, 6, 10, 15
            var search = limit - current; // 17, 15, 11, 6

            if (dict.ContainsKey(search)) // true
            {
                return new int[] { i, dict[search] }; // [3, 1] 
            }
            else
            {
                if (dict.ContainsKey(current)) // 4
                {
                    dict[current] = i;
                }
                else
                    dict.Add(current, i); // 4:0, 6:1, 10:2
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

array - sorted? 

Ask: find two items with sum equals to given limit
index [i, j] where i > j, arr[i] + arr[j] = limit

Hashmap -> 
  
  [4, 6, 10, 15, 16]
  -> 
  
  4, check hashmap 21 - 4 = 17, if it is in hashmap, 
  put 4: 0 into hashmap
  
  6, look for 21 - 6 = 15 -> hashmap
  put 6: 1 into hashmap
  
  10, 21 - 10 = 11, not found
  put 10:2 into hashmap
  
  15, 21 - 15 = 6, find in hashmap, 1, return [3, 1]
  
    Space complexity: O(n), size of the array
    time complexity:  O(n), n is size of the array
    
    */