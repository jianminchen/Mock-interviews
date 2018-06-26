

using System;

class Solution
{
    public static int BracketMatch(string text)
    {
      if(text == null || text.Length == 0) 
        return 0; 
      
      var length = text.Length; 
      
      int openBracket = 0; 
      int unmatchedCloseBracket = 0; 
      
      for(int i = 0; i < length; i++)
      {
        var current = text[i]; 
        
        if(current == '(')
        {
          openBracket++; 
        }
        else 
        {
          if(openBracket > 0)
          {
            openBracket--; 
          }
          else 
            unmatchedCloseBracket++; 
        }
      }
      
      return openBracket + unmatchedCloseBracket; 
    }

    static void Main(string[] args)
    {
      Console.WriteLine(BracketMatch("())(")); 
    }
}

/*
(()  -> 1 does not match, (
  
(())  -> 0 
  
())( -> ( -> )  -> ) no open bracket to match - unmatchedCloseBracket++ -> ( openBracket++
        1 + 1 = 2
                                                                            
                                                                            
  openBracket++
    
  unmatchedCloseBracket++
                                                                            
  return sum of two variables 
  */