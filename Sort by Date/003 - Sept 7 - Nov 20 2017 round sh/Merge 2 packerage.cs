using System;
using System.Collections.Generic;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {
        // your code goes here
        if (arr == null || arr.Length == 0)
        {
            return new int[0]; // empty array 
        }

        // assume that the array is not empty 
        var set = new HashSet<int>(); // O(n)

        var length = arr.Length;
        for (int index = 0; index < length; index++)
        {
            var visit = arr[index]; // 4, 6, 10, 15
            var search = limit - visit; // 17, 15, 11, 6
            if (set.Contains(search)) // true
            {
                return new int[] { index, Array.LastIndexOf(arr.SubArray(0, index - 1), search) }; // 15, 6 [3, 1]
            }

            set.Add(visit); // 4, 6 , 10, 
        }

        return new int[0];
    }

    static void Main(string[] args)
    {
        var result = GetIndicesOfItemWeights(new int[] { 4, 6, 10, 15, 16 }, 21);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}

// are you there?
//can you hear me? can you speak?
// hello
// 3 - 15, 1 - 6, 15 + 6 = 21
// two items -> 
// sorted array -> O(nlogn)
// n(n-1) -> O(n^2)
// brute force 
// for(int first = 0; first < length - 1; first ++)
// for(int second = first + 1; second < length; second++)
//    sum = arr[first] + arr[second]
//    return new int[]{first, second}
// Array.Sort(arr) -> ascending order
// two pointers  4, 16 -> 20 < 21, -> 6 + 16 = 22, 6 + 15 
// O(n)   
// data search -> 
// extra -> 
// 4, 17 in hashset -> Dictionary<int, int>,  value, index
// <4, 0>, 
// 6 -> 15 , add <6, 1> to the table 
// when we find 4, 21-4 = 17. 

// Array.IndexOf(value) -> first occurence -> hashtable -> hashset -> data search 
