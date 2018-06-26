using System;
using System.Collections.Generic;

class Solution
{
    public static int[] FindDuplicates(int[] arr1, int[] arr2)// [1,2,3,5,6,7], [3, 6,7,8 20]
    {
        if (arr1 == null || arr1.Length == 0 || arr2 == null || arr2.Length == 0) // false
        {
            return new int[0];
        }

        var length1 = arr1.Length; // 6
        var length2 = arr2.Length; // 5

        var index1 = 0;
        var index2 = 0;

        var duplicate = new List<int>();

        while (index1 < length1 && index2 < length2)  // false 
        {
            var current1 = arr1[index1]; // 1, 2, 3, 5, 6, 7
            var current2 = arr2[index2]; // 3, 6, 7

            if (current1 == current2) //false, true
            {
                duplicate.Add(current1); // 3, 6, 7
                index1++;  // 3, 5, 6
                index2++; // 1, 2, 3
            }
            else if (current1 < current2)// true
            {
                index1++; // 1, 2, 4
            }
            else
            {
                index2++;
            }
        }

        return duplicate.ToArray();
    }

    static void Main(string[] args)
    {
        var duplicated = FindDuplicates(new int[] { 1, 2, 3, 5, 6, 7 }, new int[] { 3, 6, 7, 8, 20 });
        foreach (var item in duplicated)
        {
            Console.WriteLine(item);
        }
    }
}

/*
case m almost same as n

m > n
first array first 

[1, 2, 3, 5, 6, 7]

index1 = 0
[3, 6, 7, 8, 20, 8]

index2 = 0;


O(m + n)


// iterate 

*/