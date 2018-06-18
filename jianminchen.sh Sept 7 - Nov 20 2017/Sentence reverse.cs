using System;
// 
// 
class Solution
{
    public static char[] ReverseWords(char[] arr) // "a b cd"
    {
        if (arr == null || arr.Length == 0) // false 
        {
            return new char[0];
        }

        var length = arr.Length; // 6 
        reverseWordInplace(arr, 0, length - 1); // "dc b a"

        // reverse each word                   
        int start = 0;

        for (int index = 0; index < length; index++) //"dc b a"
        {
            var visit = arr[index];
            var isNonSpacer = visit != ' '; // true

            var isFirst = isNonSpacer && (index == 0 || arr[index - 1] == ' ');  // d, false 
            if (isFirst) // true
            {
                start = index; // 0
            }

            var isLast = isNonSpacer && (index == (length - 1) || arr[index + 1] == ' '); // false, true

            if (isLast)
            {
                reverseWordInplace(arr, start, index); //0, 1           
            }
        }

        return arr;
    }

    private static void reverseWordInplace(char[] arr, int start, int end)// "a b cd" 0, 5 -> "dc b a"
    {
        while (start < end) // 
        {
            var temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++; // 0 -> 1
            end--; // 5 -> 4
        }
    }

    static void Main(string[] args)
    {

    }
}

// "a b cd" -> "cd b a" -> each word -> reverse each word -> "cd"
// inplace all the time -> reverse the string 
// last word -> first word, every word the word is reversed, reverse again
// instead of API - > by myself 
// time complexity -> empty char ' ' delimiter 
// space complexity - O(1)
