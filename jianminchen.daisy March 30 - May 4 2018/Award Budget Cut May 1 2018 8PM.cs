// https://www.linkedin.com/in/jianminchen
// http://juliachencoding.blogspot.ca/

using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget)
    {
        if (grantsArray == null || newBudget <= 0)
            return 0;

        var length = grantsArray.Length;
        double prefixSum = 0;

        Array.Sort(grantsArray);

        for (int index = 0; index < length; index++)
        {
            var current = grantsArray[index];

            var available = newBudget - prefixSum;
            var numbersLeft = length - index;

            if (current * numbersLeft > available)
            {
                return available / numbersLeft;
            }

            prefixSum += current;
        }

        return grantsArray[length - 1];
    }

    static void Main(string[] args)
    {
        var newCap = FindGrantsCap(new double[] { 2, 100, 50, 120, 1000 }, 190);
        Console.WriteLine(newCap);
    }
}

/*
Keywords:
N 
given grantsArray, 
newBudget
constraint: impact as few grant recipients as possible by applying maximum cap 
Ask: calculate cap value 
  
  [2, 100, 50, 120, 1000], 190 - new budget, cap value 47
  
  linear scan the array -> sorted array 
  sorted the array O(nlogn)
  [2, 50, 100, 120, 1000 ], 190 -> cap value
  
  
  
  ___|   compared to newBudget
  
  _________|   2 + 50 * 4 = 202 > 190
  
             | 
  ______________
  
  ___________|______
  
  ___________|______________________________________
  
  */

