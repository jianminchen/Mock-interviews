using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    public static string[,] WordCountEngine(string document) // "A b a a b c"
    {
        if (document == null || document.Length == 0) // false
        {
            return new string[0, 0];
        }

        var processed = document.ToLower(); // "a b a' a b c"

        // replace 
        processed = processed.Replace('\\', '\0');

        // split the words 
        var words = Regex.Split(processed, "[:;,?!. ]+"); //"[ ,?!.]"   @" ,!"

        // sorted the dictionary and then send to buckets
        var buckets = applyBucketSort(storeToDict(words));

        // send to List<string, int>
        var sortedbyDescending = sortByDescending(buckets);

        // send to dimensional array
        var sortedLength = sortedbyDescending.Count;
        var sortedwords = new string[sortedLength, 2];
        int index = 0;
        foreach (var item in sortedbyDescending)
        {
            sortedwords[index, 0] = item[0];
            sortedwords[index, 1] = item[1];

            index++;
        }

        return sortedwords;
    }

    private static List<string[]> sortByDescending(List<string>[] buckets)
    {
        int length = buckets.Length;

        var descendingOrder = new List<string[]>();
        for (int i = length - 1; i >= 0; i--)   // -- not ++
        {
            foreach (var item in buckets[i])
            {
                descendingOrder.Add(new string[] { item, i.ToString() });
            }
        }

        return descendingOrder;
    }

    /// comparison sort -> nlogn -
    /// bucket sort -> detmine max value -> 1 to max buckets -> go over each word
    /// const size of bucket -> hint at most 200 
    private static List<string>[] applyBucketSort(Dictionary<string, int> dict)
    {
        // get maximum value count 
        var max = 0;
        foreach (var pair in dict)
        {
            var number = pair.Value;
            max = number > max ? number : max;
        }

        // var list = new List<string> 

        var buckets = new List<string>[max + 1]; // not max, should be max + 1

        for (int i = 0; i < max + 1; i++)
        {
            buckets[i] = new List<string>();
        }

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var value = pair.Value;

            buckets[value].Add(key);
        }

        return buckets;
    }

    private static Dictionary<string, int> storeToDict(string[] words)
    {
        var dict = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (word.Length == 0)
            {
                continue;
            }

            if (!dict.ContainsKey(word))
            {
                dict.Add(word, 1);
            }
            else
            {
                dict[word]++;
            }
        }

        return dict;
    }


    static void Main(string[] args)
    {

    }
}

/*
constraints: lower case/ upper case -> lower case 
    delimiter at least ". !"
    sorted by descending order, number of occurrences 
    if ascending order apping to same occurrence
    replace - punctuation 'you'll'   with whitespace  ""?
      
Time complexity: linear time complexity - > 
  sorting O(nlogn)      
  counting - bucket   O(n) - number of bucket 
  
Space complexity 

*/