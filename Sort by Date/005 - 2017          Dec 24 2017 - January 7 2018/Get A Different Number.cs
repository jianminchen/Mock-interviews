using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr) // [1, 3, 2, 100]
    {
        if (arr == null || arr.Length == 0) //false
        {
            return 0;
        }

        scanArraySwap(arr);

        return findFirstMissingNumber(arr);
    }

    private static void scanArraySwap(int[] arr)
    {
        int length = arr.Length; // 4

        int index = 0;
        while (index < length)  /// [100, 1, 2, 3]
        {
            var number = arr[index]; // 1
            var isLessThanSize = number < length; // true, false 
            if (isLessThanSize && index != arr[index])
            {
                swap(arr, index, arr[index]); // 0, 1; 0, 3                            
            }
            else
            {
                index++; // 1
            }
        }
    }

    private static int findFirstMissingNumber(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length; i++)
        {
            if (arr[i] != i)
            {
                return i;
            }
        }

        return length;
    }

    private static void swap(int[] arr, int pos1, int pos2)
    {
        int tmp = arr[pos1];
        arr[pos1] = arr[pos2];
        arr[pos2] = tmp;
    }



    static void Main(string[] args)
    {
        Console.WriteLine(GetDifferentNumber(new int[] { 0, 1, 2, 3 }));
    }
}
// [0, 1, 2, 3]  - 
// 4 
// array size 4
// int[4] - 0 
// index = 0, 
// found[index] = 1, found[2] = 1, > 4, 
// scan minimum index with 0 -> size = 4
// O(n) space, time complexity O(n)
// 
// [1, 3, 2, 100] -> 0 
// size of 4
// [3, 1, 2, 100]
// [100, 1, 2, 3]
// 100 -> outside 100 - 
// 1 -> 
// time complexity once - O(n)

