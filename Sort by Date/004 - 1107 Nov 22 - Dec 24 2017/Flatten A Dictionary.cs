using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict) // "Key1"
    {
        if (dict == null || dict.Count == 0) // false 
        {
            return new Dictionary<string, string>();
        }

        var flattenDictionary = new Dictionary<string, string>();

        FlattenDictionaryRecursive(dict, flattenDictionary, "");

        return flattenDictionary;
    }

    private static void FlattenDictionaryRecursive(Dictionary<string, object> original, Dictionary<string, string> flatten, string prefix)
    {
        foreach (var pair in original)  // two pairs, first pair, key = "Key1", key2
        {
            var key = pair.Key;  // "Key1", "Key2"
            var value = pair.Value; // object, "1"

            var valueIsDictionary = value.GetType() == typeof(Dictionary<string, object>); // false , true 

            var newKey = prefix == null || prefix.Length == 0 ? key : (key.Length == 0) ? prefix : (prefix + "." + key); // "Key1", "Key2"

            if (!valueIsDictionary)
            {
                var newValue = (string)value; // "1"

                flatten.Add(newKey, newValue); // ("Key1", "1")
            }
            else
            {
                var newPrefix = newKey;

                FlattenDictionaryRecursive((Dictionary<string, object>)value, flatten, newPrefix);
            }
        }
    }

    static void Main(string[] args)
    {

    }
}

// prefix -> build key-> prefix.isNullorEmpty -> 
// type not dictionary -> newPrefix = prefix + "." + key -> new entry 
// C# GetType -> stackoverflow 

// From StackOverflow:
// if (obj1.GetType() == typeof(Dictionary))
// Some code here

