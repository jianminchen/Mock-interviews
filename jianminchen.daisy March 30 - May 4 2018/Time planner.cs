using System;

class Solution
{
    public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
    {
      if(slotsA == null || slotsB == null || dur < 0)
        return new int[0]; 
      
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
        
        int overlapStart = (int) Math.Max(startA, startB);
        int overlapEnd   = (int) Math.Min(endA,   endB);                   
       
        if(overlapEnd - overlapStart >= dur)
        {
          return new int[]{overlapStart, overlapStart + dur};
        }
        
        if(endA <= endB)
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
keywords: 

given dur > 0 integer, in seconds, 
each slots, disjointed, no overlap, start time acending order

   10       50 60        120    140            210
   ----------   ------------    ----------------   - slotsA
   
   ->indexA 0, 1, 2
   
 0     15      60    70
 _______        ______  slotsB
 
 ->indexB, 0, 1
 
  first two intervals [10, 50], [0, 15], overlap > dur, find one
  otherwise, continue to search:
  whicheven ends first, then slot will move to next 
  
  time complexity: O(m + n), m slotsA's length, n slotsB's length
  
  
    |______________
    
    
 __________|
    
    find overlap [max of two start value, min of two end value], overlap min(end1, end2) - max(start1, start2)
    
    */