
using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2)
    {
      if(str1 == null || str2 == null)
      {
        return 0;
      }
      
      var length1 = str1.Length; 
      var length2 = str2.Length; 
      
      var dp = new int[length1 + 1, length2 + 1]; 
      
      // base case
      for(int col = 0; col < length2 + 1; col++)
      {
        dp[0, col] = col; 
      }
      
      for(int row = 0; row < length1 + 1; row++)
      {
        dp[row, 0] = row; 
      }
      
      // inductive step 
      for(int row = 1; row < length1 + 1; row++)
      {
        for(int col = 1; col < length2 + 1; col++)
        {
          var char1 = str1[row - 1]; 
          var char2 = str2[col - 1]; 
          var isEqual = char1 == char2; 
          
          if(isEqual)
          {
            dp[row, col] = dp[row - 1, col - 1];
          }
          else 
          {
            dp[row, col] = 1 + Math.Min(dp[row - 1, col], dp[row, col - 1]); 
          }
        }
      }
      
      return dp[length1, length2]; 
    }

    static void Main(string[] args)
    {

    }
}

// time complexity  O((length1)(length2 ))  
// brute force: 2^(length1 + length2)
// space complexity : O(n * m)
// optimal space complexity: O(min(m , n)))

/*
hit and heat how to calculate distance, using dynamic programing 

        0     1     2      3        4
        ""   "h"  "he"   "hea"   "heat"
        ---------------------------------------------
0  ""   0     1     2      3      4 
1 "h"   1     0     1
2  "hi" 2
3 "hit" 3                          ? 
  
  
  "h", "he"
  
   |     |    two choices: delete either one of latest char in two strings
  
              delete "h", 1 + dist("", "he")  = 1 + dist(0, 2) = 1 + 2
              delete "e",  1 + dist("h", "h") = 1 + dist(1, 1) = 1 + 0 
              Min(3, 1) = 1
              
               if current two chars are equal, then dist(i - 1, j - 1)
               
               */