using System;
using System.Collections.Generic;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {
        if (arr == null || arr.Length < 2) // false 
        {
            return new int[0];
        }

        var length = arr.Length; // 5

        var dict = new Dictionary<int, int>();
        dict.Add(arr[0], 0); // (4, 0)

        for (int index = 1; index < length; index++)
        {
            var visit = arr[index]; // 6, 10 
            var search = limit - visit; // 21 - 6 = 15, 11
            var findOne = dict.ContainsKey(search); // false 
            if (findOne)
            {
                return new int[] { index, dict[search] };
            }
            else
            {
                var hasKey = dict.ContainsKey(visit); // 
                if (hasKey)
                {
                    dict[visit] = index;
                }
                else
                {
                    dict.Add(visit, index); // (6, 1)
                }
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {

    }
}

// [4, 6, 10, 15, 16], lim = 21 
// [i, j] , i < j
// 21 
// 4 -> hashMap - (4, 0)
// 6 -> 21 -> 17 -> false, then add to (6,1)
// 2 * duplicate = sum, -> pair 
// linear scan O(n)
// space - O(n), hashmap -> 

