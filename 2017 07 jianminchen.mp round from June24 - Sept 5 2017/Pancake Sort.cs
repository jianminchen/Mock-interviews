using System;

class Solution
{
    static int[] pancakeSort(int[] arr)
    {
        // your code goes here
        if (arr == null || arr.Length == 0)
        {
            return new int[0];
        }

        int length = arr.Length; //5 
        int index = 1; // 1
        while (index < length)
        {
            int maxIndex = getMax(arr, length - index); // 4

            flip(arr, maxIndex + 1); // first 2
            flip(arr, length - index + 1); // first 5

            index++; // 2
        }

        return arr;
    }

    private static int getMax(int[] number, int end)
    {
        var max = number[0];
        int position = 0;
        for (int i = 0; i <= end; i++)
        {
            var visit = number[i];
            if (visit > max)
            {
                max = visit;
                position = i;
            }
        }

        return position;
    }

    // flip first k numbers
    private static void flip(int[] numbers, int k)
    {
        if (numbers == null || numbers.Length == 0 || k < 0 || numbers.Length < k)
        {
            return;
        }

        // reverse first k elments
        int start = 0;
        int end = k - 1;
        while (start < end)
        {
            var tmp = numbers[start];
            numbers[start] = numbers[end];
            numbers[end] = tmp;

            start++;
            end--;
        }
    }

    static void Main(string[] args)
    {
        var sorted = pancakeSort(new int[] { 1, 5, 4, 3, 2 });
        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}
// 1, 5, 4, 3, 2
// find 1, put 1; 
// original 5, 4, 1, 3, 2
// third number -> 5, 4, 1, -> 1, 4, 5
// 1, 4, 5, 3, 2 -> smallest number, lost 1 position 
// 1, 5, 4, 3, 2 -> find maximum 
// 5, 1, 4, 3, 2  -> flip 
// k value, flip -> any position, index - 0 
// 4, index - 1, length - index
// index = 0, 5, flip the array 
// [1, 5, 4, 3, 2] -> [1, 2, 3, 4, 5]
// max = 1
// max = 5, 1
// flip the arry [5, 1, 4, 3, 2]
// [2, 3, 4, 1, 5] -> assume an array lenghth - 1 , 4

