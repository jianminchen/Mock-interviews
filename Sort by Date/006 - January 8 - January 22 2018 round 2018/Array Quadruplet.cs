using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s)  // [1, 0, 2, 3,4], given sum = 5
    {
        if (arr == null || arr.Length < 4) // false 
        {
            return new int[0];
        }

        int length = arr.Length; // 5
        Array.Sort(arr); // [0, 1, 2, 3, 4]

        var twoSumDict = getTwoSumDictionary(arr);

        for (int first = 0; first < length - 3; first++)
        {
            for (int second = first + 1; second < length - 2; second++)
            {
                var firstTwoSum = arr[first] + arr[second]; // 0  + 1
                var search = s - firstTwoSum; // 4

                if (!twoSumDict.ContainsKey(search)) // [2, 3], [0, 4]
                {
                    continue;
                }

                foreach (var pair in twoSumDict[search])
                {
                    var thirdIndex = pair[0];
                    var fourthIndex = pair[1];

                    if (thirdIndex > second)
                    {
                        return new int[] { arr[first], arr[second], arr[thirdIndex], arr[fourthIndex] };
                    }
                }
            }
        }

        return new int[0];
    }

    private static Dictionary<int, List<int[]>> getTwoSumDictionary(int[] arr)
    {
        int length = arr.Length;

        var twoSumDict = new Dictionary<int, List<int[]>>();

        for (int first = 0; first < length - 1; first++)
        {
            for (int second = first + 1; second < length; second++)
            {
                var twoSum = arr[first] + arr[second]; // 1

                if (!twoSumDict.ContainsKey(twoSum))
                {
                    twoSumDict[twoSum] = new List<int[]>();
                }

                twoSumDict[twoSum].Add(new int[] { first, second });
            }
        }

        return twoSumDict;
    }

    static void Main(string[] args)
    {

    }
}

/*
You’re asked to return the first one you encounter (considering the results are sorted).

arr = [2, 7, 4, 0, 9, 5, 1, 3], s = 20
output: [0, 4, 7, 9] # The ordered quadruplet of (7, 4, 0, 9)
                     # whose sum is 20. Notice that there
                     # are two other quadruplets whose sum is 20:
                     # (7, 9, 1, 3) and (2, 4, 9, 5), but again you’re
                     # asked to return the just one quadruplet (in an
                     # ascending order)


constraints: unsorted array
             integer
             
  problem to solve:
given the sum s, find four numbers in the array sum up to give s. should be ascending order

brute force:  O(n^4)
O(n^2)  
Sort the array, ascending order
All two sum into the dictionary, [0, 1, 2, 3, 4, 5], 
   key, twoSum value, value -> List<int[]> 
   sum = 3, 1 + 2, 0 + 3, two pairs - List<int[]> new int[]{1, 2}, new int[]{0, 3}
for first i = 0 to length - 3
    for second i + 1 to length - 2
        sum = first + second
        search = 4sum - sum
        search the dictionary -> go over list, second's index < pair's smaller index 
        return  // <- 
      
      Time complexity: O(n^2)  better than O(n^4)
      space: n^2 dictionary 
      */