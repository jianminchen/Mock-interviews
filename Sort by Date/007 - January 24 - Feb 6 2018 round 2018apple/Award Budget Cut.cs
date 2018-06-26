using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget)
    {
        if (grantsArray == null || grantsArray.Length == 0) // false
        {
            return 0;
        }

        Array.Sort(grantsArray); // 2, 50, 100, 120, 1000

        double sumOfSeries = 0; // 0

        var length = grantsArray.Length;  // 5

        for (int index = 0; index < length; index++)
        {
            // do a survive test 
            double current = grantsArray[index]; // 2, 50
            int restNumbers = (length - index);// 5, 4

            var canSurvive = sumOfSeries + current * restNumbers <= newBudget; // true, false
            if (!canSurvive)
            {
                return (newBudget - sumOfSeries) / restNumbers; // 47
            }

            sumOfSeries += current; // 2
        }

        return grantsArray[length - 1];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindGrantsCap(new double[] { 2, 100, 50, 120, 1000 }, 190));
    }
}
/*
keywords:

given an array, new budget, double 
ask cap value, 
constraint: the least number of recipents is impacted 

nlogn -
2, 50, 100, 120, 1000, new budget 190
2, 47, 47 , 47, 47  - impacted 4 of them 

-> scan the array, see if the current value can be survived. 
  2 -> 2 * 5 < 190 - true
  dynamic programming 2 + 
  2 + 50 * 4 < 190 - false 
  2 + cap * 4 = 190 -> cap = 188/ 4 = 47 
  
  
  */