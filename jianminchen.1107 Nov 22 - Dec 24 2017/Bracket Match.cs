using System;

class Solution
{
    public static int BracketMatch(string text) //  ())(
    {
        if (text == null || text.Length == 0) // false 
        {
            return 0;
        }

        int openBracket = 0;
        int unmatchedCloseBracket = 0;

        foreach (var item in text)  // () ) (
        {
            var isOpenBracket = item == '('; // true
            if (isOpenBracket)
            {
                openBracket++;   // 1,   1
            }
            else
            {
                var hasOpenBracket = openBracket > 0; // true
                if (hasOpenBracket)
                {
                    openBracket--;  // 0 
                }
                else
                {
                    unmatchedCloseBracket++; // 1
                }
            }
        }

        return openBracket + unmatchedCloseBracket; // 2
    }

    static void Main(string[] args)
    {
        Console.WriteLine(BracketMatch("(()"));
        Console.WriteLine(BracketMatch("(())"));
        Console.WriteLine(BracketMatch("())("));
    }
}

// (() -> 1 -> openBracket ++ 
// (()) -> 2 -> 1 -> 0 
// ())(  -> 1 -> 0  -> unmatchedCloseBracket + 1, openBracket -> 1
// time complexity -> O(n)
// O(1)