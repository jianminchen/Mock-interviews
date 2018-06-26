using System;

class Solution
{
    public static int CalcDroneMinEnergy(int[,] route)
    {
        if (route == null || route.GetLength(0) == 0 || route.GetLength(1) < 2)
            return 0;

        var rows = route.GetLength(0);
        var startHeight = route[0, 2];
        var maxHeight = startHeight;

        for (int row = 1; row < rows; row++)
        {
            var current = route[row, 2];
            if (current > maxHeight)
            {
                maxHeight = current;
            }
        }

        return maxHeight - startHeight; // return 0
    }

    static void Main(string[] args)
    {

    }
}

/*
                        D




A-----------------------------------------------  break even - maxHeight - orignalHeight

                                E

            C



                                  

     B

*/
