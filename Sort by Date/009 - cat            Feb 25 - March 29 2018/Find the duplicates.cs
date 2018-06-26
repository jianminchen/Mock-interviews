
using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindDuplicates(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null)
            return new int[0];

        var length1 = arr1.Length;
        var length2 = arr2.Length;

        int index1 = 0;
        int index2 = 0;

        var duplicate = new List<int>();

        while (index1 < length1 && index2 < length2)
        {
            var current1 = arr1[index1];
            var current2 = arr2[index2];

            if (current1 == current2)
            {
                duplicate.Add(current1);
                index1++;
                index2++;
            }
            else if (current1 < current2)
                index1++;
            else
                index2++;
        }

        return duplicate.ToArray();
    }

    static void Main(string[] args)
    {

    }
}

/*
M is close N, two arrays has almost size - ascending order
index1 -> 
index2 -> 
  duplicate -> add result, advance two indexes
  advance with smaller 
  
  time complexity: O(M + N)
  
  binary search in large array - M >> N, time complexity: N * logM 
  
  */