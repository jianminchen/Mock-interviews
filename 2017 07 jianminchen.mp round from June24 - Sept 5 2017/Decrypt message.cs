using System;

class Solution
{
    static string decrypt(string word)
    {
        // your code goes here
        if (word == null || word.Length == 0)
        {
            return "";
        }

        int length = word.Length;
        var message = new char[length];

        message[0] = (char)(word[0] - 1);

        for (int i = 1; i < length; i++)
        {
            var visit = word[i];
            var previous = word[i - 1];

            // 100, 110, need to go back to 214 first
            // 114 -> encrypt 
            // 100 + 114 = 214
            // 214 - 26 * multiple(4) = 214 - 104
            // 

            int difference = (int)visit - (int)previous; // 10
            // go back to 214, then reduce 26 multilple time   //
            while (difference - 'a' < 0) // 10 + 104 = 114
            {
                difference += 26;
            }

            message[i] = (char)difference;
        }

        return new string(message);
    }

    static void Main(string[] args)
    {
        var message = decrypt("dnotq");
        Console.WriteLine(message);
    }
}

// char[] word
// encrypt[char[0]] = char[0] + 1; (char)(char[0] + 1), c - > d
// encrypt[char[i]] = encrypt[char[i-1]] + 100, i > 0, from second to last
// r 114 + 100, ascii of r is 114, a - 97, r - a = 17, 
// i 105 + 214 = 319 
// m 109 + 319 = 428
// e 101 + 428 = 529 
// encrypt[char[i]] = encrypt[char[i-1]] + 100 - 26 * MultipleTime, i > 0, from second to last a - z
// decrpty[encrypt[0]] = encrypt[0] - 1; 
// 110 -> 114
// 114 - 100 + 26 * Mutiple in range of a - z
// decrypt[i] = encrypt[i] - 100 + 26 * multipletime until a - z


