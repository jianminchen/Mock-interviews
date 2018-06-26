using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr) // [0, 1, 2, 3]
    {
        if (arr == null || arr.Length == 0)  //false
        {
            return -1;
        }

        var length = arr.Length; // 2

        var found = new int[length];  // 2

        // construct an array to contain the numbers found less than possible smallest integer
        for (int i = 0; i < length; i++) // 2
        {
            var current = arr[i];

            if (current < length) // 1 < 1
            {
                found[current] = 1;
            }
        }

        // scan the found array and then find first missing number
        for (int i = 0; i < length; i++)
        {
            if (found[i] == 0)
            {
                return i;
            }
        }

        return length;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetDifferentNumber(new int[] { 1 }));
    }
}


/*
assumption:  unique, nonnegative, integer array
getDifferentNumber = find smallest, nonnegative >=0, integer, not in the array

not allowed to modify the input array

time complexity
- O(n)

space complexity
- extra space - O(n)

[0, 1, 2, 3]

4 
extraFound
[1, 1, 1, 1] -> from 0 - length - 1, length

[1, 0, 100, 200]

[1,1,0,0] -> 100 > 4 , length + 1

*/