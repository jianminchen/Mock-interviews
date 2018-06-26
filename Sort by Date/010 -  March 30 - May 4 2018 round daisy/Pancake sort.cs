// https://www.linkedin.com/in/jianminchen/
// 
// Hortonworks - Hadoop, BigData
// Cloudra - main competitor
// MapR
// QA for Apache Storm, Apache Kakfa, Starting Apache Spark
// http://juliachencoding.blogspot.ca/
// 
using System;

class Solution
{
    public static int[] PancakeSort(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return new int[0];

        var length = arr.Length;

        int index = 0;

        while (index < length)
        {
            var lastPosition = length - 1 - index;

            var maxIndex = findMaxIndex(arr, 0, lastPosition); // start/end

            flipFirstGivenNumbers(arr, maxIndex + 1);
            flipFirstGivenNumbers(arr, lastPosition + 1); // move max value to last position 

            index++;
        }

        return arr;
    }

    private static int findMaxIndex(int[] numbers, int start, int end)
    {
        var maxIndex = start;
        for (int index = start; index <= end; index++)
        {
            if (numbers[index] > numbers[maxIndex])
            {
                maxIndex = index;
            }
        }

        return maxIndex;
    }

    private static void flipFirstGivenNumbers(int[] numbers, int totalNumbers)
    {
        int start = 0;
        int end = totalNumbers - 1;

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
        var sorted = PancakeSort(new int[] { 1, 5, 4, 3, 2 });

        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}

/*
keyword: 
flip(arr, k) - reverse the order of the first k elements in the array - time complexity: O(n) in place

Ask: pancakeSort(arr)
  
Constraint: flip function only be used 

[1, 5, 4, 3, 2], sort last element in the array first 
Find maxIndex -> 1
flip(arr, 1 + 1)
max value is first element in the array 
flip whole array -> 
max value will be last element in the array

Go back to line 25 to work on subarray from 0 to length - 2, which is to remove last element

Time complexity: O(n^2), space -> O(1)
*/