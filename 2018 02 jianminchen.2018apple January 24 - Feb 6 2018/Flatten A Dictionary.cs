using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict) // 
    {
        if (dict == null || dict.Count == 0)  // false
        {
            return new Dictionary<string, string>();
        }

        var flatten = new Dictionary<string, string>();

        foreach (var pair in dict)
        {
            var key = pair.Key; // Key1, Key2
            var value = pair.Value; // 1, dict

            if (value.GetType() == typeof(Dictionary<string, object>))
            {
                // recursive 
                var childFlattern = FlattenDictionary((Dictionary<string, object>)value);

                // go over each pair
                foreach (var childPair in childFlattern)
                {
                    var childKey = childPair.Key;
                    var childValue = childPair.Value;

                    var newKey = key + "." + childKey;

                    if (String.IsNullOrEmpty(key))
                    {
                        newKey = childKey;
                    }

                    if (String.IsNullOrEmpty(childKey))
                    {
                        newKey = key;
                    }

                    flatten.Add(newKey, childValue);
                }
            }
            else
            {
                flatten.Add(key, (string)value); // Key1: 1
            }
        }

        return flatten;
    }

    static void Main(string[] args)
    {
        var dict = new Dictionary<string, object>();

        dict.Add("Key1", 1);

        var childDict = new Dictionary<string, object>();
        childDict.Add("a", 2);
        childDict.Add("b", 3);

        dict.Add("Key2", childDict);

        var flatten = FlattenDictionary(dict);

        foreach (var pair in flatten)
        {
            Console.WriteLine(pair.Key + " - " + pair.Value);
        }
    }
}

/*
keywords

Dictionary 

value - integer, string, dictionary
Key2: 
  a : 2
  b : 3
    
flatten 
b, flatten <string, string> 

go over each pair in flatten, 

construct new key: b + "." +  key

Time complexity: 
size of all keys 
*/
