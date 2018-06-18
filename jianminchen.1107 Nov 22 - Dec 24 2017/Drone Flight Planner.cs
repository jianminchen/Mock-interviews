using System;

class Solution
{
    public static int CalcDroneMinEnergy(int[,] route) // 5, 3
    {
        if (route == null || route.GetLength(0) == 0 || route.GetLength(1) < 3) // false
        {
            return -1;
        }

        var rows = route.GetLength(0); // 5


        var startHeight = route[0, 2]; // 10 
        var maxHeight = startHeight; // 10 
        for (int row = 1; row < rows; row++) // row = 1, 2, 3, 4
        {
            var visit = route[row, 2]; // 0, 6 , 15, 8
            var isBigger = visit > maxHeight; // false, false, true
            maxHeight = isBigger ? visit : maxHeight; // 15        
        }

        return maxHeight - startHeight; // 5
    }

    static void Main(string[] args)
    {

    }
}

/*
15                   D
14
13
12
11
10   A
9
8                           E
7
6               C
5
4
3
2
1
0          B
 time complexity O(N), space O(1)

*/