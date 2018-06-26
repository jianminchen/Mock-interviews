using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindDuplicates(int[] arr1, int[] arr2) // 
    {
        if (arr1 == null || arr2 == null || arr1.Length == 0 || arr2.Length == 0) // false
        {
            return new int[0];
        }

        var list = new List<int>();

        var length1 = arr1.Length; // 6
        var length2 = arr2.Length; // 5

        var index1 = 0;
        var index2 = 0;

        while (index1 < length1 && index2 < length2) // true 
        {
            var visit1 = arr1[index1]; // 1
            var visit2 = arr2[index2]; // 3

            var isEqual = visit1 == visit2; // false  
            var firstSmaller = visit1 < visit2; // true

            if (isEqual)
            {
                list.Add(visit1);
                index1++;
                index2++;
            }
            else if (firstSmaller)
            {
                index1++;
            }
            else
            {
                index2++;
            }
        }

        // https://stackoverflow.com/questions/268671/best-way-to-convert-ilist-or-ienumerable-to-array/16970830
        var result = new int[list.Count];
        var index3 = 0;
        foreach (var item in list)
        {
            result[index3++] = item;
        }
        //T[] array = query.Cast<T>().ToArray();

        return result;

    }

    static void Main(string[] args)
    {

    }
}

// M = N 
// [1, 2, 3, 5, 6, 7]
//     |
// [3, 6, 7, 8, 20]
//  |
// 3, 6, 7 
//time complexity O(M + N), Max(M, N) - space , O(1)

// M >> N
// O(N) -> O(M) -> binary search logM -> Time complexity N * logM << N * M
// binary search -> logM -> 