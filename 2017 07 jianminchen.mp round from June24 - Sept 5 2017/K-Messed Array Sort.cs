using System;

class Solution
{
    internal class MinimumHeap
    {
        public static int[] Data;
        public MinimumHeap(int size)
        {
            Data = new int[0];
        }

        public int ExtractMin()
        {
            Array.Sort(Data);
            var minimumValue = Data[0];
            int length = Data.Length;
            var newData = new int[length - 1];
            for (int i = 1; i < length; i++)
            {
                newData[i - 1] = Data[i];
            }

            Data = newData;
            return minimumValue;
        }

        public int Count()
        {
            return Data.Length;
        }

        public void Insert(int value)
        {
            int length = Data.Length;
            var newData = new int[length + 1];
            for (int i = 0; i < length; i++)
            {
                newData[i] = Data[i];
            }
            newData[length] = value;

            Data = newData;
        }
    }

    public static int[] SortKMessedArray(int[] arr, int k)
    {
        // your code goes here
        if (arr == null || arr.Length == 0 || k < 0)
        {
            return new int[0];
        }

        // assume that the array is not empty
        int length = arr.Length;

        // build a heap first 

        var size = Math.Min(length, k + 1);
        var minHeap = new MinimumHeap(size);

        for (int i = 0; i < size; i++)
        {
            minHeap.Insert(arr[i]);
        }

        var sorted = new int[length];
        int index = 0;
        // now iterate the array and also output to the array
        for (int i = size; i < length; i++)
        {
            sorted[index] = minHeap.ExtractMin();

            var visit = arr[i];
            minHeap.Insert(visit);

            index++;
        }

        while (minHeap.Count() > 0)
        {
            sorted[index] = minHeap.ExtractMin();

            index++;
        }

        return sorted;
    }

    static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 4, 5, 2, 3, 7, 8, 6, 10, 9 };
        int[] result = SortKMessedArray(arr, 2);

        Console.Write(string.Join(" ", result));
    }
}

//   K + 1 = 3, 1, 4, 5
// index = 1 , 2, 3, K sorted array, find minimum O(klogk)
// minimum heap -> O(1)  to extract, O(logk)
// build a minimum heap first, k + 1
// extract minimum heap, visit next element
// extract -> iterate 
// time complexity O(k + 1) + O(1) * N + O(logk)(N - k) = O(Nlogk), O(k + 1), 
// MinimumHeap - API - ExtractMin, Insert - O(nlogn)  sort Array.Sort 
// SortedSet - 


