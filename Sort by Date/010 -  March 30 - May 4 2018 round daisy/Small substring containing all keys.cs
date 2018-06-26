using System;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] arr, string str)
    {
      // your code goes here
    }

    static void Main(string[] args)
    {

    }
}

/*
Julia explained the algorithm to the peer:

'x', 'y', 'z'  -> dictionary<'x', 1, 'x':1, 'y':1,'z':1, 3 keys
  "xyyzyzyx"
   |  -> x -> found One key
   || -> xy -> read y -> 'y' - 0, 2 < 3 -> substring
   | | -> xyy -> 'y' -> -1, 2 < 3 
   |   |-> xyyz -> 'z' -> 0, 3 == 3, "xyyz", 4, "zyx"
    | -> x -> 'x': 0 -> 1, foundKey = 2
        | -> yyzy -> 
   ....
      
      minimum substring "zyx"
   The time complexity: O(n)
     
     
     substring is different from subsequence
     define by start/ end position -> how to define "xyyz"  -> 
     
     
     Leetcode first 200 questions - easy question -> read discussion - go over easy question - two sum problem 
     - 20 algorithms easy questions - as many as -> learn how to analyze the problem -> 
     -> read one algorithm at least 3 ideas 
     -> bring up your intelligent -> 
     -> math, logic, reasoning, principle -> simple math, simple logic 
     -> record how many hours -> 
     -> 2 + 2 + 2 + ..., 

  */ 
     