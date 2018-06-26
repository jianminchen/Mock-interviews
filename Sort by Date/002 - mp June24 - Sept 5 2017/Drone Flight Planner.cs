using System;

class Solution
{
    public static int CalcDroneMinEnergy(int[,] route)
    {
        // your code goes here
        if (route == null || route.GetLength(0) == 0 || route.GetLength(1) == 0)
        {
            return 0;
        }

        var rows = route.GetLength(0); // 5
        var start = route[0, 2]; // 10 
        var max = start;   // 10 

        for (int row = 1; row < rows; row++)
        {
            var visit = route[row, 2]; //0 
            if (visit > max) // 0 vs 10, 6, 15
            {
                max = visit; // max = 15
            }
        }

        return max - start; // 15 - 10 = 5
    }

    static void Main(string[] args)
    {
        var route = new int[,] { { 0, 2, 30 }, { 3, 5, 10 }, { 9, 20, 6 }, { 10, 12, 15 }, { 10, 10, 28 } };
        Console.WriteLine(CalcDroneMinEnergy(route));
    }
}
// 10 0 6 15 8 
// x , + 10  -6 (x + 10 vs 6)
// 10 0 6 -> downward 0 -> 15 -> downward -> assert: 10 -> 15 -> 5 kWh
// time O(n), space complexity max > start point O(1)
