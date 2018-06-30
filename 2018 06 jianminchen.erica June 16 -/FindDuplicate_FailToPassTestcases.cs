using System;
using System.Collections.Generic;

class Solution
{
    /// <summary>
    /// June 30, 2018 - A bug in the code - binary search 
    /// line 66 - the code could not pass all test cases. 
    /// </summary>
    /// <param name="arr1"></param>
    /// <param name="arr2"></param>
    /// <returns></returns>
    public static int[] FindDuplicates(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null || arr1.Length == 0 || arr1.Length == 0)
            return new int[0];

        var length1 = arr1.Length;
        var length2 = arr2.Length;

        if (length1 > length2)
            return FindDuplicates(arr2, arr1);

        var duplicate = new List<int>();

        for (int i = 0; i < length1; i++)
        {
            var current = arr1[i];

            if (binarySearch(current, arr2))
            {
                Console.WriteLine(current);

                duplicate.Add(current);
            }
        }

        var size = duplicate.Count;
        int[] duplicateArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            duplicateArray[i] = duplicate[i];
            Console.WriteLine(duplicate[i]);
            Console.WriteLine(size);
        }

        return duplicateArray;
    }

    private static bool binarySearch(int search, int[] numbers)
    {
        var length = numbers.Length;

        int start = 0;
        int end = length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = numbers[middle];

            if (middleValue == search)
                return true;
            else if (search < middleValue)
                start = middle + 1;
            else
                end = middle - 1;
        }

        return false;
    }


    static void Main(string[] args)
    {

    }
}

/*
keywords: two sorted array, return the numbers in both arrays
sorted in an ascending order
two cases: M is close N or M >> N
solutions:
O(M + N), for M is close to N -> M + N comparison, each comparison at least advance of pointers
for the case: M >> N
N smaller, N logM  - iterate the small size of array, try to find in a big array using binary search 
*/