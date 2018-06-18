using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    /// <summary>
    /// count word practice - August 7, 2017
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var result = WordCountEngine("this practice is good one. Good to practice.");
    }

    public static string[,] WordCountEngine(string document)
    {
        // your code goes here
        if (document == null || document.Length == 0)
        {
            return new string[0, 2];
        }

        var delimiter = new char[] { '.', '!', ' ', ',', ':', ';', '?' };
        var split = document.Split(delimiter);

        var dictionary = addToDictionary(split);

        // bucket sort 
        var size = dictionary.Values.Max(); // LINQ 
        var sorted = new List<string[]>[size];   // 0 - max value, ..., size -1 - 1

        // added on August 9, 2017, 3 days after mocking practice
        for (int i = 0; i < size; i++)
        {
            sorted[i] = new List<string[]>();
        }

        var total = dictionary.Count; // 
        foreach (var pair in dictionary)
        {
            var key = pair.Key;
            var value = pair.Value;

            int index = size - value;

            sorted[index].Add(new string[] { key, value.ToString() });
        }

        // output to two dimension array 
        var result = new string[total, 2];
        var row = 0;  // added aftr the mocking - bug in writing 
        for (int i = 0; i < size; i++)
        {
            var visit = sorted[i]; // visit is List<string[]>
            foreach (var item in visit) // add the loop after the mocking ... bug in writing
            {
                result[row, 0] = item[0]; // visit[0] is the array, string new List<string[]>[size]
                result[row, 1] = item[1];
                row++;
            }
        }

        return result;
    }

    private static Dictionary<string, int> addToDictionary(string[] items)
    {
        var result = new Dictionary<string, int>();

        foreach (var item in items)
        {
            var key = filter(item).ToLower(); // you'll -> youll

            if (key.Length == 0)
            {
                continue;
            }

            if (result.ContainsKey(key))
            {
                result[key]++;
            }
            else
            {
                result.Add(key, 1);
            }
        }

        return result;
    }

    private static string filter(string s)
    {
        //var filterString = "abc'"; 
        var filtered = new StringBuilder();

        foreach (var item in s)
        {
            if (item != '\'')
            {
                filtered.Append(item);
            }
        }

        return filtered.ToString();
    }
}
