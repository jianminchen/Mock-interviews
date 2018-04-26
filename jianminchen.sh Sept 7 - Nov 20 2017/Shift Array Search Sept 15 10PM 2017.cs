using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
        // your code goes here
        if (shiftArr == null || shiftArr.Length == 0)
        {
            return -1;
        }

        // assume that the array is not empty
        var length = shiftArr.Length;
        var start = 0;
        var end = length - 1;
        while (start <= end)
        {
            var middle = start + (end - start) / 2;

            // two subarray 
            var startValue = shiftArr[start];
            var middleValue = shiftArr[middle];
            var endValue = shiftArr[end];

            var firstHalfAscending = middleValue > startValue;
            var secondHalfAscending = endValue > middleValue;

            if (num == middleValue)
            {
                return middle;
            }

            var bothAscending = firstHalfAscending && secondHalfAscending;

            if (bothAscending)
            {
                if (num < middleValue)  // go left
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1; // go right 
                }
            }
            else if (firstHalfAscending)
            {
                // determine num 
                var numIsInFirstHalf = num >= startValue && num < middleValue;
                // search normal binary search 
                if (numIsInFirstHalf)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            else if (secondHalfAscending)
            {
                // determine num in second half 
                var numIsInSecondHalf = num > middleValue && num <= endValue;
                // search normal binary search 
                if (numIsInSecondHalf)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {

    }
}
//[9, 12, 17, 2, 4, 5] 
// 2, 4, 5, 9, 12, 17 <- 9 is the first element, num = 2 
// search = 2, return index of 2 output = 3
// binary search [9, 12, 17] ascending [2, 4, 5] ascending order 
// 2
// pivot table 17 > 2 
// 6 -> middle = 2, arr[2] = 17, left neighbor 12 < 17, 9 - 17, 17 - 5 descending, left part 
// converge -> 1
//
//9, 12
// 17, 2, 4, 5
// search 2 
// [9,  12]
//[17, 5] descending -> pivot value -> search 2 -> shifted array 
//-> 20 
// 9, 12 
// left side 11 -> normal binary search 

