using System;

class Solution
{
    public static char[] ReverseWords(char[] arr)
    {
        if (arr == null || arr.Length == 0)
            return new char[0];

        var length = arr.Length;

        reverse(arr, 0, length - 1);

        int start = 0;
        for (int i = 0; i < length; i++)
        {
            var current = arr[i];

            var isSpace = current == ' ';
            if (isSpace)
                continue;

            if (i == 0 || arr[i - 1] == ' ')
                start = i;

            if (i == length - 1 || arr[i + 1] == ' ')
            {
                // reverse the word
                reverse(arr, start, i);
            }
        }

        return arr;
    }

    private static void reverse(char[] arr, int start, int end)
    {
        int left = start;
        int right = end;

        while (left < right)   // diff = left - start -> determine: end - left
        {
            var tmp = arr[left];
            arr[left] = arr[right];
            arr[end - (left - start)] = tmp;

            left++;
        }
    }

    static void Main(string[] args)
    {
        var reversed = ReverseWords(new char[] { 'a', ' ', 'b', ' ', 'c', 'a', 't' });

        foreach (var item in reversed)
        {
            Console.WriteLine(item);
        }
    }
}

/*
reverse(char[] arr, int start, int end)
  
"a b cat"  -> "tac b a" -> "cat b a"  -> Pattern 
Iterate the reversed array -> if word is found

cat
  |
  next index = ' ' or it is last index in the array
  */