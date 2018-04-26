using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] search, string source)
    {
        if (search == null || search.Length == 0)
        {
            throw new ArgumentException("Search collection is null or empty.", "Search argument"); // code review 1
        }

        // assume that search string is not empty
        if (string.IsNullOrEmpty(source))
        {
            return "";
        }

        // put unique chars in search string to the dictionary
        var map = search.ToDictionary(c => c, c => 1);  // code review 3

        var needChars = search.Length; // 'xyz' - 3, var match = needChars == 0 
        // iterate the string and find match, and also keep track of minimum 
        var left = 0;
        var length = source.Length;

        var smallestLength = length + 1;
        var smallestSubstring = "";

        for (int index = 0; index < length; index++)
        {
            var visit = source[index];

            //TryGetValue method to avoid double search of the value by key. 
            int count;   // code review
            var inMap = map.TryGetValue(visit, out count); // code review 4
            var needOne = inMap && count > 0;

            if (inMap)
            {
                map[visit]--;
            }

            if (needOne)
            {
                needChars--;
            }

            var findMatch = needChars == 0;
            if (!findMatch)
            {
                continue;
            }

            // move left point forward - while loop                
            while (left <= index && (!map.ContainsKey(source[left]) || (map[source[left]] < 0))) // code review 5
            {
                var removeChar = source[left];

                // update the variable needChars                     
                if (map.ContainsKey(source[left]))
                {
                    map[removeChar]++;
                }

                left++;
            }

            var currentLength = index - left + 1;
            var findSmallerOne = currentLength < smallestLength;
            if (findSmallerOne)
            {
                smallestLength = currentLength;
                smallestSubstring = source.Substring(left, currentLength);

                needChars++;
                map[source[left]]++;
                left = left + 1;
            }
        }

        // edge case
        return smallestLength == length + 1   // code review 6
            ? string.Empty
            : smallestSubstring;
    }


    static void Main(string[] args)
    {

    }
}

