using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget) // [2, 100, 50, 120, 1000], 190
    {
        if (grantsArray == null || grantsArray.Length == 0 || newBudget <= 0) // false 
        {
            return 0;
        }

        Array.Sort(grantsArray); // [2, 39, 100, 120, 1000]

        int length = grantsArray.Length; // 5

        double sum = 0;

        for (int i = 0; i < length; i++)
        {
            var current = grantsArray[i]; // 2, 39, 100
            var countOfImpacted = length - i; // 5, 4

            if (sum + current * countOfImpacted > newBudget) // false, 4* 50 > 190, 2 + 4 * 39 vs 190, 158 < 190, 41 + 3 * 100 vs 190
            {
                return (newBudget - sum) / countOfImpacted;  // (190 - 2)/ 4 = 188/ 4 = 47, (190 - 41)/  3 = 149/ 3 = 49.7
            }

            sum += current; // 10, 41
        }

        return grantsArray[length - 1]; // 
    }

    static void Main(string[] args)
    {

    }
}

/*
 N - total grant 
 newBudget - new budget 
 constraint: impact as few grant recipents as possible -> less impact
 maximum cap on all grants -> arr[i] <= cap for any i < length 
 
 Find cap, given an array grants, find new cap to make least number of impacted recipents 
 
 Solution: Sort the array, time O(nlogn)
 linear scan array from left to right
    determine if cap is smaller than arr[i] or not
    if it should be smaller   // length - i
     calculate cap 
     return cap 
   
 return arr[length - 1]; // 0 


*/