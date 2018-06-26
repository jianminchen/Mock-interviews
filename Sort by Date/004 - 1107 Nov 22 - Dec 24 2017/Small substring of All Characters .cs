using System;
using System.Linq;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] source, string search) // "xyyzyzyx", ['x','y','z']
    {
        if (source == null || source.Length == 0 || search.Length == 0) // false
        {
            return string.Empty;
        }

        var length = source.Length;// 3
        var searchLength = search.Length; // 8

        var minimumSubstring = "";
        var minimumLength = searchLength + 1;// 9 
        var uniqueCharsMet = 0;

        int left = 0;

        var dictionary = source.ToDictionary(c => c, c => 1); // dictionary['x'] = 1, same as 'y', 'z'

        for (int index = 0; index < searchLength; index++) // 0, 1, 2, 3, 4
        {
            var visit = search[index]; // 'x', 'y', 'y', 'z', 'y'
            var isInSet = dictionary.ContainsKey(visit); // true, true, true, true, true

            if (!isInSet)
            {
                continue;
            }

            var isNeeded = dictionary[visit] > 0; // true, true, false, true, false
            if (isNeeded)
            {
                uniqueCharsMet++; // 1, 2, 3
            }

            dictionary[visit]--; // d['x'] = 0; d['y'] = 0; d['y'] = -1, d['z'] = 0, d['y'] = -2

            while (uniqueCharsMet == length) // 1 != 3, false; 2 != 3, false; 2!= 3, false; true, false
            {
                // check to see if the left point can move forward
                if (!dictionary.ContainsKey(search[left]) || dictionary[search[left]] <= 0) // "xyyz"
                {
                    var current = search[left]; // 'x'                         

                    if (dictionary.ContainsKey(current) && dictionary[current] <= 0) // true
                    {
                        var count = dictionary[current];

                        if (count == 0)
                        {
                            uniqueCharsMet--; // 2
                        }

                        dictionary[current]++; // dictionary['x'] = 1                            
                    }

                    // maintain substring length
                    var startPosition = left; // 0 
                    var currentLength = index - startPosition + 1; // 4
                    var currentSubstring = search.Substring(startPosition, currentLength); //"xyyz"
                    if (currentLength < minimumLength) // 4 < 9
                    {
                        minimumLength = currentLength; // 4
                        minimumSubstring = currentSubstring; // "xyyz"
                    }

                    left++; // 1
                }
            }
        }

        return minimumLength == (searchLength + 1) ? string.Empty : minimumSubstring;
    }
    static void Main(string[] args)
    {

    }
}

