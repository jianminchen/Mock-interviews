using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr) // [0, 1, 2, 3] -> 4  [2, 10]
    {
        if (arr == null || arr.Length == 0) // false, false
        {
            return -1;
        }

        var length = arr.Length; // 2
        var check = new int[length];

        for (int i = 0; i < length; i++) // i = 0, i = 1
        {
            var visit = arr[i]; // 2, 10

            var isInRange = visit < length; // 2 < 2 false
            if (isInRange && check[visit] == 0)
            {
                check[visit] = 1; // check[0] = 1, check[1] = 1, .. check[3] = 1
            }
        }

        // now it is time to find the number - smallest one non-negative
        var smallestNonNegatvie = length; // 2
        for (int i = 0; i < length; i++)
        {
            var found = check[i] == 0; // true
            if (found)
            {
                smallestNonNegatvie = i; // 0
                break;
            }
        }

        return smallestNonNegatvie; // 0
    }

    static void Main(string[] args)
    {

    }
}

// [0, 1, 2, 3]  -> 4 
// unique, nonnegative
// smallest one - not in the array 
// not allow to modify the array -> sort the array 
// minimum value -> 
// SIZE - 4,  in generic, n , 0 , 1, 2, ,,,, n-1 , you have to find n. 
// otherwise, there is number from 0 - n - 1 missing , 0 - nonnegative 
// size 4
// check[4] -> 0 -> 1, 
// iterate the array -> 0, 
// [2, 10, 20, 30]
// [0]  [1] [2] [3]  -> array return 0 size 4 , 0 - 3  10 > 3, 0 - 3, 4 maximum 4 
// O(n)
// extra array -> O(n) -> O(n)
//           1
