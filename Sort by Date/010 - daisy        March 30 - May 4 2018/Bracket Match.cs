// https://www.linkedin.com/in/jianminchen
// http://juliachencoding.blogspot.ca/
// 300 last 12 months 
using System;

class Solution
{
    public static int BracketMatch(string text)
    {
        if (text == null)
            return 0;

        var length = text.Length;

        var openBracket = 0;
        var unmatchedCloseBracket = 0;

        for (int index = 0; index < length; index++)
        {
            if (text[index] == '(')
            {
                openBracket++;
            }
            else
            {
                if (openBracket > 0)
                    openBracket--;
                else
                    unmatchedCloseBracket++;
            }
        }

        return openBracket + unmatchedCloseBracket;
    }

    static void Main(string[] args)
    {

    }
}

/*
keywords:

open bracker/ closing bracket

(() - 1 unmatched open bracket, it may be first or second one 
(()) - 0 matched
())( - (), )( - 2 unmatched 

Idea: openBracket
      unmatchedCloseBracket 
      find a (, increment variable openBracket; 
      find a ), to see if there is an open bracket, then openBracket--; 
             otherwise unmatchedCloseBracket++
      return openBracket + unmatchedCloseBracket
      
*/

