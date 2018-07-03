using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
    {
        if (dict == null || dict.Count == 0)
            return new Dictionary<string, string>();

        var flatten = new Dictionary<string, string>();

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var valueObject = pair.Value;

            if (valueObject.GetType() == typeof(Dictionary<string, object>))
            {
                var subDict = FlattenDictionary((Dictionary<string, object>)valueObject);

                foreach (var childPair in subDict)
                {
                    var childKey = childPair.Key;
                    var childValue = childPair.Value;

                    var keyComposed = key;
                    var newKey = key.Length == 0 ? "" : keyComposed;
                    var newSubKey = childKey;
                    if (key.Length > 0)
                        newSubKey = keyComposed + "." + childKey; // bug
                    newKey = childKey.Length == 0 ? keyComposed : newSubKey;

                    flatten.Add(newKey, childValue);
                }
            }
            else
            {
                flatten.Add(key, (string)valueObject);
            }
        }

        return flatten;
    }

    static void Main(string[] args)
    {

    }
}
/*
keywords:
values - integer, string, another dictionary

ask: flatten a dctionary 
constraint: key is empty, exclude the key 

go over each entry of the dictionary, 
if the value is not dictionary, then put the entry
otherwise, recurisve call, go over sub dict flatten output, 
compose new key
*/