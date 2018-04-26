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

        // array is not empty
        return modifiedBinarySearch(arr, 0, arr.Length - 1);
    }

    /// time complexity O(n)
    private static int modifiedBinarySearch(int[] numbers, int start, int end)
    {
        // Look for 0
        //var search = 0; 
        while (start <= end)  // [-8, 0, 1, 3, 5]  length = 5, 0 - 4 
        {
            var valueBegin = numbers[start] - start;
            var valueEnd = numbers[end] - end;

            var middle = start + (end - start) / 2; // 2 numbers[2] = 1 
            var middleValue = numbers[middle] - middle;

            var beginZero = valueBegin == 0;
            if (beginZero)
            {
                return start;
            }
            var endZero = valueEnd == 0;
            if (endZero)
            {
                return end;
            }

            var middleValueZero = middleValue == 0;
            if (middleValueZero)
            {
                return middle;
            }

            // start < 0, end < 0 -> return -1 
            // start > 0, end > 0 -> return -1 
            var bothNegative = valueBegin < 0 && valueEnd < 0;
            var bothPositive = valueBegin > 0 && valueEnd > 0;
            if (bothNegative || bothPositive)
            {
                return -1;
            }

            // both of them not zero
            var middlePositive = middleValue > 0;
            // start < 0, end > 0 -> 
            // check middle value < 0 -> start = middle + 1
            //  middle value = 0, return middle 
            // middle value > 0, -> end = middel - 1
            if (middlePositive)
            {
                end = middle - 1;
            }
            else
            {
                start = middle + 1;
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {

    }
}
//[1, 2, 2] - distinct integer 
// -8, 0, 2, 5, sorted array, ascending order, distinct order a < b < c < d ... 
// original array
// increment value b - a, c - b, d - c > 0 
// define a new array, numbers, for element, newNumbers[i] = numbers[i] - i 
// all nonnegative numbers
// newNumbers = new int[]{-8 - 0, 0 - 1, 2 - 2, 5 - 3} = new int[]{-8, -1, 0, 2}  
// newNumbers array is in the ascending order, we are looking for value 0, numbers[index] = index
// O(n) -> newNumbers -> iterative once O(n), 
// O(logn) -> O(n)
//[-5, -3, -2] - not sorted -> -1
// start = 0, end = 2, -5 - 0 < 0, -2 - 3 < 0, [-5, -5], 
// [0, 1, 2, 3]   ascending order, but increment value is 1 
