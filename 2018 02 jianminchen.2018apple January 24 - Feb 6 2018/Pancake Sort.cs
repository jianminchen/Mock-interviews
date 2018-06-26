using System;

class Solution
{
    public static int[] PancakeSort(int[] arr) // [1, 5, 4, 3, 2]
    {
        if (arr == null || arr.Length == 0) // false
        {
            return new int[0];
        }

        var length = arr.Length; // 5
        int index = 0;
        while (index < length)
        {
            var lastPosition = length - 1 - index; // 4

            var maxIndex = getMaxIndex(arr, lastPosition);  // 1

            moveFromOneToAnother(arr, maxIndex, lastPosition);  // 4, 3, 2, 1, 

            index++;
        }

        return arr;
    }

    private static int getMaxIndex(int[] arr, int lastPosition)
    {
        var max = arr[0];
        var maxIndex = 0;
        for (int i = 1; i < arr.Length && i <= lastPosition; i++)
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

    private static void flipFirstKElements(int[] arr, int k)
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

    private static void moveFromOneToAnother(int[] arr, int maxIndex, int lastPosition)
    {
        flipFirstKElements(arr, maxIndex + 1);
        flipFirstKElements(arr, lastPosition + 1);
    }

    static void Main(string[] args)
    {

    }
}

// flip - first k elements in the array
// moveFromOneToAnother using two flips - left, right
// flip(left + 1) -> left index value to the first one
// flip(right + 1) -> first index value to the right index position
// try to put left index value to right index posititon, but right index value -> left index position
// time complexity O(n^2)   , in place o(1)
