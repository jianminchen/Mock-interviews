using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s) // [1, 2, 3, 4]  -> 10
    {
        if (arr == null || arr.Length < 4) // false 
        {
            return new int[0];
        }

        Array.Sort(arr); // nlogn 

        var length = arr.Length; // 4

        var dictionary = getTwoSum(arr); // <string, List<int[]>

        for (int first = 0; first < length - 3; first++)  // 4 , -, - , -  // n
        {
            for (int second = first + 1; second < length - 2; second++)     // n
            {
                var firstTwoSum = arr[first] + arr[second];
                var search = s - firstTwoSum;

                if (dictionary.ContainsKey(search))  // look up dictionary of two sum 
                {
                    var value = dictionary[search];

                    foreach (var item in value)  // ? logn - binary search - start -> O(1) - logn  n2, first, /second
                    {
                        if (item[0] > second)
                        {
                            return new int[] { arr[first], arr[second], arr[item[0]], arr[item[1]] };  // 
                        }
                    }
                }
            }
        }

        return new int[0];
    }

    private static Dictionary<int, List<int[]>> getTwoSum(int[] numbers)  // n2 => n2
    {
        var twoSum = new Dictionary<int, List<int[]>>();

        var length = numbers.Length; // 4

        for (int first = 0; first < length - 1; first++) // 
        {
            for (int second = first + 1; second < length; second++)
            {
                var sum = numbers[first] + numbers[second];

                if (!twoSum.ContainsKey(sum))
                {
                    twoSum.Add(sum, new List<int[]>());
                }

                twoSum[sum].Add(new int[] { first, second });
            }
        }

        return twoSum;
    }

    static void Main(string[] args)
    {

    }
}
/*
keywords:

unsorted 
integer
given sum s, find four numbers to sum of s

cosntraints: ascending order 

[0, 4, 7, 9] -> ascending order 

time complexity : O(n^4) -> 
  n = 4 -> preprocessing two sum -> dictionary )(n^2)
  brute force first two numbers, look up for the rest of sum -> check index, duplicate index
  O(n^2) -> best case, worst case, 
*/



