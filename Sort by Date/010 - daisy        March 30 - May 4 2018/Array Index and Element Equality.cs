using System;

class Solution
{
    public static int IndexEqualsValueSearch(int[] arr)
    {
      if(arr == null || arr.Length == 0)
      {
        return -1;
      }
      
      var length = arr.Length;
      var start = 0; 
      var end   = arr.Length;
      
      while(start <= end)
      {
        var middle = start + (end - start)/2;
        var middleValue = arr[middle] - middle; 
        
        if(middleValue == 0 )
        {
           if(middle > 0 && arr[middle - 1] == middle - 1)
             end = middle - 1; // not lowest index 
           else 
             return middle;
        }
        else if(middleValue > 0)
        {
          end = middle - 1;
        }
        else
          start = middle + 1;
      }
      
      return -1; 
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:  sorted array,  distinct integers, 
asking: lowest index,  and also index i, arr[i] == i
if not found, return -1;

Time complexity: brute force will take O(n), linear search, that is not good.
Better to use binary search 

constraint: lowest index 
[0, 1, 2, 3]  - lowest index = 0
  
numbers[i] = Arr[i] - i, this array is not descending, apply binary search 


*/

/*
Julia's sharing:
 * 
https://www.linkedin.com/in/jianminchen/

http://juliachencoding.blogspot.com/

http://juliachencoding.blogspot.com/2018/04/10-rounds-of-mock-interviews.html

Leetcode - 
  
  craft skilling - The art of readable code - 200 pages - two googlers 
  
  udemy.com - jeff bae   interview 
 */
  
  