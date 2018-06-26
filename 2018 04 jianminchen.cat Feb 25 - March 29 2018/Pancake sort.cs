/*
https://www.linkedin.com/in/jianminchen
http://juliachencoding.blogspot.ca/
https://codereview.stackexchange.com/questions/181046/four-sum-algorithm-mock-interview-practice
https://www.hackerrank.com/jianminchen_fl 

The art of readable code - 200 pages - my suggestion - how to readable code
pluralsight.com  - clean code, write code for humans - 4 hours course 

break giant expression 
declare explanation variable 
art - 
principle - TED - terse, express the intent, do one thing - 3 principle 

k, l -> third, fourth
  
clean code 

*/
using System;

class Solution
{
    public static int[] PancakeSort(int[] arr)
    {
      if(arr == null || arr.Length == 0)
      {
        return new int[0]; 
      }
      
      var length = arr.Length; 
      var lastPosition = length - 1; 
      
      while(lastPosition > 0)
      {
        var maxIndex = findMaxIndexGivenLastPosition(arr, lastPosition); 
        moveMaxIndexToLastPosition(arr, maxIndex, lastPosition); 
        
        lastPosition--; 
      }
      
      return arr; 
    }

    private static int findMaxIndexGivenLastPosition(int[] arr, int lastPosition)
    {
      int maxIndex = 0; 
      for(int i = 1; i <= lastPosition; i++)
      {
        var current  = arr[i]; 
        var maxValue = arr[maxIndex]; 
        if(current > maxValue)
        {
          maxValue = current; 
          maxIndex = i; 
        }
      }
         
      return maxIndex; 
    }
  
    private static void moveMaxIndexToLastPosition(int[] arr, int maxIndex, int lastPosition)
    {
      flip(arr, maxIndex + 1); 
      flip(arr, lastPosition + 1); 
    }
  
    private static void flip(int[] arr, int firstK)
    {
      int start = 0; 
      int end = firstK - 1; 
      
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

/*keywords:

one API - flip( arr, k), reverse first k elements 
sort the array 
Constraints:

 only use flip API 
 
 For example, [1, 5, 4, 3, 2]
 [1, 2, 3, 4, 5] -> 
   define last position of the array - index = 4
 First find maximum number in the array with given last position, 5 is largest, index = 1, -> flip first two numbers -> [5, 1] -> flip whole array -> 
   5 is the last element in the array 
 Repeat step on line 26, work on the subarray, index-- (reduce last position of subarray) , 

Time complexity: O(n * n ) = O(n)  O(n) + O(n - 1) + ... + O(1)
Space complexity: O(1)*/
  
  