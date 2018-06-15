using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
    {
        if (dict == null)
            return new Dictionary<string, string>();

        return FlattenDictionaryHelper(dict, "");
    }

    private static Dictionary<string, string> FlattenDictionaryHelper(Dictionary<string, object> dict, string prefix)
    {
        var flatten = new Dictionary<string, string>();

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var valueStr = pair.Value;

            var newKey = key;
            if (prefix.Length > 0)
                newKey = prefix + "." + key;
            if (key.Length == 0)
                newKey = prefix;

            if (valueStr.GetType() == typeof(Dictionary<string, object>))
            {
                // solve subproblem 
                var newKeyObject = (Dictionary<string, object>)valueStr;

                var childFlatten = FlattenDictionaryHelper(newKeyObject, newKey);   // key ? 

                foreach (var childPair in childFlatten)
                {
                    flatten.Add(childPair.Key, childPair.Value);
                }
            }
            else
            {
                flatten.Add(newKey, valueStr.ToString());
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

dictionary
key
value - primitive type / dictionary
   primitive type: integer, boolean, double, string, excluding boolean, double
   
ask: flattenDictionary 
  concatenate by dot 
  Key2.a
  Key2.b
  
  parent dictionary key as prefix, then prefix + '.' + key
  
  recursive/ depth first search 
  
  iterate every key/value pair, if value is primtive type then put back to flatten as is; 
  otherwise it is dictioinary type, and then solve subproblem with string/ string flatten dict - sub dict
    add current key as prefix by going over subdict
   
 */