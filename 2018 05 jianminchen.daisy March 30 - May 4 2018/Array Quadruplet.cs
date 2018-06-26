using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s)
    {
        if (arr == null || arr.Length < 4)
            return new int[0];

        var length = arr.Length;

        Array.Sort(arr);

        var dict = prepareTwoSum(arr);

        for (int first = 0; first < length - 3; first++)
        {
            for (int second = first + 1; second < length - 2; second++)
            {
                var firstValue = arr[first];
                var secondValue = arr[second];

                var search = s - firstValue - secondValue;

                // search the dictionary 
                if (!dict.ContainsKey(search))
                    continue;

                var pairList = dict[search];
                foreach (var item in pairList)
                {
                    var third = item[0];
                    if (third > second)
                    {
                        return new int[] { firstValue, secondValue, arr[third], arr[item[1]] };
                    }
                }
            }
        }

        return new int[0];
    }

    private static Dictionary<int, List<int[]>> prepareTwoSum(int[] numbers)
    {
        var length = numbers.Length;

        var dict = new Dictionary<int, List<int[]>>();

        for (int first = 0; first < length - 1; first++)
        {
            for (int second = first + 1; second < length; second++)
            {
                var twoSum = numbers[first] + numbers[second];


                if (!dict.ContainsKey(twoSum))
                {
                    dict.Add(twoSum, new List<int[]>());
                }

                dict[twoSum].Add(new int[] { first, second });
            }
        }

        return dict;
    }

    static void Main(string[] args)
    {
        var fourNumbers = FindArrayQuadruplet(new int[] { 0, 1, 2, 3, 4 }, 6);
        foreach (var item in fourNumbers)
        {
            Console.WriteLine(item + " ");
        }
    }
}

/*
keywords:
unsorted array, integer
given the sum

ask to find 4 numbers, in the ascending order, sum of 4 numbers == given sum

Brute force solution, O(n^4)
optimal O(n^3), O(n^2)
  
Sort the array -> o(nlogn)
1. brute force first two small numbers, O(n^2), and then use two pointer technique, find two sum. 
  O(n^3)
  the third number and fourth number are searched by linear time -> two pointer technique
2. brute force first two small numbers, all two sum pairs in the hashmap -> dictionary

  O(n^2logn)
  */

