using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr)  // [0, 1, 2, 3]
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return 0;
        }

        var length = arr.Length;
        var visited = new int[length];

        for (int i = 0; i < length; i++)
        {
            var current = arr[i];
            if (current < length)
            {
                visited[current] = 1;
            }
        }

        // scan visited array to find first missing      
        for (int i = 0; i < length; i++)
        {
            if (visited[i] != 1)
            {
                return i;
            }
        }

        return length;
    }

    static void Main(string[] args)
    {

    }
}
/*
keywords:

unique, 
nonnegative
integer, 

Ask: find smallest nonnegative integer, not in the array

constraint: not allowed to modify the array

linear solution -> smallest >= 0 
length N, 
nothing is missing, from 0 to N - 1, first missing should N -> 
  
one smallest number is mising, i, 0 - i -1 inside the array, but i not in the array, 
N all other number can by any number, not duplicated 

visited[N] -> 0, visited[0] = 1, ..., visited[i] = 0, i is number we search, -> O(N)
*/