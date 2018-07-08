using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
        if (arr == null || arr.Length < 2 || k < 0)
            return new int[0, 0];

        var dict = saveToDict(arr);  // int, List<int>

        var pairs = new List<int[]>();

        int length = arr.Length;

        for (int i = 0; i < length; i++)
        {
            var current = arr[i];

            var search = current + k;

            if (!dict.ContainsKey(search))
                continue;

            var item = dict[search];


            var left = arr[item];
            var right = arr[i];

            pairs.Add(new int[] { left, right });

        }

        // convert to dimension return 
        return convertToDimensionArray(pairs);
    }

    private static Dictionary<int, int> saveToDict(int[] numbers)
    {
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            var current = numbers[i];


            dict.Add(current, i);
        }

        return dict;
    }

    private static int[,] convertToDimensionArray(List<int[]> pairs)
    {

        var count = pairs.Count;

        var pairsInArray = new int[count, 2];

        var index = 0;
        foreach (var pair in pairs)
        {
            pairsInArray[index, 0] = pair[0];
            pairsInArray[index, 1] = pair[1];

            index++;
        }

        return pairsInArray;
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords: distinct integer array, k >= 0, 
asking pairs with given differnce k, [x, y], x - y = k , bigger value first
constraint: y element in the original array 

k = 1
 [5,4, 3, 2, 1] 
 y =5, hashset 6 -> no, 5 -> hashset 
 y = 4, hashset [5], [5, 4] -> 
  on right side of 4, index = 1, missing those pair
  -> left to right -> O(n)
  
  brute force solution - n ^2 -> index of small value , pair 
  put the array into dictionary, search value quickly -> value as key, dictionary key should be list of index elements
  take O(n) 
  go over the array, each value in the array, search k + currentValue in the dictionary 
  */