using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindDuplicates(int[] arr1, int[] arr2) // [1, 2, 3,5, 6,7], [3, 6,7,8, 10]
    {
        if (arr1 == null || arr1.Length == 0 || arr2 == null || arr2.Length == 0)  // false 
        {
            return new int[0];
        }

        int length1 = arr1.Length; // 6
        int length2 = arr2.Length; // 5

        int start1 = 0;
        int start2 = 0;

        var list = new List<int>();

        while (start1 < length1 && start2 < length2) // true
        {
            var visit1 = arr1[start1]; // 1, 2, 3
            var visit2 = arr2[start2]; // 3

            var isSame = visit1 == visit2; // false 
            if (isSame) // true
            {
                list.Add(visit1); // 3, 
                start1++; // 3
                start2++; // 2
            }
            else if (visit1 < visit2)
            {
                start1++; // 1, 2
            }
            else
            {
                start2++;
            }
        }

        // LINQ statement  - C# 
        // https://stackoverflow.com/questions/629178/conversion-from-listt-to-array-t
        /*
        int length = list.Count; 
      
        var result = new int[length]; 
        for(int i = 0; i < length; i++)
        {
          result[i] = list[i]; 
        }
      
        return result; 
        */
        return list.ToArray();
    }

    static void Main(string[] args)
    {
        var duplicate = FindDuplicates(new int[] { 1, 2, 3, 5, 6, 7 }, new int[] { 3, 6, 7, 8, 20 });
        foreach (var item in duplicate)
        {
            Console.WriteLine(item);
        }
    }
}

// linear scan 
// O(m + n) - two array sizes are almost the same , first case
// [1, 2, 3, 5, 6, 7]  -> [3, ]
/*
             |
    
   [3, 6, 7, 8, 20]
       |
    
    
*/
/*
M >> N

work on N, small array [1, 2, 3]
1, try to find it in the second array using binary search log(N)
My solution using binary search is N * log(M), it is better than brute force M * N


*/
