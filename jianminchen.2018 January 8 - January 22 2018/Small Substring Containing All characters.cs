using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] keys, string search) // ['x','y','z'], "axxxyz"
    {
        if (keys == null || keys.Length == 0 || search == null || search.Length < keys.Length) // false 
        {
            return string.Empty;
        }

        var dictionary = keys.ToDictionary(key => key, val => 1);
        // https://stackoverflow.com/questions/15252225/convert-an-array-to-dictionary-with-value-as-index-of-the-item-and-key-as-the-it

        int left = 0;
        int length = search.Length;

        int minimumSubstringLength = length + 1; //2
        string minimumSubstring = string.Empty;

        // TERSE - self document - 

        int findUniqueCharCount = 0;
        int totalUniqueChars = keys.Length;

        for (int i = 0; i < length; i++)
        {
            var current = search[i]; // 'a'

            if (!dictionary.ContainsKey(current))  //'a'
            {
                continue;
            }

            if (--dictionary[current] == 0)
            {
                findUniqueCharCount++; // 1
            }

            while (findUniqueCharCount == totalUniqueChars) // true
            {
                // record minimum substring
                var substringLength = i - left + 1; // 1
                string substring;

                if (substringLength < minimumSubstringLength)
                {
                    minimumSubstringLength = substringLength;  //
                    //minimumSubstring       = search.Substring(left, substringLength); //
                }

                // move left pointer 
                var leftChar = search[left++]; // 

                if (dictionary.ContainsKey(leftChar)) // 
                {
                    if (dictionary[leftChar]++ == 0)
                    {
                        findUniqueCharCount--;  // break the loop
                    }
                }
            }
        }

        return minimumSubstringLength == length + 1 ? string.Empty : search.Substring(left - 1, minimumSubstringLength);
    }

    static void Main(string[] args)
    {
        //Console.WriteLine(GetShortestUniqueSubstring())
    }
}

/*

slide window

['x','y', 'z'], "xyyzyzyx"

xyyzyzyx
|
|

Dictionary<char, int>   "axbcyz" -> xbcyz, but b, c not in dictionary 
'x',  1
'y',  1
'z',  1

int minimumSubstringLength  = str.Length + 1
string smallestSubstring = "";

xyyzyzyx
|

findUniqueChar = 0, 3 dictionary.Key.Count
'x' -> 0 -> 
1 
"xy"
y -> y -> 0 

findUniqueChar = 2

"xyy" -> y -1
findUniqueChar = 2

continue to slide window
"xyyz" -> z ->0
findUniqueChar = 3

find substring -> record -> compare to minimum, replace 
left pointer sliding if need

"xxxxyz"  -> remove extra 3 x
while(it is substring)
{

    update minimum substring 
    
    continuous to left pointer once
    
    update dictionary
    free one char, +1 
    
    update findUniqueChar--; // break the loop 
}

return == str.Length + 1? string.Empty : smallestSubstring 
*/
