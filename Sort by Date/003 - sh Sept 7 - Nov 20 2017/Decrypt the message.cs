using System;
using System.Text;

class Solution
{
    public static string Decrypt(string word)
    {
        // your code goes here
        if (word == null || word.Length == 0)
        {
            return string.Empty;
        }

        // assume that string is not emtpy
        var length = word.Length;

        var decryptMessage = new StringBuilder();

        var firstChar = (char)(word[0] - 1);
        decryptMessage.Append(firstChar);

        int previousEncrypted = (int)word[0];

        for (int i = 1; i < length; i++) // 
        {
            var visit = word[i]; // encryptWord[i], 110

            var difference = visit - previousEncrypted; // integer 110 - 100 = 10

            while ('a' - difference > 0) // a-z, 'a' = 97
            {
                difference += 26; // 10, 36, 62, 88, 104, 
            }

            var currentEncrypted = (char)difference; // 114 -> r
            decryptMessage.Append(currentEncrypted);

            // reset previous
            previousEncrypted = visit;
        }

        return decryptMessage.ToString();
    }

    static void Main(string[] args)
    {

    }
}

// crime 
// step 2:
// encrypt[word[0]] = word[0] + 1; // a - 97, c- 99, 
// encrypt[word[i]] = encrypt[word[i - 1]] + word[i]    for any i > 0  // r - 114, 100 + 114 = 214
// r -> 100 + 114 = 214
// i -> 105 + 214 = 319
// m -> 109 + 319 = 428
// e -> 101 + 428 = 529 
//
// step 3: 
// out of range a - z, 97 + 26 = 123 
// lower value 
// encrpt[word[i]] = lowerValueToaToZ( encrypt[word[i - 1]] + word[i] ), -26 , while(value - 'a' >=0 && 'z' - value >=0)
// encryptWord
// decrypt[encryptWord[0]] = encryptWord[0] - 1; 
// decrypt[encryptWord[i]] = 
// by line 19 
// word[i] = encrypt[word[i]]  -  encrypt[word[i - 1]]  for any i > 0
// n -> r : 110 - 100 = 10 -> 114 -> 10 + 26 * 4 = 114 -> r
// 0 -> i: 111 - 110 = 1 -> 1 + 26 * 4 = 105  -> i
// t -> m: 116 - 111 = 5 -> 5 + 26 * 4 = 109
// q -> e: 113 - 116 = -3 + 26 * 4 = 101 -> e 
// time O(n), O(1)