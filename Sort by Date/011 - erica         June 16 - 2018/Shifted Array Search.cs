using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return -1;

        var length = numbers.Length;

        var start = 0;
        var end = length - 1;

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = numbers[middle];

            if (middleValue == middle)
            {
                if (middle > 0 && numbers[middle - 1] == (middle - 1))
                {
                    end = middle - 1;
                }
                else
                {
                    return middle; // lowest index
                }
            }
            else if (middleValue > middle)
            {
                end = middle - 1;
            }
            else
                start = middle + 1;
        }

        return -1;
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:  sorted array, integer, distinct
asking: lowest index i to satisfy arr[i] = i
return -1 
  
Brute force: linear scan, O(n)   time complexity -> not optimal
optimal solution: binary search 

declare numbers[i] = arr[i] - i for any i from 0 to length - 1,
argument that numbers[i] is not in descending order

[0, 1, 2, 3]

numbers[i]
[0,0,0,0]  -> index = 0 
  
*/