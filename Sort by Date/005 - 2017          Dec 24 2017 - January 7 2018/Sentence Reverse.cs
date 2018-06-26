using System;

class Solution
{
    public static char[] ReverseWords(char[] arr) // "a b cd"
    {
        if (arr == null || arr.Length == 0) // false
        {
            return new char[0];
        }

        int length = arr.Length; // 6

        reverseGiveRange(arr, 0, length - 1); // 0, 5

        reverseWordByWord(arr);

        return arr;
    }

    private static void reverseGiveRange(char[] arr, int start, int end)// 0, 5
    {
        while (start < end) // true
        {
            var tmp = arr[start]; // 'a'
            arr[start] = arr[end]; // 'd'
            arr[end] = tmp; //'a'

            start++; // 1
            end--; // 4
        }
    }

    private static void reverseWordByWord(char[] arr)  // "dc b a"
    {
        const char space = ' ';

        int length = arr.Length; // 6

        int start = 0;

        for (int i = 0; i < length; i++)
        {
            var visit = arr[i]; // 'd', 'c'

            var isSpace = visit == space; // 
            if (isSpace)
            {
                continue;
            }

            var isStart = i == 0 || arr[i - 1] == space; // true
            var isEnd = i == (length - 1) || arr[i + 1] == space; // false, true

            if (isStart)
            {
                start = i;
            }

            if (isEnd)
            {
                reverseGiveRange(arr, start, i); // 0, 1
            }
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine(new string(ReverseWords("a b cd".ToCharArray())));
    }
}

// "a b cd" -> "dc b a" -> O(n)
// "dc" -> "cd" -> find word 
// start/ end -> 
// is not space char
// index == 0 || arr[index - 1] = ' ' - true - start
// index == length - 1 || arr[index - 1] = ' '  - true - end 
// reverse(arr, start, end)
// 