using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
        if (arr == null || k < 0 || arr.Length < 2)
        {
            return new int[0, 0];
        }

        Array.Sort(arr); // [-2, -1, 0, 1, 2]

        var pairs = new List<int[]>();

        var length = arr.Length;
        var left = 0;
        var right = 1;
        while (left <= right && right < length)
        {
            var leftValue = arr[left];
            var rightValue = arr[right];

            var diff = rightValue - leftValue;
            if (diff == k)
            {
                pairs.Add(new int[] { rightValue, leftValue });

                left++;
                right++;
            }
            else if (diff < k)
            {
                right++;
            }
            else
            {
                left++;
            }
        }

        // save to two dimension
        var output = new int[pairs.Count, 2];
        int index = 0;
        foreach (var item in pairs)
        {
            output[index, 0] = item[0];
            output[index, 1] = item[1];

            index++;
        }

        return output;
    }

    static void Main(string[] args)
    {

    }
}
/*
keyword:

distinct integer
nonnegative k, 
array not sorted

ask: return all pairs of numbers, [x, y], x is larger one, x - y = k 

constraint: reduce memory usage maintaining time efficiency

sort array, then go over the array, two pointers, 
find small value -> iterate -> 
  time complexity:
  O(n) -> sorting O(nlogn)
  space: O(1)
    
 [0, -1, -2, 2, 1]
 
    
    -> sorted 
 [-2, -1, 0, 1, 2]
 |    |
 
 -1 +  2 = 1 given k = 1, [-1, -2], advance to left pointer
 advance both pointer 
 move right pointer if it is smaller than k
 move left pointer if it is larger 
*/