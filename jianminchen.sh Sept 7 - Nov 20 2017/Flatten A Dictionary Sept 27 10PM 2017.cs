using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
    {
        if (dict == null || dict.Count == 0)
        {
            return new Dictionary<string, string>();
        }

        var flatten = new Dictionary<string, string>();

        FlattenDictionaryHelper(dict, "", flatten);

        return flatten;
    }

    /// recursive function
    private static void FlattenDictionaryHelper(Dictionary<string, object> dict, string prefix, Dictionary<string, string> flatten)
    {
        foreach (var pair in dict) // ("Key1", "1") "Key2", Dictionary
        {
            string key = pair.Key; // "Key1", "Key2"
            Object value = pair.Value; //"1" // dictionary

            // https://stackoverflow.com/questions/16956903/determine-if-type-is-dictionary
            string newPrefix = (prefix.Length == 0) ? key : ((key.Length == 0) ? prefix : (prefix + "." + key)); // "Key1"

            var isDictionary = value.GetType() == typeof(Dictionary<string, object>);

            if (!isDictionary)
            {

                flatten.Add(newPrefix, (string)value); // ("Key1", "1")
            }
            else
            {
                FlattenDictionaryHelper((Dictionary<string, object>)value, newPrefix, flatten); // 
            }
        }
    }

    static void Main(string[] args)
    {

    }
}

// "Key1" -> key, value type -> string 1, "1"
// "Kye2" , value type -> GetType -> Dictionary -> DFS-> recursive -> pass extra argument
// Key2 -> prefix 
// prefix is empty? key : (key is empty)? prefix : (prefix +"." + key) 
// 