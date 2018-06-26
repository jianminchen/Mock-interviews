using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget) // 2, 100, 50, 120, 1000
    {
        if (grantsArray == null || grantsArray.Length == 0 || newBudget <= 0) // false 
        {
            return 0;
        }

        Array.Sort(grantsArray); // 2, 50, 100, 120, 1000

        int length = grantsArray.Length; // 5

        double sum = 0;  // 0 

        for (int i = 0; i < length; i++) // 
        {
            var visit = grantsArray[i]; // 2, 50 

            var restItems = length - i;
            // do a test
            var hasEnoughMoney = (sum + visit * restItems) < newBudget; // 0 + 2 * 5 < 190, 2 + 50 * 4 < 190
            if (!hasEnoughMoney) // true
            {
                return (newBudget - sum) / restItems; // (190 - 2)/ 4 = 47 
            }

            sum += visit; // sum = 2
        }

        // edge case
        return grantsArray[length - 1];
    }

    static void Main(string[] args)
    {
        var grantsArray = new double[] { 2, 100, 50, 120, 1000 };

        Console.WriteLine(FindGrantsCap(grantsArray, 190));
    }
}


// input:  grantsArray = [2, 100, 50, 120, 1000], newBudget = 190

// output: 47
// cap
// 2, 50 , 100, 120, 1000 -> 
// 47 
// 2, -> 5 * 2 = 10 -> 190 
// 50 - 2 + 50 * 4 = 202 > 190 -> less than 
// (190 - 2)/ 4 = 188/4 = 47 
// test - new budget -> cap , 2 - 50 
// Time complexity: O(nlogn), space complexity O(1)

