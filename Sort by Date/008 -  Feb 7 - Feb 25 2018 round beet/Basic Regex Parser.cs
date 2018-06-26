using System;

class Solution
{
    public static bool IsMatch(string text, string pattern)
    {
        if (text == null || pattern == null)
        {
            return false;
        }

        var tLength = text.Length;
        var pLength = pattern.Length;

        var dp = new bool[tLength + 1, pLength + 1];

        // set base case first 
        dp[0, 0] = true; ;

        // first row
        for (int col = 1; col < pLength + 1; col++)
        {
            var pChar = pattern[col - 1];
            var isStar = pChar == '*';
            if (col >= 2 && isStar)   // "" matches "a*" or "a*b*"
                dp[0, col] = dp[0, col - 2];
        }

        for (int row = 1; row < tLength + 1; row++)
        {
            for (int col = 1; col < pLength + 1; col++)
            {
                var tChar = text[row - 1];
                var pChar = pattern[col - 1];
                var isStar = pChar == '*';
                var isDot = pChar == '.';

                if (!isStar)
                {
                    dp[row, col] = (isDot || (tChar == pChar)) && dp[row - 1, col - 1]; // bug fixed
                }
                else
                {
                    // it is star
                    //                 zero time,                     one time          or more than one time 
                    dp[row, col] = (col >= 2 || dp[row, col - 2]) || dp[row, col - 1] || dp[row - 1, col];
                }
            }
        }

        return dp[tLength, pLength];
    }

    static void Main(string[] args)
    {

    }
}
/*
   b*  repeat zero time, one time and more than one time
   
   "",
   b
   bb
   bbbb
   
   acd with ab*c.
          0    1     2     3      4        5          pattern 
         ""   "a"  "ab"  "ab*"  "ab*c"  "ab*c."
         ----------------------------------------
 0  ""    T    F    F     F       F       F
 1  "a"   F    T    F     T(0)    F       F
 2  "ac"  F    
 3  "acd" F                              dp(3,5)=?
    text 
     
     base case:  "", dp[0,0] = true, dp[row,0] = false;
              text empty, "" match "a*" and "a*b*"
     
     inductive step: 
            discuss two case: 
            * involved - match zero, match one or more than one
            compare two key or if pattern key is wild char .
    */

/*
function isMatch(text, pattern):
    return isMatchHelper(text, pattern, 0, 0)


#  Input:
#    text - the text to check,
#    pattern - the regular expression to be checked,
#    textIndex - the index the text is checked from
#    patIndex -  the index the pattern is checked from
#  Output:
#   true if the text from the index textIndex matches
#   the regular expression pattern from the pattern Index.
#   E.g. isMatchHelper(“aaabb”,”cab*”,2, 1) since the text
#   from index 2 (“abb”) matches the pattern from index 1 (“ab*”)

function isMatchHelper(text, pattern, textIndex, patIndex):
    # base cases - one of the indexes reached the end of text or pattern
    if (textIndex >= text.length):
        if (patIndex >= pattern.length):
            return true
        else:
            if (patIndex+1 < pattern.length) AND  (pattern[patIndex+1] == '*'):
                return isMatchHelper(text, pattern, textIndex, patIndex + 2)
            else:
                return false

    else if (patIndex >= pattern.length) AND (textIndex < text.length):
        return false

    # string matching for character followed by '*'
    else if (patIndex+1 < pattern.length) AND (pattern[patIndex+1] == '*'):
        if (pattern[patIndex] == '.') OR (text[textIndex] == pattern[patIndex]):
            return (isMatchHelper(text, pattern, textIndex, patIndex + 2) OR
                    isMatchHelper(text, pattern, textIndex + 1, patIndex))
        else:
            return isMatchHelper(text, pattern, textIndex, patIndex + 2)

    # string matching for '.' or ordinary char.
    else if (pattern[patIndex] == '.') OR
            (pattern[patIndex] == text[textIndex]):
        return  isMatchHelper(text, pattern, textIndex + 1, patIndex + 1)
    else:
        return false
          
          
         
// Peer shared his solution. My solution:
func isMatch(text: String, pattern: String) -> Bool {
  var i: Int = 0
  var textIndex: Int = 0
    
  while i < pattern.count && textIndex < text.count {
    let currPat = Array(pattern)[i]
      
    var nextPat: String.Element = " "
      
    if i < pattern.count - 1 
    { 
      nextPat = Array(pattern)[i+1] 
    }    
    
    if nextPat == "*" {
      var matchPat = currPat
      if currPat == "." 
      { 
        matchPat = Array(text)[textIndex] 
      } // if ".*" pattern, save first item in sequence
      
      while textIndex < text.count && matchPat == Array(text)[textIndex]  { // match 0+ times
        textIndex += 1 // match at least 1 time 
      }
      
      i += 1  // extra increment to skip star
    } 
    else if currPat != Array(text)[textIndex] && currPat != "." 
    {
      return false
    } 
    else {
      textIndex += 1  // match 1 time
    }
    
    i += 1   // advance pattern index
  }
  
  // Handle case if pattern ends with "*" with element count of 0
  if i < pattern.count - 1 && Array(pattern)[i+1] == "*" { i += 2 }
  
  return textIndex == text.count && i == pattern.count
}

print(isMatch(text: "acdddd", pattern: "ab*c.*"))
  */