using System;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k)
    {
      if(arr == null || arr.Length == 0 || k < 0 || k > arr.Length)
        return new int[0];
      
      // selection sort
      var length = arr.Length;
      
      // in place algorithm
      int index = 0; 
      while( index < length)
      {
        putMinimumToFirstSwap(arr, index, k);
        index++;
      }
      
      return arr;
    }
  
    private static void putMinimumToFirstSwap(int[] numbers, int start, int k)
    {
      int minIndex = start;
      for(int index = start; index <= start + k && index < numbers.Length; index++)
      {
        var current = numbers[index];
        var minValue = numbers[minIndex];
        if(current < minValue)
        {
          minIndex = index;          
        }
      }
      
      // swap start with minIndex
      swap(numbers, start, minIndex);
    }
  
    private static void swap(int[] numbers, int pos1, int pos2)
    {
      var tmp = numbers[pos1];
      numbers[pos1] = numbers[pos2];
      numbers[pos2] = tmp;      
    }

    static void Main(string[] args)
    {

    }
}

// Array, integer, sorted -> move at most k places away 
// asking: sort the array
// nlogn - brute force - beat the solution using partial 
// Find minimum number 
// k + 1 into a data structure 
//k = 2
// [1, 4, 5]  -> extract minimum 1
// [4,5,] <- 2 -> extract minimum 
// selection sort -> k comparison -> k logN (find minimum  in each subarray)-> better than nlogn - complete sort the whole array
// minimum heap -> k + 1 -> O(1)  selection -> insertion O(logk+1), O(nlog(k+1)), is better compared to selection sort

/*
 * 
 * Julia shared something:
 * 
https://www.linkedin.com/in/jianminchen

jeff bae

leetcode 
udemy.com  - 15  jeff bae - how to prepare algorithm 

The art of readable code - 200 pages - readable -> expedite -> art 

- be nervous 
structure -> 
constraint -> 

*/