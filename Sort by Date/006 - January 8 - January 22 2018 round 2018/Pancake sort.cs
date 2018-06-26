using System;

class Solution
{
    public static int[] PancakeSort(int[] arr)  // [1, 5, 4, 3, 2]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return new int[0];
        }

        int length = arr.Length; // 5
        int index = 0;

        while (index < length) // 0 < 5 
        {
            int lastIndex = length - index - 1; // 4

            var maxIndex = getMaxIndex(arr, lastIndex); // 1
            swapTwoElements(arr, maxIndex, lastIndex); // 1, 4

            index++;
        }

        return arr;
    }

    private static int getMaxIndex(int[] arr, int lastIndex)
    {
        int max = arr[0];
        int maxIndex = 0;
        for (int i = 1; i <= lastIndex; i++)
        {
            var current = arr[i];

            if (current > max)
            {
                max = current;
                maxIndex = i;
            }
        }

        return maxIndex;

    }

    private static void swapTwoElements(int[] arr, int first, int second)
    {
        flip(arr, first + 1);  // 
        flip(arr, second + 1);
    }

    private static void flip(int[] arr, int firstKElement)
    {
        int start = 0;
        int end = firstKElement - 1;


        // [1 5 4 3 2] -> [2 5 4 3 1] -> [2 3 4 5 1] 
        while (start < end)
        {
            var tmp = arr[start];
            arr[start] = arr[end];
            arr[end] = tmp;

            start++;
            end--;
        }
    }

    static void Main(string[] args)
    {

    }
}

/*
Constaints: integer array arr
Define flip(arr, k) - reverse the order of the first k elements in the array 
Define pancakeSort(arr), only use flip API

[1, 5, 4, 3, 2]

how to put 5 in last position? find maxIndex = 1
  call flip(arr, maxIndex + 1)  -> flip 5 to first element
       flip(arr, length) -> 5 moves to last index
  implement swap(maxIndex, lastIndex
  )
  
  Time complexity: O(n^2)    n + n -1 + (n - 2)  + ... + 1
    
  Space complexity: O(1)  in place 
  */