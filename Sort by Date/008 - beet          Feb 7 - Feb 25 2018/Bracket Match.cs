using System;

class Solution
{
    public static int BracketMatch(string text)
    {
        if (text == null || text.Length == 0)
        {
            return 0;
        }

        var length = text.Length;

        int openBracket = 0;
        int unmatchedCloseBracket = 0;

        for (int i = 0; i < length; i++)
        {
            var current = text[i];
            var isOpen = current == '(';

            if (isOpen)
            {
                openBracket++;
            }
            else
            {
                if (openBracket > 0)
                {
                    openBracket--;
                }
                else
                    unmatchedCloseBracket++;
            }
        }

        return openBracket + unmatchedCloseBracket;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(BracketMatch("())("));
    }
}
/*
https://leetcode.com/problems/remove-invalid-parentheses/

I study - over 20 hours 
study ten submission

http://juliachencoding.blogspot.ca/2018/02/leetcode-301-breadth-first-search-and.html
(() -> let left to right, move invalid close bracket 
-> removed close bracket

total number

openBracket
unmatchCloseBracket

(  openBracket++
) -> 
  if openBracket > 0 
    openBracket--
  else 
    unmatchedCloseBracket++; // ))) -> 3, openone 0 

    
// ()))(
// Openbracket 1
//             0
// unmatchedCloseBracket 1
//                       2
// openbracket 1
// 1 + 2 = 3
 return openBracket + unmatchedClosedBracket
 
 time complexity O(n), space O(1)

find minimum parentheses
(()) -> ()
(()()) -> (()())
  )))() -> ()
  
 
  find minimum legal paretheses
*/