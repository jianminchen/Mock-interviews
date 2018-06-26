using System;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k) // [[3, 2, 1]], k = 2
    {
        if (arr == null || arr.Length == 0 || k <= 0) // false 
        {
            return arr;
        }

        // 
        int length = arr.Length; // 3
        int index = 0;

        while (index < length) // 
        {
            // find first k + 1 's minimum
            int minimumIndex = findFirstKplusOne(arr, index, k + 1); // 
            swap(arr, index, minimumIndex);

            index++;
        }

        return arr;
    }

    private static int findFirstKplusOne(int[] arr, int index, int number)
    {
        int minIndex = index;  // 

        for (int i = index; i < Math.Min(arr.Length, index + number); i++)
        {
            var visit = arr[i];
            var smaller = visit < arr[minIndex];

            if (smaller)
            {
                minIndex = i;
            }
        }

        return minIndex;
    }

    private static void swap(int[] arr, int start, int end)
    {
        var tmp = arr[start];
        arr[start] = arr[end];
        arr[end] = tmp;
    }

    static void Main(string[] args)
    {

    }
}
// 1  4 5
// 1 vs 4 -> swap
// 1 vs 4 -> swap 
// O(kn) -> 

// 4 5 2 -> 
// 2 5 4
// 5 4 3
// 5 4 2 -> 
// 4 5 2
// 2 5 4 -> 

// k + 1
// minimum number in k + 1 -> first number in the array
// 2
// k + 1 -> data structure -> k + 1 - minimum heap 
// O(1) - minimum -> extract the minimum
// O()
// k + 1, find minimum, -> iterate the array to visit k + 2 number
// finish - heap -> emtpy 
// fully sorted array
// C# 

// class Heap<T> {
//  void Insert(T t);
//  T ExtractMin();

//}