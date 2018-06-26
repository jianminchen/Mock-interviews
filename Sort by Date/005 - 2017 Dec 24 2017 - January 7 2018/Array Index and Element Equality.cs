using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr) // [-8, 0, 2, 5], [0, 1, 2, 3]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return -1;
        }

        int length = arr.Length; // 4
        int start = 0;
        int end = length - 1; // 3

        while (start <= end) // 0 <= 3
        {
            int middle = start + (end - start) / 2; // 1, 2

            var isZero = arr[middle] - middle == 0; // 0 - 1= -1, true
            var isPositive = arr[middle] - middle > 0; // false
            if (isZero) // lowest index 
            {
                if (middle > 0 && arr[middle - 1] - (middle - 1) == 0)  // left side, false 
                {
                    end = middle - 1;
                }
                else
                {
                    return middle; // 2
                }
            }
            else if (isPositive)
            {
                end = middle - 1;
            }
            else
            {
                start = middle + 1; // 2
            }
        }

        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IndexEqualsValueSearch(new int[] { 0, 1, 2, 3 }));
        Console.WriteLine(IndexEqualsValueSearch(new int[] { -8, 0, 2, 5 }));
    }
}
// [-8, 0, 2, 5] -> arr[2] == 2, O(N)
// binary search -> sorted, applied binary search 
// value index arr[i] - i = 0; 
// arry2[i] = arr[i] - i -> sorted 
//[0, 1, 2, 3]
// [-8, -1, 0, 2] -> sorted , look for zero
// ascending -> 
// 
// [1, 3, 5, 7, 9]
// [2, 4, 6, 8, 20]
// [-1, -1, -1, -11] -> sorted 
