using System;

class Solution
{
    public static int[] SortKMessedArray(int[] arr, int k)
    {
        if (arr == null || arr.Length == 0 || k < 0)
        {
            return new int[0];
        }

        var length = arr.Length;

        int index = 0;

        while (index < length)
        {
            placeKplusOneMinimumPosition(arr, index, k + 1); // in place

            index++;
        }

        return arr;
    }

    private static void placeKplusOneMinimumPosition(int[] numbers, int start, int firstSpecifedNumbers)
    {
        var length = numbers.Length;


        for (int i = start + 1; i < start + firstSpecifedNumbers && i < length; i++)
        {
            var startValue = numbers[start];
            var current = numbers[i];

            if (current < startValue)
            {
                // swap two values 
                numbers[start] = current;
                numbers[i] = startValue;
            }
        }
    }

    static void Main(string[] args)
    {
        var sorted = SortKMessedArray(new int[] { 1, 4, 5, 2, 3, 7, 8, 6, 10, 9 }, 2);
        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}

/*
K messed array, k = 2, first three numbers and then find minimum number, it will be first number of the array

[1, 4, 5, ]
  
k + 1 number -> special data structure -> minimum heap -> K + 1  
  
left 

Heap class -> O(1), O(logn)
complete sort klogk -> 
  time complexity: O(K) -> first number will be smallest, k comparison 
  time complexity: O(nK)
    
O(1)    
O(logk)    > klogk - build a heap k + 1 
    
    1 
    2 <- O(log2)
    3 <- O(log3)
    ..
    k+1 < -O(logk)   O(klogk)
    
    */
