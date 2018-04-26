using System;

class Solution
{
    public static int[] PancakeSort(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return new int[0];
        }

        // let me flip 5 from test case [1, 5, 4, 3, 2] to the last one
        var length = arr.Length;

        var countFound = 0;


        while (countFound < length)  // 5 , 1 < 5
        {
            var maxIndex = 0;
            var maxValue = arr[0]; // [2, 3, 4, 1, 5]


            var subArrayLength = length - countFound;  // 5, 4

            // iterate the subarray 
            for (int i = 1; i < subArrayLength; i++) // 
            {
                var visit = arr[i];
                var isBigger = visit > maxValue;
                if (isBigger)
                {
                    maxValue = visit;
                    maxIndex = i;
                }
            }

            flip(arr, maxIndex + 1); // 1
            flip(arr, subArrayLength); // 5, 4

            countFound++; // 1
        }

        return arr;
    }

    // reverse
    private static void flip(int[] arr, int k)
    {
        if (k <= 0)
        {
            return;
        }

        int start = 0;
        int end = k - 1;

        while (start < end)
        {
            var tmp = arr[start];

            arr[start] = arr[end];
            arr[end] = tmp;

            start++;
            end--;
        }
    }

    static void Main(string[] args)
    {

    }
}

/*
arr = [1, 5, 4, 3, 2]
flip(arr, k), first k element - reverse 
[1, 2, 3, 4, 5]
sort the array left -> right 
right -> left 
above 5 -> O(n) -> 1
flip -> 5
flip first 5 element -> last one 
O(n) + O(n - 1) + ...+ O(1) = O(n*(n+1)/2 ) time complexity 
extra array O(1)

edge: null, 0
size = 1
sample test case 

*/