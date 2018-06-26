using System;

class Solution
{
    // 
    static char[] reverseWords(char[] arr)
    {
        // your code goes here
        if (arr == null || arr.Length == 0)
        {
            return new char[0];
        }

        // assume the arr is not empty
        int length = arr.Length;
        reverse(arr, 0, length - 1); // "a b  cd" ->"dc  b a"

        int start = 0;
        // find each word in sentence and then reverse each word
        for (int i = 0; i < length; i++)
        {
            var visit = arr[i];
            bool isSpace = visit == ' ';

            bool isStart = !isSpace && (i == 0 || arr[i - 1] == ' ');
            bool isLastChar = !isSpace && (i == (length - 1) || arr[i + 1] == ' ');

            if (isStart)
            {
                start = i; // char is not space, first char or previous char is space
            }

            if (isLastChar)
            {
                reverse(arr, start, i); // landing char 
            }
        }

        return arr;
    }

    /// in pace, O(1)
    static void reverse(char[] arr, int start, int end)
    {
        if (start > end)
        {
            return;
        }

        while (start < end)
        {
            var tmp = arr[start];
            arr[start] = arr[end];
            arr[end] = tmp;

            start++;
            end--;
        }
    }

    public static void Main(String[] args)
    {

        var reversed = reverseWords(new char[] { 'a', ' ', 'b', ' ', ' ', 'c', 'd' });
        Console.WriteLine(reversed);
    }

}
// "a b cd"
// reverse whole string using in place algorithm - swap two numbers from two ends
//"dc b a"   - 3 words 
// word dc -> cd, API reverse(char[] arr, int start, int end)
// linear scan an array 
// determine if a word has found 
// visit = arr[i]
// isAlpha = visit != ' '
// isSpace = 
// dc  - d, c, ' '
// bool isStart     =  isAlpha && ( i == 0 || arr[i-1] == ' ')
// bool isLastChar  =  isAlpha && ( i == (length - 1 || arr[i+1] == ' ')
// reverse 
