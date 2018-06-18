using System;

class Solution
{
    // 0 , 0.001, 3=> 0.1, x = 7, n = 3
    static double root(double x, uint n)
    {
        // your code goes here
        if (x < 0)
        {
            return -1;
        }

        if (Math.Abs(x) < 0.001)
        {
            return 0;  // 0 
        }
        // assume that x is nonnagative 

        var search = binarySearch(x, n); // 0.001, 3

        return search;
    }

    /// 0.001, 3 => 0.1 from 0 to 1, 1000 numbers, 
    private static double binarySearch(double x, uint n)
    {
        double start = 0;
        double end = Math.Max(1, x);   // Math.Max(1, x), x < 1, x > 1, x , [0 7]

        int index = 0;
        while (start <= end) // 0, 0.001
        {
            index++;
            if (index < 20)
            {
                Console.WriteLine("start=" + start);
                Console.WriteLine("end=" + end);
                Console.WriteLine(index);
            }
            else
            {
                break;
            }

            var middle = keep3Decimal(start + (end - start) / 2.0); // keep to 3 decimal, 0, middle = 7/2.0 = 3.500, 1.7

            var middleValue = Math.Pow(middle, n); // 3.5^3 > 7
            bool isEqual = Math.Abs(middleValue - x) < 0.001;
            bool isLess = x - middleValue > 0.001;

            if (isEqual)
            {
                return middle; //
            }
            else if (isLess)
            {
                start = middle + 0.001; // 1.701 - 1.7
            }
            else
            {
                end = middle - 0.001; // 3.5 - 0.001 = 3.499
            }
        }

        return -1; // not found 
    }

    ///
    private static double keep3Decimal(double value)
    {
        int integerValue = (int)(value * 1000);
        return integerValue / 1000.0;  // double
    }

    static void Main(string[] args)
    {
        Console.WriteLine(root(7, 3));
    }
}
// x = 7, n = 3, 1.913 
// x > 1, Math.Abs(1.913 ^ 3 - 7) <= 0.001
// x > 1, > 1, lower bound 1, upper bound <= 7 
// binary search - error range 0.001, 7000, log(n) = 10 * log7 , 30 times, find the number
// x = 9 , n = 2, 3.0 = 9, 2.999 -3 = 0.001, 3.000, 2.999 
// x < 1, upper bound 1, lower bound - nonnegative number
// min(0, 1),  max ( 1, x)
// < 0.001, they are equal 
// double -> convert to 3 decimal 
// double d , d * 1000 -> integer - type conversion - double -> integer -> 1000.0 
// 0.1001 -> 100 -> 100/ 1000.0 = 0.1 00 -> fourth decimal 0.0005 -> 0.001 