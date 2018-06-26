using System;

class Solution
{
    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
      if(shiftArr == null || shiftArr.Length == 0)
      {
        return -1; 
      }
      
      var length = shiftArr.Length; 
      
      var start = 0; 
      var end   = length - 1; 
      
      while(start <= end)
      {
        var middle      = start + (end - start)/ 2; 
        var middleValue = shiftArr[middle]; 
        
        if(middleValue == num)
          return middle; 
        
        var startValue = shiftArr[start]; 
        var endValue   = shiftArr[end];
        
        var leftHalfAscending  = startValue  <= middleValue; 
       // var rightHalfAscending = middleValue <= endValue; 
        
        if(leftHalfAscending)
        {
          if(num >= startValue && num <= middleValue)
          {
            end = middle - 1; 
          }
          else 
          {
            start = middle + 1; 
          }
        }
        else 
        {
          if(num >= middleValue && num <= endValue)
          {
            start = middle + 1; 
          }
          else 
            end = middle - 1; 
        }
      }
      
      return -1; 
    }

    static void Main(string[] args)
    {

    }
}

/*
[9, 12, 17, 2, 4, 5]
----------  ascending order
            -------  ascending order 
 given number 2, find index = 3, in the array, index is 3. 
 brute force, go over the array once. Time complexity: O(n)
 modified binary search -> lower O(logn)
   at most one pivot point -> line 16, 2 is pivot, 17, 2 descending 
   
   into two halves, one of them should be in ascending order <- given value is in range
 Divide the array -> ascending order, at least one of two ranges will be ascending order
 */ 
