
using System;

class Solution
{
    public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
    {
      if(slotsA == null || slotsB == null || dur <= 0)
      {
        return new int[0]; 
      }
      
      var rowsA = slotsA.GetLength(0); 
      var rowsB = slotsB.GetLength(0); 
      
      int indexA = 0; 
      int indexB = 0; 
      
      while(indexA < rowsA && indexB < rowsB)
      {
        var startA = slotsA[indexA, 0]; 
        var endA   = slotsA[indexA, 1]; 
        
        var startB = slotsB[indexB, 0]; 
        var endB   = slotsB[indexB, 1]; 
        
        var overlapStart = Math.Max(startA, startB); 
        var overlapEnd   = Math.Min(endA, endB); 
        
        var interval = overlapEnd - overlapStart;
        if(interval >= dur)
        {
          return new int[]{overlapStart, overlapStart + dur};
        }
        else if(endA < endB)
        {
          indexA++; 
        }
        else 
        {
          indexB++; 
        }
      }
      
      return new int[0]; 
    }

    static void Main(string[] args)
    {

    }
}

/*
keyword: 
Each solts, nonoverlap , sorted by start time, ascending order 
two intervals overlap -> given dur -> return 
advance one of pointers 

 10       50   60  120
  -----------   ___________

0    15
_____


___________________
  |______|
  
  
  max - min overlap - nonexist 
  
  
time complexity :

O(n + m), n time solts, m length of time slots second one

*/