using System;

class Solution
{
    public static string Decrypt(string word)
    {
        if (word == null || word.Length == 0)
            return "";

        var length = word.Length;

        var source = new char[length];
        var firstChar = word[0];
        source[0] = firstChar == 'a' ? 'z' : (char)(word[0] - 1); // a -> z 

        for (int i = 1; i < length; i++)
        {
            //line 39 - (encrypt[i] - encrypt[i - 1]) + 26 * m -> a - z, for i >= 1
            int diff = word[i] - word[i - 1]; // 10 -> 10 + 26 * 4 = 114
            // 111 - 110 + 26 * 4 = 105
            while (diff < 'a')  // 4 * length -     n * n -> last char -> all asscii value -> 100 * n -> 100, 
            {
                diff += 26; // 26 -> binary m < 100
            }

            source[i] = (char)diff;
        }

        return new string(source);
    }

    static void Main(string[] args)
    {

    }
}
/*
        c   r        i            m      e 
       99  114      105          109    101  
step 2 100 100+114  224 + 105 
            214      319              <- encrypt[i] = encrypt[i - 1] + source[i], i >= 1  -- Formula 1
step 3: 100  214 -26 * x        
          
        d    a - z
        d    n        o         t       q
  based on formula 1, I can imply that 
  
  source[i] = (char)(encrypt[i] - 1),   i = 0
            = (encrypt[i] - encrypt[i - 1]) + 26 * m -> a - z, for i >= 1
            
            */