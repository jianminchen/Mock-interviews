using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Solution
{
    public static string[,] WordCountEngine(string document)
    {
        if (document == null || document.Length == 0)
            return new string[0, 0];

        var length = document.Length;

        var lowerOne = document.ToLower();
        var removeExtra = lowerOne.Replace('\'', '0');

        var split = Regex.Split(removeExtra, "[ ,.!]+");

        var dict = storeToDict(split);

        // LINQ 
        var bucketsorted = applyBucketSort(dict);

        var valueMax = bucketsorted.Length;

        for (int i = 0; i < valueMax; i++)
        {
            var number = valueMax - 1 - i;
            var current = bucketsorted[number];
            if (current.Count == 0)
                continue;

            foreach (var item in current)
            {
                Console.WriteLine(item + " and value is " + number);
            }
        }

        return new string[0, 0];

    }

    private static List<string>[] applyBucketSort(Dictionary<string, int> dict)
    {
        int maxValue = 0;
        foreach (var pair in dict)
        {
            var number = pair.Value;
            maxValue = number > maxValue ? number : maxValue;
        }

        var sorted = new List<string>[maxValue + 1];

        for (int i = 0; i < maxValue + 1; i++)
            sorted[i] = new List<string>();

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var number = pair.Value;

            sorted[number].Add(key);
        }

        return sorted;
    }

    private static Dictionary<string, int> storeToDict(string[] split)
    {
        var length = split.Length;
        var dict = new Dictionary<string, int>();

        for (int i = 0; i < length; i++)
        {
            var current = split[i];
            if (!dict.ContainsKey(current))
                dict.Add(current, 1);
            else
                dict[current]++;
        }

        return dict;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(WordCountEngine("a bus bus cat cat C'at"));
    }
}

/*
"Practice makes perfect, you'll get perfecT by practice. just practice! just just just!!"
  
 [["just","4"],["practice","3"],["perfect","2"],["makes","1"],["youll","1"],["get","1"],["by","1"]]
 
 
 */