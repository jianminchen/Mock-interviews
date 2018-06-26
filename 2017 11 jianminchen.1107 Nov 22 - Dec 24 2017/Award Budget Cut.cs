using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget) // 1, 2, 3, 4, 5 -> 10
    {
        if (grantsArray == null || grantsArray.Length == 0 || newBudget < 0) // false 
        {
            return -1;
        }

        Array.Sort(grantsArray); // [1, 2,3, 4, 5]

        double sum = 0;
        int length = grantsArray.Length; // 5

        for (int i = 0; i < length; i++)
        {
            var visit = grantsArray[i]; // 1, 2, 3

            var left = newBudget - sum; // 10, 9 , 7
            var count = length - i; // 5, 4, 3
            var enoughMoney = visit * count < left; // 1 * 5 < 10 , 2 * 4 < 9 , 3 * 3 < 7 
            if (!enoughMoney)
            {
                // find the cap 
                return left * 1.0 / count; // 7 /3 = 2.3
            }

            sum += visit; // 1, 3
        }

        return grantsArray[length - 1]; // 
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindGrantsCap(new double[] { 2, 100, 50, 120, 1000 }, 190));
    }
}
// [2, 50, 100, 120, 1000] - O(nlogn)  time  190
// cap 
// 2 * 5 = 10 < 190
// cap = 2, 10 < 190
// 50 -> cap = 50, 2 + 50 * 4 = 202 > 190
// (190 - 2)/ 4 = 47 
