using System;

class Solution
{
    static double errorRange = 0.0001;
    public static double Root(double x, int n) // 7, 3 
    {
        // nonnegative number double x, positive n > 0
        if (x < 0 || n <= 0) // false 
        {
            return -1; // exception 
        }

        //x = 0 , < 0.001, return 0 , 0.001 ^n < 0.001
        //n = 1, return itself 
        var isZero = Math.Abs(x - 0) < errorRange; // false
        if (isZero)
        {
            return 0;
        }

        var isOne = Math.Abs(x - 1) < errorRange; // false 
        if (isOne)
        {
            return 1;
        }

        //x > 1 && Math.Abs(x - 1) > 0.001
        //   (0, 1)  
        // (1, x] -> (1, x]
        var isBiggerThanOne = x > 1 && Math.Abs(x - 1) >= errorRange; // true
        if (isBiggerThanOne)
        {
            return runBinarySearchInRangeDotOnePercentage(x, n, 1, x);  // 1, 7 
        }

        //x < 1
        // (0, x) -> (0, 0.5)
        return runBinarySearchInRangeDotOnePercentage(x, n, 0, x);
    }

    private static double runBinarySearchInRangeDotOnePercentage(double x, int n, double start, double end) // 7, 3, 1, 7
    {

        double middle = 0;

        while (end > start && Math.Abs(end - start) >= errorRange) // 6 > 0.001  < 0.001   >= 
        {
            middle = start + (end - start) / 2.0; // 1 + 6/ 2= 4

            var middleValue = calculatePower(middle, n); // 4 ^ 3

            var isEqual = Math.Abs(middleValue - x) < errorRange; // false  
            var isBigger = middleValue - x >= errorRange;

            if (isEqual)
            {
                return roundTo3Decimal(middle);
            }

            if (isBigger)  // 4, 
            {
                end = middle; // 4.001
            }
            else
            {
                start = middle;
            }
        }

        return roundTo3Decimal(middle); // exception - not reachable   0.0005 -> 0.001 -> 0.0 
    }

    private static double roundTo3Decimal(double x)
    {
        return ((int)((x + 0.0005) * 1000)) / 1000.0;
    }

    private static double calculatePower(double baseValue, int power) // 2, 1
    {
        double powerValue = baseValue;

        int index = 1;
        while (index < power)
        {
            powerValue = powerValue * baseValue; // 0.0005 -> 0 
            index++;
        }

        // number to 3 decimal       
        return powerValue;
    }

    static void Main(string[] args)
    {

    }
}

// https://msdn.microsoft.com/en-us/library/6be1edhb(v=vs.110).aspx

/*
9 -> 3
27 -> 5.2312
27 -> 3
  
Root(27, 3) -> 3
Root(32, 5) -> 2
Root(7, 3) -> 1.913

x = 7, n =3 
Math.Abs(1.913 * 1.913 * 1.913 - 7) < 0.001 , have to search and find 1.913 

x =9, n = 2
Math.Abs(3 * 3 - 9) < 0.001, search and find 3

nonnegative number double x, positive n > 0
test case: 
x = 0 , < 0.001, return 0 , 0.001 ^n < 0.001
n = 1, return itself 

Math.Abs(x - 1) < 0.001 return 1; 

exclude 0 -> (0, x]
binary search -> expedite -> better than linear scan 0 -> 0.001 -> x = 7, [0 , 7000], 0.001 -> O(log7000) = 10 * log7 = 30 number 

modify the binary search -> == double , <0.001 equal 
x > 1 && Math.Abs(x - 1) > 0.001
(0, 1)  
(1, x] -> (1, x]

x < 1
(0, x) -> (0, 0.5)
*/