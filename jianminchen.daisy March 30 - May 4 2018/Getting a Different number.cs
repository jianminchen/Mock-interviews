using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr)
    {

    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:

unique nonnegative integers - 
  
  Ask: find smallest nonnegative integer that is not in the array
  
  not allowed to modify input the array
  
 [1, 2, 3, 100]  - size 4, find missing number 0
 
 how can I found?
 [2,1, 3, 100]
 check 2
 [3, 1, 2, 100]
 [100, 1, 2, 3]
                -> 
  100 -> index - return 0  
 
*/