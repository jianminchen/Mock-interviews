using System;

class Solution
{
    public static char[] ReverseWords(char[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return new char[0];
        }

        var length = arr.Length;
        reverseInplace(arr, 0, length - 1);

        int left = 0;

        for (int i = 0; i < length; i++)
        {
            var current = arr[i];

            if (current == ' ')
            {
                continue;
            }

            var isStart = i == 0 || arr[i - 1] == ' ';

            if (isStart)
            {
                left = i;
            }

            var isEnd = i == (length - 1) || arr[i + 1] == ' ';
            if (isEnd)
            {
                reverseInplace(arr, left, i);
            }
        }

        return arr;
    }

    private static void reverseInplace(char[] arr, int start, int end)
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

    }
}



