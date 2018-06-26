using System;

class Solution
{
    /// <summary>
    /// code review on Dec. 15, 2017
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int IndexEqualsValueSearch(int[] arr) // [0, 1, 2, 3]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return -1;
        }

        var length = arr.Length; // 4        

        return binarySearch(arr, 0, length - 1); // 0, 0 , 3
    }

    /// <summary>
    /// time complexity is O(n), space complexity is O(1)
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private static int binarySearch(int[] numbers, int start, int end)  // logn - 
    {
        if (start > end)  // false 
        {
            return -1;
        }

        var middle = start + (end - start) / 2; // 1
        var middleValue = numbers[middle];  // 0 
        // base case 
        if (middleValue == middle) // 
        {
            // You need to make some changes here
            // You definitely know 1 index
            // [0 0 0 0 0]
            // middle = 2
            // [0 0]
            if (middle > 0 && numbers[middle - 1] == (middle - 1))
            {
                return binarySearch(numbers, start, middle - 1);
            }
            else
            {
                return middle; // 1 -> lowest one - bug fix 
            }
        }
        else if (middleValue < middle)
        {
            start = middle + 1;
        }
        else
        {
            end = middle - 1;
        }

        return binarySearch(numbers, start, end);
    }

    static void Main(string[] args)
    {
    }
}

// [-8, 0, 2, 5] - distinct ascending -> increment at least 1
// [0, 1, 2, 3]  -> ascending order -> increment 1 
// arr[i] - i -> array not descending 
// arr[i] <= arr[i] if i < j
// [0, 1, 2, 3]
// newArray = arr[i] - i , saying that this array is sorted, 
// [0,0,0,0] -> sorted, 
// argument if it is sorted, binary search 
// O(logn)  given value 0, find index - arr[i] - i = 0, 
//  space O(1)