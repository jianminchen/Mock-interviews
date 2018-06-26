using System;
using System.Collections.Generic;

class Solution
{
    // (1, 2,3, 4, 5,6)
    // given 4 sum 2,3,5,6 -> 1,4,5,6 - 16

    public static int[] FindArrayQuadruplet(int[] arr, int s)
    {
        if (arr == null || arr.Length < 4) // false 
        {
            return new int[0];
        }

        Array.Sort(arr); // 1, 2, 3, 4, 5, 6

        var dictionary = putAllTwoSumToDict(arr); // 

        int length = arr.Length; // 6

        for (int first = 0; first < length - 3; first++) // 0, < 3
        {
            for (int second = first + 1; second < length - 2; second++)// 1, < 4
            {
                var firstValue = arr[first]; // 1
                var secondValue = arr[second]; // 2
                var search = s - firstValue - secondValue; // 13

                if (dictionary.ContainsKey(search)) // -> arrow - like, more flat -> left side -> nested 
                {
                    var list = dictionary[search];
                    foreach (var item in list)
                    {
                        var third = item[0];
                        var fourth = item[1];
                        var thirdIndex = item[2];

                        var foundBiggerOne = thirdIndex > second;
                        if (foundBiggerOne)
                        {
                            return new int[] { firstValue, secondValue, third, fourth };
                        }// 42
                    } // match line 35
                }
            } // 23
        }// 21

        return new int[0];
    }

    private static Dictionary<int, List<int[]>> putAllTwoSumToDict(int[] arr)
    {
        int length = arr.Length; // 6

        var dict = new Dictionary<int, List<int[]>>();

        for (int first = 0; first < length - 1; first++) // 0 - < 5
        {
            for (int second = first + 1; second < length; second++) // 1, < 6
            {
                var valueNo1 = arr[first];
                var valueNo2 = arr[second];
                var twoSum = valueNo1 + valueNo2; // 3

                if (dict.ContainsKey(twoSum)) // 
                {
                    dict[twoSum].Add(new int[] { valueNo1, valueNo2, first });
                }
                else
                {
                    var list = new List<int[]>();
                    list.Add(new int[] { valueNo1, valueNo2, first });
                    dict.Add(twoSum, list);
                }
            }
        }

        return dict;
    }
    // https://codereview.stackexchange.com/questions/181046/four-sum-algorithm-mock-interview-practice
    // https://codereview.stackexchange.com/questions/181046/four-sum-algorithm-mock-interview-practice
    // n^2logn, 
    // n^3 
    static void Main(string[] args)
    {

    }
}
// 4 sum 
// [2, 7, 4, 0, 9, 5, 1, 3], given s = 20
// (7,9, 1, 3)  (2, 4, 9, 5)
// one -> ascending order
// time complexity O(n^2logn) -> O(n^3)
// sort array -> 
// put all two sum in ascending order into Dictionary<int, List<int[]>>
// (1, 2,3, 4, 5,6)
// given 4 sum 2,3,5,6 -> 1,4,5,6
// 3 - [1, 2]
// 5 - [1, 4,], [2, 3]
// for(firstNumber = 0, < length - 3) // 
//  for(second = firstNumber + 1, <Length - 2)
// twoSum = arr[first] + arr[second]
// search = givenSum - twoSum -> 
// check if index < int[2], int[0], int[1], int[2], int[3], return ascending order 


