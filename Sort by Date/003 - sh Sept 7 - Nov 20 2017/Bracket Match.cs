using System;

class Solution
{
    // (()
    // left open bracket - variable 1-> 2 , close bracket, 2 - 1 = 1, return openbracket 
    // (())
    // 1 -> 2 -> 1 -> 0  return 0
    // ())(
    // 1 -> 0 -> ) -> unmatchedCloseBracket 1 -> ( openLeftBracket 1, add two variable 2 
    // time complexity O(n), two variable O(1)
    public static int BracketMatch(string text) //"())("
    {
        // your code goes here
        if (text == null || text.Length == 0) // not true
        {
            return 0;
        }

        var leftOpenBracket = 0;
        var unmatchedRightCloseBracket = 0;

        foreach (var item in text)
        {
            var isOpenBracket = item == '('; // true, false, false, true

            if (isOpenBracket)
            {
                leftOpenBracket++; // 1, 1
            }
            else // close bracket
            {
                if (leftOpenBracket > 0) // true
                {
                    leftOpenBracket--; // 0 
                }
                else
                {
                    unmatchedRightCloseBracket++; // 1
                }
            }
        }

        return leftOpenBracket + unmatchedRightCloseBracket; // 2 
    }

    static void Main(string[] args)
    {

    }
}

