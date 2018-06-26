
using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
      if(arr == null || k < 0 )
        return new int[0,0]; 
      
      var length = arr.Length; 
      
      var hashSet = new HashSet<int>(); // save index and value 
      
      var pair = new List<int[]>(); // dictionary - [index], 
      
      for(int i = 0; i < length; i++)
      {
        var current = arr[i]; 
        
        var searchSmaller = arr[i] - k; 
        var searchBigger  = arr[i] + k; 
        
        if(hashSet.Contains(searchSmaller))
        {
          pair.Add(new int[]{current, searchSmaller}); 
        }
        
        if(hashSet.Contains(searchBigger))
        {
          pair.Add(new int[]{searchBigger, current});
        }
        
        hashSet.Add(current); 
      }          
      
      // return two dimension array
      var count = pair.Count; 
      var pairsInArray = new int[count, 2]; 
      
      for(int i = 0; i < count; i++)
      {
        pairsInArray[i, 0] = pair[i][0]; 
        pairsInArray[i, 1] = pair[i][1];
      }
      
      return pairsInArray; 
    }    
  
    static void Main(string[] args)
    {

    }
}

/*
keywords:

distinct, integer, array
nonnetative integer k, 
[x, y], x - y = k

[0, -1, -2, 2, 1], given k = 1
  
  [1, 0], [0, -1], [ -1, -2], [2, 1]
hashset -> 
[0], look for 1, or -1, 
not found, add 0 to hashset
-1, look for 0 or 2, but 0 is found, so [0, -1] to output
add -1 to hashset {0, -1}

-2, look for -1 or -3, 
found -1, add [-1, -2] to dimension array
add -2 to hashset {0, -1, -2}
2, look for 1 or 3, 

add 2 to hashset {0, -1, -2, 2}

1, look for 0 or 2
  add [1, 0] and [2, 1] to the output 
  
  total output: [0, -1], [-1, -2], [1, 0], [2, 1]
  
  */