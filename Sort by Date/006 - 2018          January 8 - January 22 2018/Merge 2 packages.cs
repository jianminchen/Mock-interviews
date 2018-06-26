using System;
using System.Collections.Generic;

class Solution
{
    public static int[] GetIndicesOfItemWeights(int[] numbers, int limit) //[4, 6, 10, 15, 16]
    {
        if (numbers == null || numbers.Length < 2) //false 
        {
            return new int[0];
        }

        var dictionary = new Dictionary<int, int>();

        int length = numbers.Length; // 5

        for (int i = 0; i < length; i++)
        {
            var current = numbers[i]; // 4, 6, 10, 15
            var search = limit - current; // 17, 15, 6

            if (dictionary.ContainsKey(search)) // false, true
            {
                var index = dictionary[search]; // 1
                return new int[] { Math.Max(index, i), Math.Min(index, i) }; // {4, 1}
            }
            else
            {
                dictionary[current] = i;
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {
        var pair = GetIndicesOfItemWeights(new int[] { 4, 6, 10, 15, 16 }, 21);

        Console.WriteLine(pair[0] + "," + pair[1]);
    }
}

/*

arr = [4, 6, 10, 15, 16], limit = 21

[3, 1], 15, 6, total 15 + 6

return first pair 
O(n^2) time complexity 

use extra space , hashamp 
4 -> {4 }
6 -> 15, {6, 15}
10 -> 11, {4, 15, 10}
15 -> 6, it is inside, index = 1, return [index, dict[key]], compared them

sorted the array O(nlogn)

O(n)

pair

*/