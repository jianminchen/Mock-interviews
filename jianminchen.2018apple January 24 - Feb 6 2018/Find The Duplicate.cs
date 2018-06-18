using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindDuplicates(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null)
        {
            return new int[0];
        }

        var length1 = arr1.Length;
        var length2 = arr2.Length;

        if (length1 > length2)
        {
            return FindDuplicates(arr2, arr1);
        }

        // first one is smaller size

        var duplicate = new List<int>();

        for (int i = 0; i < length1; i++)
        {
            var current = arr1[i];
            if (binarySearch(arr2, current))
            {
                duplicate.Add(current);
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
            {
                return true;
            }
            else if (middleValue < search)
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
        }

        return false;
    }

    static void Main(string[] args)
    {
        var duplicate = FindDuplicates(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 3, 6 });
        foreach (var item in duplicate)
        {
            Console.WriteLine(item);
        }
    }
}

/*
Keyword:
two sorted arrays - ascending order 
find duplicate number 

case: N is very close to M 
two pointer, left

O(M + N)

case: M >> N

O(M + N) = O(M)
  
  binary search in large array 
  
  O(NlogM) < O(M)
  */


