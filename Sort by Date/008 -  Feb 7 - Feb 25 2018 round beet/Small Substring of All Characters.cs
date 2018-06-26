using System;
using System.Collections.Generic;

class Solution
{
    public static string GetShortestUniqueSubstring(char[] arr, string str)
    {
        if (arr == null || str == null || arr.Length > str.Length) return "";

        int uCount = arr.Length;
        int n = str.Length;

        // Count of elements which are present in arr
        var count = new Dictionary<char, int>();

        int i, j;
        int min = Int32.MaxValue; // window length
        int start = -1; // answer start position

        for (i = 0; i < uCount; i++)
        {
            count[arr[i]] = 0;
        }

        int found = 0; j = 0;
        for (i = 0; i <= n - uCount; i++)
        {
            // at the end of this loop j should be pointing just at the end of thw windows

            // for e
            while (found != uCount && j < n)
            {
                if (count.ContainsKey(str[j]))
                {
                    if (count[str[j]] == 0)
                    {
                        found++;
                    }
                    count[str[j]]++;
                }
                j++;
            }

            if (found == uCount && (j - i) < min)
            { // Found a new smaller window
                min = j - i;
                start = i;
            }

            // If the str[i] 
            if (count.ContainsKey(str[i]))
            {
                if (count[str[i]] == 1)
                {
                    found--;
                }
                count[str[i]]--;
            }
        }

        if (start == -1) return "";

        return str.Substring(start, min);

        /*
        xyyzyzyx
        i=0  left end of the window
        j =  right end of the window
      
        var count = int [256]
        [i,j] = find all the character of arr
      
        start with i = 0
        find j till all the characters in arr is covered
        window  - compare it with old window, if it smaller then save it.
        i = 1;
        decerment the value count[a[0]]--; it doesn't affect the all covering of element in arr
        remaining element is less than size of arr
        */
    }

    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            if (s == null | t == null || s.Length == 0 || t.Length == 0 || t.Length > s.Length) return "";
            int n = s.Length; int m = t.Length;

            var need = new int[256]; int count = m;
            foreach (char c in t) need[c]++;

            int i = 0; int min_i = 0; long len = s.Length + 1;
            for (int j = 0; j < n; j++)
            {
                if (need[s[j]]-- >= 1) count--; // Reducing need -affect counter only when need >= 1
                while (count == 0)
                { // All needs met - till need satsifed continue
                    if (j - i + 1 < len) { len = j - i + 1; min_i = i; } // need valid
                    if (need[s[i++]]++ == 0) count++; // Add to need, if need created - next break;
                }
            }
            return len == s.Length + 1 ? "" : s.Substring(min_i, (int)len);
        }
    }

    static void Main(string[] args)
    {

    }
}

