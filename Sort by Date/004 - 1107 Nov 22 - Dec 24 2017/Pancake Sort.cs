using System;

class Solution
{
    public static int[] PancakeSort(int[] arr) // [1,5, 4, 3, 2]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return new int[0];
        }

        int length = arr.Length; // 5

        int lastIndex = length - 1; // 4
        for (int index = 0; index < length; index++)
        {
            var maxIndex = getMax(arr, lastIndex); // 1
            swap(arr, maxIndex, lastIndex); // swap(arr, 1, 4)

            lastIndex--;
        }

        return arr;
    }

    private static int getMax(int[] arr, int lastIndex)
    {
        int maxIndex = 0;
        int maxValue = arr[0];
        for (int i = 1; i <= lastIndex; i++)
        {
            var visit = arr[i];
            var isBigger = visit > maxValue;

            maxIndex = isBigger ? i : maxIndex;
            maxValue = isBigger ? visit : maxValue;
        }

        return maxIndex;
    }

    private static void swap(int[] arr, int left, int right)
    {
        flip(arr, left + 1);  // 
        flip(arr, right + 1);
    }

    private static void flip(int[] arr, int k)
    {
        var start = 0; // 0
        var end = k - 1; // 1

        while (start < end) // 0 < 1
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
        var result = PancakeSort(new int[] { 1, 5, 4, 3, 2 });

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}

/*
rr = [1, 5, 4, 3, 2]

rr = [5, 1, 4, 3, 2]

rr = [2, 3, 4, 1, 5] -> flip 
-> iterate -> 
  -> O(n) -> O(n) swap - two flip O(n) + O(n-1)+ ... + O(1) = O(n^2)  time complexity 
  */
// in place O(1)
