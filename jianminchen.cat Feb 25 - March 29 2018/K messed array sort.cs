
using System;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k)
    {
      if(arr == null || k < 0)  
        return new int[0]; 
      
      var length = arr.Length; 
      
      for(int i = 0; i < length; i++)
      {
        var minimumIndex = findMinimumIndexNextContiguousSubarray(arr, i, k + 1); 
        swap(arr, minimumIndex, i); 
      }
      
      return arr; 
    }
  
    private static int findMinimumIndexNextContiguousSubarray(int[] numbers, int start, int size)
    {
      int length = numbers.Length; 
      
      int minimumIndex = start; 
      var minimumValue = numbers[minimumIndex]; 
      for(int i = start + 1; i < Math.Min(start + size, length); i++)
      {        
        var current = numbers[i]; 
        if(current < minimumValue)
        {
          minimumValue = current; 
          minimumIndex = i; 
        }
      }
      
      return minimumIndex; 
    }
  
  private static void swap(int[] arr, int pos1, int pos2)
  {
    var tmp = arr[pos1]; 
    arr[pos1] = arr[pos2]; 
    arr[pos2] = tmp; 
  }

    static void Main(string[] args)
    {

    }
}

/*
[1, 4, 5, 2, 3, 7, 8, 6, 10, 9], k = 2, 
Find minimum in the array first, 
[1, 4, 5] -> find minimum in K + 1, 1
 [1,]
 [4, 5, 2] -> find minimum in contiguous subarray
 [1, 2, 5, 4] -> depth first search -> find minimum in contiguous subarray with size K + 1
  
-> minimum heap -> K + 1 minimum heap -> 
-> simulated 
k comparison, one swap -> minimum index -> 
Time complexity: O(kn) -> it is better than O(nlogn), k << n
*/



Sabri Shiraz
