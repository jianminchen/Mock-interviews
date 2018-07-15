using System;
using System.Collections.Generic;

class Solution
{
    /// <summary>
    /// Merge 2 packages
    /// July 7, 2018
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {
      if(arr == null || arr.Length < 2 || limit <= 0)
        return new int[0];
      
      var dict = new Dictionary<int, int>(); 
      
      var length = arr.Length; 
      
      for(int i = 0; i < length; i++)
      {
        var current = arr[i];
        var search = limit - current; 
        
        if(dict.ContainsKey(search))
          return new int[]{i, dict[search]};
        else
        {
          if(dict.ContainsKey(current))
            dict[current] = i;
          else
            dict.Add(current, i); 
        }
      }
      
      return new int[0];
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:  limit - int, given an integer item weight, 
ask: find two items  - sum of two items = given limit
return [i, j] - i > j, return empty array 

- brute force O(n * n) - time complexity 
- O(n) time complexity, use space trade time complexity 
- brute force bigger index i, find smaller index j - look up hashset/ dictionary, key - weight, value - index, two items will be given limit 
*/