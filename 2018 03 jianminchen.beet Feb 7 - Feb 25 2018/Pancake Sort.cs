using System;

class Solution
{
    public static int[] PancakeSort(int[] arr)
    {
      if(arr == null || arr.Length == 0)
      {
        return new int[0];
      }
      
      var lastIndex = arr.Length - 1; 
      
      int index = 0; 
      
      while(index < length)
      {
        var lastPosition = lastIndex - index; 
        
        var maxIndex = findMaxIndex(arr, lastIndex - index); 
        inplaceMove(arr, maxIndex, lastPosition); 
        
        index++; 
      }
      
      return arr; 
    }
  
    private static int findMaxIndex(int[] arr, int lastPos)
    {
      
      int maxIndex = 0; 
      for(int i = 1; i <= lastPos; i++)
      {       
        if(arr[i] > arr[maxIndex])
        {
          maxIndex = i; 
        }
      }
      
      return maxIndex; 
    }
  
    private static void inplaceMove(int[] arr, int maxIndex, int lastPosition)
    {
      flip(arr, maxIndex + 1); 
      flip(arr, lastPosition + 1); 
    }

    // flip first k element 0 - k- 1
    private static void flip(int[] arr, int k)
    {
      int start = 0; 
      int end = k - 1; 
      
      while(start < end)
      {
        var tmp = arr[start]; 
        arr[start] = arr[end]; 
        arr[end] = tmp; 
        
        start++;
        end--; 
      }
    }
  
    static void Main(string[] args)
    {

    }
}

/*
[1, 5, 4, 3, 2]


try to find subarray with given sum -> 12, then you will find subarray [5, 4, 3]

[0, 1, 0,1, 1]

1 2 3 4 5
0 1 1 0 1

[1 4 ] [2 3 5]
0 0 1 1 1
  
  -> maxIndex -
      1 
  API moveFromOneToLastPlace
  
  flip first index + 1, max value is the first in the array
  flip first lastPos + 1, 4, flip first 5 element, go to last position
  
  [1, 5, 4, 3, 2 ]
  
  */
/*
can plant flower - leetcode discussion 

http://juliachencoding.blogspot.ca/search?q=can+plant+flower

https://codereview.stackexchange.com/questions/185935/leetcode-54-spiral-matrix

jianmin chen 


play one hackerrank contest - find some diffcult - how good ranking/ motivated / hard level 

https://www.hackerrank.com/contests/w36/challenges

https://www.hackerrank.com/contests/w36/challenges


https://codereview.stackexchange.com/users/123986/jianmin-chen

https://github.com/seahawksfan/Algorithms
 
online presence

quora.com
*/

 



