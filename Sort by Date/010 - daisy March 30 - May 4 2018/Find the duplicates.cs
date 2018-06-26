
using System;
using System.Collections.Generic;

class Solution
{
    /// same size 
    public static int[] FindDuplicates_linear(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null)
            return new int[0];

        var length1 = arr1.Length;
        var length2 = arr2.Length;

        var index1 = 0;
        var index2 = 0;
        var duplicate = new List<int>();

        while (index1 < length1 && index2 < length2)
        {
            var first = arr1[index1];
            var second = arr2[index2];

            if (first == second)
            {
                duplicate.Add(first);
                index1++; // added by interviewer
                index2++;
            }
            else if (first < second)
            {
                index1++;
            }
            else
            {
                index2++;
            }
        }

        return duplicate.ToArray();
    }

    // binary search M >> N
    public static int[] FindDuplicates(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null)
            return new int[0];

        if (arr1.Length > arr2.Length)
            return FindDuplicates(arr2, arr1);

        var length1 = arr1.Length;

        var duplicate = new List<int>();

        foreach (var item in arr1)
        {
            if (binarySearch(arr2, item))
            {
                duplicate.Add(item);
            }
        }

        return duplicate.ToArray();
    }

    private static bool binarySearch(int[] numbers, int search)
    {
        int start = 0;
        int end = numbers.Length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = numbers[middle];

            if (middleValue == search)
                return true;

            if (middleValue < search)
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
keywords:
two sorted array, ascending order
case 1: M is same as N, very close
case 2: One is much bigger than another

ask:
find duplicate 

solution:
case 1:  O(M + N)
  linear scan two array, advance one pointer for each comparison, M + N at most comparison
  
case 2: iterate on small array, for each number, search large array using binary search 
  Time complexity: O(M logN), assuming that M << N, think it is better than O(M + N)
*/