using System;
using System.Collections.Generic;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] keys, string source)
    {
        if (keys == null || source == null || source.Length == 0 || keys.Length == 0)
        {
            return "";
        }

        var dictionary = addToDictionary(keys);
        var hashSet = new HashSet<char>(keys);

        int left = 0;
        int minLength = int.MaxValue;
        int countOfKeys = 0;

        int length = source.Length;
        int startIndex = 0;

        for (int index = 0; index < length; index++) // axyyz
        {
            var current = source[index]; // 'a'

            var isInDict = dictionary.ContainsKey(current);
            if (!isInDict)
            {
                continue;
            }

            if (dictionary[current] == 1)
            {
                countOfKeys++;   // 1, 2, 3
            }

            dictionary[current]--; // x :0, y: -1, z:0

            // find substring containing all keys
            // "xyyz"
            // "xxyyz" -> "xyyz"
            // "xaxyz" -> "xyz"
            while (countOfKeys == keys.Length) // true  axyyz
            {
                var currentLength = index - left + 1; // 4 - 0 + 1 = 5, 4
                if (currentLength < minLength)
                {
                    minLength = currentLength; // 5, 4, left = 1
                    startIndex = left;
                }

                var leftChar = source[left]; // 'a', 'x'
                if (!hashSet.Contains(leftChar)) // true
                {
                    left++; // 1
                    continue;
                }

                dictionary[leftChar]++; // 1
                left++;  // 2
                if (dictionary[leftChar] == 1)
                {
                    countOfKeys--;  // 2                               
                }
            }
        }

        return minLength == int.MaxValue ? "" : source.Substring(startIndex, minLength);
    }

    private static Dictionary<char, int> addToDictionary(char[] keys)
    {
        var dict = new Dictionary<char, int>();

        foreach (var item in keys)
        {
            dict.Add(item, 1);
        }

        return dict;
    }
    static void Main(string[] args)
    {

    }
}

