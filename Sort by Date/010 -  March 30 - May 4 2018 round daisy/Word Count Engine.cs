
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Solution
{
    public static string[,] WordCountEngine(string document)
    {
        if (document == null)
            return new string[0, 0];

        var lowerCase = document.ToLower();

        // you'll -> remove ' 
        var removed = removeSpecialChar(lowerCase);

        var split = removed.Split(" !.;:,?".ToCharArray());

        var dict = saveToDictionary(split);

        var totalCount = 0;
        var buckets = applyBucketSortKeepTheOriginalOrder(dict, split, ref totalCount);
        return convertToDimension(buckets, totalCount);
    }

    private static string removeSpecialChar(string lowerCase)
    {
        // '''
        var sb = new StringBuilder();
        foreach (var item in lowerCase)
        {
            if (item != '\'')
            {
                sb.Append(item);
            }
        }

        return sb.ToString();
    }

    private static Dictionary<string, int> saveToDictionary(string[] split)
    {
        var dict = new Dictionary<string, int>();

        foreach (string item in split)
        {
            if (item == null || item.Length == 0)
                continue;

            if (dict.ContainsKey(item))
            {
                dict[item]++;
            }
            else
            {
                dict.Add(item, 1);
            }
        }

        return dict;
    }

    private static string[,] convertToDimension(IList<string>[] buckets, int totalCount)
    {
        var length = buckets.Length;

        var sorted = new string[totalCount, 2];

        int index = 0;

        for (int bucketIndex = length - 1; bucketIndex > 0; bucketIndex--)
        {
            // buckets[index] -> this is a list         
            foreach (var item in buckets[bucketIndex])
            {
                sorted[index, 0] = item;
                sorted[index, 1] = bucketIndex.ToString();
                index++;
            }
        }

        return sorted;
    }

    private static IList<string>[] applyBucketSortKeepTheOriginalOrder(Dictionary<string, int> dict, string[] split, ref int totalCount)
    {
        int maxValue = dict.Values.Max();
        var buckets = new List<string>[maxValue + 1];  // 0 -> maxValue 

        for (int index = 0; index < maxValue + 1; index++)
        {
            buckets[index] = new List<string>();
        }

        var hashSet = new HashSet<string>();

        foreach (var word in split)
        {
            if (hashSet.Contains(word) || word.Length == 0)
                continue;

            hashSet.Add(word);

            var value = dict[word];

            buckets[value].Add(word);

            totalCount++;
        }

        return buckets;
    }

    static void Main(string[] args)
    {
        var sorted = WordCountEngine("a b c c d");
        for (int row = 0; row < sorted.GetLength(0); row++)
        {
            Console.WriteLine(sorted[row, 0] + " " + sorted[row, 1]);
        }
    }
}

/*
requirement:

convert to lower case
split words by delimiters - " .,!"
put to dictionary - key - string - value 3 -> Max value 
bucket sort -> 
keep the order in the original sentence -> go through the split words -> put into bucket 
output to dimension array -> 

*/