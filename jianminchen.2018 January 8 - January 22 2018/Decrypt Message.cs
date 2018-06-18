using System;

class Solution
{
    public static string Decrypt(string word)  // "dnotq"  // "anotq"  'z' ->'a'
    {
        if (word == null || word.Length == 0) // false
        {
            return string.Empty;
        }

        int length = word.Length; // 5
        var source = new char[length];

        var firstChar = word[0];
        source[0] = (firstChar == 'a') ? 'z' : (char)(firstChar - 1);  // 'd' - 1

        var sumSource = source[0];

        for (int i = 1; i < length; i++)
        {
            int diff = word[i] - 1 - sumSource;

            var smaller = diff < 97;

            if (smaller)
            {
                diff += (97 - diff) / 26 * 26;
            }

            while (diff < 97)
            {
                diff += 26; // time complexity can be optimized by using binary search 
            }

            source[i] = (char)diff;

            sumSource += source[i];
        }

        return new string(source);
    }

    static void Main(string[] args)
    {

    }
}

/*
Constraints: lowercase latin letters - a - z
Encryption: 
  encrption(arr[0]) = (char) (arr[0] + 1)
  encryption(arr[i]) = encrption(arr[i - 1]) + arr[i]  - 26 * x (?) - > a - z, i > 0 
                     = 1 + arr[0] + arr[1] + ..+ arr[i] - 26 * x  -> a - z, i > 0 
                     = 1 + sum(a[i], i from 0 to i) - 26 * x -> a - z, 
Solve the decryption: 

  source[0] = encryption[0] - 1
  source[i] = encryption(arr[i])   - 1 - sum(source[j], j from o to j - 1) + 26 * x -> a - z, a - 97
  
  total sum of char 1 + 2 + .. n = n^2, how many number of char in sum
  26 * x -> a - z 97 - (97 + 26), each add a char, you have to take at least 3 * 26 = 104 to offset, 

  26 * 3 = 78 -> 
    
  Time complexity: O(n) + n * n = 
  space complexity: O(n) , n is string length 
  */