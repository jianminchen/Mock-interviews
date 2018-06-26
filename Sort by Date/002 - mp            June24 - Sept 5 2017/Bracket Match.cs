using System;

class Solution
{
    public static int BracketMatch(string text) //((), ())(
    {
        // your code goes here
        if (text == null || text.Length == 0) //
        {
            return 0;
        }

        int length = text.Length; // 3, 4
        var openBracket = 0;
        var misMatch = 0;

        foreach (var item in text)
        {
            bool isOpen = item == '('; // 

            if (isOpen)
            {
                openBracket++; // 1, 2, 1, 0, 1
            }
            else
            {
                if (openBracket > 0)
                {
                    openBracket--; // 1, 0
                }
                else
                {
                    misMatch++; // 1
                }
            }
        }

        return openBracket + misMatch; // 1,, 2 
    }

    static void Main(string[] args)
    {

    }
}

// (() -> var open ( +1, (, open 2, ), open 1 , return 1
// (()) -> open 0->1->2->1->0  , 0 
// ())) -> open 0->1->0-> mismatch 1, 2 -> open + mistmatch 
// linear scan O(n), space complexity -> O(1)