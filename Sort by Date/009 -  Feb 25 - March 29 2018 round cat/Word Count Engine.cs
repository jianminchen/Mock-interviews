

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
    public static string[,] WordCountEngine(string document)
    {
        if (document == null)
            return new string[0, 0];

        string lower = document.ToLower();
        //var replaced = lower.Replace('\'', );
        var replaced = replaceChar(lower, '\'');
        var split = replaced.Split("., !:;?".ToCharArray());
        var dict = putToDictionary(split);

        var totalCount = 0;
        var buckets = applyBucketSort(replaced, dict, ref totalCount);

        return toDimensionArray(buckets, totalCount);
    }

    private static string replaceChar(string s, char c)
    {
        var removed = new StringBuilder();
        foreach (var item in s)
        {
            if (item == c)
            {
                continue;
            }

            removed.Append(item);
        }

        return removed.ToString();
    }

    private static string[,] toDimensionArray(List<string>[] buckets, int totalCount)
    {
        var orderedWords = new string[totalCount, 2];
        var length = buckets.Length;

        int index = 0;
        for (int i = length - 1; i >= 0; i--)
        {
            var current = buckets[i];
            if (current.Count == 0)
                continue;

            foreach (var item in current)
            {
                orderedWords[index, 0] = item;
                orderedWords[index, 1] = i.ToString();
                index++;
            }
        }

        return orderedWords;
    }

    private static Dictionary<string, int> putToDictionary(string[] words)
    {
        var dict = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (string.IsNullOrEmpty(word))
                continue;

            if (dict.ContainsKey(word))
            {
                dict[word]++;
            }
            else
            {
                dict.Add(word, 1);
            }
        }

        return dict;
    }

    private static List<string>[] applyBucketSort(string document, Dictionary<string, int> dict, ref int totalCount)
    {
        var maxValue = dict.Values.Max();

        var sorted = new List<string>[maxValue + 1];

        for (int i = 0; i < maxValue + 1; i++)
            sorted[i] = new List<string>();

        var split = document.Split("., !:;?".ToCharArray());
        var hashSet = new HashSet<string>();

        foreach (var word in split)
        {
            if (hashSet.Contains(word))
                continue;

            hashSet.Add(word);
            if (!dict.ContainsKey(word))
                continue;

            var value = dict[word];
            sorted[value].Add(word);

            totalCount++;
        }

        return sorted;
    }

    static void Main(string[] args)
    {
        var parse = "Practice makes perfect, you'll get perfecT by practice. just practice! just just just!!";
        var sorted = WordCountEngine(parse);
    }
}
/*
lower case the char
strip out punctuation
split words using whitepsace
Sort by number of occurrence - descending order
output to two dimension array

time complexity - bucket sort -> count - max integer, 3, 
count - 3 in one bucket, 
3 - practice
1 - makes, youll, only, get, by, just - sort by the orginal order 
keep the original order of sentence 

Sort -> 
  Extra dictionary<int, string> 
  1 - practice 
  2 - makes 
  
Dictionary<string, integer> 
Sort by dictionary value 
  OrderedDictionary -> 
  output -> bucket sort 
  go through orginal string - parse word by word -> 
  
  keep the order of orginal order 

space complexity - polynomial space complexity 
n, n^2, n^3
*/