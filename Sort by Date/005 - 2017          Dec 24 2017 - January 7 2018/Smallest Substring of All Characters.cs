using System;
using System.Collections.Generic;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] keys, string search)
    {
        if (keys == null || keys.Length == 0 || search == null || search.Length == 0)
        {
            return string.Empty;
        }

        int sLength = search.Length;

        // put keys to dictionary
        var dictionary = putToDictionary(keys);
        var hashSet = new HashSet<char>(keys);

        var totalKeyNeed = dictionary.Count; // 3
        var keyFoundSofar = 0; // 0

        var minLength = sLength + 1;
        var minSubstring = "";
        var left = 0;

        for (int i = 0; i < sLength; i++)
        {
            var visit = search[i];

            var isKeyChar = hashSet.Contains(visit);

            if (!isKeyChar)
            {
                continue;
            }

            var needOne = dictionary[visit] > 0;
            if (needOne)
            {
                keyFoundSofar++; // 2
            }

            dictionary[visit]--;

            var foundSubstring = totalKeyNeed == keyFoundSofar;
            if (!foundSubstring)
            {
                continue;
            }

            // substring found, need to move left pointer if need
            while (left < i && totalKeyNeed == keyFoundSofar)
            {
                var substringLength = i - left + 1;

                if (substringLength < minLength)
                {
                    minLength = substringLength;
                    minSubstring = search.Substring(left, minLength);
                }

                // decide to move 
                var leftChar = search[left];
                if (hashSet.Contains(leftChar))
                {
                    dictionary[leftChar]++; // remove left char, add one 

                    if (dictionary[leftChar] > 0)   // break the while loop
                    {
                        keyFoundSofar--;
                    }
                }

                left++;
            }

            /*
            xyyz
    |  |  "xyyz"
    "xyyz" ->
    left -> "xyyz"
      yyzyzyx
      |     |   
      move left 
      y -3 -> 
       |
         |
          |
            "zyx" - smallest 
        
    "xabxayz" -> "xayz"
            */

        }

        return minLength == sLength + 1 ? "" : minSubstring;
    }

    private static Dictionary<char, int> putToDictionary(char[] keys)
    {
        var dictionary = new Dictionary<char, int>();

        foreach (var key in keys)
        {
            dictionary.Add(key, 1);
        }

        return dictionary;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetShortestUniqueSubstring(new char[] { 'x', 'y', 'z' }, "xyyzyzyx"));
    }
}

/*
'x', 'y', 'z'

"xyyzyzyx"

linear scan left -> right
left variable -> 
index -> end of window

xyyz
|  |  "xyyz"
"xyyz" ->
left -> "xyyz"
  yyzyzyx
  |     |   
  move left 
  y -3 -> 
   |
     |
      |
        "zyx" - smallest 
        
"xabxayz" -> "xayz"


Dictionary<char, int> - 'x', 'y', 'z' 
1 needs one 
0 means enough
-1 -> have extra 
-2 -> have 2 extra

MinLength = str.Length + 1; 

slide left pointer 
     
*/