using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindDuplicates(int[] arr1, int[] arr2)
    {
        // your code goes here
        // 
        if (arr1 == null || arr1.Length == 0 || arr2 == null || arr2.Length == 0)
        {
            return new int[0];
        }

        // not empty - arr1 - short one, arr2 - longer one
        var length1 = arr1.Length;
        var length2 = arr2.Length;

        var firstOneSmall = length1 <= length2;
        if (!firstOneSmall)
        {
            return FindDuplicates(arr2, arr1);
        }

        var list = new List<int>();

        foreach (var number in arr1) // short one 
        {
            if (binarySearch(number, arr2))
            {
                list.Add(number);
            }
        }

        return list.ToArray();
    }

    private static bool binarySearch(int search, int[] numbers)
    {
        var length = numbers.Length;

        var start = 0;
        var end = length - 1;

        while (start <= end)
        {
            int middle = start + (end - start) / 2;

            // assume that middle >= 0 => end > = start
            var middleValue = numbers[middle];

            var found = search == middleValue;
            var less = search < middleValue;

            if (found)
            {
                return true;
            }


            if (less)
            {
                end = middle - 1;
            }
            else
            {
                start = middle + 1;
            }
        }

        return false;
    }

    static void Main(string[] args)
    {

    }
}

// M is close to N, 
// 1, 2, 3, 4, 6, 7
// -> 2 -> 3 -> 
// 3 6 7 8 20 
// 3 -> 
// while (index1 < length1 && index2 < length2)
// O(max(m, n))  m + n
// M >> N
// go over each number in small size array, binary search in big array 
