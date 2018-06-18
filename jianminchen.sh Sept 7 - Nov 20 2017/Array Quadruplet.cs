using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s) // [3, 2, 1, 4, 5] -> given sum: 12 = 1 + 2 + 4 + 5
    {
        if (arr == null || arr.Length < 4) // false 
        {
            return new int[0];
        }

        Array.Sort(arr); // [1, 2,3, 4, 5]

        var dictionary = saveTwoSumToDictionary(arr); // 

        int length = arr.Length;

        for (int first = 0; first < length - 3; first++) // 0, 1
        {
            for (int second = first + 1; second < length - 2; second++) // 1
            {
                var firstTwoSum = arr[first] + arr[second]; // 1 + 2 = 3
                var no1 = arr[first]; // 1
                var no2 = arr[second]; // 2

                var search = s - firstTwoSum; // 12 - 3 = 9 

                // search the dictionary 
                if (!dictionary.ContainsKey(search))
                {
                    continue;
                }

                // go over the list to find one 
                var options = dictionary[search];
                foreach (int[] pair in options)
                {
                    // check very simple logic: 
                    var no3 = pair[0];
                    var no4 = pair[1];

                    var index3 = pair[2];

                    var unique = no2 <= no3 && second < index3; // same value but index is different, include duplicate number case 
                    if (unique)
                    {
                        return new int[] { no1, no2, no3, no4 }; // no1 < no2 < no3 < no4 , duplicate number -> index are different 
                    }
                }
            }
        }

        return new int[0];
    }

    private static IDictionary<int, IList<int[]>> saveTwoSumToDictionary(int[] arr) // [1,2, 3, 4, 5]
    {
        var twoSum = new Dictionary<int, IList<int[]>>(); // 

        int length = arr.Length; // 5
        for (int i = 0; i < length - 1; i++) // 0 - 3 , 1, 2, 3, 4
        {
            for (int j = i + 1; j < length; j++) // 1, 2, 
            {
                var no1 = arr[i];
                var no2 = arr[j];

                var sum = no1 + no2; // 3

                if (twoSum.ContainsKey(sum)) // 5 , [1,4], [2, 3]
                {
                    twoSum[sum].Add(new int[] { no1, no2, i, j });
                }
                else
                {
                    var newList = new List<int[]>();
                    newList.Add(new int[] { no1, no2, i, j });
                    twoSum.Add(sum, newList);
                }
            }
        }

        return twoSum;

    }

    static void Main(string[] args)
    {

    }
}