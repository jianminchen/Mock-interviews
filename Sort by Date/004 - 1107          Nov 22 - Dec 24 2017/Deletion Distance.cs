using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2) // "heat",  "hit"
    {
        if (str1 == null || str2 == null)  // false 
        {
            return -1;
        }

        int length1 = str1.Length;
        int length2 = str2.Length;

        if (length1 == 0)
        {
            return length2;
        }

        if (length2 == 0)
        {
            return length1;
        }

        var memo = new int[length1, length2]; // int[4, 3], 12 variable 

        return DeletionDistanceHelper(str1, str2, memo, 0, 0);
    }

    ///
    private static int DeletionDistanceHelper(string str1, string str2, int[,] memo, int index1, int index2) // 
    {
        // base case 
        int length1 = str1.Length; // 4
        int length2 = str2.Length; // 3

        var reachEnd1 = length1 == index1;
        var reachEnd2 = length2 == index2;

        if (reachEnd1) // ""
        {
            return length2 - index2; // out of range of memo - 0 -> length1 - 1
        }

        if (reachEnd2)
        {
            return length1 - index1;
        }

        // memoization - 
        if (memo[index1, index2] != 0)
        {
            return memo[index1, index2];
        }

        var visit1 = str1[index1]; // 'h'
        var visit2 = str2[index2]; // 'h'
        var isSame = visit1 == visit2; // true            

        // recurrence - DP
        var current = 0;
        if (isSame)
        {
            current = DeletionDistanceHelper(str1, str2, memo, index1 + 1, index2 + 1);
        }
        else
        {
            // delete one of two chars
            var subProblem1 = DeletionDistanceHelper(str1, str2, memo, index1 + 1, index2); // delete 
            var subProblem2 = DeletionDistanceHelper(str1, str2, memo, index1, index2 + 1); //       

            current = 1 + Math.Min(subProblem1, subProblem2);
        }

        memo[index1, index2] = current;

        return current;
    }

    static void Main(string[] args)
    {

    }
}

// heat and hit 
// 3 -> 
// if two chars are the same, no deletion, both pointers move forward
// 0 + dist(s1.substring(1),s2.substring(1))
// h -> h distance = 0 
// else 
// dist("eat","it") 
// 'e' != 'i'
// two choices, delete e or delete i
// cost 1 - one deletion + subproblem containing two cases 
// 1 + Math.Min(dist("at", "it"), dist("at", "it"))  - formula 1 
// case 1: delete e, dist("at", "it")
// case 2: delete i, dist("eat", "t")
// redudant subproblem -> memoization -> timeout -> memoization -> size how many big -> hold memo
// str1 -> length1, substring 0 - length1, str2 -> substring length2 , 0 - length2 - 1
// n * m -> memo[][]
// heat 
// 0-1-2-3
// 0 -> heat
// 1-> eat
// 2-> at
// 3-> t
// ""
// "eat" "it" -> 



