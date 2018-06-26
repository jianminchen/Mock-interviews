using System;

class Solution
{
    public static string Decrypt(string word)  // "dnotq"
    {
        if (word == null || word.Length == 0)  // false
        {
            return string.Empty;
        }

        var length = word.Length; // 5

        var original = new char[length]; // 

        original[0] = (char)(word[0] - 1); // 'c'

        long sumOfSource = (int)original[0]; // c

        for (int index = 1; index < length; index++)
        {
            var current = word[index];
            //s[i] = Encryption(s[i]) - 1 - SumOfSource(0->i - 1) + x * 26
            long diff = word[index] - 1 - sumOfSource;

            // add x * 26 to a - z
            //var smaller = diff < 97; 
            /*
            if(smaller)
            {
              // number +  (97 - number)/ 26 * 26
              diff += (97 - diff)/ 26 * 26;  // diff + 26 * x < 97 
                                             // -> 26 * x < (97 - diff)
            }
            */
            while (diff < 97)
            {
                diff += 26;
            }

            original[index] = (char)diff;

            sumOfSource += original[index];
        }

        return new string(original);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Decrypt("anotq"));
    }
}

/*
Constraints: 
string s with length length, s[0] = 'c', s[1] = 'r'
  
Encryption(s[0]) = (char)s[0] + 1   - refer to line 56 
  
Encryption(s[1]) = s[1] + Encryption(s[0]) - x * 26  
  
Encryption(s[2]) = s[2] + Encryption(s[1]) - x * 26   
  
Encryption(s[i]) = s[i] + Encryption(s[i - 1]) - x * 26 -> a - z, a ascii value 97 
                 = 1 + s[0] + s[1] +...+ s[i] - x * 26   --- formula, need to find s[i]
  
  we denote sumSource = s[0] + s[1] + ...+ s[i] -> SumOfSource
  
  s[i] = Encryption(s[i]) - 1 - SumOfSource(0->i - 1) + x * 26
  
  Time complexity: for each char, one addition, one subtraction, x * 26 -> while loop each time add 26 -> x -> n * 3, O(n^2) -> O(n)
    
    -1000 -> 97 - a, number +  (97 - number)/ 26 * 26 -> 
  */
