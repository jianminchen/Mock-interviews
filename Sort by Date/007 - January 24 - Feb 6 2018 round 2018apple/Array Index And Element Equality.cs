using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr) // [0, 1, 2, 3]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return -1;
        }

        int length = arr.Length; // 4
        int start = 0;
        int end = length - 1; // 3

        while (start <= end) // 0<= 3
        {
            var middle = start + (end - start) / 2; // 1
            var middleValue = arr[middle] - middle; // 0

            if (middleValue == 0)
            {
                if (middle > 0 && arr[middle - 1] == middle - 1)
                {
                    end = middle - 1; // 0
                }
                else
                    return middle; // 0 
            }
            else if (middleValue > 0)
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
        Console.WriteLine(IndexEqualsValueSearch(new int[] { 0, 1, 2, 3 }));
    }
}
/*
keywords:

distinct integer 
sorted
ask lowest index 
satisfy arr[i] = i 
return -1 if not found 

Time complexity:
Space complexity:

[-8, 0 , 2, 5]
[0, 1 ,  2, 3]

[-8, -1, 0,  2] -> not descending 

  [0, 1, 2, 3]
  [0, 1, 2, 3]
  
  [0, 0 , 0, 0] -> lowest index = 0 
  
  
  [0,1, 100, 200] -> arr[i]          < arr[i + 1]
  [0, 1, 2,  3]   -> arrIndex[i] + 1 = arr[i + 1]
  
  [0,  0, 98, 197]  ->
  
  Try to prove define diff[i] = arr[i] - i , prove that the array is not descending, apply binary search on that 
  
  [0 1 3 5]
  [2 4 6 100]
  
  */