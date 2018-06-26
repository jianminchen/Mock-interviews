using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr) // [0, 1, 2, 3], [100,2, 0, 300] 
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return 0;
        }

        var length = arr.Length; // 4
        var visited = new int[length];

        var foundBiggerThanN = false;

        for (int index = 0; index < length; index++)
        {
            var visit = arr[index]; // 0, 1 //100
            var foundBigger = visit >= length; // false, false // true

            if (foundBigger)
            {
                foundBiggerThanN = true; // true 
            }
            else // out-of-range 
            {
                visited[visit] = 1; // visited[0] = 1, 
            }
        }

        if (!foundBiggerThanN) // true, false 
        {
            return length; // 4 
        }

        var missing = 0; // visited[0] = 1, visited[1] = 0, visited[2] = 1 visited[3]=0
        for (int index = 0; index < length; index++)
        {
            if (visited[index] == 0)
            {
                missing = index;
                break; // bug -> 
            }
        }

        return missing;
    }

    static void Main(string[] args)
    {

    }
}

// [0, 1, 2, 3], answer 4 , nonnegative >= 0, smallest not in the array
// array size n, 
// 0 - n -1, each number is in the array, the answer n, 
// unique -> any number >= n, the answer should be < n
// array - hashset 0 - n-1, index = 0
// recodingArray[index] = 1 -> linear scan  O(1)
// max > n true -> n
// max > n true
// = 0  O(n) first one is zero
// O(n), space complexity O(n)