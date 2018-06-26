using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
        if (shiftArr == null || shiftArr.Length == 0)
        {
            return -1;
        }

        return runModifiedBinarySearch(shiftArr, num);
    }

    private static int runModifiedBinarySearch(int[] numbers, int search) // [3, 4, 5, 1, 2], search = 2
    {
        int start = 0;
        int end = numbers.Length - 1; // 4

        while (start <= end) // true, start =3, end = 4  [1, 2]
        {
            int middle = start + (end - start) / 2; // 2, 3
            int middleValue = numbers[middle]; // 5, 1

            int startValue = numbers[start]; // 3, 1
            int endValue = numbers[end]; // 2, 2

            var found = middleValue == search; // false , 1

            if (found)  // 3, 5, 2
            {
                return middle;
            }
            else if (startValue <= middleValue) // true, true 
            {
                var searchIsInRange = search >= startValue && search <= middleValue; // false 
                if (searchIsInRange)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1; // 3, 4
                }
            }
            else
            {
                var searchIsInRange = search >= middleValue && search <= endValue;

                if (searchIsInRange)
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

Assumption:
  distinct array, sorted 
  shifted to the left -> 1 , 2, 3, 4, 5, -> shift 2 to left 3, 4, 5, 1, 2
  given an integer num, if num is in shifted array.
  
  If found, return the index, otherwise return -1. 
  
  Brute force, linear scan O(N). 
  
  two portions, one ascending order [3,4, 5], [1, 2] two sorted subarrays O(logn) 
  
  two chunks, sorted -> two halves,
  
  [0, length - 1], middle = start + (end - start)/ 2, middle = 0 + (4 - 0)/ 2 = 2
  3, 4, 5, 1, 2
        M
   [3, 5]  ascending order,     [5, 2]
   2 not [3, 5], get rid of half - time complexity O(logn)
   
   edge case: [1]
   
   Overview: 
     Binary search approach 
     base case: the array size is one 
                the middle value is equal to given number
                
     modified binary search, 
     find half with sacending order, treat array with one number as ascending order
     
     Iterative way 
     
     Time complexity:  O(logn)
     Space complexity: O(1)

*/