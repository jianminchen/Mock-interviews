https://www.linkedin.com/in/jianminchen/
 https://www.linkedin.com/in/carlos-castro-vargas-93517122/
using System;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget)
    {
      if(grantsArray == null || grantsArray.Length == 0)
      {
        return 0; 
      }                     
      
      Array.Sort(grantsArray); 
      
      double consumed = 0; 
      var length = grantsArray.Length; 
      
      for(int i = 0; i < length; i++)
      {
        double current = grantsArray[i]; 
        
        double available = newBudget - consumed; // 188
        int numbersLeft = length - i; // i = 1  [2, 50, 100, 120, 1000]
        
        if( current * numbersLeft > available) // 50 * 4 > 188 -> 188/ 4
        {
          return available/ numbersLeft;
        }
        
        consumed += current;         
      }
      
      return grantsArray[length - 1]; 
    }

    static void Main(string[] args)
    {

    }
}

/*
Can plant flower 
Leetcode 605 https://leetcode.com/articles/can-place-flowers/


Given new budget, array not sorted, 
find a cap, 
constraint: least number of recipents is impacted

sorted array -> O(nlogn)
linear scan the array, from smallest to largest


[2, 50, 100, 120, 1000]

2 -> capacity -> 2 * 5 < 190 -> 
50 -> 2, new budget 190, 188 for rest of number 188/ 4 = 47 
  make new budget 47 
  
cap = grantsArray[length - 1]  

*/