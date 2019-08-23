// https://www.linkedin.com/in/jianminchen
// https://www.hackerrank.com/jianminchen_fl
// https://codereview.stackexchange.com/users/123986/jianmin-chen?tab=questions
// https://www.quora.com/profile/Jianmin-Chen


// CLEAN CODE - 
// The art of readable code - 200 pages
// pluralsight: 

using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
        if (shiftArr == null)
            return -1;

        var length = shiftArr.Length;

        var start = 0;
        var end = length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = shiftArr[middle];

            if (middleValue == num)
            {
                return middle;
            }

            var startValue = shiftArr[start];
            var endValue = shiftArr[end];

            var firstHalfAscending = startValue <= middleValue;
            //var secondHalfAscending = middleValue <= endValue; 

            if (firstHalfAscending)
            {
                // get rid of half range - left/ right
                var isInFirstHalf = num >= startValue && num <= middleValue;
                if (isInFirstHalf)
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
                // assert that second half ascending
                var isInSeondHalf = num >= middleValue && num <= endValue;
                if (isInSeondHalf)
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

/*              ?
           M-
           
           
                      -
 - 
keywords:
sorted array, distinc integer, 
shift to the left unknown offset k 

given shifted array, integer num, 
ask: find the index of num 
constraint: offset k > 0, k < length - 1
  
  
Time complexity: O(logn), n is the size of the array
Space complexity: O(1)
  
  [1, 2, 3, 4, 5]
  
  [3, 4, 5, 1, 2] -> ascending order
  
  1. One approach -> find pivot value 
  
            |
  go back to search [3, 4, 5], [1, 2]
  
  2. [3, 4, 5, 1, 2]
            middle
      ascending order -> 3 < 5, 5 > 2, second half -> not ascending 
  tell if the given value is in ascending half or not
  

//////////////  ////////////// //////////////
  The peer shared his practice:
 
function shiftedArrSearch(shiftArr, num):
    pivot = findPivotPoint(shiftArr)

    if(pivot == 0 OR num < shiftArr[0]):
        return binarySearch(shiftArr, pivot, shiftArr.length - 1, num)
    
    return binarySearch(shiftArr, 0, pivot - 1, num)


function findPivotPoint(arr):
    begin = 0
    end = arr.length - 1

    while (begin <= end):
        mid = begin + floor((end - begin)/2)
        if (mid == 0 OR arr[mid] < arr[mid-1]):
            return mid
        if (arr[mid] > arr[0]):
            begin = mid + 1
        else:
            end = mid - 1

    return 0


function binarySearch(arr, begin, end, num):
    while (begin <= end):
        mid = begin + floor((end - begin)/2)
        if (arr[mid] < num):
            begin = mid + 1
        else if (arr[mid] == num):
            return mid
        else:
            end = mid - 1

    return -1
*/