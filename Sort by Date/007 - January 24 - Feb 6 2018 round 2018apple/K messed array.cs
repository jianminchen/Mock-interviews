using System;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k) // [1, 4, 5, 2, 3], k = 2
    {
        if (arr == null || arr.Length == 0 || k < 0)  // false 
        {
            return new int[0];
        }

        int length = arr.Length; // 5

        int index = 0;
        while (index < length)
        {
            findKPlusOneMinimumInpace(arr, index, k);

            index++;
        }

        return arr;
    }

    private static void findKPlusOneMinimumInpace(int[] arr, int start, int k)
    {
        int length = arr.Length; // 5

        for (int i = start; i < length && i < (start + k + 1); i++) // 0, 1, 2
        {
            var first = arr[start];
            var second = arr[i];

            if (first > second)
            {
                var tmp = arr[start];
                arr[start] = arr[i];
                arr[i] = tmp;
            }
        }
    }

    static void Main(string[] args)
    {

    }
}

/*
look up K + 1, if k = 2, find first 3 numbers and then we can find minimum number 

first K + 1 -> O(klogk) -> minimum number -> min heap -> log K 

k comparison
1, 4, 5
  at most k swap -> kn - n is array length 
  
  
  java priorityQueue analog in C# 
  */
