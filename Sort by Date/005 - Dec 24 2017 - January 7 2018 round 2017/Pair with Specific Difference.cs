using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k) // [0, -1, -2, 2, 1], k = 1
    {
        if (arr == null || arr.Length <= 1 || k < 0) // false 
        {
            return new int[0, 0];
        }

        int length = arr.Length;  // 5

        Array.Sort(arr); // -2, -1, 0, 1, 2

        var pair = new List<int[]>();

        int front = 1;
        int back = 0;

        while (front < length && back < length)   // [1, 5, 7, 11]
        {
            var bigger = arr[front];
            var smaller = arr[back];

            var diff = bigger - smaller;
            var found = diff == k;
            if (found)
            {
                // add to the pair
                pair.Add(new int[] { bigger, smaller });
                //
                back++;
            }
            else if (diff < k)
            {
                front++;
            }
            else
            {
                back++;
            }
        }


        // convert to the two dimension array
        var pairLength = pair.Count;

        var pairArray = new int[pairLength, 2];

        for (int i = 0; i < pairLength; i++)
        {
            pairArray[i, 0] = pair[i][0];
            pairArray[i, 1] = pair[i][1];
        }

        return pairArray;
    }

    private static bool binarySearch(int[] numbers, int start, int end, int search) // 1, 4, 1
    {
        while (start <= end)    // true
        {
            int middle = start + (end - start) / 2; // 2
            var middleValue = numbers[middle]; // 0

            var found = middleValue == search; // false 
            if (found)
            {
                return true;
            }
            else if (middleValue < search) // 0 < 1
            {
                start = middle + 1; // 3
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
        var pair = FindPairsWithGivenDifference(new int[] { 0, -1, -2, 2, 1 }, 1);

        var rows = pair.GetLength(0);

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine(pair[i, 0] + "," + pair[i, 1]);
        }
    }
}

/*
[0, -1, -2, 2, 1], k = 1  x - y = k , k = 1, x > y
O(n^2)

sort the array -  O(nlogn)
[-2, -1, 0, 1, 2]  -> all possible pairs -2, need to find -2 + 1 = -1, binary search  nlogn

O(nlogn)

extra space 
scan the array, in the same time, put past integer in hashset, 
-2, try to find -3, -2 hashset
-1, -2 in hashset, [-1, -2] result list, 
[-1] in hashset
-> O(n), space O(n)
*/
