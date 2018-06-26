using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
        if (shiftArr == null || shiftArr.Length == 0)
        {
            return -1;
        }

        return runModifiedBinarySearch(shiftArr, num, 0, shiftArr.Length - 1);
    }

    /// <summary>
    /// code review on Nov. 23, 2017
    /// Make sure that the code is simple as possible. 
    /// No code smell, no copy and paste. 
    /// ONLY CHECK THE FIRST HALF AND SEE IF IT IS IN THE FIRST HALF. 
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="search"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private static int runModifiedBinarySearch(int[] numbers, int search, int start, int end)
    {
        if (start > end)
        {
            return -1;
        }

        int middle = start + (end - start) / 2;
        bool found = numbers[middle] == search;

        // base case, find one solution. 
        if (found)
        {
            return middle;
        }

        var middleValue = numbers[middle];
        var startValue = numbers[start];
        var endValue = numbers[end];

        var startBoundaryChecked = search >= startValue;
        var middleBoundaryChecked = search < middleValue;
        var firstHalfTwoBoundariesChecked = startBoundaryChecked && middleBoundaryChecked;

        if (firstHalfTwoBoundariesChecked)
        {
            return runModifiedBinarySearch(numbers, search, start, middle - 1);
        }
        else
        {
            return runModifiedBinarySearch(numbers, search, middle + 1, end);
        }
    }

    static void Main(string[] args)
    {
        RunTestcase();
    }

    public static void RunTestcase()
    {
        ShiftedArrSearch(new int[] { 1, 2 }, 2);
    }
}