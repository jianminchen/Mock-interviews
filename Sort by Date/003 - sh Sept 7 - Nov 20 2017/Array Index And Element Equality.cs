using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr)
    {
        // your code goes here
        if (arr == null || arr.Length == 0)
        {
            return -1;
        }

        // assume that array is not empty 
        var start = 0;
        var end = arr.Length - 1;
        while (start <= end)
        {
            var middle = start + (end - start) / 2;

            var middleValue = arr[middle] - middle;
            bool found = middleValue == 0;
            if (found)
            {
                return middle;
            }

            if (middleValue < 0)
            {
                start = middle + 1;
            }
            else // > 0 
            {
                end = middle - 1;
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {

    }
}

