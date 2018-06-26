using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
        if (shiftArr == null)
        {
            return -1;
        }

        int start = 0;
        int end = shiftArr.Length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = shiftArr[middle];

            // base case
            if (middleValue == num)
            {
                return middle;
            }

            // check to get rid of half of numbers
            var startValue = shiftArr[start];
            var endValue = shiftArr[end];
            var firstHalfAscending = startValue <= middleValue;
            //  var secondHalfAscending = middleValue <= endValue; 

            if (firstHalfAscending)
            {
                // if num is in first half, then get rid of second half
                if (num >= startValue && num <= middleValue)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            else
            {
                if (num >= middleValue && num <= endValue)
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

/*
[9, 12, 17, 2, 4, 5]  6 numbers, given value 2, middle = 2, 
         |
           
[9, 12, 17]   [17, 2, 4, 5 ]           
 ascending order
 [9, 17]  if 2 is in the range of ascending half, get rid of the another half 
 
 two step: 
1. which half is in ascending 
2. given number is in the ascending half 

*/