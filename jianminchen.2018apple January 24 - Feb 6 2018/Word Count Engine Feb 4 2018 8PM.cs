using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Solution
{
    public static string[,] WordCountEngine(string document)
    {
        if (document == null || document.Length == 0)
        {
            return new string[0, 0];
        }

        var lowered = document.ToLower();
        lowered.Replace('\'', '\0'); // you'll -> youll

        var splitted = Regex.Split(lowered, "[., !]+"); // a.b!c =>"a","b","c"

        var dictionary = putToDict(splitted);

        var sorted = applyBucketSort(dictionary);

        // output to dimension array 
        var length = sorted.Length;
        var sortedToArray = new List<string[]>();

        for (int i = length - 1; i >= 0; i--)
        {
            var current = sorted[i];

            foreach (var item in current)
            {
                if (item != null && item.Length > 0)
                    sortedToArray.Add(new string[] { item, i.ToString() });
            }
        }

        var dimension = new string[sortedToArray.Count + 1, 2];

        for (int i = 0; i < sortedToArray.Count; i++)
        {
            dimension[i, 0] = sortedToArray[i][0];
            dimension[i, 1] = sortedToArray[i][1];
        }

        return dimension;
    }

    private static Dictionary<string, int> putToDict(string[] words)
    {
        var dict = new Dictionary<string, int>();

        foreach (var item in words)
        {
            if (dict.ContainsKey(item))
            {
                dict[item]++;
            }
            else
                dict.Add(item, 1);
        }

        return dict;
    }

    private static List<string>[] applyBucketSort(Dictionary<string, int> dict)
    {
        var maxValue = 0;
        foreach (var pair in dict)
        {
            var value = pair.Value;
            if (maxValue < value)
            {
                maxValue = value;
            }
        }

        var sorted = new List<string>[maxValue + 1];

        for (int i = 0; i < maxValue + 1; i++)
        {
            sorted[i] = new List<string>();
        }

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var value = pair.Value;

            if (value > 0)
                sorted[value].Add(key);
        }

        return sorted;
    }

    static void Main(string[] args)
    {
        var dimension = WordCountEngine("a a b c");  // a 2, b 1, c 1
        var rows = dimension.GetLength(0);
        var cols = dimension.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write(dimension[row, col] + " ");
            }
            Console.WriteLine("new Line");
        }
    }
}
/*
upcase -> lower case
' replace ''
split string by delimters ". !" - regular expression 

group words -> how many time Dictionary< string, int> 
Sort them -> order by descending order 

LINQ - nlogN - I am learning 

bucket sort 
value 3, "practice"
value 2, "perfect"
value 1, "by", "get", ...
  
  send to two dimension 
  */