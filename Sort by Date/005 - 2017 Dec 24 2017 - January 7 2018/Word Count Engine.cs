using System;
using System.Linq; 
using System.Collections.Generic;

class Solution
{
    public static string[,] WordCountEngine(string document)
    {
        if(document == null || document.Length == 0)
        {
          return new string[0,0]; 
        }
      
        var preprocessed = document.ToLower().Replace('\'', '\0'); // remove ' to empty space
           
        var splitted = preprocessed.Split(", !".ToCharArray()); 
      
        // https://stackoverflow.com/questions/7325278/group-by-in-linq
        var map = splitted
          .Select(x => x.Trim())
          .GroupBy(x => x)
          .OrderByDescending(g => g.Count()); 
      
       var parse = map.Select(g=>$"{g.Key}: {g.Count()}");
       Console.WriteLine(string.Join(", ", parse)); 
          
        return new string[0,0];
                                                 
    }

    static void Main(string[] args)
    {
        WordCountEngine("a b c a a b ");
    }
}

/*
string[] words = string.Split(" .!")
lowercase -> Practice -> practice
bucket sort 
dictionary<string, int> practice 3 
sort by total value -> 
value -> max value 
value-> OrderByValue -> 
 value = 3   value 2     value 1
bucket        perfect     by
                          get
                          just
descending -> biggest value first -> go to small value                           
*/