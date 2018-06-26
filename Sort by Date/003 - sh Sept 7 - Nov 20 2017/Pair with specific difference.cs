using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k) // [0, -1, -2, 2, 1 ], k = 1
    {
        // your code goes hereif
        if (arr == null || arr.Length == 0 || k <= 0)
        {
            return new int[0, 0];
        }

        // assume that arr is not empty
        var pairs = new List<int[]>(); // int[0] -> bigger value
        var set = new HashSet<int>();

        foreach (var number in arr) // 0, -1, -2 , 2, 1
        {
            var searchBigger = number + k; // 1 , 0, -1, 3, 2
            var searchSmaller = number - k; // -1, -2, -3, 1, 0 

            if (set.Contains(searchBigger)) // true, 2
            {
                // add the pair
                pairs.Add(new int[] { searchBigger, number }); // (0, -1), (-1, -2), [2, 1]
            }

            if (set.Contains(searchSmaller)) // -1=> true, 
            {
                // add the pair
                pairs.Add(new int[] { number, searchSmaller }); // -> [1, 0]
            }

            set.Add(number);   // {0, -1, -2, 2}
        }

        var count = pairs.Count; // 
        if (count == 0)
        {
            return new int[0, 0];
        }

        var pairsArray = new int[count, 2];
        int index = 0;
        foreach (var pair in pairs)
        {
            pairsArray[index, 0] = pair[0];
            pairsArray[index, 1] = pair[1];
            index++;
        }

        return pairsArray;
    }

    static void Main(string[] args)
    {
        var pairs = FindPairsWithGivenDifference(new int[] { 0, -1, -2, 2, 1 }, 1);

        for (var row = 0; row < pairs.GetLength(0); row++)
        {
            Console.WriteLine(pairs[row, 0] + "," + pairs[row, 1]);
        }
    }
}

// [0, -1, -2, 2, 1 ], k = 1
// not sorted, all pairs of (a, b), a < b, then b - a = k, k = 1
// Do not sorted, n * (n - 1), brute force, diff = k, time complexity O(n^2)
// sort array, -2, -1, 0, 1, 2,   k = 1, O(nlogn)
// left -> index = 0, right index = 1, add to output 
// extra few variable -> O(1), in place 
// hashtable -> O(n), distinct integers, O(n)
// O(n)
// iterate array, visit each element, 0, dictionary<int, int>, value, second index value, 0 -> dictionary
// -1, k = 1, two values -> 0 or -2, 
// [x, y] in arr, such that x - y = k > 0 , x = y + k; 

