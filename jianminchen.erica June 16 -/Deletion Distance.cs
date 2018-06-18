using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2)
    {
      if(str1 == null || str2 == null)
        return -1; 
      
      var length1 = str1.Length; 
      var length2 = str2.Length; 
      
      if(length1 == 0)
        return length2;
      
      if(length2 == 0)
        return length1; 
      
      var rows = length1 + 1; 
      var columns = length2 + 1;
      
      var dist = new int[rows, columns];
      
      for(int col = 0; col < columns; col++)
        dist[0, col] = col;
      
      for(int row = 0; row < rows; row++)
        dist[row, 0] = row; 
      
      for(int row = 1; row < rows; row++)
      {
        for(int col = 1; col < columns; col++)
        {
          var char1 = str1[row - 1]; 
          var char2 = str2[col - 1];
          
          if(char1 == char2)
            dist[row, col] = dist[row - 1, col - 1];
          else 
            dist[row, col] = 1 + Math.Min(dist[row -1, col], dist[row, col - 1]);
        }
      }
      
      return dist[rows -1, columns - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
heat
hit

dynamic programming 
he
hi 
delete one of them, Math.min(dist("h","hi"), dist("he","h"))
  
  dynamic programming table 
              ''  'h'   'e'  'a'     't'
              ""  "h"  "he"  "hea"   "heat"
  '' ""       0    1     2    3       4
  'h'"h"      1    0     1    1+1 =2  1+2
  'i'"hi"     2
  't'"hit"    3
  
  Time complexity: O(m * n)
  Space complexity: O(m * n)
  
  */