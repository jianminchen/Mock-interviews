using System;

class Solution
{
    public static int CalcDroneMinEnergy(int[,] route)
    {
        if (route == null || route.GetLength(0) == 0 || route.GetLength(1) < 3)
        {
            return 0;
        }

        int max = 0;

        for (int index = 0; index < route.GetLength(0); index++)
        {
            var height = route[index, 2];
            max = (max < height) ? height : max;
        }

        var startHeight = route[0, 2];
        return max > startHeight ? (max - startHeight) : 0;
    }

    static void Main(string[] args)
    {

    }
}

/*

15                  maximum height 


10  --- start 
  
  
  8
  
  6
  
  
  0
  */