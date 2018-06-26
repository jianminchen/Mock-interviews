using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return -1;
        }

        var length = arr.Length;

        int start = 0;
        int end = length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = arr[middle];

            if (middle == middleValue)
            {
                if (middle > 0 && arr[middle - 1] == (middle - 1))
                {
                    end = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            else if (middle < middleValue)  // search left side 
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
        var indexFound = IndexEqualsValueSearch(new int[] { -8, 0, 2, 5 });
        Console.WriteLine(indexFound);
    }
}


/*
lowest index 
distinct integers, 
a sorted array  [-8, 0, 2, 5]  at least increment one each time 
[0, 1, 2, 3, ...]  increment but only one at a time 

newARray[i]  = arr[i] - i , not in descending order 
[-8, -1, 0, 2]  -> non descending order 

[0, 1,2, 3, 4]
[0, 1, 2, 3, 4]

arr[i] - i

[0, 0, 0, 0, 0] -> find index = 0; 

binary search 

middle = start + (end - start)/ 2
  4, 0 - 3, middle = 1
  
  middlevalue = 0 
  base case: middleValue = middle 
  return middle 
  : middleVAlue < middle
  search right, get rid of left half
  else 
    middleValue > middle
  search left, get rid of right half 
  

arr[i] = i , 
-1 not found
*/