using System;

class Solution
{
    public static double Root(double x, int n)
    {
        if (x < 0 || n <= 0)
            return -1;

        int start = 0;
        int end = (int)(Math.Max(1, x) * 10000); // 0.01 -> 0.1 

        while (start <= end)
        {
            int middle = start + (end - start) / 2;
            // middle - root(x, n) < 0.001

            double middleValue = Math.Pow(middle / 10000.0, n);

            if (Math.Abs(middleValue - x) <= 0.001) /// not true, my anaylisy 
                return middle / 10000.0;

            if (middleValue < x)
                start = middle + 1;
            else
                end = middle - 1;
        }

        return start / 10000.0; // x = 7, 0, 0.0001, 0.0002, ..., 1 using binary search 70,000 
    }

    static void Main(string[] args)
    {

    }
}
/*
keywords:
nonegative number x
n > 0 integer
error of 0.001 
  
ask: root of number, y ^ n = x
given example: x = 7, n = 3, find solution: 1.913 
  Abs(1.917 - root(x, n)) < 0.001
  Binary search -> 0.001
  0 - 7 lower bound/ upper bound
  increment value -> 0.0001 
  70000 to search, logn = 10 * log70 = 60 times 
  */