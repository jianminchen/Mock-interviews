using System;

class Solution
{
    public static char[] ReverseWords(char[] arr) //"ab c d"
    {
        if (arr == null || arr.Length == 0) // false
        {
            return new char[0];
        }

        int length = arr.Length; // 6
        inplaceReverse(arr, 0, length - 1); // "d c ba"

        // go over the array and find each word, reverse each word in place

        int startWord = 0;

        for (int i = 0; i < length; i++)
        {
            var visit = arr[i]; // d
            var isSpace = visit == ' '; // false

            if (isSpace)
            {
                continue;
            }

            if (i == 0 || arr[i - 1] == ' ')
            {
                startWord = i; // 0
            }

            if (i == length - 1 || arr[i + 1] == ' ')
            {
                inplaceReverse(arr, startWord, i); // 
            }
        }

        return arr;
    }

    private static void inplaceReverse(char[] arr, int start, int end)
    {
        while (start < end)
        {
            var tmp = arr[start];
            arr[start] = arr[end];
            arr[end] = tmp;

            start++;
            end--;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ReverseWords("a b cd".ToCharArray()));
    }
}
/*
sentence reverse

constraints: most efficient manner - in place 
   space-delimited 
   
   "a b cd" -> "dc b a"->find first word "dc"->"cd"-> iteration 
   Time complexity: O(n)
   space complexity: O(1)
   */
