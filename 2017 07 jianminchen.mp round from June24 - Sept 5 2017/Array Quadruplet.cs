using System;
using System.Collections.Generic;

// [2,3,4,5,6,7] target = 22
// [4,5,6,7]
// O(n^3) 
// O(n^2)   hashtable 
// nlogn -> sort the array -> given 22, 
// give all possible two sum -> 2, 3 -> 5, search two sum -> 17
// a < b < c < d , a + b < c + d, 
// -> [2, 7, 4, 0, 9, 5, 1, 3], s = 20 
// [0, 1, 2, 3, 4, 5, 7, 9] - 8 elements, sum = 20 
// O(n^2) -> (n - 2) * (n - 1), a <= b <= c <= d, a, b-> two sum , two sum -> c, d, two pointers -> O(n)
// O(n^3)
// two for loops -> two pointers techniques -> 
// -> hashtable ->  Dictionary<int, List<int[]>
// two sum -> O(n^2), put into hashtable -> dictionary , 22, for each pair in 22 - key, 
// index -> unique -> 
// more than one pair -> key, store as list -> go over the list 
class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s)
    {
        // your code goes here
        if (arr == null || arr.Length < 4)
        {
            return new int[0];
        }

        // added after mocking 
        Array.Sort(arr);

        var twoSumTable = getTwoSumTable(arr);

        // two sum - s/2 
        var half = s / 2;
        foreach (var pair in twoSumTable)
        {
            var key = pair.Key;
            if (key > half)
            {
                continue;
            }

            var value = pair.Value; // 4,  list1
            var search = s - key; // 4, 
            var found = twoSumTable.ContainsKey(search);
            if (!found)
            {
                continue;
            }

            var list = twoSumTable[search];
            var quadruplet = new int[4];
            var isUnique = checkUnique(value, list, ref quadruplet, arr);  // list1, list2, m, n -> m *n -> make sure unique 
            if (isUnique)
            {
                return quadruplet;
            }
        }

        return new int[0];
    }

    private static bool checkUnique(IList<int[]> list1, IList<int[]> list2, ref int[] quadruplet, int[] arr)
    {
        var length1 = list1.Count;
        var length2 = list2.Count;

        for (var index1 = 0; index1 < length1; index1++)
        {
            for (var index2 = 0; index2 < length2; index2++)
            {
                var pair1 = list1[index1];
                var pair2 = list2[index2];

                var checking = foundAscending(pair1, pair2);
                if (checking)
                {
                    quadruplet = new int[] { arr[pair1[0]], arr[pair1[1]], arr[pair2[0]], arr[pair2[1]] };
                    return checking;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// make it simple
    /// try to find four numbers, so that the indexes in the sorted array is in 
    /// ascending order
    /// </summary>
    /// <param name="pair1"></param>
    /// <param name="pair2"></param>
    /// <returns></returns>
    private static bool foundAscending(int[] pair1, int[] pair2)
    {
        var lastOne = pair1[1];
        var firstOne = pair2[0];

        return lastOne < firstOne;
    }

    private static Dictionary<int, IList<int[]>> getTwoSumTable(int[] arr)
    {
        var length = arr.Length;

        var twoSumTable = new Dictionary<int, IList<int[]>>();

        for (var first = 0; first < length - 1; first++)
        {
            for (var second = first + 1; second < length; second++)
            {
                var value1 = arr[first];
                var value2 = arr[second];
                var twoSum = value1 + value2;

                var valuePair = new int[] { first, second };

                if (twoSumTable.ContainsKey(twoSum))
                {
                    twoSumTable[twoSum].Add(valuePair);
                }
                else
                {
                    var list = new List<int[]>();
                    list.Add(valuePair);
                    twoSumTable.Add(twoSum, list);
                }
            }
        }

        return twoSumTable;
    }

    static void Main(string[] args)
    {
        var result = FindArrayQuadruplet(new int[] { 4, 4, 4, 4 }, 16);
    }
}