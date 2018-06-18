using System;

class Solution
{
    // interviewing.io - 
    // pass the interview - spiral matrix - while 4 for loops
    // while 4 for loop - hard to maintain - all bug - bug free 
    // delete -> 
    // https://codereview.stackexchange.com/questions/185935/leetcode-54-spiral-matrix
    public static int DeletionDistance(string str1, string str2) // 
    {
        if (str1 == null && str2 == null)
        {
            return 0;
        }

        var length1 = str1.Length;
        var length2 = str2.Length;

        var dp = new int[length1 + 1, length2 + 1];

        for (int row = 0; row < length1; row++)
        {
            dp[row, 0] = row;
        }

        for (int col = 0; col < length2; col++)
        {
            dp[0, col] = col;
        }

        for (int row = 1; row < length1 + 1; row++)
        {
            for (int col = 1; col < length2 + 1; col++)
            {
                var visit1 = str1[row - 1];
                var visit2 = start2[col - 1];

                if (visit1 == visit2)
                {
                    dp[row, col] = dp[row - 1, col - 1];
                }
                else
                {
                    dp[row, col] = 1 + Math.Min(dp[row - 1, col], dp[row, col - 1]);
                }
            }
        }

        return dp[length1, length2];
    }

    static void Main(string[] args)
    {

    }
}
/*
heat hit                              delete e         delete i
'e'  compares to 'i', 1 + Math.Min(dist("at","it"),  dist("eat","t"))
  if dist("heat","hit") =  dist("eat", "it") since "h", "h"
    
  "heat", "hit"
  "eat", "it"
  heat and hit
  
  dp[5, 4]
          0    1   2       3      4
  
          ""  "h"  "he"  "hea"   "heat"
       ----------------------------------------------
  ""      0   1     2    3       4
  "h"     1
  "hi"    2                ? A    ?C
  "hit"   3                ? B    ?D
  
               case 1: if 't' == 't' : dp[4, 3] = dp[3, 2]
                                                  delete last char in row         delete last char in col
               case 2: else        dp[4, 3] = 1 + min(dp on left side,             dp on up side);

  D  dist("heat", "hit")
  A  dist("hea",  "hi")
  B  dist("hea",  "hit")
  C  dist("heat", "hi")
    
    why D = A? 
    
    math major 
    */