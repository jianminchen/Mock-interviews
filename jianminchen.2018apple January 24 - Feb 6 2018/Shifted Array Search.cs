using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num) // [3, 4, 5, 1, 2]
    {
        if (shiftArr == null || shiftArr.Length == 0) // false 
        {
            return -1;
        }

        var length = shiftArr.Length; // 5
        int start = 0;
        int end = length - 1; // 4

        while (start <= end) // 0 <= 4, 3 <= 4
        {
            int middle = start + (end - start) / 2; // 2, 3 
            var middleValue = shiftArr[middle]; // 5, 1

            int startValue = shiftArr[start]; // 3, 1
            int endValue = shiftArr[end]; // 2, 2

            if (middleValue == num) // false 
            {
                return middle;
            }
            else if (startValue <= middleValue) // true 3 < 5
            {
                // check if num is the range or not 
                if (isInRange(num, startValue, middleValue)) // [3, 5] false 
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1; // 3
                }
            }
            else
            {
                if (isInRange(num, middleValue, endValue))
                {
                    start = middle + 1;
                }
                else
                    end = middle - 1;
            }
        }

        return -1;
    }

    private static bool isInRange(int search, int start, int end)
    {
        return search >= start && search <= end;
    }

    static void Main(string[] args)
    {

    }
}

// interviewing.io
// Leetcode 54 - 10 spiral matrix 

/*
keyword:

sorted array, distinct integers

1, 2, 3, 4, 5, -> 3, 4, 5, 1, 2 
  
binary search -> O(logn) time complexity 

space complexity: O(1)
  
binary search applied to sorted array -> every time we have to get rid of half numbers 

3, 4, 5, 1, 2 
  
start -> middle  middle -> end -> at least one range is ascending order
-> which part -> ascending order, search number 2 is in range - > to go the right left

*/