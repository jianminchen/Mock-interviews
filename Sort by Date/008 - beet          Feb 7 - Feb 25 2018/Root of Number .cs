
using System;
//using System.Math;

class Solution
{
    public static double Root(double x, int n)
    {
        if (x < 0 || n < 1)
        {
            return -1;
        }

        double start = Math.Min(x, 1);
        double end = Math.Max(x, 1);

        while (start <= end)
        {
            double middle = start + (end - start) / 2;
            var middleValue = Math.Pow(middle, n);

            if (Math.Abs(middleValue - x) < 0.001)
            {
                return (int)(middle * 1000 + 0.5) / 1000.0;
            }
            else if (middleValue < x)
            {
                start = middle;
            }
            else
            {
                end = middle;
            }
        }

        return start;
    }

    static void Main(string[] args)
    {

    }
}

/*
nth root of a number

x - nonnegative >= 0-> 
  n - positive interger
  constraint: error range 0.001   < 0.001
    
    using binary search y = root(x, n)
    0 < x < 1, [0, 1]  - x - 1
    x >=1, [1, x]
    
    define search range from Min(x, 1) to Max(1, x)
    
    Min(0, 1)
    
    abs(middleValue -x) < 0.001
    
    get rid of half of range
    */