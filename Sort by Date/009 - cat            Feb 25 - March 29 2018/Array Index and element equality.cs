using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return -1;

        var length = arr.Length;

        int start = 0;
        int end = length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = arr[middle];

            if (middleValue == middle)
            {
                if (middle > 0 && arr[middle - 1] == (middle - 1))
                {
                    end = middle - 1;
                }
                else
                    return middle;
            }
            else if (middleValue < middle)
            {
                start = middle + 1;
            }
            else
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

/*
keywords:

sorted array, distinct integer
ask: lowest index of i , arr[i] = i
return -1
  
  time complexity: O(n) -> arr[i] - i is not descending order, so we can apply binary search to search value with 0. 
  [0, 1, 2, 3]   -> 
  [0, 1, 2, 3]  
  ------
  edge case: [0, 0, 0, 0] -> return index = 0, first zero
  
  binary search -> get rid of half number, O(logn), 
arr[i] - i  search 0, middle value = 0 -> left neighbor is also -> arr
  
  -8,-7,0,1,2,5   mid =  0   => i = 2, arr[i] != i, get rid of left -> go to right 
  */



