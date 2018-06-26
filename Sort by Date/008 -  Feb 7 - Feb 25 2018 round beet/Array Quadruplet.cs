using System;

class Solution
{
    public static int[] FindArrayQuadruplet(int[] arr, int s)
    {
        if (arr == null || arr.Length < 4)
        {
            return new int[0];
        }

        Array.Sort(arr);

        var length = arr.Length;

        for (int first = 0; first < length - 3; first++)
        {
            var firstValue = arr[first];

            for (int second = first + 1; second < length - 2; second++)
            {
                var secondValue = arr[second];

                var searchTwoSum = s - firstValue - secondValue;

                var twoSumIndexes = searchTwoPointers(arr, second + 1, length - 1, searchTwoSum);
                if (twoSumIndexes.Length == 0)
                    continue;

                return new int[] { firstValue, secondValue, arr[twoSumIndexes[0]], arr[twoSumIndexes[1]] };
            }
        }

        return new int[0];
    }

    private static int[] searchTwoPointers(int[] arr, int start, int end, int twoSum)
    {
        while (start < end)
        {
            var currentSum = arr[start] + arr[end];

            if (currentSum == twoSum)
            {
                return new int[] { start, end };
            }
            else if (currentSum < twoSum)
            {
                start++;
            }
            else
            {
                end--;
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {

    }
}



