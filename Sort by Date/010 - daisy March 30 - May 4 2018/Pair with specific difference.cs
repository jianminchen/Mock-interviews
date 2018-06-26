using System;
using System.Collections.Generic;

class Solution
{
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
        if (arr == null || k < 0 || arr.Length < 2)
            return new int[0, 0];

        Array.Sort(arr);

        var length = arr.Length;
        var left = 0;
        var right = 1;

        var pairs = new List<int[]>(); // dictionary - small value as key,value is pair I found with k 
        // try to find all pairs
        while (left < length && right < length)
        {
            var leftValue = arr[left];
            var rightValue = arr[right];
            var difference = rightValue - leftValue;
            if (difference == k)
            {
                pairs.Add(new int[] { rightValue, leftValue }); // -> add - 

                left++;
                right++;
            }
            else if (difference < k)
            {
                right++;
            }
            else
            {
                left++;
            }
        }

        // save the list to dimensional array
        var size = pairs.Count;
        var pairArray = new int[size, 2];

        int index = 0;
        foreach (var item in pairs)  // go through the original array, current elment -> 
        {
            pairArray[index, 0] = item[0];
            pairArray[index, 1] = item[1];

            index++;
        }

        return pairArray;
    }

    static void Main(string[] args)
    {

    }
}

/*
https://codereview.stackexchange.com/questions/181046/four-sum-algorithm-mock-interview-practice

https://codereview.stackexchange.com/a/193293/123986

https://www.linkedin.com/in/jianminchen

http://juliachencoding.blogspot.ca/

https://www.hackerrank.com/jianminchen_fl


The peer gave me his solution, which is better than ... 

      // set( 0, -1, -2, 2, 1)
      // Loop through the list
      // we see 0, so we look for 0 + k in the set
      // we find 1 exists
      // so we add (1, 0) to the pair collection we have ( list of pairs )
      // So this way we maintain the order of y

*/
/*
keywords:

arr, integer, distinct, given k >=0 integer, 
ask:

Find all pairs, [x, y], x - y = k
not found, return empty array

Constraint: reduce memory usage -> maintain time efficiency 
maintain the order of the y element in the original array 

you cannot have [ [0, -1], [ 1, 0] ]
  
  
[0, -1, -2, 2, 1], k = 1
  
 brute force 
 [ , 0], try to find 1 -> go through the array O(n)
 time complexity: n^2 solution 
 nlogn -> 
   
   sort the array 
   [-2, -1, 0, 1, 2]
   
   pair difference k = 2
   
   ptr at -2, ptr at -1  ( 1 ) < k  - I cannot hear you, maybe you can refresh 
   ptr at -2, ptr at 0 ( 2 ) == k -> add this pair
   
   use pointer - dynamic programming
   -2,       -1
   left -<   right
   */