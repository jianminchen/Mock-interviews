using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
    {
        // your code goes here
        var flatten = new Dictionary<string, string>();

        FlattenDictionaryHelper(dict, "", flatten);
        return flatten;
    }    

    public static void FlattenDictionaryHelper(
      Dictionary<string, object> dict,
      string prefix,
      Dictionary<string, string> flatten)
    {
        if (dict == null || dict.Count == 0)
        {
            return;
        }

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var value = pair.Value;

            // https://stackoverflow.com/questions/16956903/determine-if-type-is-dictionary
            var t = value.GetType();
            bool isDict = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);

            if (isDict)
            {
                var newPrefix = key;
                newPrefix = (prefix.Length == 0) ? newPrefix : (prefix + "." + newPrefix);
                FlattenDictionaryHelper((Dictionary<string, object>)value, newPrefix, flatten);
            }
            else
            {
                string newKey = (prefix.Length == 0) ? key : ((key.Length == 0) ? prefix : (prefix + "." + key)); // i think you need to check either prefix is "" or key is "", if key is also "", then no ".key"
                // case 5 is last key ""

                flatten.Add(newKey, (string)value);
            }
        }
    }

    static void Main(string[] args)
    {

    }
}

// Key1 : 1 
// Key2:  value object is a dictionary 
// prefix of key Key2. = key + '.'
// prefix + key - handle key