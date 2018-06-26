using System;

class Solution
{
    public const double RANGE = 0.0001;

    public static double Root(double x, int n) // x = 7, n= 3
    {
        if (x < 0 || n <= 0) //false
        {
            return -1;
        }

        return binarySearch(x, n, 0, x); // 0.0001, 0, 7
    }

    private static double binarySearch(double x, int n, double start, double end)
    {
        // base case
        var isSame = Math.Abs(end - start) < RANGE;
        if (isSame)
        {
            return toThreeDecimal(start); // edge 
        }

        var middle = start + (end - start) / 2; // middle = 7.0/2 = 3.5 

        var middleValue = Math.Pow(middle, n); // 3.5 ^3 = 27 > 7 

        var diff = x - middleValue; // 7 - 27

        var found = Math.Abs(diff) < RANGE; // false 
        var less = diff > RANGE; // middleValue < x , false 7 < 3.5^3 

        if (found)
        {
            return toThreeDecimal(middle); // base case 
        }

        if (less)
        {
            start = middle + RANGE;

        }
        else
        {
            end = middle - RANGE; // 3.5 - 0.0001 = 3.4999
        }

        return binarySearch(x, n, start, end);
    }

    private static double toThreeDecimal(double value) // 0.1234 -> 0.123, 0.125 -> 0.126 
    {
        int round1000 = (int)(value * 1000 + 0.5);
        return round1000 / 1000.0; // round up 
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Root(7, 3));
    }
}
// x = 7, n = 3 
// 1.913
// binary search tree 0 - 7 -> middle = 3.5, 3.5^3 > 7 , right half 
// Math.abs (middle^3 - 7) < 0.0001 -> 
// API powerFunction(x, n)  -> x^n -> Math.power
// x >= 0, 0^3 = 0 
// n > 0 