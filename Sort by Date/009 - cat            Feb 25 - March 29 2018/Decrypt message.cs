using System;


class Solution
{
    public static string Decrypt(string word)
    {
      if(word == null || word.Length == 0)
        return "";
      
      int  length = word.Length; 
      char[] source = new char[length]; 
      
      source[0] = (char)(word[0] - 1); 
      
      int prefixSum = source[0];
      
      for(int i = 1; i < length; i++)
      {
        // source[i] = encrypt[i] - 1 - (source[0] + ... + source[i = 1]) + 26 * n until it is in a - z, i >0 
        char current = word[i]; 
        int diff = current - 1 - prefixSum; 
        
        while(diff < 'a' )        
        {
          diff += 26; 
        }
        
        source[i] = (char) diff; 
        
        prefixSum += source[i] ; 
      }
      
      return new string(source); 
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Decrypt("dnotq")); 
    }
}
/*

c     r        i                 m     e
99   114      105              109  101
100 1+99+114  1+99+114+105
100  214
     -26 *n
100   110 
d      n 

encrypt[source[i]] = source[i] + 1, i = 0
encrypt[source[i]] = 1 + source[0] + ... + source[i] - 26 * n, i > 0  , a - z


source[0] = encrypt[0] - 1; 
source[i] = encrypt[i] - 1 - (source[0] + ... + source[i = 1]) + 26 * n until it is in a - z, i >0 

*/