using System;

class Solution
{
    public static double Root(double x, int n)
    {
        if (x < 0 || n < 0)
            return -1;

        double start = 0;
        double end = Math.Max(1, x);

        while (start <= end)
        {
            var middle = start + (end - start) / 2;
            var middleValue = Math.Pow(middle, n);

            var diff = Math.Abs(middleValue - x);
            if (diff < 0.001)
            {
                return (int)(middle * 1000) / 1000.0;
            }
            else if (middleValue < x)
            {
                start = middle + 0.0005; // 0.001 - deadloop - get rid of one number 
            }
            else
            {
                end = middle - 0.0005;
            }
        }

        return (int)(start * 1000) / 1000.0;
    }

    static void Main(string[] args)
    {

    }
}
/*
given: nonnegative number, double number, n
keywords:
asking: nth root of a number 

constraint: error 0.001  < 0.001 

  work on:
  x = 7, n = 3, solution: 1.913 
    
 integer , + 1, 
x = 7, from 0 to 7, 0, 0.001, 0.002, ...., 7 -> 7000 search -> log7000 = 10 * log 7 
  
  | 1.912 ^ 3 - 7 | > 0.001 
  
  7000 -> 0, 0.0001, 0.0002, ..., -> 70000 search -> log70000 = 10 * log 70
  
  start = 0, end = 7, 
  middle -> 7, get rid of middle = start + ( end -start)/ 2
  
*/