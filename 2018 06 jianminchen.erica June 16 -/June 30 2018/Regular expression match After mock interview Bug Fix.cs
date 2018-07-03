using System;

class Solution
{
    public static bool IsMatch(string text, string pattern)
    {
        if (text == null || pattern == null)
            return false;

        var tLength = text.Length;
        var pLength = pattern.Length;

        if (pLength == 0)
            return text.Length == 0; // return true here

        var rows = tLength + 1; ;
        var columns = pLength + 1;

        var dp = new bool[rows, columns];

        // "" matchs "b*a*" 
        dp[0, 0] = true;
        for (int col = 1; col < columns; col++)
        {
            if (col > 1 && col % 2 == 0 && pattern[col - 1] == '*' && pattern[col - 2] != '*')
                dp[0, col] = dp[0, col - 2];
        }

        // first column default false
        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < columns; col++)
            {
                var currentChar = text[row - 1];
                var currentP = pattern[col - 1];

                if (currentChar == currentP || currentP == '.')
                {
                    dp[row, col] = dp[row - 1, col - 1];  // ok 
                }
                else if (currentP == '*' && col >= 2 && pattern[col - 2] != '*')  // this is bug to confuse text and pattern
                {
                    //                             zero or                   one or more than one
                    dp[row, col] = col >= 2 && (dp[row, col - 2] || (currentChar == pattern[col - 2] || pattern[col - 2] == '.') && dp[row - 1, col]);
                }
            }
        }

        return dp[rows - 1, columns - 1];
    }

    static void Main(string[] args)
    {
    }
}
/*
constraints: ., *, not in text, used for pattern string
. - single wildcard character
* match for zero or more sequence of the previous letter
asking: isMatch 
"aa" "a" - false
"aa" "aa" - true
"abc" "a.c" - true
"abbb" "ab*" - b* matchs bbb true
"acd"  "ab*c." - match
acd, ab*c.
     ''   'a'   'b'    '*''
      ""  "a"  "ab"   "ab*"   "ab*c"  "ab*c."
      ---------------------------------------
  ""  T   F     F      F
  "a" F   T     F      T(<-2)   F       F
  
  Time complexity: O(length of text * length of pattern)
  space complexity: O(n * m)  - only previous row - only two rows
  */