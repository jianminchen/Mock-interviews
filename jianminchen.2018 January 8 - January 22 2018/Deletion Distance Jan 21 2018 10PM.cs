using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2) // "heat", "hit"
    {
        if (str1 == null && str2 == null) // false 
        {
            return 0;
        }

        if (str1 == null)
        {
            return str2.Length;
        }

        if (str2 == null)
        {
            return str1.Length;
        }

        var length1 = str1.Length; // 4
        var length2 = str2.Length; // 3

        var deletionDist = new int[length1 + 1, length2 + 1]; // 5, 4

        // base case 
        for (int col = 0; col < length2 + 1; col++)
        {
            deletionDist[0, col] = col;
        }

        for (int row = 0; row < length1 + 1; row++)
        {
            deletionDist[row, 0] = row;
        }

        for (int row = 1; row < length1 + 1; row++)
        {
            for (int col = 1; col < length2 + 1; col++)
            {
                var first = str1[row - 1];
                var second = str2[col - 1];

                if (first == second)
                {
                    deletionDist[row, col] = deletionDist[row - 1, col - 1];
                }
                else
                {
                    deletionDist[row, col] = 1 + Math.Min(deletionDist[row - 1, col],
                                                          deletionDist[row, col - 1]);
                }
            }
        }

        return deletionDist[length1, length2];
    }

    static void Main(string[] args)
    {

    }
}

/*
constraints: minimum number of deletion 
two strings 

heat 
hit 

if first char is equal, then we do not need to delete, move to next iteration both, 0 + dist("eat", "it")
if 'e' != 'i', delete e or i , 1 + min(dist("at", "it"), dist("eat","t"))
  
  Draw a diagram, dynamic problem -> (str1.Length1 + 1) * (str2.Length + 1)
  dist("", "hit") = 3
  dist("heat", "") = 4
  
         5 * 4 matrix -> start from (0,0), solution will be matrix[4, 3]
         
         "" "t" "at"  "eat"  "heat"
  ---------------------------------------
    ""    0  1   2      3      4
    "t"   1
    "it"  2             -|
    "hit" 3                    ?
  
  
  Time complexity: 
  space complexity: 
  */