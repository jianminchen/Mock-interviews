using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2) // heat, hit
    {
        if (str1 == null && str2 == null) // false 
        {
            return 0;
        }

        if (str1 == null)  // false 
        {
            return str2.Length;
        }

        if (str2 == null) // false 
        {
            return str1.Length;
        }

        var length1 = str1.Length; // 4
        var length2 = str2.Length; // 3

        var deletionDistance = new int[length1 + 1, length2 + 1];

        for (int col = 0; col < length2 + 1; col++) // base case 
        {
            deletionDistance[0, col] = col;
        }

        for (int row = 0; row < length1 + 1; row++)
        {
            deletionDistance[row, 0] = row;
        }

        for (int row = 1; row < length1 + 1; row++)
        {
            for (int col = 1; col < length2 + 1; col++)
            {
                // it is equal 
                var firstChar = str1[row - 1]; // heat -> left -> right 
                var secondChar = str2[col - 1];  //hit

                var isSame = firstChar == secondChar;
                if (isSame)
                {
                    deletionDistance[row, col] = deletionDistance[row - 1, col - 1];
                }
                else
                {
                    deletionDistance[row, col] = 1 + Math.Min(deletionDistance[row - 1, col], deletionDistance[row, col - 1]);
                }
            }
        }

        return deletionDistance[length1, length2];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(DeletionDistance("heat", "hit"));
    }
}



/*

---------------------
|
|
|    ^
|  < 

heat  = length1   
hit   = length2 

     0  1  2   3     4      total length = length1 + 1, 0 - length1
    ""  t  at  eat   heat   
0
1              u
2          l   ?
3
..
.
length2 + 1



base case: 
one thing is empty, distance

both distance 0 

subproblem

say that dynamic programming today 


h -> 0
eat -> 1 + Math.Min(dist("at", "it"), dist("eat", "t"))
it  -> 

ht 



dog
frog

d, f
og-> frog
f, r -> 3 

some some
0

some thing

4 + 5 = 9
"" "" 0



*/

