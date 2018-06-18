using System;

class Solution
{
    public static char[] ReverseWords(char[] arr) // "a b cd"
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return new char[0];
        }

        reverseInplace(arr, 0, arr.Length - 1); // 

        reverseEachWord(arr); // "dc b a"
        return arr;
    }

    private static void reverseInplace(char[] arr, int start, int end)// 0, end = 5
    {
        var length = arr.Length;   // 6  

        while (start < end) // true
        {
            var tmp = arr[start]; // a
            arr[start] = arr[end]; // 'b'
            arr[end] = tmp; // 'a'

            start++;
            end--;
        }
    }

    private static void reverseEachWord(char[] arr) // "dc b a"
    {
        const char space = ' ';
        int length = arr.Length; // 6

        var start = 0;
        var end = 0;
        for (int i = 0; i < length; i++) // 'c'
        {
            var visit = arr[i]; // 'd'
            var isSpace = visit == space; // false

            if (isSpace)
            {
                continue;
            }

            var isStart = i == 0 || arr[i - 1] == space; // true
            var isEnd = i == length - 1 || arr[i + 1] == space; // false , true

            if (isStart)
            {
                start = i; // 0
            }

            if (isEnd)
            {
                end = i; // 1

                reverseInplace(arr, start, end); // "dc" - > "cd"
            }
        }
    }

    static void Main(string[] args)
    {
        var reversed = ReverseWords("a b cd".ToCharArray());

        Console.WriteLine(new string(reversed));

    }
}

/*
"a b cd"
reverse the sentence -> "dc b a"  -> two pointer, in place
reverse each word, how do I do it?
"dc "
 ||
 start position - two checking index == 0 || arr[index - 1] == ' '
 end position - two checking   indx == lastChar || arr[index + 1] == ' '
 
eacH word, then reverse each word  - API 

*/

