using System;

class Solution
{
    public static int CalcDroneMinEnergy(int[,] route) 
    {
      if(route == null || route.GetLength(0) == 0 || route.GetLength(1) < 3)
      {
        return 0; 
      }
      
      var rows = route.GetLength(0); 
      
      int startHeight = route[0, 2]; 
      int maxHeight = startHeight; 
      
      for(int row = 1; row < rows; row++)
      {
        var current = route[row, 2]; 
        maxHeight = current > maxHeight? current : maxHeight;                
      }
      
      return  maxHeight - startHeight; 
    }

    static void Main(string[] args)
    {

    }
}


/*

15                    D




10    A ------------------------------------------------ go above original line
  
  
8                              E
  
6               C
  
  
  
  
0           B 

*/