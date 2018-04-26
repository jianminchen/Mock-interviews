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

        //assume the array is not empty; 
        var rows = route.GetLength(0); // 5, 
        //var columns = route.GetLength(1); // 3 third element - height, ignore first and second one

        var maxHeight = route[0, 2]; // 10

        for (int row = 1; row < rows; row++) // 1 - 4
        {
            var visitHeight = route[row, 2]; // 0, 6, 15, 8 

            maxHeight = visitHeight > maxHeight ? visitHeight : maxHeight; // 15
        }

        return maxHeight - route[0, 2];  // 0 -> 15 - 10 
    }

    static void Main(string[] args)
    {
        var initialEnergy = CalcDroneMinEnergy(new int[,] { { 0, 2, 10 }, { 3, 5, 0 }, { 9, 20, 6 }, { 10, 12, 15 }, { 10, 10, 8 } });
        Console.WriteLine(initialEnergy);
    }
}

// 15                                             -- 0Kwh
//
//
//
//
// 10   - 5wh                             -- 0KWh -> 5kwh
// 9
//                                                                -- 7Kwh  -- 
//
// 6                         --  10 - 6 = 4kWh
//
//
//
//
//
// 0             -- 10KWh

// [[0, 0, 0], [1, 1, 2], [1, 2, 1]]
// answer = 2
