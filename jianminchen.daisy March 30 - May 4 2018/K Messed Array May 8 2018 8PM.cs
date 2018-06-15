// 
using System;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k) // [2, 3, 1, 4], k = 2
    {
        if (arr == null || k < 0) // false
        {
            return new int[0];
        }

        // work on selection sort, iterate on the array 
        int index = 0;
        var length = arr.Length; // 4

        while (index < length)
        {
            selectionSortToPlaceMinimumInPlace(arr, index++, k + 1);
        }

        return arr;
    }

    private static void selectionSortToPlaceMinimumInPlace(int[] numbers, int start, int totalNumber)// 0, 3
    {
        var length = numbers.Length; // 4

        for (int index = start; index < length && (index - start) < totalNumber; index++) // 0, 1, 2
        {
            if (numbers[index] < numbers[start]) // 
            {
                // swap two elements 
                var tmp = numbers[start];
                numbers[start] = numbers[index]; // 1
                numbers[index] = tmp; // 2
            }
        }
    }

    static void Main(string[] args)
    {
        // [1, 2, 3, 4], k = 2
        // [2, 3, 1, 4]
        var sorted = SortKMessedArray(new int[] { 2, 3, 1, 4 }, 2);
        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}

/*
keywords:

given array integer, sorted original, then each element can be moved away at most k places

For example: 
[1, 2, 3, 4], 1 move to index = 2 from index = 0 if k = 2 

  Ask: sort the array 
  
  Solution 1: optimal 
  
  minimum heap: 

k = 2, minimum heap size = 3 
  
  1
 /\
2  3
  
  k + 1 , minimum number in the heap is minimum in the array -> pop heap -> next element 4, push 4 into heap 
  
  2
  /\
  3 4
  
  Time complexity:  O(klogK + n * logK)
    
 C# heap class -> C# does not have class for heap -> 
   
  Solution 2: 

 selection sort
 
 Find minimum in k + 1 subarray
 
 [1, 2, 3, 4], given k = 2, work on subarray with size 3 = K + 1
 [1, 2, 3]  -> selection sort -> find minimum value 
  k + 1 time to find minimum value
   
 For whole array, time complexity O(n * (k + 1))  which is better than O(nlogn), k << n 
 
 */