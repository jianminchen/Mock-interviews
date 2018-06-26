
// K. I. T. - open source projects -
// soft skills - interview -> work on before - memorize 
// number of paths -catalan number - 
using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget)
    {
        if (grantsArray == null || grantsArray.Length == 0 || newBudget <= 0)
            return 0;

        var length = grantsArray.Length;

        Array.Sort(grantsArray);

        double prefixSum = 0;

        for (int i = 0; i < length; i++)
        {
            var current = grantsArray[i];   // 50 

            var available = newBudget - prefixSum; // 188 
            var numberOfGrant = length - i; // 4

            if (current * numberOfGrant > available)  // 2 * 5 vs 190 , 50 * 4 vs 188
            {
                return available / numberOfGrant; // 188/ 4 = 47
            }

            prefixSum += current; // 2
        }

        return grantsArray[length - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:

double array , given newBudget, find the a maximum cap on all grants

Constraints:  impact as few grant recipents

linear scan -> sort the array O(nlogn) -> ascending order -> left to right, 

[2, 50, 100, 120, 1000]

2 -> prefixSum = 0, 190, 2 * 5 = 10 < 190
    50, prefixSum = 2, 190 - 2 = 188, 50 * 4 = 200 > 188 => cap = 188/ 4 = 47, length - index
    
    Edge case: 
cap = grantsArray[4], 0 

*/