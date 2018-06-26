using System;

class Solution
{
    public static int[] PancakeSort(int[] arr) // [1, 5, 4, 3, 2]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return new int[0];
        }

        int length = arr.Length; // 5
        int lastPosition = length - 1; // 4
        while (lastPosition > 0)
        {
            var maxIndex = findMaxIndex(arr, lastPosition); // 4, maxIndex = 1
            swap(arr, maxIndex, lastPosition); // 1 and 4 swap 
            lastPosition--;
        }

        return arr;
    }

    private static int findMaxIndex(int[] arr, int lastPosition) // 4 return 1 
    {
        int maxValue = arr[0]; // 1
        int maxIndex = 0; // 0

        for (int i = 0; i <= lastPosition; i++)
        {
            var visit = arr[i]; // 1
            if (visit > maxValue)
            {
                maxIndex = i; // 1
                maxValue = visit; // 5
            }
        }

        return maxIndex; // 1
    }

    private static void flip(int[] arr, int k)
    {
        int start = 0;
        int end = k - 1;

        while (start < end)
        {
            var tmp = arr[start];
            arr[start] = arr[end];
            arr[end] = tmp;

            start++;
            end--;
        }
    }

    private static void swap(int[] arr, int start, int end)
    {
        flip(arr, start + 1); // first ttwo
        flip(arr, end + 1);  // first 5 
    }

    static void Main(string[] args)
    {
        var sorted = PancakeSort(new int[] { 1, 5, 4, 3, 2 });

        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}

/*
[1, 5, 4, 3, 2]

flip(arr, k) - reverse first k, for exmaple, k = 3, [1, 5, 4]-> [4, 5, 1]
sort the array 
Find maximum value's index 
flip(arr, maxIndex) -> index = 0
flip(arr, arrSize) -> max -> last element of the array
swap(int maxIndex, int anyPosition)
{
   flipToFront
   flipToEnd
}
sort an elment 

*/
