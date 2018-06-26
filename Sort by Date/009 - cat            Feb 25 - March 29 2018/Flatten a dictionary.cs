using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
    {
        if (dict == null)
            return new Dictionary<string, string>();

        var flatten = new Dictionary<string, string>();

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var value = pair.Value;

            if (value.GetType() == typeof(Dictionary<string, object>))
            {
                var childDict = FlattenDictionary((Dictionary<string, object>)value);

                foreach (var item in childDict)
                {
                    var childKey = item.Key;
                    var childValue = item.Value;

                    var newKey = key + "." + childKey;
                    if (string.IsNullOrEmpty(key))
                        newKey = childKey;

                    if (string.IsNullOrEmpty(childKey))
                        newKey = key;

                    flatten.Add(newKey, childValue);
                }
            }
            else
            {
                flatten.Add(key, (string)value);
            }
        }

        return flatten;
    }

    static void Main(string[] args)
    {

    }
}

/*
value is not dictionary -> key, value to flatten dictionary
value is dictionary -> recursive, 
  value -> flattenDictChild(string, string)
    
key -> prefix 
go over each entry in flattenDictChild, 
  foreach pair in dict
  
    put key = prefix + "." + pair.key 
        value = pair.value
    
return flatten dictionary 

DFS/ recursive -> 
*/