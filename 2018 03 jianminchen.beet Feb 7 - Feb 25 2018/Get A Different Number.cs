using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return -1;

        var length = arr.Length;
        int index = 0;
        while (index < length)
        {
            var current = arr[index]; // implicit  - var dict = new Dictionary<string, int> ()
            var isEqual = current == index;
            if (!isEqual && current < length)
            {
                swap(arr, index, current);
            }
            else
            {
                index++;
            }
        }

        // go over the array again to find first negative number      
        for (int i = 0; i < length; i++)
        {
            if (arr[i] != i)
                return i;
        }

        return length;
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

/*
[3, 0, 1, 4]


keyword:
unique - nonegative integers
array -
  Ask: find smallest nonenative >=0 not in the array
  Constraint:  not allowed to modify the input arr
  
  example: [0, 1, 2, 3], 4 - first missing number
  [0, 1, 2, 100] - first missing number 3
   - extra space
   - bucket sort -> given the array size N, sorted[N], sort[i] = 1, i in the array, 
   - Look for first N number, N is the size of the array
   - if nonthing is found, return N

Extra space - using the array -> 
     HashSet<int> -> put all the numbers, 
     index 0 to N - 1, go to search hashset
     
     [0,1, 2, 3]
     
     [0, 1, 2, 4] -> find missing 3 , size is 4
     0 , 1, 2, 4 -> where is 3, 4 -> -4
     
     [1, 0, 3, 100] -> [0, 1,-100, 3] -> if I can find any negative 
     [0, 1, 2, 3] -> 4
     [1, 2, 3, 10] -> [2, 1, 3, 10] -> [3, 1, 2, 10]-> [10, 2, 1, 3] -> [10, 2, 1, 3] -> index 
  */