using System;

class Solution
{
    public static int BracketMatch(string text)  // "(()"
    {

        if (text == null || text.Length == 0) // false
        {
            return 0;
        }

        var length = text.Length; // 3
        int openBracket = 0;
        int unmatchedCloseBracket = 0;

        for (int i = 0; i < length; i++)
        {
            var visit = text[i]; // ( (  )
            var isOpen = visit == '(';
            if (isOpen)
            {
                openBracket++; // 1 -> 2
            }
            else
            {
                if (openBracket > 0)
                {
                    openBracket--; // 1
                }
                else
                    unmatchedCloseBracket++;
            }
        }

        return openBracket + unmatchedCloseBracket; // 1

    }

    static void Main(string[] args)
    {

    }
}

