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

        foreach (var pair in dict)
        {
            var key = pair.Key;
            var value = pair.Value;

            if (value.GetType() != typeof(Dictionary<string, object>))
            {
                // put the pair into flatten
                flatten.Add(key, (string)value);
            }
            else
            {
                var subtree = FlattenDictionary((Dictionary<string, object>)value);

                foreach (var subtreePair in subtree)
                {
                    var subKey = subtreePair.Key;
                    var subValue = subtreePair.Value;

                    var newKey = key + "." + subKey;
                    if (key == "")
                    {
                        newKey = subKey;
                    }

                    if (subKey == "")
                    {
                        newKey = key;
                    }

                    flatten.Add(newKey, subValue);
                }
            }
        }

        return flatten;
    }

    static void Main(string[] args)
    {

    }
}

/*
{"" => {"a": 1, "b": 2, "": {"d": 3}}, "c": 4, "e": {"f": 5}}

{
  "a": 1,
  "b": 2,
  "d": 3,
  "c": 4,
  "e.f": 5
}


Constraints:

given value: integer, string or another dictionary

a flatten dictionary - 

Solution: depth first search, using recursive to solve it 

   "Key1": "1"
   "key2": {
    
   }
   
   if value is not dictionary, integer, string
     put pair to flatten dictionary
     
   value of key2 as dictinary object <string, string> 
   go over each pair
      newKey = "key2" + "." + key
      newValue = value; 
      
      flatten.Add(newKey, newValue)
     
     Time complexity: visit key -> value -> value, all nodes in tree, time complexity sizeof all keys 
     height of tree - maximum level 
*/