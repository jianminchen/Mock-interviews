using System;
using System.Collections.Generic;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {
      if(arr == null)
        return new int[0]; 
      
      var length = arr.Length; 
      
      var visitedElements = new Dictionary<int, int>(); 
      
      for(int index = 0; index < length; index++)
      {
        var current = arr[index]; 
        var search  = limit - current; 
        
        if(visitedElements.ContainsKey(search))
        {
          return new int[]{index, visitedElements[search]}; 
        }
        else 
        {
          if(visitedElements.ContainsKey(current))
            visitedElements[current] = index; 
          else
            visitedElements.Add(current, index);
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
array, not sorted, integer
ask: given limit = 21, find a pair of two indexes, arr[i] + arr[j] = limit


Iterate the array, 4, limit 21, -> check visited elements if there is 17 visited, -> find a pair 
dict<int, int> 4:0 -> O(1), extra space for dictionary 

Time complexity: O(n)
*/

/*
https://github.com/donnemartin/system-design-primer



https://www.linkedin.com/in/jianminchen
http://juliachencoding.blogspot.ca/
Leetcode
hackerrank - 20 contest, 1 gold, 2 silver, 7 bronze medal 
https://codereview.stackexchange.com/users/123986/jianmin-chen
303 mock interview
interviewing.io
refdash.com 
*/
