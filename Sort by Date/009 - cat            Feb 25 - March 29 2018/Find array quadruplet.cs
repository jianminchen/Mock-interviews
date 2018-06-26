
// https://leetcode.com/problems/container-with-most-water/description/


using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s)
    {
        if (arr == null || arr.Length < 4)
            return new int[0];

        Array.Sort(arr);

        var dict = getTwoSumDictionary(arr);

        var length = arr.Length;

        for (int first = 0; first < length - 3; first++)
        {
            for (int second = first + 1; second < length - 2; second++)
            {
                var twoSum = arr[first] + arr[second];
                var search = s - twoSum;

                if (dict.ContainsKey(search))
                {
                    var values = dict[search]; // List<int[]>

                    foreach (var item in values)
                    {
                        // if(item[0] > second) // it may be a valid quar - sort them out -> 
                        {
                            return new int[] { arr[first], arr[second], arr[item[0]], arr[item[1]] };
                        }
                    }
                }
            }
        }

        return new int[0];
    }

    private static IDictionary<int, List<int[]>> getTwoSumDictionary(int[] numbers)
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

                dict[twoSum].Add(new int[] { first, second }); /// not - she comparison - comparison 
            }
        }

        return dict;
    }

    static void Main(string[] args)
    {

    }
}

//https://github.com/derekhh/LeetCode

//Leetcode Triangle - medium level 

//  https://cs.stackexchange.com/questions/2973/generalised-3sum-k-sum-problem/2995#2995
/*
4sum -> preprocessing two sum pairs, brute force first two smaller number, then look up dictionary of two sum, 
  try to find a pair with distinct index, smaller index > second smaller 

brute force first two numbers, 
  
  a < b < c < d, brute force a and b, and then find c and d by looking up two sum dictionary. 
  first < second, twoSum, search s - twoSum in dictionary
  value int[]   index1 < index2, make sure that second < index1, 
  
  arr[first], arr[second], arr[index1], arr[index2]
  
  Sort the array -> nlogn 
  
  brute force any two numbers in the array, add sum to dictionary, value is index of array - O(n^2)
  Second one: 
  brute force first two small number, and then two pointers to find third/ fourth numbers, O(n^3
  
  )
  */