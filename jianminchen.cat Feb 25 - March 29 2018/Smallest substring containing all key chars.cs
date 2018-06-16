using System;
using System.Collections.Generic;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] keys, string search)
    {
        if (keys == null || keys.Length == 0 || search == null || search.Length == 0)
            return "";

        var dict = new Dictionary<char, int>();

        foreach (var c in keys)
        {
            dict.Add(c, 1);
        }

        int minSubstringLength = int.MaxValue;
        int minSubstringStart = 0;

        int left = 0;
        int right = 0;
        int length = search.Length;
        int numberKey = keys.Length;
        int countOfWindowChar = 0;

        while (right < length)
        {
            var current = search[right];

            if (!dict.ContainsKey(current))
            {
                right++;
                continue;
            }

            if (dict[current] == 1)   // "x"
                countOfWindowChar++;

            dict[current]--;

            while (countOfWindowChar == numberKey)
            {
                // Let us update minimum substring if it is smaller
                var currentLength = right - left + 1;
                if (currentLength < minSubstringLength)
                {
                    minSubstringLength = currentLength;
                    minSubstringStart = left;
                }

                // move left pointer 
                var leftChar = search[left];
                var InDict = dict.ContainsKey(leftChar);
                if (InDict)
                {
                    if (dict[leftChar] == 0)
                    {
                        countOfWindowChar--; // break the loop 
                    }


                    dict[leftChar]++;
                }

                left++;
            }

            right++;
        }

        return minSubstringLength == int.MaxValue ? string.Empty : search.Substring(minSubstringStart, minSubstringLength);
    }

    static void Main(string[] args)
    {
        var substring = GetShortestUniqueSubstring(new char[] { 'x', 'y', 'z' }, "xaxxayz");
        Console.WriteLine(substring);
    }
}

/*
xyyzyzyx   "zyx"  countOfChars = 0 -> 3  
-        1 -> x = 0 do not need
 y       1 -> y = 0 do not need   2
  y      1 -> y = - 1 extra one   2
   z     1 -> z = 0  do not need  3
"xyyz" -> left pointer -> x -> x = 1, countOfChars 2
  
  "yyzy"   -> 
     
     continuously slide window
"xaxxyz" -> slide left -> x -> "axxyz"
                       -> a not in "zyz", "xxyz"
                       -> x, "xyz", "xyz"
      Time complexity: right O(n)    left O(n)  -> O(n)
      Space complexity: O(m) , key array length 
                       */